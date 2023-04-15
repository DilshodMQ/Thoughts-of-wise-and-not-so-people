using DsrProject.Common.Security;
using Duende.IdentityServer.Models;

namespace DsrProject.Identity.Configuration
{
    public static class AppApiScopes
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
            new ApiScope(AppScopes.ThoughtsRead, "Access to thoughts API - Read data"),
            new ApiScope(AppScopes.ThoughtsWrite, "Access to thoughts API - Write data")
            };
    }
}