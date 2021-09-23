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
    public class GetReferencesController : ControllerBase
    {
        private readonly ILogger<GetReferencesController> _logger;
        private readonly IGetReferencesService _service;

        public GetReferencesController(ILogger<GetReferencesController> logger, IGetReferencesService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("GetFilials")]
        public async Task<IActionResult> GetFilials()
        {
            var response = new Response<List<FilialModel>>();
            try
            {
                response.Result = await _service.FilialsList();
                response.StatusCode = 0;
            }
            catch (Exception e)
            {
                response.StatusCode = -1;
                response.ErrorMessage = "Some error in FilialsList service";
                _logger.LogError(e, response.ErrorMessage);
            }

            return Ok(response);
        }
        
        [HttpGet("GetCurrencies")]
        public async Task<IActionResult> GetCurrencies()
        {
            var response = new Response<List<CurrencyModel>>();
            try
            {
                response.Result = await _service.CurrencyList();
                response.StatusCode = 0;
            }
            catch (Exception e)
            {
                response.StatusCode = -1;
                response.ErrorMessage = "Some error in CurrencyList service";
                _logger.LogError(e, response.ErrorMessage);
            }

            return Ok(response);
        }
        
        [HttpGet("RequestTypes")]
        public async Task<IActionResult> RequestTypes()
        {
            var response = new Response<List<RequestTypeModel>>();
            try
            {
                response.Result = await _service.RequestTypeList();
                response.StatusCode = 0;
            }
            catch (Exception e)
            {
                response.StatusCode = -1;
                response.ErrorMessage = "Some error in RequestTypeList service";
                _logger.LogError(e, response.ErrorMessage);
            }

            return Ok(response);
        }
        
        [HttpGet("Segments")]
        public async Task<IActionResult> Segments()
        {
            var response = new Response<List<SegmentModel>>();
            try
            {
                response.Result = await _service.SegmentList();
                response.StatusCode = 0;
            }
            catch (Exception e)
            {
                response.StatusCode = -1;
                response.ErrorMessage = "Some error in SegmentList service";
                _logger.LogError(e, response.ErrorMessage);
            }

            return Ok(response);
        }
        
    }
}