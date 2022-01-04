using FullSite.Models;
using Microsoft.EntityFrameworkCore;

namespace FullSite.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Main> Mains { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
    }
}
