using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ART_PACKAGE.Areas.Identity.Data.Configrations
{
    public class UserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(

              new IdentityUserRole<string> { UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9", RoleId = "ae3a9d7a-5adf-4cd9-85c4-517e59d08513" },
              new IdentityUserRole<string> { UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9", RoleId = "83393df2-1bfa-471d-9a8a-8bf7c4b3f112" },
              new IdentityUserRole<string> { UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9", RoleId = "e60411ee-1127-4f5e-8f03-367ef13017a6" }
              );
        }
    }
}
