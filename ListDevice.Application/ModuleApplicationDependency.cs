using ListDevice.Application.Abstractions;
using ListDevice.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Application
{
    public static class ModuleApplicationDependency
    {
        public static IServiceCollection AddApplicationDependency(this IServiceCollection service)
        {
            service.AddTransient<IDeviceService, DeviceService>();
            service.AddTransient<ICategoryService, CategoryService>();
            service.AddTransient<IUserService, UserService>();


            return service;
        }

        public static IServiceCollection AddMediatRDependency(this IServiceCollection service)
        {
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return service;
        }
    }
}
