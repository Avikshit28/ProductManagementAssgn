using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductManagementApi.Models;
using ProductManagementApi.Services;

namespace ProductManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} was not found.");
            }
            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdProduct = await _productService.CreateProductAsync(product);
            _logger.LogInformation("Product Created: ID = {Id}, Name = {Name}, Category = {Category}, Price = {Price}", 
                createdProduct.Id, createdProduct.Name, createdProduct.Category, createdProduct.Price);

            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedProduct = await _productService.UpdateProductAsync(id, product);
            if (updatedProduct == null)
            {
                return NotFound($"Product with ID {id} was not found.");
            }

            _logger.LogInformation("Product Updated: ID = {Id}, Name = {Name}, Category = {Category}, Price = {Price}", 
                updatedProduct.Id, updatedProduct.Name, updatedProduct.Category, updatedProduct.Price);

            return Ok(updatedProduct);
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _productService.DeleteProductAsync(id);
            if (!deleted)
            {
                return NotFound($"Product with ID {id} was not found.");
            }

            _logger.LogInformation("Product Deleted: ID = {Id}", id);

            return NoContent();
        }

        // GET: api/products/search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProducts([FromQuery] string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return BadRequest("Category parameter is required for searching.");
            }

            var products = await _productService.SearchProductsByCategoryAsync(category);
            return Ok(products);
        }
    }
}
