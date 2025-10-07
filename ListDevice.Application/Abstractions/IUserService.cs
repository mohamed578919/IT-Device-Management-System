using ListDevice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Application.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();

    }
}
