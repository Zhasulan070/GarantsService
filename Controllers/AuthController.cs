using System;
using System.Data;
using System.Threading.Tasks;
using GarantsService.Helpers;
using GarantsService.Interfaces;
using GarantsService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Logging;

namespace GarantsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _service;
        private readonly JwtService _jwtService;

        public AuthController(IAuthService service, ILogger<AuthController> logger, JwtService jwtService)
        {
            _service = service;
            _logger = logger;
            _jwtService = jwtService;
        }
        
        [HttpPost("loginByUserId")]
        public async Task<IActionResult> loginByUserId([FromQuery(Name = "username")] string username, [FromQuery(Name = "password")] string password)
        {
            var response = new Response<UserModel>();

            try
            {
                var user = await _service.GetUserByUsername(username);
                if (user == null) throw new DataException();
                if (!user.Password.Equals(password)) throw new DataException();
                
                response.Result = user;
                response.StatusCode = 0;
            }
            catch (Exception e)
            {
                response.StatusCode = -1;
                response.ErrorMessage = e is DataException ? "Еmail или пароль не верный"
                    : "Some problem in GetUserByUsername service";
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromQuery(Name = "username")] string username, [FromQuery(Name = "password")] string password)
        {
            var response = new Response<string>();

            try
            {
                var user = await _service.GetUserByUsername(username);
                if (user == null) throw new DataException();
                if (!user.Password.Equals(password)) throw new DataException();

                response.Result = _jwtService.Generate(user.Id);
                response.StatusCode = 0;
            }
            catch (Exception e)
            {
                response.StatusCode = -1;
                response.ErrorMessage = e is DataException ? "Еmail или пароль не верный"
                    : "Some problem in GetUserByUsername service";
            }

            return Ok(response);
        }

        [HttpGet("user")]
        public async Task<IActionResult> User([FromQuery(Name = "jwt")] string jwt)
        {
            var response = new Response<UserModel>();

            try
            {
                // var token = _jwtService.Verify(jwt);
                var userId = int.Parse(jwt);

                response.Result = await _service.GetUserById(userId);
                response.StatusCode = 0;
            }
            catch (Exception e)
            {
                response.StatusCode = -1;
                response.ErrorMessage = "Some error in GetUserById service";
                _logger.LogError(e, response.ErrorMessage);
            }

            return Ok(response);
        }

    }
}