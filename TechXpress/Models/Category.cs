using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechXpress.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [MinLength(3)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [ForeignKey("ParentCategory")]
        public int? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        [InverseProperty("ParentCategory")]
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

}
