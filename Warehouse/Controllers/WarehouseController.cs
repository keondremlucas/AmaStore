using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;

namespace Warehouse
{

    [ApiController]
    [Route("api/warehouse")]
    public class WarehouseController : ControllerBase
    {

        private IWarehouseRepository _repository;

        public WarehouseController(IWarehouseRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("newproduct")]
        public async Task<IActionResult> newproduct(ProductDto productDto)
        {

            var product = new Product(productDto);
            await _repository.AddProductAsync(product);
            await _repository.SaveAsync();

            return CreatedAtAction("GetOneProduct", new { product.Id }, product);
        }

        [HttpGet("product")]
        public async Task<IActionResult> GetOneProduct(int productId)
        {
            var product = await _repository.GetOneProductAsync(productId);
            return Ok(product);
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _repository.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("product/quantity")]
        public async Task<IActionResult> CheckProductQuantity(int productId)
        {   Console.WriteLine($"ProductId: {productId}");
            var product = await _repository.GetOneProductAsync(productId);
            Console.WriteLine("");
            Console.WriteLine($"Product Name {product.ProductName}");

            var quantity = _repository.CheckProductQuantity(product);
            Console.WriteLine("");    
            Console.WriteLine($"Quantity {quantity}");   
            if (quantity < 10 && quantity > 0)
            {
                return Ok($"{product.ProductName} has low inventory. Currently {quantity} in stock.");
            }
            else if (quantity == 0)
            {
                return Ok($"{product.ProductName} is currently out of stock.");
            }
            else
            {
                return Ok($"{product.ProductName} currently has {quantity} in stock.");
            }
        }

        [HttpGet("product/exists")]
        public async Task<IActionResult> CheckExists(int productId)
        {
             var product = await _repository.GetOneProductAsync(productId);
             var check = _repository.CheckProductExists(product);
            

            if(check == 2)
            {
                return Ok($"{product.ProductName} exists.");
            }
            else 
            {
                return BadRequest("This item does not exist.");
            }

        
        }

        [HttpPatch("product/update/{quantity}")]
        public async Task<IActionResult> UpdateProduct(int productId, int quantity)
        {
            var product = await _repository.GetOneProductAsync(productId);
            _repository.UpdateProduct(product,quantity);
            await _repository.SaveAsync();
            return Ok($"{product.ProductName} Updated with Quantity: {quantity}");

          

        
        }
    }
}