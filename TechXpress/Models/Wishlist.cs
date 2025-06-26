using System.ComponentModel.DataAnnotations.Schema;

namespace TechXpress.Models
{
    public class Wishlist
    {
        public int WishlistId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public AppUser Customer { get; set; } = null!;
        public ICollection<WishlistItem> Items { get; set; } = new List<WishlistItem>();
    }


}
