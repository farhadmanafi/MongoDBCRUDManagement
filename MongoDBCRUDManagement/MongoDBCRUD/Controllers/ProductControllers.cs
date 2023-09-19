using Microsoft.AspNetCore.Mvc;
using MongoDBPersistent.Models;
using MongoDBPersistent.Services;

namespace MongoDBCRUD.Controllers
{
    public class ProductControllers : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductControllers(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> GatAllProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _productRepository.GetByProductIdAsync(id).ConfigureAwait(false);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _productRepository.CreateProductAsync(product).ConfigureAwait(false);
            return Ok(product.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, Product product)
        {
            var productDB = await _productRepository.GetByProductIdAsync(id).ConfigureAwait(false);
            if (productDB == null)
            {
                return NotFound();
            }
            await _productRepository.UpdateProductAsync(id, product).ConfigureAwait(false);
            return NoContent();
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
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
