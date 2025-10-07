using ListDevice.Application.ErrorsHandler;
using ListDevice.Application.ViewModels;
using ListDevice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Application.Features.DeviceR.Query.Models.UserQuery
{
    public class GetAllUserQuery : IRequest<Response<IEnumerable<User>>>
    {
    }
}
