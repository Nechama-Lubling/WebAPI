using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly Manager214877003Context _managerContext;


        public CategoryRepository(Manager214877003Context managerContext)
        {
            _managerContext = managerContext;
        }


        public async Task<Category> addCategory(Category category)
        {
            await _managerContext.Categories.AddAsync(category);
            await _managerContext.SaveChangesAsync();
            return category;
        }


        public async Task<IEnumerable<Category>> getCategories()
        {
            return await _managerContext.Categories.ToListAsync();
        }

        public async Task<Category> getCategoryById(int id)
        {
            return await _managerContext.Categories.FindAsync(id);

        }
        public async Task<Category> editCategory(Category categoryToUpdate)
        {
            _managerContext.Categories.Update(categoryToUpdate);
            await _managerContext.SaveChangesAsync();
            return categoryToUpdate;
        }


        public async Task deleteCategory(int id)
        {
            var category = await _managerContext.Categories.FindAsync(id);
            _managerContext.Remove(category);
            _managerContext.SaveChangesAsync();

        }







    }
}
