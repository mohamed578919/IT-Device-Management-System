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

namespace ListDevice.Application.Features.DeviceR.Query.Handlers.categoryHandler
{
    internal class GetAllCategoriesHandler : ResponseHandler, IRequestHandler<GetAllCategoriesQuery, Response<IEnumerable<CategoryViewModel>>>
    {
        private readonly ICategoryService CategoryService;

        public GetAllCategoriesHandler(ICategoryService _CategoryService)
        {
            CategoryService = _CategoryService;
        }

        public async Task<Response<IEnumerable<CategoryViewModel>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var Categories = await CategoryService.GetAllCategoriesAsync();

            var vm = Categories.Select(c => new CategoryViewModel
                  {
                        Id = c.Id,
                      CategoryName = c.CategoryName
                   }
                );
            return Success(vm);
        }
    }
}
