using ListDevice.Application.ErrorsHandler;
using ListDevice.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Application.Features.DeviceR.Query.Models.CategoryQuery
{
    public class GetAllCategoriesQuery : IRequest<Response<IEnumerable<CategoryViewModel>>>
    {
    }
}
