﻿using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.ProductRepo;

namespace ProjectManagemnetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsControllers : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => repository.GetProducts();

        [HttpPost]
        public IActionResult PostProduct(Product p)
        {
            repository.SaveProduct(p);
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            var p = repository.GetProductById(id);
            if (p == null)
                return NotFound();
            repository.DeleteProduct(p);
            return NoContent();
        }

        [HttpPut("id")]
        public IActionResult UpdateProduct(int id, Product p)
        {
            var pTmp = repository.GetProductById(id);
            if (p == null) return NotFound();
            repository.UpdateProduct(p);
            return NoContent();
        }
    }

}
