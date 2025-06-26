using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechXpress.Models
{
    public class Order
    {
        private decimal totalAmount;

        public enum OrderStatus
        {
            Processing,
            Shipped,
            Delivered,
            Cancelled
        }

        public int OrderId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public AppUser Customer { get; set; } = null!;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get => Items.Count != 0 ? Items.Sum(i => i.UnitPrice * i.Quantity) : 0; set => totalAmount = value; }
        [MinLength(3, ErrorMessage = "Shipping address must be at least 3 characters long.")]
        public string ShippingAddress { get; set; } = null!;
        public OrderStatus Status { get; set; } = OrderStatus.Processing;

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }

}
