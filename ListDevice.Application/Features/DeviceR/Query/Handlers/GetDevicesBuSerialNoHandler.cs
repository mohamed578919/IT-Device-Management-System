using ListDevice.Application.Abstractions;
using ListDevice.Application.ErrorsHandler;
using ListDevice.Application.Features.DeviceR.Query.Models;
using ListDevice.Application.Features.DeviceR.Query.Models.CategoryQuery;
using ListDevice.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Application.Features.DeviceR.Query.Handlers
{
    public class GetDevicesBuSerialNoHandler : ResponseHandler, IRequestHandler<GetDevicesBuSerialNoQuery, Response<DeviceIndexViewModel>>
    {
        private readonly IDeviceService deviceService;

        public GetDevicesBuSerialNoHandler(IDeviceService _deviceService)
        {
            deviceService = _deviceService;
        }

        public async Task<Response<DeviceIndexViewModel>> Handle(
        GetDevicesBuSerialNoQuery request,
        CancellationToken cancellationToken)
        { 
            var d = await deviceService.GetDevicesBuSerialNo(request.SerialNo);
            if (d == null) {return NotFound(new DeviceIndexViewModel() , "Not Found"); }
                


            var vm =  new DeviceIndexViewModel
            {
                DeviceName = d.DeviceName,
                SerialNo = d.SerialNo,
                CategoryName = d.Category?.CategoryName,
                CurrentUserName = d.CurrentUser?.FullName,
                AcquisitionDate = d.AcquisitionDate,
                PropertiesJson = d.PropertiesJson
            };
            return Success(vm);
        }
    }
}
