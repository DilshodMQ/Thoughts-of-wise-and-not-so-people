using DsrProject.Api.Settings;
using DsrProject.Services.Categories;
using DsrProject.Services.Respondents;
using DsrProject.Services.Settings;
using DsrProject.Services.Thoughts;

namespace DsrProject.Api
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services
                .AddSwaggerSettings(builder)
                .AddApiSpecialSettings(builder)
                .AddMainSettings(builder)
                .AddMailSettings(builder)
                .AddThouhgtService()
                .AddRespondentService()
                .AddCategoryService();
            return services;
        }
        public static IServiceCollection AddMainSettings(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<MainSettings>(builder.Configuration.GetSection("Main"));
            return services;
        }
        public static IServiceCollection AddApiSpecialSettings(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<ApiSpecialSettings>(builder.Configuration.GetSection("ApiSpecial"));
            return services;
        }
        public static IServiceCollection AddSwaggerSettings(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<SwaggerSettings>(builder.Configuration.GetSection("Swagger"));
            return services;
        }

        public static IServiceCollection AddMailSettings(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
            return services;
        }
    }
}
