using App.Web.Framework.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace App.Web.Framework.Infrastructure.AppStartup
{
    internal static class ModelFactoryStartup
    {
        internal static IServiceCollection AddModelFactories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBuildingModelFactory, BuildingModelFactory>();
            services.AddScoped<IObjectModelFactory, ObjectModelFactory>();
            services.AddScoped<IDataFieldModelFactory, DataFieldModelFactory>();
            services.AddScoped<IReadingModelFactory, ReadingModelFactory>();
           
            return services;

        }
    }
}
