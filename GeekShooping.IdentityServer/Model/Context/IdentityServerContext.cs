using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.IdentityServer.Model.Context;

public class IdentityServerContext : IdentityDbContext<ApplicationUser>
{
    public IdentityServerContext(DbContextOptions<IdentityServerContext> options) : base(options)
    {
    }

}
