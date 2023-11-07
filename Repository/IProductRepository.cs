using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> getProductsByCategory(int categoryId);
    }
}