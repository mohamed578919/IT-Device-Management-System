using ListDevice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Application.Abstractions
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByNameAsync(string CategoryName);

        Task<IEnumerable<Property>> GetAllCategoryPropertiesAsync(string categoryName);

    }
}
