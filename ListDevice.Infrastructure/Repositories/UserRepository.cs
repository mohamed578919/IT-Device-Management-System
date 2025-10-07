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
    internal class UserRepository : IUserRepository
    {
        private readonly ListDeviceContext context;

        public UserRepository(ListDeviceContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await context.users.ToListAsync();
        }
    }
}
