using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Runtime.Serialization;

namespace Entities.Models
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string? Id { get; set; }

        [BsonElement("name")]
        [BsonRequired]
        public string? Name { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonElement("product_type")]
        public string? ProductType { get; set; }

        [BsonElement("category")]
        public string? Category { get; set; }

        [BsonElement("summary")]
        public string? Summary { get; set; }

        [BsonElement("created")]
        public DateTime Created { get; set; }

        [BsonElement("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("charge_taxes")]
        public bool ChargeTaxes { get; set; }

        [BsonElement("weight")]
        public Weight? WeightOfProduct { get; set; }

        [BsonElement("is_available")]
        public bool IsAvailable { get; set; }

        [BsonRequired]
        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("image")]
        public ProductImage? Image { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<string>? ProductVariants { get; set; }

        [BsonIgnore]
        public List<ProductVariant>? ProductVariantList { get; set; }

    }
}
