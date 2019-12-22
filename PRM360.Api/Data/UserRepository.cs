using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRM360.Api.Models;

namespace PRM360.Api.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public User CreateUser(User user)
        {
            if(_context.Users == null)
            {
                return null;
            }
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User GetUser(int id)
        {
            if (_context.Users == null)
            {
                return null;
            }
            return _context.Users.FirstOrDefault(o => o.Id == id);
        }

        public User GetUserByLogin(string userName, string password)
        {
            if (_context.Users == null)
            {
                return null;
            }
            return _context.Users.FirstOrDefault(o => o.Email.Equals(userName) && o.Password.Equals(password));
        }

        public List<User> GetUsers()
        {
            if (_context.Users == null)
            {
                return null;
            }
            return _context.Users.ToList();
        }
    }
}
