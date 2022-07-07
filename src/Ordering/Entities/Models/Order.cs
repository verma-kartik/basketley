using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Order
    {
        public Order()
        {
            CreatedOn = DateTimeOffset.Now;
            LatestUpdatedOn = DateTimeOffset.Now;
            OrderStatus = OrderStatus.New;
            IsMasterOrder = false;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTimeOffset LatestUpdatedOn { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public int CreatedById { get; set; }

        public int? VendorId { get; set; }

        [StringLength(450)]
        public string? CouponCode { get; set; }

        [StringLength(450)]
        public string? CouponRuleName { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal SubTotal { get; set; }

        public decimal SubTotalWithDiscount { get; set; }

        public int ShippingAddressId { get; set; }

        public OrderAddress ShippingAddress { get; set; }

        public IList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public OrderStatus OrderStatus { get; set; }

        [StringLength(1000)]
        public string? OrderNote { get; set; }

        public long? ParentId { get; set; }

        [JsonIgnore]
        public Order Parent { get; set; }

        public bool IsMasterOrder { get; set; }

        [StringLength(450)]
        public string ShippingMethod { get; set; }

        public decimal ShippingFeeAmount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal OrderTotal { get; set; }

        [StringLength(450)]
        public string PaymentMethod { get; set; }

        public decimal PaymentFeeAmount { get; set; }

        public IList<Order> Children { get; protected set; } = new List<Order>();

        public void AddOrderItem(OrderItem item)
        {
            item.Order = this;
            OrderItems.Add(item);
        }
    }
}
