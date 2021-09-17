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
    public class GetCheckerController : ControllerBase
    {
        private readonly ILogger<GetCheckerController> _logger;
        private readonly IGetChecherService _service;

        public GetCheckerController(ILogger<GetCheckerController> logger, IGetChecherService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCheckers()
        {
            var response = new Response<List<CheckerModel>>();

            try
            {
                response.Result = await _service.GetCheckersList();
                response.StatusCode = 0;
            }
            catch (Exception e)
            {
                response.StatusCode = -1;
                response.ErrorMessage = "Some error in GetCheckersList service";
                _logger.LogError(e, response.ErrorMessage);
            }

            return Ok(response);
        }
    }
}