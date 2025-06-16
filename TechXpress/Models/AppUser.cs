using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TechXpress.Models
{
    public class AppUser : IdentityUser<int>
    {
        public Gender Gender { get; set; }
        [MinLength(3)]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only letters A-Z or a-z are allowed.")]
        public string Country { get; set; }
        [MinLength(3)]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only letters A-Z or a-z are allowed.")]
        public string City { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public virtual Cart Cart { get; set; } = new Cart();
        public virtual Wishlist Wishlist { get; set; } = new Wishlist();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
    }

    public enum Gender
    {
        Male,
        Female
    }
}
