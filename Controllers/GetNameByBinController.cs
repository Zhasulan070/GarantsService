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
    public class GetNameByBinController : ControllerBase
    {
        private readonly ILogger<GetNameByBinController> _logger;
        private readonly IGetNameByBinService _service;

        public GetNameByBinController(ILogger<GetNameByBinController> logger, IGetNameByBinService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetNameByBin([FromQuery(Name = "bin")] string bin)
        {
            var response = new Response<LoanRequestModel>();

            try
            {
                response.Result = await _service.GateNameByBin(bin);
                response.StatusCode = 0;
            }
            catch (Exception e)
            {
                response.StatusCode = -1;
                response.ErrorMessage = "Some error in GetNameByBin service";
                _logger.LogError(e, response.ErrorMessage);
            }

            return Ok(response);
        }
        
    }
}