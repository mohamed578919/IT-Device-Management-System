using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListDevice.Application.Abstractions;
using ListDevice.Domain.Entities;
using ListDevice.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace ListDevice.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ListDeviceContext context;

        public CategoryRepository(ListDeviceContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await context.categories.Include(c => c.CategoryProperties).ThenInclude(cp => cp.Property).ToListAsync();
        }

        public async Task<Category> GetCategoryByNameAsync(string CategoryName)
        {

            return await context.categories
                            .Include(c => c.CategoryProperties)
                                .ThenInclude(cp => cp.Property)   
                            .FirstOrDefaultAsync(c => c.CategoryName == CategoryName);
        }
    }
}
