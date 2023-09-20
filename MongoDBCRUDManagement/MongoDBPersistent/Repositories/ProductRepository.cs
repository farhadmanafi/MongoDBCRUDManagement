using MongoDB.Driver;
using MongoDBPersistent.Configuration;
using MongoDBPersistent.Models;

namespace MongoDBPersistent.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly MongoDbConfiguration _configuration;
        public ProductRepository(MongoDbConfiguration configuration)
        {
            this._configuration = configuration;
            
            var client = new MongoClient(_configuration.ConnectionString);
            var database = client.GetDatabase(_configuration.DatabaseName);
            _productCollection = database.GetCollection<Product>(_configuration.CollectionName);
        }

        public Task<List<Product>> GetAllProductsAsync()
        {
            return _productCollection.Find(a => true).ToListAsync();
        }

        public Task<Product> GetByProductIdAsync(string productId)
        {
            return _productCollection.Find(a => a.Id == productId).FirstOrDefaultAsync();
        }

        public async Task CreateProductAsync(Product product)
        {
            await _productCollection.InsertOneAsync(product).ConfigureAwait(false);
        }

        public Task UpdateProductAsync(string productId, Product product)
        {
            return _productCollection.ReplaceOneAsync(a => a.Id == productId, product);
        }

        public Task DeleteProductAsync(string productId)
        {
            return _productCollection.DeleteOneAsync(a => a.Id == productId);
        }
    }
}
