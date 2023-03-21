using Microsoft.Extensions.DependencyInjection;

namespace DsrProject.Services.Categories
{ 
    public static class Bootstrapper
    {
       public static IServiceCollection AddCategoryService(this IServiceCollection services)
       {
        services.AddSingleton<ICategoryService, CategoryService>();

        return services;
       }
    }

}