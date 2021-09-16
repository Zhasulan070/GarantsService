﻿using System;
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
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _service;
        
        public OrderController(ILogger<OrderController> logger, IOrderService service)
        {
            _logger = logger;
            _service = service;
        }
        
        [HttpPost("CheckOrder")]
        public async Task<IActionResult> CheckOrder([FromQuery(Name = "userId")] string userId)
        {
            var response = new Response<List<OrderModel>>();
            try
            {
                response.Result = await _service.CheckOrder(int.Parse(userId));
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
        
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderModel order)
        {
            var response = new Response<string>();
            try
            {
                response.Result = await _service.CreateOrder(order);
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