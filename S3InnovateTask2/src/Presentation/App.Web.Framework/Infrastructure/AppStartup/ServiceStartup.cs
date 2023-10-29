using App.Services.Buildings;
using App.Services.DataFields;
using App.Services.DateFields;
using App.Services.Object;
using App.Services.Readings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Web.Framework.Infrastructure.AppStartup
{
    internal static class ServiceStartup
    {
        internal static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IObjectService,   ObjectService>();
            services.AddScoped<IDataFieldService, DataFieldService>();
            services.AddScoped<IReadingService, ReadingService>();

            return services;

        }
    }
}
