using Internship_4_OOP2.Doimain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Internship_4_OOP2.Infrastructure.Common.DbContexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Name)
                      .IsRequired()
                      .HasMaxLength(User.NameMaxLenght);

                entity.Property(u => u.Username)
                      .IsRequired()
                      .HasMaxLength(User.UsernameMaxLenght);

                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(User.EmailMaxLenght);

                entity.Property(u => u.AddressStreet)
                      .IsRequired()
                      .HasMaxLength(User.AddressStreetMaxLenght);

                entity.Property(u => u.AddressCity)
                      .IsRequired()
                      .HasMaxLength(User.AddressCityMaxLenght);

                entity.Property(u => u.GeoLat)
                      .IsRequired();

                entity.Property(u => u.GeoLng)
                      .IsRequired();

                entity.Property(u => u.Website)
                      .HasMaxLength(User.WebsiteMaxLenght);

                entity.Property(u => u.Password)
                      .IsRequired()
                      .HasMaxLength(User.PasswordMaxLenght);

                entity.Property(u => u.IsActive)
                      .HasDefaultValue(true);

                entity.Property(u => u.CreatedAt)
                      .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(u => u.UpdatedAt)
                      .HasDefaultValueSql("GETUTCDATE()");
            });
        }
    }
}
