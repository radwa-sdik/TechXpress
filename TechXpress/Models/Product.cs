using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechXpress.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [MinLength(3)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Range(0.01, 500_000.00, ErrorMessage = "Price must be between 0.01 and 500000.00")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be 0 or more")]
        public int StockQuantity { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; } = "Placeholder.jpeg";

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } 
        public bool IsActive { get; set; } = true;
        public Category Category { get; set; } = null!;
        public ICollection<ProductReview> Reviews { get; set; } = new List<ProductReview>();
    }
}
