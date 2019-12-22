using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRM360.Api.Models;

namespace PRM360.Api.Data
{
    public class MockCustomerRepository : ICustomerRepository
    {
        private List<Customer> CustomerList { get; set; }
        public MockCustomerRepository()
        {
            CustomerList = new List<Customer>();
            CustomerList.Add(new Customer
            {
                Id = 1,
                FirstName = "Chaithaya",
                LastName = "Mylavarapu",
                Password = "abc",
                Role = "Admin",
                CompanyName = "Saga",
                Currency = "GBP",
                TimeZone = "GMT",
                Email = "chaitu@abc.com",
                Phone = 123456789,
                GST = "18%"
            });
            CustomerList.Add(new Customer
            {
                Id = 2,
                FirstName = "Murthy",
                LastName = "Mylavarapu",
                Password = "xyz",
                Role = "Vendor",
                CompanyName = "TerminusItSolutions",
                Currency = "INR",
                TimeZone = "BST",
                Email = "murthy@abc.com",
                Phone = 9999999999,
                GST = "20%"
            });
        }
        public List<Customer> GetCustomers()
        {
            return CustomerList;
        }

        public Customer GetCustomer(int Id)
        {
            return CustomerList.FirstOrDefault(o => o.Id == Id);
        }

        public Customer GetCustomerByLogin(string userName, string password)
        {
            return CustomerList.FirstOrDefault(o => o.Email == userName && o.Password == password);
        }

        public void CreateCustomer(Customer customer)
        {
            CustomerList.Add(customer);
        }
    }
}
