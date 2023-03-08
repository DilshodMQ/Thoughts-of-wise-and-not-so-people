using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DsrProject.Common.Helpers
{
    public static class AutoMappersRegisterHelper
    {
        public static void Register(IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(s => s.FullName != null && s.FullName.ToLower().StartsWith("dsrproject."));

            services.AddAutoMapper(assemblies);
        }
    }
}
