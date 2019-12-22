using PRM360.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM360.Api.Data
{
    public interface IUserRepository
    {
        List<User> GetUsers();

        User GetUser(int id);

        User GetUserByLogin(string userName, string password);

        User CreateUser(User user);
    }
}
