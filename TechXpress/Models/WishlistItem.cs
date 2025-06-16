using System.ComponentModel.DataAnnotations.Schema;

namespace TechXpress.Models
{
    public class WishlistItem
    {
        public int WishlistItemId { get; set; }
        [ForeignKey("Wishlist")]
        public int WishlistId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Wishlist Wishlist { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }


}
