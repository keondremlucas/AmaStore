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
        public async Task<ActionResult> newproduct(ProductDto productDto)
        {

            var product = new Product(productDto);
            await _repository.AddProductAsync(product);
            await _repository.SaveAsync();

            return CreatedAtAction("GetOneProduct", new { product.Id }, product);
        }

        [HttpGet("product/{id}")]
        public async Task<ActionResult> GetOneProduct(int productId)
        {
            var product = await _repository.GetOneProductAsync(productId);
            return Ok(product);
        }

        [HttpGet("products")]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await _repository.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("product/{id}/quantity")]
        public async Task<ActionResult> CheckProductQuantity(int productId)
        {
            var product = await _repository.GetOneProductAsync(productId);
            var quantity = _repository.CheckProductQuantity(product);

            if (quantity < 10)
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
    }
}