using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Web.Data.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
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
        }
    }
}
