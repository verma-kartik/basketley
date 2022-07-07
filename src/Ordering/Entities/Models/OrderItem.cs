using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class OrderItem
    {
        [Key]
        public int? OrderItemId { get; set; }

        public int? OrderId { get; set; }
        [JsonIgnore]
        public Order? Order { get; set; }

        public int ProductId { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TaxPercent { get; set; }
    }
}
