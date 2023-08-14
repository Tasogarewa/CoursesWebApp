using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Tasogarewa.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
            new ApiScope("Tasogarewa.Api")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
            new Client
            {
                ClientId = "Tasogarewa.Api",
                ClientSecrets = { new Secret("5653337d5854444e44613b65385e4855".Sha256()) },
                RequireConsent = true,
                AllowedGrantTypes = GrantTypes.ClientCredentials,
           
              
                AllowedScopes = { "Tasogarewa.Api" }
            },
                

            new Client
            {
                ClientId = "35682e2c71354c7c5e7168282a334f742b7d7c3e545c564b6e3b636649",
                ClientSecrets = { new Secret("4e4e2f4954536a7a79257945232f5f50".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = { "https://localhost:5002/signin-oidc" },
                PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                  RequirePkce = true,
                   RequireConsent = true,
                  AllowAccessTokensViaBrowser = true,
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "Tasogarewa.Api"
                }
                
            }
            };
    }
}