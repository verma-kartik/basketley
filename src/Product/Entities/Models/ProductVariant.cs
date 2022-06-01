using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Models
{
    [BsonIgnoreExtraElements]
    public class ProductVariant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("title")]
        [BsonRequired]
        public string? Title { get; set; }

        [BsonElement("price")]
        [BsonRequired]
        public double Price { get; set; }

        [BsonElement("created")]
        public DateTime Created { get; set; }

        [BsonElement("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("is_available")]
        public bool IsAvailable { get; set; }

        public static implicit operator ProductVariant(string id)
        {
            return new ProductVariant() { Id = id };
        }
    }
}
