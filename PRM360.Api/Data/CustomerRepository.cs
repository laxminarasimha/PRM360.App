using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRM360.Api.Models;

namespace PRM360.Api.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateCustomer(Customer customer)
        {
            if(_context.Customers == null)
            {
                return;
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public Customer GetCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return null;
            }
            return _context.Customers.FirstOrDefault(o => o.Id == id);
        }

        public Customer GetCustomerByLogin(string userName, string password)
        {
            if (_context.Customers == null)
            {
                return null;
            }
            return _context.Customers.FirstOrDefault(o => o.Email.Equals(userName) && o.Password.Equals(password));
        }

        public List<Customer> GetCustomers()
        {
            if (_context.Customers == null)
            {
                return null;
            }
            return _context.Customers.ToList();
        }
    }
}
