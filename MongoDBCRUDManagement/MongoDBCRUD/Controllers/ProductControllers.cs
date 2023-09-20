using Microsoft.AspNetCore.Mvc;
using MongoDBPersistent.Models;
using MongoDBPersistent.Repositories;

namespace MongoDBCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControllers : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductControllers(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GatAllProducts")]
        public async Task<IActionResult> GatAllProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet("GetByProductId")]
        public async Task<IActionResult> GetByProductId(string id)
        {
            var product = await _productRepository.GetByProductIdAsync(id).ConfigureAwait(false);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _productRepository.CreateProductAsync(product).ConfigureAwait(false);
            return Ok(product.Id);
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(string id, Product product)
        {
            var productDB = await _productRepository.GetByProductIdAsync(id).ConfigureAwait(false);
            if (productDB == null)
            {
                return NotFound();
            }
            await _productRepository.UpdateProductAsync(id, product).ConfigureAwait(false);
            return NoContent();
        }
        
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> Delete(string id)
        {
            var productDB = await _productRepository.GetByProductIdAsync(id).ConfigureAwait(false);
            if (productDB == null)
            {
                return NotFound();
            }
            await _productRepository.DeleteProductAsync(productDB.Id).ConfigureAwait(false);
            return NoContent();
        }


    }
}
