using GGinfoSite.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;

namespace GGinfoSite.Data
{
    public class ApplicationDbContext : DbContext
    {
        // constructor just calls the base class constructor
        public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // one DbSet for each domain model class
        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
