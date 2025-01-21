using GGinfoSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GGinfoSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<BlogPost> BlogPost { get; set; }
    }
}
