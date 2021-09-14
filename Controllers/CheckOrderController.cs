using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GarantsService.Interfaces;
using GarantsService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GarantsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckOrderController : ControllerBase
    {
        private readonly ILogger<CheckOrderController> _logger;
        private readonly ICheckOrderService _service;
        public CheckOrderController(ILogger<CheckOrderController> logger, ICheckOrderService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> GetOrder([FromQuery(Name = "bin")] string bin, [FromQuery(Name = "kl")]string kl)
        {
            var response = new Response<List<OrderModel>>();
            try
            {
                response.Result = await _service.CheckOrder(long.Parse(bin), kl);
                response.StatusCode = 0;
            }
            catch (Exception e)
            {
                response.StatusCode = -1;
                response.ErrorMessage = "Some error in CheckOrder service";
                _logger.LogError(e, response.ErrorMessage);
            }

            return Ok(response);
        }
    }
}