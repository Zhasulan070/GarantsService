using System;
using System.Threading.Tasks;
using GarantsService.Interfaces;
using GarantsService.Models;
using GarantsService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GarantsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestDeniedController : ControllerBase
    {
        private readonly IRequestDeniedService _service;
        private readonly ILogger<RequestDeniedController> _logger;

        public RequestDeniedController(IRequestDeniedService service, ILogger<RequestDeniedController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> RequestD()
        {
            var response = new Response<string>();
            try
            {
                response.Result = await _service.RequestDenied();
                response.StatusCode = 0;
            }
            catch (Exception e)
            {
                response.StatusCode = -1;
                response.ErrorMessage = "Some error in GetCompanyName service";
                _logger.LogError(e, response.ErrorMessage);
            }

            return Ok(response);
        }
    }
}