using App.Core.Entities;
using App.Core.Entities.AppUserAggregate;
using App.Web.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<IdentityAppUser> IdentityAppUsers { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<MovieLike> MovieLikes { get; set; }
}