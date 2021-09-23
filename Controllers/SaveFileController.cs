using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GarantsService.Interfaces;
using GarantsService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GarantsService.Controllers
{
    public class SaveFileController : ControllerBase
    {
        private readonly ILogger<SaveFileController> _logger;
        private readonly ISaveFileService _service;

        public SaveFileController(ILogger<SaveFileController> logger, ISaveFileService service)
        {
            _logger = logger;
            _service = service;
        }
        
        [HttpPost]
        public async Task<IActionResult> SaveFile([FromQuery(Name = "orderId")] string orderId, [FromQuery(Name = "fielName")] string fielName, [FromQuery(Name = "path")] string path)
        {
            var response = new Response<bool>();

            try
            {
                response.Result = await _service.SaveFile(orderId, fielName, path);
                response.StatusCode = 0;
            }
            catch (Exception e)
            {
                response.StatusCode = -1;
                response.ErrorMessage = "Some error in SaveFile service";
                _logger.LogError(e, response.ErrorMessage);
            }

            return Ok(response);
        }
    }
}