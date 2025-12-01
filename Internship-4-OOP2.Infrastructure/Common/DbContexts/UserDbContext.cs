using Internship_4_OOP2.Doimain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Internship_4_OOP2.Infrastructure.Common.DbContexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");

            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnName("email");
            modelBuilder.Entity<User>().Property(u => u.AddressStreet).HasColumnName("address_street");
            modelBuilder.Entity<User>().Property(u => u.AddressCity).HasColumnName("address_city");

            modelBuilder.Entity<User>().Property(u => u.GeoLat)
                .HasColumnName("geo_lat")
                .HasColumnType("numeric");
            modelBuilder.Entity<User>().Property(u => u.GeoLng)
                .HasColumnName("geo_lng")
                .HasColumnType("numeric");

            modelBuilder.Entity<User>().Property(u => u.Website).HasColumnName("website");
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnName("password");
            modelBuilder.Entity<User>().Property(u => u.CreatedAt).HasColumnName("created_at");
            modelBuilder.Entity<User>().Property(u => u.UpdatedAt).HasColumnName("updated_at");
            modelBuilder.Entity<User>().Property(u => u.IsActive).HasColumnName("is_active");
        }
    }
}
