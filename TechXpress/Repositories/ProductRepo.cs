using Microsoft.EntityFrameworkCore;
using TechXpress.Interface;
using TechXpress.Models;

namespace TechXpress.Repositories
{
    public class ProductRepo : IProductRepo
    {
        public AppDBContext DBContext;
        public ProductRepo(AppDBContext appDBContext)
        {
            DBContext = appDBContext;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await DBContext.Products
                .Include(p => p.Reviews)
                .ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await DBContext.Products
                .Include(p => p.Reviews)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await DBContext.Products
                .Include(p => p.Reviews)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByNameAsync(string name)
        {
            return await DBContext.Products
                .Include(p => p.Reviews)
                .Where(p => p.Name.Contains(name))
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByPaginationAsync(int pageNumber, int pageSize = 10)
        {
            return await DBContext.Products
                .Include(p => p.Reviews)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await DBContext.Products
                .Include(p => p.Reviews)
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByRatingAsync(double minRating)
        {
            return await DBContext.Products
                .Include(p => p.Reviews)
                .Where(p => p.Reviews.Any() && p.Reviews.Average(pr => pr.Rating) >= minRating)
                .ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            DBContext.Products.Update(product);
            await DBContext.SaveChangesAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            await DBContext.Products.AddAsync(product);
            await DBContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            if (product != null)
            {
                DBContext.Products.Remove(product);
                await DBContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ProductExistsAsync(int id)
        {
            return await DBContext.Products.AnyAsync(p => p.ProductId == id);
        }

        public async Task<int> GetTotalProductCountAsync()
        {
            return await DBContext.Products.CountAsync();
        }

        public async Task<List<string>> GetAllProductNamesAsync()
        {
            return await DBContext.Products
                .Select(p => p.Name)
                .ToListAsync();
        }

        public async Task<List<Product>> GetLatestProductsAsync(int count)
        {
            return await DBContext.Products
                .Include(p => p.Reviews)
                .OrderByDescending(p => p.CreatedAt)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<Product>> GetTopRatedProductsAsync(int count)
        {
            return await DBContext.Products
                .Include(p => p.Reviews)
                .OrderByDescending(p => p.Rating)
                .Take(count)
                .ToListAsync();
        }
    }
}
