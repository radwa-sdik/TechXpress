using System.ComponentModel.DataAnnotations.Schema;

namespace TechXpress.Models
{
    public class Payment
    {
        public enum PaymentStatus
        {
            Pending,
            Completed,
            Failed,
            Refunded
        }

        public int PaymentId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = null!;

        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string TransactionId { get; set; } = null!;
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        public string? GatewayResponse { get; set; } // Optional
        public string? ErrorMessage { get; set; } // Optional
    }

}
