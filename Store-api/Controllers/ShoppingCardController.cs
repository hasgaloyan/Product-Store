using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ProductStoreAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductStoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingCardController : Controller
    {
        ProductContext context;
        //Dependency injection
        public ShoppingCardController(ProductContext contextDI)
        {
            context = contextDI;
        }

        // GET all orderItems of current user(uniqueness is provided by cookie generate) api/shoppingcard
        [HttpGet]
        public IQueryable Get([FromQuery]string UID)
        {
            var res = new List<object>().AsQueryable();
            res = from o in context.OrderItems
                  where o.UID == UID
                  join p in context.Products
                  on o.ProductID equals p.ID
                  select new { Name = p.Name, Price = p.Price, Quantity = o.Quantity.ToString(), Id = o.ID };
            return res;
        }

        // POST add an ORDERITEM(with a ProductID and client-generated UID and quantity) to shopping card api/shoppingcard
        [HttpPost]
        public IActionResult Post([FromBody]JObject newItem)
        {
            Console.WriteLine("Jobject received is:" + newItem.ToString());
            OrderItem oItem = newItem.ToObject<OrderItem>();
            int count = 0;
            var coll = new List<object>().AsQueryable();
            coll = from oi in context.OrderItems
                   where oi.UID == oItem.UID
                   select oi;
            if (coll.Count() > 0)
            {
                foreach (OrderItem item in coll)
                    if (item.ProductID == oItem.ProductID)
                    {
                        item.Quantity += oItem.Quantity;
                        count = coll.Count();
                        break;
                    }
            }
            if (count == 0)
            {
                context.OrderItems.Add(oItem);
                count = coll.Count() + 1;
            }

            context.SaveChanges();
            return StatusCode(200, count);
        }

        // PUT modify THIS orderitem's quantity to THIS QUANTITY: api/shoppingcard
        [HttpPut]
        public IActionResult Put([FromQuery]int id, [FromQuery]int quantity)
        {
            var item = context.OrderItems.FirstOrDefault(oi => oi.ID == id);
            Console.WriteLine("The item is" + item);
            if (item == null)
                return NotFound();
            item.Quantity = quantity;
            context.SaveChanges();
            return StatusCode(200, item);
        }

        // DELETE orderitem with THIS ID from shopping card: api/shoppingcard/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var orderItem = context.OrderItems.FirstOrDefault(item => item.ID == id);
            if (orderItem == null)
            {
                return NotFound();
            }
            context.OrderItems.Remove(orderItem);
            context.SaveChanges();
            return StatusCode(200, "Successfully deleted.");
        }
    }
}
