using ListDevice.Application.Abstractions;
using ListDevice.Application.ErrorsHandler;
using ListDevice.Application.Features.DeviceR.Commands.Models.DeviceQuery;
using ListDevice.Application.Features.DeviceR.Query.Models;
using ListDevice.Application.Services;
using ListDevice.Application.ViewModels;
using ListDevice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Application.Features.DeviceR.Commands.Handlers.DeviceHandler
{
    internal class AddDeviceHandler : ResponseHandler, IRequestHandler<AddDeviceQuery, Response<DeviceCreateViewModel>>
    {
        private readonly IDeviceService deviceService;

        public AddDeviceHandler(IDeviceService _deviceService)
        {
            deviceService = _deviceService;
        }

        public async Task<Response<DeviceCreateViewModel>> Handle(AddDeviceQuery request, CancellationToken cancellationToken)
        {
            var d = await deviceService.GetDevicesBuSerialNo(request.device.SerialNo);
            if (d != null) { return NotFound(new DeviceCreateViewModel(), "The Device has been added"); }

            
            var device = new Device
            {
                DeviceName = request.device.DeviceName,
                SerialNo = request.device.SerialNo,
                AcquisitionDate = request.device.AcquisitionDate,
                Memo = request.device.Memo,
                CategoryId = request.device.CategoryId,
                CurrentUserId = request.device.CurrentUserId,
                PropertyValues = request.device.PropertyValues
            };

             deviceService.AddDeviceAsync(device);

            var vm = new DeviceCreateViewModel
            {
                DeviceName = device.DeviceName,
                SerialNo = device.SerialNo,
               
                AcquisitionDate = device.AcquisitionDate,
                PropertyValues = device.PropertyValues
            };

            return Success(vm);
        }
    }
}
