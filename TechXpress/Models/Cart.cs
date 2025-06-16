using System.ComponentModel.DataAnnotations.Schema;

namespace TechXpress.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public AppUser Customer { get; set; } = null!;
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }


}
