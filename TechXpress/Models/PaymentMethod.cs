using System.ComponentModel.DataAnnotations;

namespace TechXpress.Models
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        [MinLength(3, ErrorMessage = "Payment method name must be between 3 and 50 characters.")]
        [MaxLength(50, ErrorMessage = "Payment method name must be between 3 and 50 characters.")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only letters A-Z or a-z are allowed.")]
        public string Name { get; set; } = null!; // e.g., "Stripe", "PayPal"
        public string? ProviderDetails { get; set; } // optional JSON or XML config
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }

}
