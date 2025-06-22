using TechXpress.Models;

namespace TechXpress.Interface
{
    public interface IProductRepo
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetProductsByPaginationAsync(int pageNumber, int pageSize = 10);
        Task<Product?> GetProductByIdAsync(int id);
        Task<List<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<List<Product>> GetProductsByNameAsync(string name);
        Task<List<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<List<Product>> GetProductsByRatingAsync(double minRating);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);

        // Additional useful functions:
        Task<bool> ProductExistsAsync(int id); // Check if a product exists
        Task<int> GetTotalProductCountAsync(); // Get total number of products
        Task<List<string>> GetAllProductNamesAsync(); // Get all product names
        Task<List<Product>> GetLatestProductsAsync(int count); // Get latest added products
        Task<List<Product>> GetTopRatedProductsAsync(int count); // Get top-rated products
    }
}
