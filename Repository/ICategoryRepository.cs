using Entities;

namespace Repository
{
    public interface ICategoryRepository
    {
        Task<Category> addCategory(Category category);
        Task deleteCategory(int id);
        Task<Category> editCategory(Category categoryToUpdate);
        Task<IEnumerable<Category>> getCategories();
        Task<Category> getCategoryById(int id);
    }
}