using Duende.IdentityServer.EntityFramework.Options;
using ISAT.Server.Models;
using ISAT.Shared.Models;
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


            builder.HasDefaultSchema("dbo");

            builder.Entity<IdentityUser>(b =>
            {
                b.ToTable("User");
            });


            builder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.ToTable("UserLogins");
            });

            builder.Entity<IdentityUserToken<string>>(b =>
            {
                b.ToTable("UserTokens");
            });

            builder.Entity<IdentityRole>(b =>
            {
                b.ToTable("Roles");
            });

            builder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.ToTable("RoleClaims");
            });

            builder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("UserRoles");
            });


            builder.Entity<SexualOrientation>().HasData(
                new SexualOrientation
                {
                    Id = Guid.NewGuid(),
                    Name = "Not asked",
                    Description = "Was not asked"
                },
                new SexualOrientation
                {
                    Id = Guid.NewGuid(),
                    Name = "Not Informed",
                    Description = "Asked but, not informed"
                }
                );

            builder.Entity<Gender>().HasData(
                new Gender
                {
                    Id = Guid.NewGuid(),
                    Name = "Not asked",
                    Description = "Was not asked"
                },
              new Gender
              {
                  Id = Guid.NewGuid(),
                  Name = "Not Informed",
                  Description = "Asked but, not informed"
              }
              );


            builder.Entity<InterviewStatus>().HasData(
           new InterviewStatus
           {
               Id = 1,
               Description = "New",
               Status = "New",
               Inactive = false
           },
           new InterviewStatus
           {
               Id = 2,
               Description = "Waiting Confirmation - Email Sent",
               Status = "Waiting Confirmation",
               Inactive = false
           },
           new InterviewStatus
           {
               Id = 3,
               Description = "Confirmed",
               Status = "Confirmed",
               Inactive = false
           },
             new InterviewStatus
             {
                 Id = 4,
                 Description = "Confirmed by Team",
                 Status = "Confirmed by Team",
                 Inactive = false
             },
           new InterviewStatus
           {
               Id = 5,
               Description = "Canceled",
               Status = "Canceled",
               Inactive = false
           },
            new InterviewStatus
            {
                Id = 6,
                Description = "Canceled by Team",
                Status = "Canceled by Team",
                Inactive = false
            },
            new InterviewStatus
            {
                Id = 7,
                Description = "Interviewed",
                Status = "Interviewed",
                Inactive = false
            },
            new InterviewStatus
            {
                Id = 8,
                Description = "In Review",
                Status = "In Review",
                Inactive = false
            },
            new InterviewStatus
            {
                Id = 9,
                Description = "Finished",
                Status = "Finished",
                Inactive = false
            }
           );

            builder.Entity<UsersType>().HasData(
                new UsersType
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrative",
                    Description = "Administrative Users",
                    Deletable = false
                }
                );

            builder.Entity<UsersType>().HasData(
                new UsersType
                {
                    Id = Guid.NewGuid(),
                    Name = "Interviewer",
                    Description = "Interviewer Users",
                    Deletable = false
                }
                );

            builder.Entity<UsersType>().HasData(
               new UsersType
               {
                   Id = Guid.NewGuid(),
                   Name = "Researcher",
                   Description = "Researcher Users",
                   Deletable = false
               }
               );


            builder.Entity<Interviewer>(b =>            
            {
                b.ToView("Interviewers");
                b.HasNoKey();
            });

        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<SexualOrientation> SexualOrientations { get; set; }
        public DbSet<UsersType> UsersTypes { get; set; }
        public DbSet<Interviewee> Interviewees { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<InterviewStatus> InterviewsStatus { get; set; }
        public DbSet<Interviewer> Interviewers { get; set; }

    }
}