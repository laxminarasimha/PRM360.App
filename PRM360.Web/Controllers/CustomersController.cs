using Microsoft.AspNetCore.Mvc;
using PRM360.Web.Models;
using PRM360.Web.Services;

namespace PRM360.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
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
            CustomerApiResponseMessage response = _customerService.GetCustomerByLogin(model.UserName, model.Password);
            if (response == null || !response.Success)
            {
                ModelState.AddModelError("LoginError", "Invalid user name or password");
                return View(model);
            }
            return View("Admin");
        }

        public IActionResult GetCustomers()
        {
            CustomerApiResponseMessage response = _customerService.GetCustomers();
            return null;
        }
    }
}