using PRM360.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRM360.Web.Services
{
    public interface IUserService
    {
        UserApiResponseMessage GetUsers();
        Task<UserApiResponseMessage> GetUsersAsync<UserApiResponseMessage>();

        UserApiResponseMessage GetUserById(int id);
        Task<UserApiResponseMessage> GetUserByIdAsync<UserApiResponseMessage>(int id);

        UserApiResponseMessage GetUserByLogin(string username, string passwor);
        Task<UserApiResponseMessage> GetUserByLoginAsync<UserApiResponseMessage>(string username, string password);

        UserApiResponseMessage CreateUser(User user);
        Task<UserApiResponseMessage> CreateUserAsync<UserApiResponseMessage>(User user);
    }
}
