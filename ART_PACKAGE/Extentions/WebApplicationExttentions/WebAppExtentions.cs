using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.DgUserManagement;
using Data.Data.AmlAnalysis;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.Audit;
using Data.Data.ECM;
using Data.Data.FTI;
using Data.Data.KYC;
using Data.Data.SASAml;
using Data.Data.Segmentation;
using FakeItEasy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace ART_PACKAGE.Extentions.WebApplicationExttentions
{
    public static class WebAppExtentions
    {
        public static void ApplyModulesMigrations(this WebApplication app)
        {
            List<string>? modules = app.Configuration.GetSection("Modules").Get<List<string>>();
            using IServiceScope scope = app.Services.CreateScope();
            AuthContext authContext = scope.ServiceProvider.GetRequiredService<AuthContext>();


            if (authContext.Database.GetPendingMigrations().Any())
            {
                authContext.Database.Migrate();
            }

            if (modules.Contains("ECM"))
            {
                EcmContext ecmContext = scope.ServiceProvider.GetRequiredService<EcmContext>();

                if (ecmContext.Database.GetPendingMigrations().Any())
                {
                    ecmContext.Database.Migrate();
                }
            }

            if (modules.Contains("SEG"))
            {
                SegmentationContext SegContext = scope.ServiceProvider.GetRequiredService<SegmentationContext>();

                if (SegContext.Database.GetPendingMigrations().Any())
                {
                    SegContext.Database.Migrate();
                }
            }
            if (modules.Contains("GOAML"))
            {
                ArtGoAmlContext GoAmlContext = scope.ServiceProvider.GetRequiredService<ArtGoAmlContext>();

                if (GoAmlContext.Database.GetPendingMigrations().Any())
                {
                    GoAmlContext.Database.Migrate();
                }
            }
            if (modules.Contains("SASAML"))
            {
                SasAmlContext sasAmlContext = scope.ServiceProvider.GetRequiredService<SasAmlContext>();

                if (sasAmlContext.Database.GetPendingMigrations().Any())
                {
                    sasAmlContext.Database.Migrate();
                }
            }

            if (modules.Contains("DGAML"))
            {
                ArtDgAmlContext DgAmlContext = scope.ServiceProvider.GetRequiredService<ArtDgAmlContext>();

                if (DgAmlContext.Database.GetPendingMigrations().Any())
                {
                    DgAmlContext.Database.Migrate();
                }
            }
            if (modules.Contains("DGAUDIT"))
            {
                ArtAuditContext DgAuditContext = scope.ServiceProvider.GetRequiredService<ArtAuditContext>();

                if (DgAuditContext.Database.GetPendingMigrations().Any())
                {
                    DgAuditContext.Database.Migrate();
                }
            }
            if (modules.Contains("AMLANALYSIS"))
            {
                AmlAnalysisContext amlAnalysisContext = scope.ServiceProvider.GetRequiredService<AmlAnalysisContext>();

                if (amlAnalysisContext.Database.GetPendingMigrations().Any())
                {
                    amlAnalysisContext.Database.Migrate();
                }
            }
            if (modules.Contains("FTI"))
            {
                FTIContext fti = scope.ServiceProvider.GetRequiredService<FTIContext>();

                if (fti.Database.GetPendingMigrations().Any())
                {
                    fti.Database.Migrate();
                }
            }
            if (modules.Contains("KYC"))
            {
                KYCContext kyc = scope.ServiceProvider.GetRequiredService<KYCContext>();

                if (kyc.Database.GetPendingMigrations().Any())
                {
                    kyc.Database.Migrate();
                }
            }
        }

        public static async void SeedModuleRoles(this WebApplication app)
        {
            IEnumerable<Type> types = AppDomain.CurrentDomain
                        .GetAssemblies()
                        .SelectMany(a => a.GetTypes())
                        .Where(a => !string.IsNullOrEmpty(a.Namespace) && a.IsClass && !a.IsNested);
            List<string>? modules = app.Configuration.GetSection("Modules").Get<List<string>>();
            RoleManager<IdentityRole>? rm = app.Services.CreateScope().ServiceProvider.GetService<RoleManager<IdentityRole>>();
            HttpClient? httpClient = app.Services.CreateScope().ServiceProvider.GetService<HttpClient>();
            var model = new
            {
                name = "um_admin@dgpw",
                password = "um_admin1"
            };



            // Serialize the model to JSON
            string jsonModel = JsonConvert.SerializeObject(model);

            // Create StringContent from JSON
            StringContent content = new(jsonModel, Encoding.UTF8, "application/json");
            HttpResponseMessage authRes = await httpClient.PostAsync("http://192.168.1.20:9999/dg-userManagement-console/security/authenticate", content);
            string token = string.Empty;
            if (authRes.IsSuccessStatusCode)
            {
                string responseBody = await authRes.Content.ReadAsStringAsync();
                AuthRes? userManagementResponse = JsonConvert.DeserializeObject<AuthRes>(responseBody);
                token = userManagementResponse.Token;
            }
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage res = await httpClient.GetAsync("http://192.168.1.20:9999/dg-userManagement-console/Group/findGroups");
            string resString = await res.Content.ReadAsStringAsync();
            IEnumerable<GroupsRes>? groupsRes = JsonConvert.DeserializeObject<List<GroupsRes>>(resString).Where(x => x.Name.ToLower().StartsWith("art_"));

            res = await httpClient.GetAsync("http://192.168.1.20:9999/dg-userManagement-console/Role/UsersGroupsOfRole");
            resString = await res.Content.ReadAsStringAsync();
            IEnumerable<RoleRes>? rolesRes = JsonConvert.DeserializeObject<List<RoleRes>>(resString).Where(x => x.Name.ToLower().StartsWith("art_"));

            List<string> ExistingRoles = rm.Roles.Select(x => x.Name).ToList();
            foreach (string module in modules)
            {
                IEnumerable<string> moduleRoles = types.Where(a => a.Namespace.Contains($"ART_PACKAGE.Controllers.{module}")).Select(x => $"ART_{x.Name.Replace("Controller", "")}".ToLower());
                foreach (string role in moduleRoles)
                {
                    RoleRes? umRole = rolesRes.FirstOrDefault(x => x.Name.ToLower() == role.ToLower());
                    if (umRole == null)
                    {
                        if (!await rm.RoleExistsAsync(role))
                        {
                            IdentityRole roleToadd = new(role);
                            _ = await rm.CreateAsync(roleToadd);
                        }
                        continue;
                    }

                    res = await httpClient.GetAsync("http://192.168.1.20:9999/dg-userManagement-console/Role/UserGroups/" + umRole.Id);
                    resString = await res.Content.ReadAsStringAsync();
                    IEnumerable<string> roleGroups = groupsRes.Where(x => JsonConvert.DeserializeObject<RoleGroupsRes>(resString).Groups.Contains(x.Id)).Select(x => x.Name.ToUpper());

                    if (await rm.RoleExistsAsync(role))
                    {
                        IdentityRole roundRole = await rm.FindByNameAsync(role);
                        _ = await rm.DeleteAsync(roundRole);
                    }

                    IdentityRole roleToAdd = new(role);
                    _ = await rm.CreateAsync(roleToAdd);
                    foreach (string? group in roleGroups)
                    {
                        _ = await rm.AddClaimAsync(roleToAdd, new Claim("GROUP", group));
                    }
                }
            }

        }


    }



}
