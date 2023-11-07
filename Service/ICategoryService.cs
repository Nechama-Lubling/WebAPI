using Entities;

namespace Service
{
    public interface ICategoryService
    {
        Task<Category> addCategory(Category category);
        Task<IEnumerable<Category>> getCategories();
        Task<Category> getCategoryById(int id);
    }
}