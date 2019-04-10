using CyberMentor.Model;
using CyberMentor.Service;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CyberMentor.ViewModel
{
    public class TubeViewModel : INotifyPropertyChanged
    {

        const string DataServ = "https://www.youtube.com/oembed?url=https://www.youtube.com/watch?v=";

        const string ApiKey = "AIzaSyC3HhPjcrVfeJXWnpp0uEl-rKP59C4Lit8";

        // doc : https://developers.google.com/apis-explorer/#p/youtube/v3/youtube.videos.list 
        private string apiUrlForChannel = "https://www.googleapis.com/youtube/v3/search?part=id&maxResults=20&channelId="
            + "UCCYR9GpcE3skVnyMU8Wx1kQ"
            //+ "Your_ChannelId"
            + "&key="
            + ApiKey;

        // doc : https://developers.google.com/apis-explorer/#p/youtube/v3/youtube.playlistItems.list
        private string apiUrlForPlaylist = "https://www.googleapis.com/youtube/v3/playlistItems?part=contentDetails&maxResults=20&playlistId="
            + "PLuEZQoW9bRnRnzwx4z1kzoY2Pt2nve6L_"
            //+ "Your_PlaylistId"
            + "&key="
            + ApiKey;

        // doc : https://developers.google.com/apis-explorer/#p/youtube/v3/youtube.search.list
        private string apiUrlForVideosDetails = "https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id="
            + "{0}"
            //+ "Your_Videos_Id"
            + "&key="
            + ApiKey;

        private List<YoutubeItem> _youtubeItems;

        public List<YoutubeItem> YoutubeItems
        {
            get { return _youtubeItems; }
            set
            {
                _youtubeItems = value;
                OnPropertyChanged();
            }
        }

        public TubeViewModel()
        {
            InitDataAsync();
        }

        public bool isRunning { get; set; }

        private ObservableCollection<CyberModel> _allTubes;
        public ObservableCollection<CyberModel> AllTubes
        {
            get { return _allTubes; }
            set { _allTubes = value; OnPropertyChanged(); }
        }


        public async void InitDataAsync()
        {
            IsRunning = true;
            TubeServices ser = new TubeServices();
            //var videoIds = await GetVideoIdsFromChannelAsync();
            var data = await ser.GetAllTubes();
            foreach (var item in data)
            {
                var x = await GetVideosDetailsAsync(item.key);
                item.Youtube = x;
            }
            AllTubes = data;
            IsRunning = false;
        }

        private async Task<List<string>> GetVideoIdsFromChannelAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(apiUrlForChannel);

            var videoIds = new List<string>();

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var items = response.Value<JArray>("items");

                foreach (var item in items)
                {
                    videoIds.Add(item.Value<JObject>("id")?.Value<string>("videoId"));
                }

                YoutubeItems = await GetVideosDetailsAsync(videoIds);
            }
            catch (Exception exception)
            {
            }

            return videoIds;
        }

        private async Task<List<string>> GetVideoIdsFromPlaylistAsync()
        {

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(apiUrlForPlaylist);

            var videoIds = new List<string>();

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var items = response.Value<JArray>("items");

                foreach (var item in items)
                {
                    videoIds.Add(item.Value<JObject>("contentDetails")?.Value<string>("videoId"));
                };

                YoutubeItems = await GetVideosDetailsAsync(videoIds);
            }
            catch (Exception exception)
            {
            }

            return videoIds;
        }

        private async Task<List<YoutubeItem>> GetVideosDetailsAsync(List<string> videoIds)
        {

            var videoIdsString = "";
            foreach (var s in videoIds)
            {
                videoIdsString += s + ",";
            }

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(string.Format(apiUrlForVideosDetails, videoIdsString));

            var youtubeItems = new List<YoutubeItem>();

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var items = response.Value<JArray>("items");

                foreach (var item in items)
                {
                    var snippet = item.Value<JObject>("snippet");
                    var statistics = item.Value<JObject>("statistics");

                    var youtubeItem = new YoutubeItem
                    {
                        Title = snippet.Value<string>("title"),
                        Description = snippet.Value<string>("description"),
                        ChannelTitle = snippet.Value<string>("channelTitle"),
                        PublishedAt = snippet.Value<DateTime>("publishedAt"),
                        VideoId = item?.Value<string>("id"),
                        DefaultThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("default")?.Value<string>("url"),
                        MediumThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("medium")?.Value<string>("url"),
                        HighThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("high")?.Value<string>("url"),
                        StandardThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("standard")?.Value<string>("url"),
                        MaxResThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("maxres")?.Value<string>("url"),

                        ViewCount = statistics?.Value<int>("viewCount"),
                        LikeCount = statistics?.Value<int>("likeCount"),
                        DislikeCount = statistics?.Value<int>("dislikeCount"),
                        FavoriteCount = statistics?.Value<int>("favoriteCount"),
                        CommentCount = statistics?.Value<int>("commentCount"),

                        Tags = (from tag in snippet?.Value<JArray>("tags") select tag.ToString())?.ToList(),
                    };

                    youtubeItems.Add(youtubeItem);
                }

                return youtubeItems;
            }
            catch (Exception exception)
            {
                return youtubeItems;
            }
        }

        private async Task<YoutubeItem> GetVideosDetailsAsync(string videoIds)
        {

            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(string.Format(apiUrlForVideosDetails, videoIds));

            var youtubeItems = new List<YoutubeItem>();

            try
            {
                JObject response = JsonConvert.DeserializeObject<dynamic>(json);

                var items = response.Value<JArray>("items");
                var snippet = items[0].Value<JObject>("snippet");
                var statistics = items[0].Value<JObject>("statistics");

                var youtubeItem = new YoutubeItem();

                youtubeItem.Title = snippet.Value<string>("title");
                youtubeItem.Description = snippet.Value<string>("description");
                youtubeItem.ChannelTitle = snippet.Value<string>("channelTitle");
                youtubeItem.PublishedAt = snippet.Value<DateTime>("publishedAt");
                youtubeItem.VideoId = items[0]?.Value<string>("id");
                youtubeItem.DefaultThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("default")?.Value<string>("url");
                youtubeItem.MediumThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("medium")?.Value<string>("url");
                youtubeItem.HighThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("high")?.Value<string>("url");
                youtubeItem.StandardThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("standard")?.Value<string>("url");
                youtubeItem.MaxResThumbnailUrl = snippet?.Value<JObject>("thumbnails")?.Value<JObject>("maxres")?.Value<string>("url");
                youtubeItem.ViewCount = statistics?.Value<int>("viewCount");
                youtubeItem.LikeCount = statistics?.Value<int>("likeCount");
                youtubeItem.DislikeCount = statistics?.Value<int>("dislikeCount");
                youtubeItem.FavoriteCount = statistics?.Value<int>("favoriteCount");
                youtubeItem.CommentCount = statistics?.Value<int>("commentCount");
                
                youtubeItem.Title = snippet.Value<string>("title");

                return youtubeItem;
            }
            catch (Exception exception)
            {
                return null;
            }
        }


        public FlowDirection PageDirection { get; set; }

        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
            set { _isRunning = value; OnPropertyChanged(); }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(InitDataAsync);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
