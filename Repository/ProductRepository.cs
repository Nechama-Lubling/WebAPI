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


        //אם נוסיף פונקציות צריך לעדכן את הממשק

        private readonly Manager214877003Context _managerContext;


        public ProductRepository(Manager214877003Context managerContext)
        {
            _managerContext = managerContext;
        }



        public async Task<IEnumerable<Product>> getProductsByCategory(int categoryId)
        {
            return await _managerContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> getProducts()
        {
            return await _managerContext.Products.ToListAsync();
        }




    }
}
