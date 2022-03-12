using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace GeekShooping.IdentityServer.Configuration;

public class IdentityConfiguration
{
    public const string Admin = "Admin";
    public const string Client = "Client";

    public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Email(),
        new IdentityResources.Profile()
    };

    public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
    {
        new ApiScope("geek_shooping", "GeekShopping Server"),
        new ApiScope("read", "Read data."),
        new ApiScope("write", "Write data."),
        new ApiScope("delete", "Delete data.")
    };

    public static IEnumerable<Client> Clients => new List<Client>
    {
        new Client
        {
            ClientId = "client",
            ClientSecrets =
            {
                new Secret("my_super_secret".Sha256()),
            },
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            AllowedScopes = { "read", "write", "profile" }
        },
        new Client
        {
            ClientId = "geek_shooping",
            ClientSecrets =
            {
                new Secret("my_super_secret".Sha256()),
            },
            AllowedGrantTypes = GrantTypes.Code,
            RedirectUris = { "http://localhost:5035/signin-oidc" },
            PostLogoutRedirectUris = { "http://localhost:5035/signout-callback-oidc" },
            AllowedScopes = new List<string>
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.Email,
                "geek_shooping"
            }
        }
    };
};
