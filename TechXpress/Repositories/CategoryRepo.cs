using Microsoft.EntityFrameworkCore;
using TechXpress.Interface;
using TechXpress.Models;

namespace TechXpress.Repositories
{
    /// <summary>
    /// Repository for managing Category entities.
    /// </summary>
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDBContext _dbContext;

        public CategoryRepo(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CategoryExistsAsync(int id)
        {
            return await _dbContext.Categories.AnyAsync(c => c.CategoryId == id);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<string>> GetAllCategoryNamesAsync()
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .Select(c => c.Name)
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<Category?> GetCategorieByNameAsync(string name)
        {
            return await _dbContext.Categories
                .Where(c => c.Name == name)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Category>> GetRootCategoriesAsync()
        {
            // Root categories have no parent
            return await _dbContext.Categories
                .AsNoTracking()
                .Where(c => c.ParentCategoryId == null)
                .ToListAsync();
        }

        public async Task<List<Category>> GetSubCategoriesAsync(int parentCategoryId)
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .Where(c => c.ParentCategoryId == parentCategoryId)
                .ToListAsync();
        }

        public async Task<int> GetTotalCategoryCountAsync()
        {
            return await _dbContext.Categories.CountAsync();
        }

        public async Task<int> GetTotalProductsInCategoryAsync(int categoryId)
        {
            // Count products in this category and all subcategories
            var category = await _dbContext.Categories
                .Include(c => c.SubCategories)
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.CategoryId == categoryId);

            if (category == null)
                return 0;

            int count = category.Products?.Count ?? 0;

            // Recursively count products in subcategories
            if (category.SubCategories != null && category.SubCategories.Any())
            {
                foreach (var sub in category.SubCategories)
                {
                    count += await GetTotalProductsInCategoryAsync(sub.CategoryId);
                }
            }
            return count;
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCategoryParentAsync(int categoryId, int? newParentId)
        {
            var category = await _dbContext.Categories.FindAsync(categoryId);
            if (category != null)
            {
                category.ParentCategoryId = newParentId;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}