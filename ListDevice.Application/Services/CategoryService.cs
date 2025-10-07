using ListDevice.Application.Abstractions;
using ListDevice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;


        public CategoryService(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await categoryRepository.GetAllCategoriesAsync();
        }

       

        public async Task<Category> GetCategoryByNameAsync(string CategoryName)
        {
            return await categoryRepository.GetCategoryByNameAsync(CategoryName);
        }



        public async Task<IEnumerable<Property>> GetAllCategoryPropertiesAsync(string categoryName)
        {
            var category = await GetCategoryByNameAsync(categoryName);

            if (category == null)
                return Enumerable.Empty<Property>(); 

            return category.CategoryProperties
                          .Select(cp => cp.Property)
                          .ToList();
        }

       
    }
}
