using TechXpress.Models;

namespace TechXpress.Interface
{
    public interface ICategoryRepo
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<List<Category>> GetSubCategoriesAsync(int parentCategoryId);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
        Task<bool> CategoryExistsAsync(int id); // Check if a category exists
        Task<int> GetTotalCategoryCountAsync(); // Get total number of categories
        Task<List<string>> GetAllCategoryNamesAsync(); // Get all category names
        Task<Category?> GetCategorieByNameAsync(string name); // Get categories by name

        // Get categories that don't have a parent (root categories)
        Task<List<Category>> GetRootCategoriesAsync();
        
        // Get number of products in a category (including subcategories)
        Task<int> GetTotalProductsInCategoryAsync(int categoryId);

        // Move a category under a new parent
        Task UpdateCategoryParentAsync(int categoryId, int? newParentId);
    }
}
