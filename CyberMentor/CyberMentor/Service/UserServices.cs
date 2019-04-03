using CyberMentor.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CyberMentor.Service
{
    public class UserServices
    {
        public async Task<User> UserLogin(string email, string password)
        {
            using (var client = new HttpClient())
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("email", email);
                values.Add("password", password);
                try
                {
                    string content = JsonConvert.SerializeObject(values);
                    var response = await client.PostAsync("https://cyber.alsalil.net/api/login", new StringContent(content, Encoding.UTF8, "text/json"));
                    var serverResponse = response.Content.ReadAsStringAsync().Result.ToString();
                    var json = JsonConvert.DeserializeObject<Response<string, User>>(serverResponse);
                    return json.message;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
        public async Task<User> Register(string email, string password,string name)
        {
            using (var client = new HttpClient())
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("name", name);
                values.Add("email", email);
                values.Add("password", password);
                values.Add("confirmpass", password);
                try
                {
                    string content = JsonConvert.SerializeObject(values);
                    var response = await client.PostAsync("http://cyber.alsalil.net/api/register", new StringContent(content, Encoding.UTF8, "text/json"));
                    var serverResponse = response.Content.ReadAsStringAsync().Result.ToString();
                    var json = JsonConvert.DeserializeObject<Response<string, User>>(serverResponse);
                    return json.message;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
