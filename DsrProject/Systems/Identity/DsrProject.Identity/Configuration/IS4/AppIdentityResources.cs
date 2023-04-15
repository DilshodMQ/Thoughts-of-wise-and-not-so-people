using Duende.IdentityServer.Models;

namespace DsrProject.Identity.Configuration
{
    public static class AppIdentityResources
    {
        public static IEnumerable<IdentityResource> Resources => new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile()
    };
    }
}
