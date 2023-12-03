using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {


        public IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<IEnumerable<Product>> getProductsByCategory(int categoryId)
        {
            return await _productRepository.getProductsByCategory(categoryId);
        }
        public async Task<IEnumerable<Product>> getProducts(int position, int skip, string? desc, int? minPrice,
            int? maxPrice, int?[] categoryIds)
        {
            return await _productRepository.getProducts(position, skip, desc, minPrice, maxPrice, categoryIds);
        }

    }
}
