using MongoDBPersistent.Models;

namespace MongoDBPersistent.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetByProductIdAsync(string productId);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(string productId, Product product);
        Task DeleteProductAsync(string productId);
    }
}
