using App.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using App.Data.Repository;

namespace App.Web.Framework.Infrastructure.AppStartup
{
    internal static class PersistanceStartup
    {
        internal static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<DatabaseSettings>()
               .BindConfiguration(nameof(DatabaseSettings));

            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>((serviceProvider, options) =>
            {
                var dbSettings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;

                options.UseSqlServer(dbSettings.ApplicationConnectionString)
                       .UseLazyLoadingProxies(dbSettings.UseLazyLoading);
            });

            return services.AddRepositories();
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services
                .AddScoped(typeof(IRepository<>), typeof(ApplicationDbRepository<>))
                .AddScoped<IQueryRepository, ApplicationQueryRepository>();
    }
}
