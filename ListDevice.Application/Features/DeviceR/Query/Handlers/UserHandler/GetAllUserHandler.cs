using ListDevice.Application.Abstractions;
using ListDevice.Application.ErrorsHandler;
using ListDevice.Application.Features.DeviceR.Query.Models;
using ListDevice.Application.Features.DeviceR.Query.Models.UserQuery;
using ListDevice.Application.Services;
using ListDevice.Application.ViewModels;
using ListDevice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Application.Features.DeviceR.Query.Handlers.UserHandler
{
    internal class GetAllUserHandler : ResponseHandler, IRequestHandler<GetAllUserQuery, Response<IEnumerable<User>>>
    {

        private readonly IUserService UserService;


        public GetAllUserHandler(IUserService _UserService )
        {
            UserService = _UserService;
        }
        public async Task<Response<IEnumerable<User>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var Users = await UserService.GetAllUsersAsync();

            return Success(Users);
        }
    }
}
