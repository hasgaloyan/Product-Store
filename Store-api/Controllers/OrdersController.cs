using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductStoreAPI.Models;
using System.Linq;
using Newtonsoft.Json.Linq;
using System;

namespace ProductStoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        ProductContext context;
        //Dependency injection
        public OrdersController(ProductContext contextDI)
        {
            context = contextDI;
        }

        // GET orders history api/orders
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return context.Orders.ToList();
        }

        // GET order by ID  api/orders/4
        [HttpGet("{id}")]
        public IQueryable<Order> Get(int id)
        {
            return context.Orders.Where(or=>or.ID == id);
        }

        // POST add a new order api/orders
        [HttpPost]
        public IActionResult Post([FromBody]JObject newOrder)
        {
            Console.WriteLine("New order is " + newOrder);
            Order order = newOrder.ToObject<Order>();
            context.Orders.Add(order);
            context.SaveChanges();
            Console.WriteLine("Order username is:D " + order.Username);
            var coll = context.OrderItems.Where(x => x.UID == order.Username);
            context.OrderItems.RemoveRange(coll);
            context.SaveChanges();
            return StatusCode(200);
        }

        // DELETE api/orders/
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
