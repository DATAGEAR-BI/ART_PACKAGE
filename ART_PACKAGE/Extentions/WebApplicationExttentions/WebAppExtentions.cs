using ART_PACKAGE.Areas.Identity.Data;
using Data.Services;
using Data.Services.Tenat;
using FakeItEasy;
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


            /*if (authContext.Database.GetPendingMigrations().Any())
            {
                //authContext.Database.Migrate();
            }*/
            /*
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
            //}*/
        }

        public static async void SeedModuleRoleso(this WebApplication app)
        {

            IEnumerable<Type> types = AppDomain.CurrentDomain
                        .GetAssemblies()
                        .SelectMany(a => a.GetTypes())
                        .Where(a => !string.IsNullOrEmpty(a.Namespace) && a.IsClass && !a.IsNested);
            List<string>? modulesNameSpaces = app.Configuration.GetSection("Modules").Get<List<string>>().Select(s=> $"ART_PACKAGE.Controllers.{s}").ToList();
            var curentModulesTyes=types.Where(s=>modulesNameSpaces.Contains(s.Namespace)).Select(x => $"ART_{x.Name.Replace("Controller", "")}".ToLower());
            var httpContextAccessor = app.Services.CreateScope().ServiceProvider.GetRequiredService<IHttpContextAccessor>();
            var tenantConstant = app.Services.CreateScope().ServiceProvider.GetRequiredService<TenantConstants>();
           
            ITenantService? _tn = app.Services.CreateScope().ServiceProvider.GetService<ITenantService>();

            List<string> tenants= _tn.GetAllTenantsIDs();
            foreach (var tenantId in tenants)
            {
                _tn.ManiualSetCurrentTenant(tenantId);
                //if (httpContextAccessor.HttpContext != null)
                //{
                //    httpContextAccessor.HttpContext.Request.Headers["tenant"] = tenantId;

                RoleManager<IdentityRole>? rm = app.Services.CreateScope().ServiceProvider.GetService<RoleManager<IdentityRole>>();
                    var tenantRoles = rm.Roles.Select(s=>s.Name);
             
                    UserManager<AppUser>? um = app.Services.CreateScope().ServiceProvider.GetService<UserManager<AppUser>>();
                    var adminUser = um.Users.Where(u => u.NormalizedEmail == "ART_ADMIN@DATAGEARBI.COM").FirstOrDefault();
                    var userRoles=await um.GetRolesAsync(adminUser);

                    if (modulesNameSpaces is null || modulesNameSpaces.Count == 0)
                        return;
                    List<string> modulesRolesShouldAdded = curentModulesTyes.Except(tenantRoles).ToList();

                    foreach (var role in modulesRolesShouldAdded)
                    {
                        IdentityRole roleToadd = new(role);
                        _ = await rm.CreateAsync(roleToadd);
                    }

                   _=await um.AddToRolesAsync(adminUser, tenantRoles.Union(modulesRolesShouldAdded));

          
                //}

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
                .Select(x => $"ART_{x.Name.Replace("Controller", "")}".ToLower());

            using var scope = app.Services.CreateScope();
            var tenantService = scope.ServiceProvider.GetRequiredService<ITenantService>();
            var tenants = tenantService.GetAllTenantsIDs();

            foreach (var tenantId in tenants)
            {
                tenantService.ManiualSetCurrentConnections(tenantId);

                using var tenantScope = app.Services.CreateScope();
                var hh= tenantScope.ServiceProvider.GetRequiredService<ITenantService>();
                hh.ManiualSetCurrentConnections(tenantId);
                var authc = tenantScope.ServiceProvider.GetRequiredService<AuthContext>();
                authc.Database.SetConnectionString(hh.GetConnectionString());
                var s = authc.Users;
                //authc.ChangeConnectionString(tenantId);
                //var connectionstr_ = authc.Database.GetDbConnection();
                var roleManager = tenantScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = tenantScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
              
                var tenantRoles = roleManager.Roles.Select(r => r.Name).ToList();
                var adminUser = await userManager.Users
                    .FirstOrDefaultAsync(u => u.NormalizedEmail == "ART_ADMIN@DATAGEARBI.COM");

                if (adminUser == null || modulesNameSpaces == null || modulesNameSpaces.Count == 0)
                    continue;

                var modulesRolesToAdd = currentModuleTypes.Except(tenantRoles).ToList();

                foreach (var role in modulesRolesToAdd)
                {
                    var roleToAdd = new IdentityRole(role);
                    await roleManager.CreateAsync(roleToAdd);
                }

                await userManager.AddToRolesAsync(adminUser, tenantRoles.Union(modulesRolesToAdd));
            }
        }
    }



}
