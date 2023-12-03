using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> getProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
        Task<IEnumerable<Product>> getProductsByCategory(int categoryId);
    }
}