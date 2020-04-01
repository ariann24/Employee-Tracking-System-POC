using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TimeTrackingBackEnd.Context;
using TimeTrackingFrontEnd.Models;

namespace TimeTrackingFrontEnd.Services
{
    public class LoginService
    {
        public LoginService()
        { }

        public HttpClient GetJWTAuthentication(string username, string password)
        {
            string baseUrl = "http://localhost:59323";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            User userModel = new User();
            userModel.UserName = username;
            userModel.Password = password;

            string stringData = JsonConvert.SerializeObject(userModel);
            var contentData = new StringContent(stringData,
            System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("/api/user", contentData).Result;
            string stringUserData = response.Content.ReadAsStringAsync().Result;

            User dataUser = JsonConvert.DeserializeObject<User>(stringUserData);

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + dataUser.Token);

            return client;
        }

        public string GetToken(string username, string password)
        {
            string baseUrl = "http://localhost:59323";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            User userModel = new User();
            userModel.UserName = username;
            userModel.Password = password;

            string stringData = JsonConvert.SerializeObject(userModel);
            var contentData = new StringContent(stringData,
            System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("/api/user", contentData).Result;
            string stringUserData = response.Content.ReadAsStringAsync().Result;

            User dataUser = JsonConvert.DeserializeObject<User>(stringUserData);

            return dataUser.Token;
        }
    }
}
