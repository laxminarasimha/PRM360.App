using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRM360.Api.Models;

namespace PRM360.Api.Data
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> UserList { get; set; }
        public MockUserRepository()
        {
            UserList = new List<User>();
            UserList.Add(new User
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
            UserList.Add(new User
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
        public List<User> GetUsers()
        {
            return UserList;
        }

        public User GetUser(int Id)
        {
            return UserList.FirstOrDefault(o => o.Id == Id);
        }

        public User GetUserByLogin(string userName, string password)
        {
            return UserList.FirstOrDefault(o => o.Email == userName && o.Password == password);
        }

        public User CreateUser(User user)
        {
            UserList.Add(user);
            return user;
        }
    }
}
