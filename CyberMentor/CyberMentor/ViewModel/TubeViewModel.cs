using CyberMentor.Helper;
using CyberMentor.Model;
using CyberMentor.Service;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
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
            IsRunning = true;
            MainVisable = true;
            VisableError = false;
            PageDirection = (AppSettings.LastUserGravity == "Arabic") ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            IsRunning = false;
            InitDataAsync();
        }

        private string _ErrorValue;
        public string ErrorValue
        {
            get { return _ErrorValue; }
            set { _ErrorValue = value; OnPropertyChanged(); }
        }

        public bool VisableError { get; set; }
        public bool MainVisable { get; set; }

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
            if (CrossConnectivity.Current.IsConnected)
            {
                TubeServices ser = new TubeServices();
                var data = await ser.GetAllTubes();
                AllTubes = data;
                if (AllTubes.Count == 0)
                {
                    MainVisable = false;
                    VisableError = true;
                    ErrorValue = Resource.NoBuildings;
                }
                else
                {
                    foreach (var item in data)
                    {
                        var x = await GetVideosDetailsAsync(item.key);
                        item.Youtube = x;
                    }
                    AllTubes = data;
                }
            }
            else
            {
                MainVisable = false;
                VisableError = true;
                ErrorValue = Resource.ErrorMessage;
            }
            IsRunning = false;
            //var videoIds = await GetVideoIdsFromChannelAsync();

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
