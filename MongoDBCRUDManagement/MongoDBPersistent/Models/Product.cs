using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBPersistent.Models
{
    public class Product
    {
        [BsonId]
        public string Id { get; set; }
        public string Title { get; set; }
        public long Price { get; set; }
        public int InventoryCount { get; set; }
        public string Description { get; set; }
    }
}
