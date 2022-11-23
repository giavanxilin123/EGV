using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace EGV.IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("SampleAPI"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "admin_web_app",
                ClientName = "Admin Web App",
                // ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                // 
                RequirePkce = true,
                RequireClientSecret = false,
                AllowAccessTokensViaBrowser = true,
                // AllowedGrantTypes =  new[] { 
                //     GrantType.AuthorizationCode, 
                //     GrantType.ResourceOwnerPassword // Add this to allow the client to use ROPC to authorize**
                // },

                AllowOfflineAccess = true, // Add this to receive the refresh token after login

                // where to redirect to after login
                RedirectUris = { "http://localhost:3000/signin-oidc" },
                // where to redirect to after logout
                PostLogoutRedirectUris = { "http://localhost:3000" },
                AllowedCorsOrigins= { "http://localhost:3000" },

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "SampleAPI"
                },
            },

            // interactive client using code flow + pkce
            new Client
            {
                ClientId = "api_swagger",
                ClientName = "Swagger UI for Sample API",
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:7062/swagger/oauth2-redirect.html" },
                // FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                // PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                // AllowOfflineAccess = true,
                AllowedCorsOrigins = {"https://localhost:7062"},
                // AllowedScopes = { "openid", "profile", "SampleAPI" }
                AllowedScopes = new List<string>
                {
                    "SampleAPI"
                }
            },
        };
}
