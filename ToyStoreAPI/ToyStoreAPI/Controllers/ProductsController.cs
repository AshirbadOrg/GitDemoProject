using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToyStoreAPI.DAL;
using ToyStoreAPI.Models;

namespace ToyStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            return Ok(product);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategoryAsync(categoryId);
            return Ok(products);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            var productId = await _productRepository.CreateProductAsync(product);
            if (productId > 0)
            {
                product.ProductId = productId;
                return CreatedAtAction(nameof(GetById), new { id = productId }, product);
            }
            return BadRequest(new { message = "Failed to create product" });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            product.ProductId = id;
            var result = await _productRepository.UpdateProductAsync(product);
            if (result > 0)
            {
                return Ok(new { message = "Product updated successfully" });
            }
            return BadRequest(new { message = "Failed to update product" });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productRepository.DeleteProductAsync(id);
            if (result > 0)
            {
                return Ok(new { message = "Product deleted successfully" });
            }
            return NotFound(new { message = "Product not found" });
        }
    }
}
