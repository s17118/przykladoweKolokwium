using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzykladoweKolokwium.DTOs;
using PrzykladoweKolokwium.Services;

namespace PrzykladoweKolokwium.Controllers
{
    [Route("api")]
    [ApiController]
    public class ConfectioneryController : ControllerBase
    {
        private readonly IConfectioneryDbServices _dbService;

        public ConfectioneryController(IConfectioneryDbServices dbService)
        {
            _dbService = dbService;
        }

        // GET: api/orders
        [HttpGet("orders/")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_dbService.GetOrders());
            }
            catch (Exception e)
            {
                return BadRequest("Exception: " + e.Message + "\n" + e.StackTrace);
            }
        }

        // GET: api/orders/surname
        [HttpGet("orders/{surname}")]
        public IActionResult Get(String surname)
        {
            try
            {
                return Ok(_dbService.GetOrder(surname));
            }
            catch (Exception e)
            {
                return BadRequest("Exception: " + e.Message + "\n" + e.StackTrace);
            }
        }

        // POST: api/orders
        [HttpPost("clients/{idClient}/orders")]
        public IActionResult Post([FromBody] NewOrderDto newOrderDto, int idClient)
        {
            try
            {
                return Ok(_dbService.AddOrder(newOrderDto, idClient));
            }
            catch (Exception e)
            {
                return BadRequest("Exception: " + e.Message + "\n" + e.StackTrace);
            }
        }
    }
}