using Internship_4_OOP2.Doimain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Internship_4_OOP2.Infrastructure.Common.DbContexts
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name)
                      .IsRequired()
                      .HasMaxLength(Company.NameMaxLenght);

                entity.HasIndex(c => c.Name)
                      .IsUnique();
            });
        }
    }
}
