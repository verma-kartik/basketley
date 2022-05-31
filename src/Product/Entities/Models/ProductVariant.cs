using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Models
{
    public class ProductVariant
    {
        public ProductVariant() : this(string.Empty, string.Empty, 0, DateTime.Now, DateTime.Now, false) { }
        public ProductVariant(string? id, string? title, double price, DateTime created, DateTime updated, bool isAvailable)
        {
            Id = id;
            Title = title;
            Price = price;
            Created = created;
            UpdatedAt = updated;
            IsAvailable = isAvailable;
        }

        public string? Id { get; set; }


        public string? Title { get; set; }


        public double Price { get; set; }

        public DateTime Created { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsAvailable { get; set; }

    }
}
