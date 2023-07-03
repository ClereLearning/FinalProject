using Duende.IdentityServer.EntityFramework.Options;
using ISAT.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ISAT.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("ISAT");
            
            
            builder.Entity<IdentityUser<string>>(
                entity =>
                {
                    entity.ToTable(name: "User");
                }
                );

            builder.Entity<IdentityUserLogin<string>>(
               entity =>
               {
                   entity.ToTable(name: "UserLogin");
               }
               );

            builder.Entity<IdentityUserToken<string>>(
                entity => 
                {
                    entity.ToTable(name: "UserToken");
                }
                );

            builder.Entity<IdentityRole<string>>(
                entity =>
                {
                    entity.ToTable(name: "Role");
                }
                );

            builder.Entity<IdentityUserRole<string>>(
                entity =>
                {
                    entity.ToTable(name: "UserRole");
                }
                );

            builder.Entity<IdentityUserClaim<string>>(
                entity =>
                {
                    entity.ToTable(name: "UserClaim");
                }
                );

            builder.Entity<IdentityRoleClaim<string>>(
               entity =>
               {
                   entity.ToTable(name: "RoleClaim");
               }
               );
            
        }

    }
}