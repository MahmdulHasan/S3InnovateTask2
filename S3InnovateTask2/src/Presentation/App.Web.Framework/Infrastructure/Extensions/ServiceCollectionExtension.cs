using App.Web.Framework.Infrastructure.AppStartup;
using Microsoft.Extensions.DependencyInjection;


namespace App.Web.Framework.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services
                  .AddPersistance(configuration)
                  .AddServices(configuration)
                  .AddModelFactories(configuration);


        }
    }
}
