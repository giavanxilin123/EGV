using EGV.DataAccessor.Entities;
using EGV.DataAccessor.Entities.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EGV.DataAccessor.Data 
{
    public class ApplicationDbContext: IdentityDbContext<User, IdentityRole<int>, int> {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.Entity<IdentityRole<int>>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
            builder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("UserRoles").HasKey("UserId", "RoleId");
            });

            builder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            
            builder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("UserLogins").HasKey("UserId");
            });

            builder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            
            builder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UserTokens").HasKey("UserId");
            });
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}