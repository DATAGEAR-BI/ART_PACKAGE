using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ART_PACKAGE.Areas.Identity.Data.Configrations
{
    public class RolesConfigration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {

            builder.HasData(
                //home role
                new IdentityRole { Id = "e60411ee-1127-4f5e-8f03-367ef13017a6", Name = "art_home", NormalizedName = "art_home".ToUpper() },
                new IdentityRole { Id = "83393df2-1bfa-471d-9a8a-8bf7c4b3f112", Name = "art_customreport", NormalizedName = "art_cutomreport".ToUpper() },
                //role for prefrences and any action requir admin
                new IdentityRole { Id = "ae3a9d7a-5adf-4cd9-85c4-517e59d08513", Name = "art_admin", NormalizedName = "art_admin".ToUpper() },
                new IdentityRole { Id = "f96288d4-8936-4fb1-8427-d5b45dd66023", Name = "art_superadmin", NormalizedName = "art_superadmin".ToUpper() }
                );

        }
    }
}
