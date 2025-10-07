using ListDevice.Domain.Entities;

using ListDevice.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListDevice.Application.Abstractions;
namespace ListDevice.Infrastructure.Repositories
{
    
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ListDeviceContext context;

        public DeviceRepository(ListDeviceContext _context)
        {
            context = _context;
        }

        public async Task AddDeviceAsync(Device device)
        {
            await context.Devices.AddAsync(device);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Device>> GetAllDevices()
        {
            return await context.Devices
                                .Include(d => d.Category)      
                                .Include(d => d.CurrentUser)    
                                .ToListAsync();
        }

        public async Task<Device> GetDevicesBuSerialNo(string SerialNo)
        {
            return await context.Devices
                        .Include(d => d.Category)
                        .Include(d => d.CurrentUser)
                        .FirstOrDefaultAsync(d => d.SerialNo == SerialNo);
        }
    }
}
