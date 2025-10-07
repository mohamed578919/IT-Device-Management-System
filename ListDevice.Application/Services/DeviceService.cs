using ListDevice.Application.Abstractions;
using ListDevice.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ListDevice.Application.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository DeviceRepository;


        public DeviceService(IDeviceRepository _DeviceRepository)
        {
            DeviceRepository = _DeviceRepository;
        }

        public async Task AddDeviceAsync(Device device)
        {
            await DeviceRepository.AddDeviceAsync(device);
        }

        public async Task<IEnumerable<Device>> GetAllDevices()
        {
            return await DeviceRepository.GetAllDevices();
        }

        public async Task<Device> GetDevicesBuSerialNo(string SerialNo)
        {
            return await DeviceRepository.GetDevicesBuSerialNo(SerialNo);
        }
    }
}
