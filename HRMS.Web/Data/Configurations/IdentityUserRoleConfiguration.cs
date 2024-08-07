using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMS.Web.Data.Configurations
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = "6b310686-884d-422c-8c10-94f7788ef935",
                        UserId = "13a64665-8ce6-4d08-87a8-9814e266e391"
                    });
        }
    }
}
