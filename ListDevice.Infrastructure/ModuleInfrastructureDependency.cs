
using ListDevice.Application.Abstractions;
using ListDevice.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDevice.Infrastructure
{
    public static class ModuleInfrastructureDependency
    {
        public static IServiceCollection AddInfrastructureDependency(this IServiceCollection service )
        {
            service.AddTransient<IDeviceRepository, DeviceRepository>();
            service.AddTransient<ICategoryRepository, CategoryRepository>();
            service.AddTransient<IUserRepository, UserRepository>();

            //service.AddTransient<IPropertyRepository, PropertyRepository>();


            return service;
        }
    }
}
