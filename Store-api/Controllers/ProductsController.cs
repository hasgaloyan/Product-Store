using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductStoreAPI.Models;

namespace ProductStoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        ProductContext context;

        public ProductsController(ProductContext contextDI)
        {
            context = contextDI;
        }

        // GET all products   api/products
        //(query) GET products filtered by price(greater, lower)  api/products?gt=1000&lt=2500
        [HttpGet]
        public IEnumerable<Product> Get([FromQuery] int gt, [FromQuery] int lt)
        {
            if (gt > lt)
                return null;
            if (lt == 0)
            {
                lt = 20000; //temporary solution
            }
            return context.Products.Where(pr => pr.Price > gt && pr.Price < lt).ToList();
        }

        // GET product details  api/products/details?id=1
        [Route("details")]
        [HttpGet]
        public Product Get([FromQuery]long productID)
        {
            return context.Products.FirstOrDefault(p => p.ID == productID);
        }


        // GET products by categoryID  api/products/2
        [HttpGet("{categoryID}")]
        public IEnumerable<Product> Get(int categoryID)
        {
            return context.Products.Where(x => x.CategoryID == categoryID).ToList();
        }

        // GET categories 
        [Route("categories")]
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return context.Categories.ToList();
        }
    }



}
