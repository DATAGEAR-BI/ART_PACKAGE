using ART_PACKAGE.Areas.Identity.Data;
using FakeItEasy;
using Microsoft.AspNetCore.Identity;

namespace ART_PACKAGE.Extentions.WebApplicationExttentions
{
    public static class WebAppExtentions
    {
        public static void ApplyModulesMigrations(this WebApplication app)
        {
            _ = app.Configuration.GetSection("Modules").Get<List<string>>();
            using IServiceScope scope = app.Services.CreateScope();
            AuthContext authContext = scope.ServiceProvider.GetRequiredService<AuthContext>();


            /*if (authContext.Database.GetPendingMigrations().Any())
            {
                //authContext.Database.Migrate();
            }*/

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

        public static async void SeedModuleRoles(this WebApplication app)
        {

            IEnumerable<Type> types = AppDomain.CurrentDomain
                        .GetAssemblies()
                        .SelectMany(a => a.GetTypes())
                        .Where(a => !string.IsNullOrEmpty(a.Namespace) && a.IsClass && !a.IsNested);
            List<string>? modules = app.Configuration.GetSection("Modules").Get<List<string>>();
            RoleManager<IdentityRole>? rm = app.Services.CreateScope().ServiceProvider.GetService<RoleManager<IdentityRole>>();
            UserManager<AppUser>? um = app.Services.CreateScope().ServiceProvider.GetService<UserManager<AppUser>>();
            var adminUser=um.Users.Where(u => u.NormalizedEmail == "ART_ADMIN@DATAGEARBI.COM").FirstOrDefault();
            if (modules is null || modules.Count == 0)
                return;

            List<string> rolesAdminDoesnotHave = new List<string>();  
            foreach (string module in modules)
            {
                IEnumerable<string> moduleRoles = types.Where(a => a.Namespace.Contains($"ART_PACKAGE.Controllers.{module}")).Select(x => $"ART_{x.Name.Replace("Controller", "")}".ToLower());
                foreach (string role in moduleRoles)
                {
                    //Console.WriteLine(module + "---" + role);

                    if (!await rm.RoleExistsAsync(role))
                    {
                        IdentityRole roleToadd = new(role);
                        _ = await rm.CreateAsync(roleToadd);
                    }
                    if (!await um.IsInRoleAsync(adminUser, role))
                    {
                        rolesAdminDoesnotHave.Add(role);
                    }

                }
            }
            await um.AddToRolesAsync(adminUser, rolesAdminDoesnotHave);

        }


    }



}
