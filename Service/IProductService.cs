using Entities;

namespace Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> getProductsByCategory(int categoryId);
    }
}