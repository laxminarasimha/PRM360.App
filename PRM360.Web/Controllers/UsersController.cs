using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PRM360.Web.Models;
using PRM360.Web.Services;

namespace PRM360.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            UserApiResponseMessage response = _userService.GetUserByLogin(model.UserName, model.Password);
            if (response == null || !response.Success || string.IsNullOrEmpty(response.Result))
            {
                ModelState.AddModelError("LoginError", "Invalid user name or password");
                return View(model);
            }

            var userMoodel = JsonConvert.DeserializeObject<User>(response.Result);
            return View("Dashboard", userMoodel);
        }

        public IActionResult GetUsers()
        {
            UserApiResponseMessage response = _userService.GetUsers();
            return null;
        }
    }
}