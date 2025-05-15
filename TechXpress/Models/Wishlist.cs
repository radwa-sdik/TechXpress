namespace TechXpress.Models
{
    public class Wishlist
    {
        public int WishlistId { get; set; }
        public int CustomerId { get; set; }

        public AppUser Customer { get; set; } = null!;
        public ICollection<WishlistItem> Items { get; set; } = new List<WishlistItem>();
    }


}
