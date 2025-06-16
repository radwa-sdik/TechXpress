using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace TechXpress.Models
{
    public class AppDBContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<AppUser>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.Customer);

            builder.Entity<AppUser>()
                .HasOne(u => u.Wishlist)
                .WithOne(w => w.Customer);

            builder.Entity<AppUser>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.Customer);

            builder.Entity<AppUser>()
                .HasMany(u => u.ProductReviews)
                .WithOne(pr => pr.Customer);

            builder.Entity<Cart>()
                .HasMany(c => c.Items)
                .WithOne(ci => ci.Cart);

            builder.Entity<CartItem>()
                .HasOne(ci => ci.Product);

            builder.Entity<Wishlist>()
                .HasMany(w => w.Items)
                .WithOne(wi => wi.Wishlist);

            builder.Entity<WishlistItem>()
                .HasOne(wi => wi.Product);

            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);

            builder.Entity<Product>()
                .HasMany(p => p.Reviews)
                .WithOne(pr => pr.Product);

            builder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(oi => oi.Order);

            builder.Entity<Order>()
                .HasMany(o => o.Payments)
                .WithOne(p => p.Order);

            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Product);
     
            builder.Entity<Payment>()
                .HasOne(p => p.PaymentMethod)
                .WithMany(pm => pm.Payments);

            builder.Entity<Category>()
            .HasOne(c => c.ParentCategory)
            .WithMany(c => c.SubCategories)
            .HasForeignKey(c => c.ParentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<AppUser>()
                .Property(u => u.Gender)
                .HasConversion<string>();

            builder.Entity<Order>()
                .Property(o => o.Status)
                .HasConversion<string>();

            builder.Entity<Payment>()
                .Property(p => p.Status)
                .HasConversion<string>();


        }
    }
}
