using ListDevice.Application.Abstractions;
using ListDevice.Application.ErrorsHandler;
using ListDevice.Application.Features.DeviceR.Query.Models;
using ListDevice.Application.ViewModels;
using ListDevice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Application.Features.DeviceR.Query.Handlers
{
    internal class GetAllDeviceHandler : ResponseHandler,IRequestHandler<GetAllDeviceQuery, Response<IEnumerable<DeviceIndexViewModel>>>
    {

        private readonly IDeviceService deviceService;

        public GetAllDeviceHandler(IDeviceService _deviceService)
        {
            deviceService = _deviceService;
        }
        public async Task<Response<IEnumerable<DeviceIndexViewModel>>> 
            Handle(GetAllDeviceQuery request, CancellationToken cancellationToken)
        {
            var Devices = await deviceService.GetAllDevices();
            var vm = Devices.Select(d => new DeviceIndexViewModel
            {
                DeviceName = d.DeviceName,
                SerialNo = d.SerialNo,
                CategoryName = d.Category?.CategoryName,
                CurrentUserName = d.CurrentUser?.FullName,
                AcquisitionDate = d.AcquisitionDate,
                PropertiesJson = d.PropertiesJson
            });
            return Success(vm);
        }
    }
}
