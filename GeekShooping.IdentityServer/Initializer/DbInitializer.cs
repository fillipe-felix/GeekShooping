using GeekShooping.IdentityServer.Configuration;
using GeekShooping.IdentityServer.Model;
using GeekShooping.IdentityServer.Model.Context;

using Microsoft.AspNetCore.Identity;

namespace GeekShooping.IdentityServer.Initializer;

public class DbInitializer : IDbInitializer
{
    private readonly IdentityServerContext _identityServerContext;
    private readonly UserManager<ApplicationUser> _user;
    private readonly RoleManager<ApplicationUser> _role;

    public DbInitializer(IdentityServerContext identityServerContext, 
                         UserManager<ApplicationUser> user, 
                         RoleManager<ApplicationUser> role)
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
    }
}
