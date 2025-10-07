using ListDevice.Application.ErrorsHandler;
using ListDevice.Application.ViewModels;
using ListDevice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Application.Features.DeviceR.Commands.Models.DeviceQuery
{
    public class AddDeviceQuery : IRequest<Response<DeviceCreateViewModel>>
    {
              public DeviceCreateViewModel device { get; set; }

            public AddDeviceQuery(DeviceCreateViewModel _device)
            {
                device = _device;
            }
    
    }
}
