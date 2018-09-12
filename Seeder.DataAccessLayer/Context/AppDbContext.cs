using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Seeder.Core.Entities.Auth;
using Seeder.Core.Entities.Items;

namespace Seeder.DataAccessLayer.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Rename Identity Tables

            builder.Entity<IdentityUser>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(256);
                entity.ToTable(name: "Users");
            });

            builder.Entity<AppUser>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(256);
                entity.ToTable(name: "Users");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(256);
                entity.ToTable(name: "Roles");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRoles");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.Property(e => e.UserId).HasMaxLength(256);
                entity.Property(e => e.LoginProvider).HasMaxLength(256);
                entity.Property(e => e.ProviderKey).HasMaxLength(256);
                entity.ToTable(name: "UserLogins");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.Property(e => e.UserId).HasMaxLength(256);
                entity.ToTable(name: "UserClaims");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.Property(e => e.RoleId).HasMaxLength(256);
                entity.ToTable(name: "RoleClaims");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.Property(e => e.UserId).HasMaxLength(256);
                entity.Property(e => e.LoginProvider).HasMaxLength(256);
                entity.Property(e => e.Name).HasMaxLength(256);
                entity.ToTable(name: "UserTokens");
            });

            #endregion
        }
    }
}
