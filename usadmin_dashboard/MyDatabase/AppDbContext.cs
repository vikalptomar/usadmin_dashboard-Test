using Microsoft.EntityFrameworkCore;
using usadmin_dashboard.Models;
namespace usadmin_dashboard.MyDatabase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<MastersUsGrants> MastersUsGrants { get; set; }

    }
}
