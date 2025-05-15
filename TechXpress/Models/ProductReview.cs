using System.ComponentModel.DataAnnotations;

namespace TechXpress.Models
{
    public class ProductReview
    {
        [Key]
        public int ReviewId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Rating { get; set; } // 1-5
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public AppUser Customer { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }

}