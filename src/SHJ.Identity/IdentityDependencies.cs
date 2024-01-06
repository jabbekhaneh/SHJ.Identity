using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SHJ.Identity.Entities;
using System.Diagnostics.CodeAnalysis;

namespace SHJ.Identity;

public static class IdentityDependencies
{

    public static IServiceCollection SHJRegiterIdentity<TDbContext>(this IServiceCollection services, Action<IdentityOptions> setupAction)
         where TDbContext : DbContext
    {

        services.AddIdentity<User, Role>(setupAction).AddEntityFrameworkStores<TDbContext>()//MANAGERS
          .AddDefaultTokenProviders();// TOKEN MANAGERS
        return services;
    }
    /// <summary>
    ///  required using  SHJUserAuth for use identity
    /// </summary>
    public static IApplicationBuilder SHJUserAuth([NotNull] this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
        return app;
    }

}
