using Microsoft.AspNetCore.Mvc;
using OBJERO.Models;
using OBJERO.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>();

       
        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.ProductId = products.Count + 1;
            products.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, product);
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            if (product == null) return NotFound();

            product.Code = updatedProduct.Code;
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            if (product == null) return NotFound();

            products.Remove(product);
            return NoContent();
        }
    }
}


