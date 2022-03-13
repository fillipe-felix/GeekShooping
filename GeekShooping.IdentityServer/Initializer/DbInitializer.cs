using System.Security.Claims;

using GeekShooping.IdentityServer.Configuration;
using GeekShooping.IdentityServer.Model;
using GeekShooping.IdentityServer.Model.Context;

using IdentityModel;

using Microsoft.AspNetCore.Identity;

namespace GeekShooping.IdentityServer.Initializer;

public class DbInitializer : IDbInitializer
{
    private readonly IdentityServerContext _identityServerContext;
    private readonly UserManager<ApplicationUser> _user;
    private readonly RoleManager<IdentityRole> _role;

    public DbInitializer(IdentityServerContext identityServerContext, 
                         UserManager<ApplicationUser> user, 
                         RoleManager<IdentityRole> role)
    {
        _identityServerContext = identityServerContext;
        _user = user;
        _role = role;
    }

    public void Initialize()
    {
        if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null)
        {
            return;
        }

        _role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();
        _role.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

        ApplicationUser admin = new ApplicationUser
        {
            UserName = "Fillipe-Admin",
            Email = "fillipe-admin@teste.com",
            EmailConfirmed = true,
            PhoneNumber = "15998289356",
            FirstName = "Fillipe",
            LastName = "Félix"
        };

        _user.CreateAsync(admin, "Teste@123").GetAwaiter().GetResult();
        _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();
        var adminClaims = _user.AddClaimsAsync(admin, new List<Claim>
        {
            new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
            new Claim(JwtClaimTypes.GivenName, admin.FirstName),
            new Claim(JwtClaimTypes.FamilyName, admin.LastName),
            new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
        }).Result;
        
        ApplicationUser client = new ApplicationUser
        {
            UserName = "Fillipe-Client",
            Email = "fillipe-client@teste.com",
            EmailConfirmed = true,
            PhoneNumber = "15998289356",
            FirstName = "Fillipe",
            LastName = "Félix"
        };

        _user.CreateAsync(client, "Teste@123").GetAwaiter().GetResult();
        _user.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();
        var clientClaims = _user.AddClaimsAsync(client, new List<Claim>
        {
            new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
            new Claim(JwtClaimTypes.GivenName, client.FirstName),
            new Claim(JwtClaimTypes.FamilyName, client.LastName),
            new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
        }).Result;
    }
}
