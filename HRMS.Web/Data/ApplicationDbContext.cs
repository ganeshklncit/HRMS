using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace HRMS.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole {
                Id = "aa5b3338-5e96-4800-b3fd-f563c93f0e4c",
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "33041056-5919-4342-a364-62b942511fed",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR"
                },
                new IdentityRole
                {
                    Id = "6b310686-884d-422c-8c10-94f7788ef935",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
                );

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "13a64665-8ce6-4d08-87a8-9814e266e391",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                    FirstName = "Default",
                    LastName = "Admin",
                    DateOfBirth = new DateOnly(1985,07,18)
                }
                );


            builder.Entity<IdentityUserRole<string>>().HasData
                (new IdentityUserRole<string>
                {
                    RoleId = "6b310686-884d-422c-8c10-94f7788ef935",
                    UserId = "13a64665-8ce6-4d08-87a8-9814e266e391"
                }
                );

        }

        public DbSet<LeaveType> LeaveTypes { get; set; }

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        public DbSet<Period> Periods { get; set; }

    }
}
