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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IUserRepository userRepository, ILogger<UsersController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
       
        [HttpGet]
        public UserApiResponseMessage GetUsers()
        {            
            var response = new UserApiResponseMessage();
            try
            {
                var userModel = _userRepository.GetUsers();
                var userJson = JsonConvert.SerializeObject(userModel);
                response.Result = userJson;
                response.Status = HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Retrieved all users";
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
        public UserApiResponseMessage GetUser(int id)
        {
            var response = new UserApiResponseMessage();
            try
            {
                var userModel = _userRepository.GetUser(id);
                var userJson = JsonConvert.SerializeObject(userModel);
                response.Result = userJson;
                response.Status = HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Retrieved user";
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

        [HttpPost("/api/user/login")]
        public UserApiResponseMessage GetUserByLogin([FromBody]LoginModel request)
        {
            _logger.LogInformation($"UserName:{request.UserName}, Password:{request.Password}");
            var response = new UserApiResponseMessage();
            try
            {
                var userModel = _userRepository.GetUserByLogin(request.UserName, request.Password);
                if(userModel == null)
                {
                    response.Result = null;
                    response.Status = HttpStatusCode.NotFound;
                    response.Success = false;
                    response.Message = "User not available";

                    return response;
                }                
                var userJson = JsonConvert.SerializeObject(userModel);
                response.Result = userJson;
                response.Status = HttpStatusCode.OK;
                response.Success = true;
                response.Message = "Retrieved user by login";
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

        [HttpPost("/api/user/create")]
        public UserApiResponseMessage PostUser([FromBody]User request)
        {
            var response = new UserApiResponseMessage();
            try
            {
                _userRepository.CreateUser(request);
                response.Status = HttpStatusCode.OK;
                response.Success = true;
                response.Message = "User created successfully";
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