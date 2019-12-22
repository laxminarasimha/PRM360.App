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
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseEndPoint;

        public CustomerService()
        {
            _httpClient = new HttpClient();
            _baseEndPoint = @"http://localhost:5001/api";
        }

        public CustomerApiResponseMessage CreateCustomer(Customer customer)
        {
            var apiUrl = string.Format("{0}/customer/create", _baseEndPoint);
            var response = _httpClient.PostAsync(apiUrl, CreateHttpContent(customer));
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                return JsonConvert.DeserializeObject<CustomerApiResponseMessage>(readTask.Result);
            }

            return null;
        }

        public async Task<CustomerApiResponseMessage> CreateCustomerAsync<CustomerApiResponseMessage>(Customer customer)
        {
            var apiUrl = string.Format("{0}/customer/create",_baseEndPoint);
            var response = await _httpClient.PostAsync(apiUrl, CreateHttpContent(customer));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CustomerApiResponseMessage>(data);
        }

        public CustomerApiResponseMessage GetCustomerById(int id)
        {
            var apiUrl = string.Format("{0}/customers/{1}", _baseEndPoint, id);
            var response = _httpClient.GetAsync(apiUrl);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                return JsonConvert.DeserializeObject<CustomerApiResponseMessage>(readTask.Result);
            }

            return null;
        }

        public async Task<CustomerApiResponseMessage> GetCustomerByIdAsync<CustomerApiResponseMessage>(int id)
        {
            var apiUrl = string.Format("{0}/customers/{1}", _baseEndPoint, id);
            var response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CustomerApiResponseMessage>(data);
        }

        public CustomerApiResponseMessage GetCustomerByLogin(string username, string password)
        {
            var apiUrl = string.Format("{0}/customer/login", _baseEndPoint);
            var request = new LoginModel { UserName = username, Password = password };
            var response = _httpClient.PostAsync(apiUrl, CreateHttpContent(request));
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                return JsonConvert.DeserializeObject<CustomerApiResponseMessage>(readTask.Result);
            }

            return null;
        }

        public async Task<CustomerApiResponseMessage> GetCustomerByLoginAsync<CustomerApiResponseMessage>(string username, string password)
        {
            var apiUrl = string.Format("{0}/customer/login", _baseEndPoint);
            var request = new LoginModel { UserName = username, Password = password };
            var response = await _httpClient.PostAsync(apiUrl, CreateHttpContent(request));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CustomerApiResponseMessage>(data);
        }

        public CustomerApiResponseMessage GetCustomers()
        {
            var apiUrl = string.Format("{0}/customers",_baseEndPoint);
            var response = _httpClient.GetAsync(apiUrl);
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                return JsonConvert.DeserializeObject<CustomerApiResponseMessage>(readTask.Result);
            }

            return null;
        }

        public async Task<CustomerApiResponseMessage> GetCustomersAsync<CustomerApiResponseMessage>()
        {
            var apiUrl = string.Format("{0}/customers", _baseEndPoint);
            var response = await _httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CustomerApiResponseMessage>(data);
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
