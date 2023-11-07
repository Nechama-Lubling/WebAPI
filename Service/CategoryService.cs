using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryService : ICategoryService
    {

        public ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }



        public async Task<Category> addCategory(Category category)
        {

            return await _categoryRepository.addCategory(category);
        }



        public async Task<IEnumerable<Category>> getCategories()
        {
            return await _categoryRepository.getCategories();
        }


        public async Task<Category> getCategoryById(int id)
        {

            return await _categoryRepository.getCategoryById(id);
        }


        //public async Task<Category> deleteCategory(int id)
        //{

        //    return await _categoryRepository.deleteCategory(id);
        //}



    }
}
