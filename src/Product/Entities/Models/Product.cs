using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Models
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        public Product()
        {
            WeightOfProduct = new Weight();
            Image = new ProductImage();
            //ProductVariants = new List<ProductVariant>();
            ProductVariant = new ProductVariant();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
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
        public ProductImage Image { get; set; }

        [BsonElement("product-variant")]
        public ProductVariant ProductVariant { get; set; }
        //public List<ProductVariant> ProductVariants { get; set; }

    }
}
