using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.ExportTasks;
using Data.Data.AmlAnalysis;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.Audit;
using Data.Data.ECM;
using Data.Data.ExportSchedular;
using Data.Data.FTI;
using Data.Data.KYC;
using Data.Data.SASAml;
using Data.Data.Segmentation;
using FakeItEasy;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

            if (modules.Contains("EXPORT_SCHEDULAR"))
            {
                ExportSchedularContext sch = scope.ServiceProvider.GetRequiredService<ExportSchedularContext>();

                if (sch.Database.GetPendingMigrations().Any())
                {
                    sch.Database.Migrate();
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
            if (modules is null)
            {

                return;
            }
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




        public static void StartTasks(this WebApplication app)
        {
            IServiceScope scope = app.Services.CreateScope();
            ExportSchedularContext TasksContext = scope.ServiceProvider.GetRequiredService<ExportSchedularContext>();
            ITaskPerformer taskPerformer = scope.ServiceProvider.GetRequiredService<ITaskPerformer>();
            IQueryable<ExportTask> jobs = TasksContext.ExportsTasks.Where(x => !x.Deleted).Include(x => x.Mails);//.Select(x => new ExportTaskDto
            //{
            //    Name = x.Name,
            //    Day = x.Day,
            //    DayOfWeek = x.DayOfWeek,
            //    Description = x.Description,
            //    Hour = x.Hour,
            //    IsMailed = x.IsMailed,
            //    IsSavedOnServer = x.IsSavedOnServer,
            //    Minute = x.Minute,
            //    Month = x.Month,ي
            //    Period = x.Period,
            //    ReportName = x.ReportName,
            //    Mails = x.Mails.Select(x => x.Mail).ToList(),
            //    Parameters = x.Parameters.Select(x => new Parameter { Name = x.ParameterName, Operator = x.Operator, Value = new List<string> { x.ParameterValue } }).ToList()


            //});
            IRecurringJobManager ruccrunibJ = app.Services.GetRequiredService<IRecurringJobManager>();

            foreach (ExportTask job in jobs)
            {

                //ruccrunibJ.RemoveIfExists(job.Name);
                ruccrunibJ.AddOrUpdate(job.Name, () => taskPerformer.PerformTask(job), taskPerformer.GetPeriod(job));
            }
        }


    }



}
