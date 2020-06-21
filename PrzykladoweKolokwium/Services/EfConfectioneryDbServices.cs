using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrzykladoweKolokwium.DTOs;
using PrzykladoweKolokwium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykladoweKolokwium.Services
{
    public class EfConfectioneryDbServices : IConfectioneryDbServices
    {
        private readonly ConfectioneryContext _context;

        public EfConfectioneryDbServices(ConfectioneryContext context)
        {
            _context = context;
        }

        public IActionResult AddOrder(NewOrderDto newOrderDto, int idClient)
        {
            if (newOrderDto.Wyroby.Count() == 0)
            {
                return new BadRequestObjectResult("Order should contains at least 1 product");
            }

            Client client = _context.Clients.Find(idClient);
            if (client == null)
            {
                return new NotFoundObjectResult("Client with selected id doesn't exist");
            }

            Order order = new Order
            {
                IdClient = idClient,
                IdEmployee = idClient % 2,
                AcceptanceDate = newOrderDto.DataPrzyjecia,
                Comments = newOrderDto.Uwagi
            };
            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (NewOrderItemDto newOrderItemDto in newOrderDto.Wyroby)
            {
                ConfectioneryProduct confectioneryProduct = _context.ConfectioneryProducts
                    .Where(p => p.Name == newOrderItemDto.Wyrob)
                    .FirstOrDefault();
                if (confectioneryProduct == null)
                {
                    return new NotFoundObjectResult("Product with selected name doesn't exist");
                }
                OrderItem orderItem = new OrderItem
                {
                    IdOrder = _context.Orders.Max(o => o.IdOrder),
                    IdConfectioneryProduct = confectioneryProduct.IdConfectioneryProduct,
                    Quantity = int.Parse(newOrderItemDto.Ilosc),
                    Comments = newOrderItemDto.Uwagi
                };
                _context.OrderItems.Add(orderItem);
            }
            _context.SaveChanges();


            return new OkObjectResult("Ok");
        }

        public IActionResult GetOrder(String surname)
        {
            List<OrderDto> orderDtos = new List<OrderDto>();

            var idClient = _context.Clients.Where(c => c.Surname == surname).Select(c => c.IdClient).FirstOrDefault();
            var orders = _context.Orders.Where(o => o.IdClient == idClient).ToList();

            if (orders.Count == 0)
            {
                return null;
            }

            foreach (Order o in orders)
            {
                var items = new List<OrderItemDto>();

                var confectioneryProducts = _context.OrderItems.Where(i => i.IdOrder == o.IdOrder).ToList();
                foreach (OrderItem i in confectioneryProducts)
                {
                    var product = _context.ConfectioneryProducts.Where(p => p.IdConfectioneryProduct == i.IdConfectioneryProduct).FirstOrDefault();

                    items.Add(new OrderItemDto
                    {
                        Name = product.Name,
                        Type = product.Type,
                        Quantity = i.Quantity,
                        Comments = i.Comments
                    });
                }

                orderDtos.Add(new OrderDto
                {
                    IdOrder = o.IdOrder,
                    AcceptanceDate = o.AcceptanceDate,
                    RealizationDate = o.RealizationDate,
                    Comments = o.Comments,
                    OrderItems = items
                });
            };

            return new OkObjectResult(orderDtos);
        }

        public IActionResult GetOrders()
        {
            List<OrderDto> orderDtos = new List<OrderDto>();

            var orders = _context.Orders.ToList();
            foreach (Order o in orders)
            {
                var items = new List<OrderItemDto>();

                var confectioneryProducts = _context.OrderItems.Where(i => i.IdOrder == o.IdOrder).ToList();
                foreach (OrderItem i in confectioneryProducts)
                {
                    var product = _context.ConfectioneryProducts.Where(p => p.IdConfectioneryProduct == i.IdConfectioneryProduct).FirstOrDefault();

                    items.Add(new OrderItemDto
                    {
                        Name = product.Name,
                        Type = product.Type,
                        Quantity = i.Quantity,
                        Comments = i.Comments
                    });
                }

                orderDtos.Add(new OrderDto
                {
                    IdOrder = o.IdOrder,
                    AcceptanceDate = o.AcceptanceDate,
                    RealizationDate = o.RealizationDate,
                    Comments = o.Comments,
                    OrderItems = items
                });
            };

            return new OkObjectResult(orderDtos);
        }
    }
}
