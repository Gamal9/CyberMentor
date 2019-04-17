using CyberMentor.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CyberMentor.Service
{
    public class TubeServices
    {
        public async Task<ObservableCollection<CyberNewsModel>> GetAllNews()
        {
            var httpClient = new HttpClient();
            ObservableCollection<CyberNewsModel> news = new ObservableCollection<CyberNewsModel>();
            var json = await httpClient.GetStringAsync("https://cyber.alsalil.net/api/getcyber_news");
            try
            {
                var response = JsonConvert.DeserializeObject<Response<string, ResponseData<ObservableCollection<CyberNewsModel>>>>(json);
                news = new ObservableCollection<CyberNewsModel>(response.message.data);
            }
            catch (Exception exception)
            {
            }

            return news;
        }

        public async Task<ObservableCollection<CyberModel>> GetAllTubes()
        {
            var httpClient = new HttpClient();
            ObservableCollection<CyberModel> news = new ObservableCollection<CyberModel>();
            var json = await httpClient.GetStringAsync("https://cyber.alsalil.net/api/getcyber_tubes");
            try
            {
                var response = JsonConvert.DeserializeObject<Response<string, ResponseData<ObservableCollection<CyberModel>>>>(json);
                news = new ObservableCollection<CyberModel>(response.message.data);
            }
            catch (Exception exception)
            {
            }

            return news;
        }

        public async Task<ObservableCollection<CyberNewsModel>> GetAllEvents()
        {
            var httpClient = new HttpClient();
            var Events = new ObservableCollection<CyberNewsModel>();
            var json = await httpClient.GetStringAsync("https://cyber.alsalil.net/api/getcyber_event");
            try
            {
                var response = JsonConvert.DeserializeObject<Response<string, ResponseData<ObservableCollection<CyberNewsModel>>>>(json);
                Events = new ObservableCollection<CyberNewsModel>(response.message.data);
            }
            catch (Exception exception)
            {

            }

            return Events;
        }

        public async Task<ObservableCollection<CatModel>> AllCategories()
        {
            var httpClient = new HttpClient();
            var Cats = new ObservableCollection<CatModel>();
            var json = await httpClient.GetStringAsync("https://cyber.alsalil.net/api/allCat");
            try
            {
                var response = JsonConvert.DeserializeObject<Response<string, ObservableCollection<CatModel>>>(json);
                Cats = new ObservableCollection<CatModel>(response.message);
            }
            catch (Exception exception)
            {

            }

            return Cats;
        }

        public async Task<ObservableCollection<CyberNewsModel>> AllSubItemsPage(int id)
        {
            var httpClient = new HttpClient();
            Dictionary<string, int> values = new Dictionary<string, int>();
            values.Add("subcat_id", id);
            string content = JsonConvert.SerializeObject(values);
            var Cats = new ObservableCollection<CyberNewsModel>();
            var json = await httpClient.PostAsync("https://cyber.alsalil.net/api/postprotectme",new StringContent(content, Encoding.UTF8, "text/json"));
            try
            {
                var response = JsonConvert.DeserializeObject<Response<string,ResponseData<ObservableCollection<CyberNewsModel>>>>(json.Content.ReadAsStringAsync().Result.ToString());
                Cats = new ObservableCollection<CyberNewsModel>(response.message.data);
            }
            catch (Exception exception)
            {

            }

            return Cats;
        }

        public async Task<ObservableCollection<CyberReview>> NewsReview(int id)
        {
            var httpClient = new HttpClient();
            //Dictionary<string, int> values = new Dictionary<string, int>();
            //values.Add("post_id", id);
            //string content = JsonConvert.SerializeObject(values);
            var Reviews = new ObservableCollection<CyberReview>();
            var json = await httpClient.GetStringAsync("https://cyber.alsalil.net/api/getreview");
            try
            {
                var response = JsonConvert.DeserializeObject<Response<string, ResponseData<ObservableCollection<CyberReview>>>>(json.ToString());
                Reviews = new ObservableCollection<CyberReview>(response.message.data);
            }
            catch (Exception exception)
            {

            }

            return Reviews;
        }

        public async Task<string> PostReview(CyberReview review)
        {
            var httpClient = new HttpClient();
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("title", review.title);
            values.Add("desc", review.desc);
            values.Add("user_id", review.user_id.ToString());
            values.Add("post_id", review.post_id.ToString());
            string content = JsonConvert.SerializeObject(values);
            string message="";
            var json = await httpClient.PostAsync("https://cyber.alsalil.net/api/postreview", new StringContent(content, Encoding.UTF8, "text/json"));
            try
            {
                var response = JsonConvert.DeserializeObject<Response<string, string>>(json.Content.ReadAsStringAsync().Result.ToString());
                message= response.message;
            }
            catch (Exception exception)
            {

            }

            return message;
        }

        public async Task<SettingsModel> GetSettings()
        {
            var httpClient = new HttpClient();
            
            var Reviews = new SettingsModel();
            var json = await httpClient.GetStringAsync("https://cyber.alsalil.net/api/getSetting");
            try
            {
                var response = JsonConvert.DeserializeObject<Response<string, SettingsModel>>(json.ToString());
                Reviews = response.message;
            }
            catch (Exception exception)
            {

            }
            return Reviews;
        }



    }
}
