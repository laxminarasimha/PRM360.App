using PRM360.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM360.Web.Services
{
    public interface ICustomerService
    {
        CustomerApiResponseMessage GetCustomers();
        Task<CustomerApiResponseMessage> GetCustomersAsync<CustomerApiResponseMessage>();

        CustomerApiResponseMessage GetCustomerById(int id);
        Task<CustomerApiResponseMessage> GetCustomerByIdAsync<CustomerApiResponseMessage>(int id);

        CustomerApiResponseMessage GetCustomerByLogin(string username, string passwor);
        Task<CustomerApiResponseMessage> GetCustomerByLoginAsync<CustomerApiResponseMessage>(string username, string password);

        CustomerApiResponseMessage CreateCustomer(Customer customer);
        Task<CustomerApiResponseMessage> CreateCustomerAsync<CustomerApiResponseMessage>(Customer customer);
    }
}
