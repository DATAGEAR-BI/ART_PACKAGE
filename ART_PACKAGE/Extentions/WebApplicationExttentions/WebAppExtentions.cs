using ART_PACKAGE.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Extentions.WebApplicationExttentions
{
    public static class WebAppExtentions
    {
        public static void ApplyModulesMigrations(this WebApplication app)
        {
            _ = app.Configuration.GetSection("Modules").Get<List<string>>();
            using IServiceScope scope = app.Services.CreateScope();
            AuthContext authContext = scope.ServiceProvider.GetRequiredService<AuthContext>();

            List<string>? modules = app.Configuration.GetSection("Modules").Get<List<string>>();

            //if (authContext.Database.GetPendingMigrations().Any())
            //{
            //    authContext.Database.Migrate();
            //}

            //if (modules.Contains("ECM"))
            //{
            //    EcmContext ecmContext = scope.ServiceProvider.GetRequiredService<EcmContext>();

            //    if (ecmContext.Database.GetPendingMigrations().Any())
            //    {
            //        ecmContext.Database.Migrate();
            //    }
            //}

            //if (modules.Contains("SEG"))
            //{
            //    SegmentationContext SegContext = scope.ServiceProvider.GetRequiredService<SegmentationContext>();

            //    if (SegContext.Database.GetPendingMigrations().Any())
            //    {
            //        SegContext.Database.Migrate();
            //    }
            //}
            //if (modules.Contains("GOAML"))
            //{
            //    ArtGoAmlContext GoAmlContext = scope.ServiceProvider.GetRequiredService<ArtGoAmlContext>();

            //    if (GoAmlContext.Database.GetPendingMigrations().Any())
            //    {
            //        GoAmlContext.Database.Migrate();
            //    }
            //}
            //if (modules.Contains("SASAML"))
            //{
            //    SasAmlContext sasAmlContext = scope.ServiceProvider.GetRequiredService<SasAmlContext>();

            //    if (sasAmlContext.Database.GetPendingMigrations().Any())
            //    {
            //        sasAmlContext.Database.Migrate();
            //    }
            //}

            //if (modules.Contains("DGAML"))
            //{
            //    ArtDgAmlContext DgAmlContext = scope.ServiceProvider.GetRequiredService<ArtDgAmlContext>();

            //    if (DgAmlContext.Database.GetPendingMigrations().Any())
            //    {
            //        DgAmlContext.Database.Migrate();
            //    }
            //}
            //if (modules.Contains("DGAUDIT"))
            //{
            //    ArtAuditContext DgAuditContext = scope.ServiceProvider.GetRequiredService<ArtAuditContext>();

            //    if (DgAuditContext.Database.GetPendingMigrations().Any())
            //    {
            //        DgAuditContext.Database.Migrate();
            //    }
            //}
            //if (modules.Contains("AMLANALYSIS"))
            //{
            //    AmlAnalysisContext amlAnalysisContext = scope.ServiceProvider.GetRequiredService<AmlAnalysisContext>();

            //    if (amlAnalysisContext.Database.GetPendingMigrations().Any())
            //    {
            //        amlAnalysisContext.Database.Migrate();
            //    }
            //}
            //if (modules.Contains("FTI"))
            //{
            //    FTIContext fti = scope.ServiceProvider.GetRequiredService<FTIContext>();

            //    if (fti.Database.GetPendingMigrations().Any())
            //    {
            //        fti.Database.Migrate();
            //    }
            //}
            //if (modules.Contains("KYC"))
            //{
            //    KYCContext kyc = scope.ServiceProvider.GetRequiredService<KYCContext>();

            //    if (kyc.Database.GetPendingMigrations().Any())
            //    {
            //        kyc.Database.Migrate();
            //    }
            //}
        }

        public static async void SeedModuleRolesOld(this WebApplication app)
        {

            IEnumerable<Type> types = AppDomain.CurrentDomain
                        .GetAssemblies()
                        .SelectMany(a => a.GetTypes())
                        .Where(a => !string.IsNullOrEmpty(a.Namespace) && a.IsClass && !a.IsNested);
            List<string>? modules = app.Configuration.GetSection("Modules").Get<List<string>>();
            RoleManager<IdentityRole>? rm = app.Services.CreateScope().ServiceProvider.GetService<RoleManager<IdentityRole>>();

            foreach (string module in modules)
            {
                IEnumerable<string> moduleRoles = types.Where(a => a.Namespace.Contains($"ART_PACKAGE.Controllers.{module}")).Select(x => $"ART_{x.Name.Replace("Controller", "")}".ToLower());
                foreach (string role in moduleRoles)
                {
                    if (!await rm.RoleExistsAsync(role))
                    {
                        IdentityRole roleToadd = new(role);
                        _ = await rm.CreateAsync(roleToadd);
                    }

                }
            }

        }

        public static async Task SeedModuleRoles(this WebApplication app)
        {
            var modulesNameSpaces = app.Configuration
                .GetSection("Modules")
                .Get<List<string>>()
                .Select(s => $"ART_PACKAGE.Controllers.{s}")
                .ToList();

            IEnumerable<Type> types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => !string.IsNullOrEmpty(a.Namespace) && a.IsClass && !a.IsNested);

            var currentModuleTypes = types
                .Where(s => modulesNameSpaces.Contains(s.Namespace))
                .Select(x => $"ART_{x.Name.Replace("Controller", "")}".ToLower())
                .Concat(new[] { "art_license", "art_superadmin", "art_customreport", "art_admin" });  // Add your hardcoded values here
            





            using var scope = app.Services.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            var allRoles = roleManager.Roles.Select(r => r.Name).ToList();
            var adminUser = await userManager.Users
                .FirstOrDefaultAsync(u => u.NormalizedEmail.ToLower() == "art_admin@datagearbi.com");
            var adminRoles = await userManager.GetRolesAsync(adminUser);

            if (modulesNameSpaces == null || modulesNameSpaces.Count == 0)
                return;

            var modulesRolesToAdd = currentModuleTypes.Except(allRoles).ToList();

            foreach (var role in modulesRolesToAdd)
            {
                var roleToAdd = new IdentityRole(role);
                await roleManager.CreateAsync(roleToAdd);
            }
            if (adminUser != null&& allRoles.Union(modulesRolesToAdd).Except(adminRoles).Count()>0)
            {
               var res= await userManager.AddToRolesAsync(adminUser, allRoles.Union(modulesRolesToAdd).Except(adminRoles));

            }

        }
    }
}
