namespace Entities
{
    public class CartItem
    {  
        public DateTimeOffset CreatedOn { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public long CartId { get; set; }

        public Cart? Cart { get; set; }
    }
}
