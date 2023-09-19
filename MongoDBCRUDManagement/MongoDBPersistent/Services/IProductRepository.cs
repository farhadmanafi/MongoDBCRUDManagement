using MongoDBPersistent.Models;

namespace MongoDBPersistent.Services
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetByProductIdAsync(Guid productId);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Guid productId, Product product);
        Task DeleteProductAsync(Guid productId);
    }
}
