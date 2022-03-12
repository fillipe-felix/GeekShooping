﻿using Duende.IdentityServer.Models;
using Duende.IdentityServer;

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
        },
        new Client
        {
            ClientId = "geek_shopping",
            ClientSecrets =
            {
                new Secret("my_super_secret".Sha256()),
            },
            AllowedGrantTypes = GrantTypes.Code,
            RedirectUris = { "http://localhost:34656/signin-oidc" },
            PostLogoutRedirectUris = { "http://localhost:34656/signout-callback-iodc" },
            AllowedScopes = new List<string>
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.Email,
                "geek_shopping"
            }
        }
    };
};
