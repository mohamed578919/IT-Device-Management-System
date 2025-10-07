using ListDevice.Application.Abstractions;
using ListDevice.Application.ErrorsHandler;
using ListDevice.Application.Features.DeviceR.Query.Models;
using ListDevice.Application.Features.DeviceR.Query.Models.CategoryQuery;
using ListDevice.Application.Services;
using ListDevice.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Application.Features.DeviceR.Query.Handlers.categoryHandler
{
    public class GetAllCategoryPropertiesHandler : ResponseHandler, IRequestHandler<GetAllCategoryPropertiesQuery, Response<IEnumerable<CategoryPropertiesViewModel>>>
    {
        private readonly ICategoryService CategoryService;

        public GetAllCategoryPropertiesHandler(ICategoryService _CategoryService)
        {
            CategoryService = _CategoryService;
        }

        public async Task<Response<IEnumerable<CategoryPropertiesViewModel>>> Handle(
        GetAllCategoryPropertiesQuery request,
        CancellationToken cancellationToken)
        {
            var properties = await CategoryService.GetAllCategoryPropertiesAsync(request.CategoryName);

            var vm = properties.Select(p => new CategoryPropertiesViewModel
            {
                PropertyName = p.PropertyName,
                InputType = p.InputType
            });

            return Success(vm);
        }
    }
}
