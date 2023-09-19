using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBPersistent.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public long Price { get; set; }
        public int InventoryCount { get; set; }
        public string Description { get; set; }
    }
}
