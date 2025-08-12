using BSEB_API2026.Model;
using Microsoft.EntityFrameworkCore;

namespace BSEB_API2026.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<StudentMaster> StudentMaster { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ Mark StudentMaster as keyless for SP result mapping
            modelBuilder.Entity<StudentMaster>().HasNoKey();
        }
    }
}
