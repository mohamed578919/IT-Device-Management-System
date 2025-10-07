using ListDevice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Application.Abstractions
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetAllDevices();
        Task<Device> GetDevicesBuSerialNo(string SerialNo);
        Task AddDeviceAsync(Device device);

    }
}
