using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> getProducts();
        Task<IEnumerable<Product>> getProductsByCategory(int categoryId);
    }
}