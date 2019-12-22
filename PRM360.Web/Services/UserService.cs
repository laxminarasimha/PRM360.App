using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PRM360.Web.Models;

namespace PRM360.Web.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseEndPoint;

        public UserService()
        {
            _httpClient = new HttpClient();
            _baseEndPoint = @"https://localhost:5001/api";
        }

        public UserApiResponseMessage CreateUser(User user)
        {
            var apiUrl = string.Format("{0}/user/create", _baseEndPoint);
            var response = _httpClient.PostAsync(apiUrl, CreateHttpContent(user));
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                return JsonConvert.DeserializeObject<UserApiResponseMessage>(readTask.Result);
            }

            return null;
        }

        public async Task<UserApiResponseMessage> CreateUserAsync<UserApiResponseMessage>(User user)
        {
            var apiUrl = string.Format("{0}/user/create",_baseEndPoint);
            var response = await _httpClient.PostAsync(apiUrl, CreateHttpContent(user));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserApiResponseMessage>(data);
        }

        public UserApiResponseMessage GetUserById(int id)
        {
            var apiUrl = string.Format("{0}/users/{1}", _baseEndPoint, id);
            var response = _httpClient.GetAsync(apiUrl);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                return JsonConvert.DeserializeObject<UserApiResponseMessage>(readTask.Result);
            }

            return null;
        }

        public async Task<UserApiResponseMessage> GetUserByIdAsync<UserApiResponseMessage>(int id)
        {
            var apiUrl = string.Format("{0}/users/{1}", _baseEndPoint, id);
            var response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserApiResponseMessage>(data);
        }

        public UserApiResponseMessage GetUserByLogin(string username, string password)
        {
            var apiUrl = string.Format("{0}/user/login", _baseEndPoint);
            var request = new LoginModel { UserName = username, Password = password };
            var response = _httpClient.PostAsync(apiUrl, CreateHttpContent(request));
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                return JsonConvert.DeserializeObject<UserApiResponseMessage>(readTask.Result);
            }

            return null;
        }

        public async Task<UserApiResponseMessage> GetUserByLoginAsync<UserApiResponseMessage>(string username, string password)
        {
            var apiUrl = string.Format("{0}/user/login", _baseEndPoint);
            var request = new LoginModel { UserName = username, Password = password };
            var response = await _httpClient.PostAsync(apiUrl, CreateHttpContent(request));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserApiResponseMessage>(data);
        }

        public UserApiResponseMessage GetUsers()
        {
            var apiUrl = string.Format("{0}/users",_baseEndPoint);
            var response = _httpClient.GetAsync(apiUrl);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                return JsonConvert.DeserializeObject<UserApiResponseMessage>(readTask.Result);
            }

            return null;
        }

        public async Task<UserApiResponseMessage> GetUsersAsync<UserApiResponseMessage>()
        {
            var apiUrl = string.Format("{0}/users", _baseEndPoint);
            var response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserApiResponseMessage>(data);
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
