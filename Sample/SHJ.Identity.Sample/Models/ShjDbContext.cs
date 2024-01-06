using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SHJ.Identity.Entities;

namespace SHJ.Identity.Sample.Models;

public class ShjDbContext : IdentityDbContext<User, Role, Guid>
{
    public ShjDbContext(DbContextOptions options) : base(options)
    {

    }
    
}
