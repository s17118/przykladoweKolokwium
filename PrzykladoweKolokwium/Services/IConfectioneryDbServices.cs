using Microsoft.AspNetCore.Mvc;
using PrzykladoweKolokwium.DTOs;
using PrzykladoweKolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykladoweKolokwium.Services
{
    public interface IConfectioneryDbServices
    {
        IActionResult GetOrders();
        IActionResult GetOrder(String surname);

        IActionResult AddOrder(NewOrderDto newOrderDto, int idClient);
    }
}
