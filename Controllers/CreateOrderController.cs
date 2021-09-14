using System;
using System.Threading.Tasks;
using GarantsService.Interfaces;
using GarantsService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GarantsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CreateOrderController : ControllerBase
    {
        private readonly ICreateOrderService _service;
        private readonly ILogger<CreateOrderController> _logger;

        public CreateOrderController(ICreateOrderService service, ILogger<CreateOrderController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderModel order)
        {
            var response = new Response<string>();
            try
            {
                response.Result = await _service.CreateApp(order);
                response.StatusCode = 0;
            }
            catch (Exception e)
            {
                response.StatusCode = -1;
                response.ErrorMessage = "Some error in CreateOrder service";
                _logger.LogError(e, response.ErrorMessage);
            }
            return Ok(response);
        }
    }
}