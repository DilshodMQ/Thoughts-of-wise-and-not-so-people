using DsrProject.Api.Settings;
using DsrProject.Services.Categories;
using DsrProject.Services.Respondents;
using DsrProject.Services.Settings;
using DsrProject.Services.Thoughts;
using DsrProject.Services.UserAccount;
using DsrProject.Services.Cache;
using DsrProject.Services.RabbitMq;
using DsrProject.Services.Actions;

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
                .AddIdentitySettings(builder)
                .AddMailSettings(builder)
                .AddCache()
                .AddActions()
                .AddRabbitMq()
                .AddThouhgtService()
                .AddRespondentService()
                .AddUserAccountService()
                .AddCategoryService();
            return services;
        }
        public static IServiceCollection AddMainSettings(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<MainSettings>(builder.Configuration.GetSection("Main"));
            return services;
        }

        public static IServiceCollection AddIdentitySettings(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<IdentitySettings>(builder.Configuration.GetSection("Identity"));
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
