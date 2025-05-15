namespace TechXpress.Models
{
    public class Order
    {
        public enum OrderStatus
        {
            Processing,
            shipped,
            delivered,
            cancelled
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; } = null!;
        public AppUser Customer { get; set; } = null!;
        public OrderStatus Status { get; set; } = OrderStatus.Processing;
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }


}
