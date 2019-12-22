using PRM360.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM360.Api.Data
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();

        Customer GetCustomer(int id);

        Customer GetCustomerByLogin(string userName, string password);

        void CreateCustomer(Customer customer);
    }
}
