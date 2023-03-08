using DsrProject.Context;
using DsrProject.Context.Settings;
using DsrProject.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DSRNetSchool.Context
{
    public static class Bootstrapper
    {
        /// <summary>
        /// Register db context
        /// </summary>
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration = null)
        {
            var settings = Settings.Load<DbSettings>("Database", configuration);
            services.AddSingleton(settings);

            var dbInitOptionsDelegate = DbContextOptionsFactory.Configure(
                settings.ConnectionString,
                settings.Type);

            services.AddDbContextFactory<MainDbContext>(dbInitOptionsDelegate);

            return services;
        }
    }
}