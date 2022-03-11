using Duende.IdentityServer.Models;

namespace GeekShooping.IdentityServer.Configuration;

public class IdentityConfiguration
{
    public const string Admin = "Admin";
    public const string Customer = "Customer";

    public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Email(),
        new IdentityResources.Profile()
    };

    public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
    {
        new ApiScope("geek_shopping", "GeekShopping Server"),
        new ApiScope("read", "Read data."),
        new ApiScope("write", "Write data."),
        new ApiScope("delete", "Delete data."),
        new ApiScope("write", "Write data.")
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
        }
    };
}
