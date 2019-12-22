using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PRM360.Api.Data;
using PRM360.Api.Models;

namespace PRM360.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomersController> _logger;
        public CustomersController(ICustomerRepository customerRepository, ILogger<CustomersController> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }
       
        [HttpGet]
        public CustomerApiResponseMessage GetCustomers()
        {            
            var response = new CustomerApiResponseMessage();
            try
            {
                var customerModel = _customerRepository.GetCustomers();
                var customerJson = JsonConvert.SerializeObject(customerModel);
                response.Result = customerJson;
                response.Status = HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Retrieved all customers";
            }
            catch(Exception ex)
            {
                response.Result = null;
                response.Status = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpGet("{id}")]
        public CustomerApiResponseMessage GetCustomer(int id)
        {
            var response = new CustomerApiResponseMessage();
            try
            {
                var customerModel = _customerRepository.GetCustomer(id);
                var customerJson = JsonConvert.SerializeObject(customerModel);
                response.Result = customerJson;
                response.Status = HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Retrieved customer";
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Status = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPost("/api/customer/login")]
        public CustomerApiResponseMessage GetCustomerByUserName([FromBody]LoginModel request)
        {
            _logger.LogInformation($"UserName:{request.UserName}, Password:{request.Password}");
            var response = new CustomerApiResponseMessage();
            try
            {
                var customerModel = _customerRepository.GetCustomerByLogin(request.UserName, request.Password);
                var customerJson = JsonConvert.SerializeObject(customerModel);
                response.Result = customerJson;
                response.Status = HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Retrieved customer by user name";
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Status = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpPost("/api/customer/create")]
        public CustomerApiResponseMessage PostCustomer([FromBody]Customer request)
        {
            var response = new CustomerApiResponseMessage();
            try
            {
                _customerRepository.CreateCustomer(request);
                response.Status = HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Customer created successfully";
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Status = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}