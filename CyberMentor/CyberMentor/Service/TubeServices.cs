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
        public async Task<ObservableCollection<CyberNews>> GetAllNews()
        {
            var httpClient = new HttpClient();
            ObservableCollection<CyberNews> news = new ObservableCollection<CyberNews>();
            var json = await httpClient.GetStringAsync("https://cyber.alsalil.net/api/getcyber_news");
            try
            {
                var response = JsonConvert.DeserializeObject<Response<string, ResponseData<ObservableCollection<CyberNews>>>>(json);
                news = new ObservableCollection<CyberNews>(response.message.data);
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

        public async Task<ObservableCollection<CyberNews>> GetAllEvents()
        {
            var httpClient = new HttpClient();
            var Events = new ObservableCollection<CyberNews>();
            var json = await httpClient.GetStringAsync("https://cyber.alsalil.net/api/getcyber_event");
            try
            {
                var response = JsonConvert.DeserializeObject<Response<string, ResponseData<ObservableCollection<CyberNews>>>>(json);
                Events = new ObservableCollection<CyberNews>(response.message.data);
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

        public async Task<ObservableCollection<ProtectMeModel>> AllSubItemsPage()
        {
            var httpClient = new HttpClient();
            var Cats = new ObservableCollection<ProtectMeModel>();
            var json = await httpClient.GetStringAsync("https://cyber.alsalil.net/api/postprotectme");
            try
            {
                var response = JsonConvert.DeserializeObject<Response<string, ObservableCollection<ProtectMeModel>>>(json);
                Cats = new ObservableCollection<ProtectMeModel>(response.message);
            }
            catch (Exception exception)
            {

            }

            return Cats;
        }

    }
}
