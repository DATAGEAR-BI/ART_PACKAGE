using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ART_PACKAGE.Areas.Identity.Data;
public class UserConfigration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        var hasher = new PasswordHasher<AppUser>();



        builder.HasData(
            new AppUser
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                UserName = "Art_Admin@datagearbi.com",
                NormalizedUserName = "Art_Admin@datagearbi.com".ToUpper(),
                Email = "Art_Admin@datagearbi.com",
                NormalizedEmail = "Art_Admin@datagearbi.com".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                EmailConfirmed = true,
                Active = true,


            }
        );
    }
}

