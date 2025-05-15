namespace TechXpress.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }

        public AppUser Customer { get; set; } = null!;
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }


}
