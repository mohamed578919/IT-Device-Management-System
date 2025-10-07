using ListDevice.Application.ErrorsHandler;
using ListDevice.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Application.Features.DeviceR.Query.Models
{
    public class GetDevicesBuSerialNoQuery : IRequest<Response<DeviceIndexViewModel>>
    {
        public string SerialNo { get; set; }

        public GetDevicesBuSerialNoQuery(string _SerialNo)
        {
            SerialNo = _SerialNo;
        }
    }
}
