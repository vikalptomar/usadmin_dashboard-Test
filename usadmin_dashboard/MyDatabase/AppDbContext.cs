using Microsoft.EntityFrameworkCore;
using usadmin_dashboard.Models;
namespace usadmin_dashboard.MyDatabase
{
    public class AppDbContext : DbContext
    {
        internal object masters_audit_trial;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<masters_us_grants> masters_us_grants { get; set; }
        public DbSet<AuditLogs> masters_audit_trail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<masters_us_grants>(entity =>
            {
                entity.HasKey(e => e.GrantIndex).HasName("PRIMARY");
                entity.ToTable("masters_us_grants");
          
                //entity.Property(e => e.GrantIndex).HasColumnName("GrantIndex");
                //entity.Property(e => e.GrantTitle).HasColumnName("GrantTitle");
                //entity.Property(e => e.LinkURL).HasColumnName("LinkURL");
                //entity.Property(e => e.PostDate).HasColumnName("PostDate");
                //entity.Property(e => e.PDValue).HasColumnName("PDValue");
                //entity.Property(e => e.DeadLineDate).HasColumnName("DeadLineDate");
                //entity.Property(e => e.DDValue).HasColumnName("DDValue");
                //entity.Property(e => e.ShortIntro).HasColumnName("ShortIntro");
                //entity.Property(e => e.DonorType).HasColumnName("DonorType");
                //entity.Property(e => e.DonorIndex).HasColumnName("DonorIndex");
                //entity.Property(e => e.DonorAgency).HasColumnName("DonorAgency");
                //entity.Property(e => e.GrantType).HasColumnName("GrantType");
                //entity.Property(e => e.GrantSize).HasColumnName("GrantSize");
                //entity.Property(e => e.GrantLogoImage).HasColumnName("GrantLogoImage");
                //entity.Property(e => e.OnGoingGrants).HasColumnName("OnGoingGrants");
                //entity.Property(e => e.Status).HasColumnName("Status");
                //entity.Property(e => e.GrantContent).HasColumnName("GrantContent");
                //entity.Property(e => e.GrantDuration).HasColumnName("GrantDuration");
                //entity.Property(e => e.STCTType).HasColumnName("STCTType");
                //entity.Property(e => e.STATESTRING).HasColumnName("STATESTRING");
                //entity.Property(e => e.COUNTYSTRING).HasColumnName("COUNTYSTRING");
                //entity.Property(e => e.ISSUESTRING).HasColumnName("ISSUESTRING");

                //entity.Property(e => e.WpIndex).HasColumnName("WpIndex");
                //entity.Property(e => e.ViewCount).HasColumnName("ViewCount");
                //entity.Property(e => e.ENTITYSTRING).HasColumnName("ENTITYSTRING");
            });
            modelBuilder.Entity<AuditLogs>(entity =>
            {
                entity.HasKey(e => e.TrailLogIndex).HasName("PRIMARY");
                entity.ToTable("master_audit_trail");
            });

            // base.OnModelCreating(modelBuilder);

        }

    }
}
