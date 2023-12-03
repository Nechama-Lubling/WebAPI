using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly Manager214877003Context _managerContext;


        public ProductRepository(Manager214877003Context managerContext)
        {
            _managerContext = managerContext;
        }



        public async Task<IEnumerable<Product>> getProductsByCategory(int categoryId)
        {
            return await _managerContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> getProducts(int position, int skip, string? desc, int? minPrice,
            int? maxPrice, int?[] categoryIds)
        {

            var query = _managerContext.Products.Where(p =>
            (desc == null ? (true) : (p.ProductDescription.Contains(desc)))
            && ((minPrice == null) ? (true) : (p.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (p.Price <= maxPrice))
          && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(p.CategoryId))))
                .OrderBy(p => p.Price).Include(i=>i.Category);
 
            List<Product> products = await query.ToListAsync();
            return products;


        }

    }
}
