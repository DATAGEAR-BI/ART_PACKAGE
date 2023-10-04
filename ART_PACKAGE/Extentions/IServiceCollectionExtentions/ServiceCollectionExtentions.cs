using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.BackGroundServices;
using ART_PACKAGE.Helpers.Aml_Analysis;
using ART_PACKAGE.Helpers.DBService;
using ART_PACKAGE.Helpers.License;
using ART_PACKAGE.Security;
using Data.Audit;
using Data.Constants;
using Data.Constants.db;
using Data.Data.AmlAnalysis;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.Audit;
using Data.Data.ECM;
using Data.Data.FTI;
using Data.Data.KYC;
using Data.Data.SASAml;
using Data.Data.Segmentation;
using Data.DGAML;
using Data.DGECM;
using Data.FCFCORE;
using Data.FCFKC.AmlAnalysis;
using Data.FCFKC.SASAML;
using Data.GOAML;
using Data.TIZONE2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Extentions.IServiceCollectionExtentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDbs(this IServiceCollection services, ConfigurationManager config)
        {
            string connectionString = config.GetConnectionString("AuthContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthContextConnection' not found.");
            List<string>? modulesToApply = config.GetSection("Modules").Get<List<string>>();
            string dbType = config.GetValue<string>("dbType").ToUpper();
            string migrationPath = dbType == DbTypes.SqlServer ? "SqlServerMigrations" : "OracleMigrations";

            void contextBuilder(DbContextOptionsBuilder options, string conn)
            {
                _ = dbType switch
                {
                    DbTypes.SqlServer => options.UseSqlServer(
                        conn,
                        x => x.MigrationsAssembly("SqlServerMigrations")
                        ),
                    DbTypes.Oracle => options.UseOracle(
                        conn,
                        x => x.MigrationsAssembly("OracleMigrations")
                        ),
                    _ => throw new Exception($"Unsupported provider: {dbType}")
                };
            }

            _ = services.AddDbContext<AuthContext>(opt => contextBuilder(opt, connectionString));
            if (modulesToApply.Contains("SEG"))
            {
                _ = services.AddDbContext<SegmentationContext>(opt => contextBuilder(opt, connectionString));
            }

            if (modulesToApply.Contains("GOAML"))
            {
                string GOAMLContextConnection = config.GetConnectionString("GOAMLContextConnection") ?? throw new InvalidOperationException("Connection string 'GOAMLContextConnection' not found.");
                _ = services.AddDbContext<GoAmlContext>(opt => contextBuilder(opt, GOAMLContextConnection));
                _ = services.AddDbContext<ArtGoAmlContext>(opt => contextBuilder(opt, connectionString));
            }

            if (modulesToApply.Contains("FTI"))
            {
                string DGECMContextConnection = config.GetConnectionString("DGECMContextConnection") ?? throw new InvalidOperationException("Connection string 'DGECMContextConnection' not found.");
                string TIZONEContextConnection = config.GetConnectionString("TIZONEContextConnection") ?? throw new InvalidOperationException("Connection string 'GOAMLContextConnection' not found.");
                _ = services.AddDbContext<TIZONE2Context>(opt => contextBuilder(opt, TIZONEContextConnection));
                _ = services.AddDbContext<FTIContext>(opt => contextBuilder(opt, connectionString));
                _ = services.AddDbContext<DGECMContext>(opt => contextBuilder(opt, DGECMContextConnection));

            }

            if (modulesToApply.Contains("DGAML"))
            {
                string DGAMLContextConnection = config.GetConnectionString("DGAMLContextConnection") ?? throw new InvalidOperationException("Connection string 'DGAMLContextConnection' not found.");
                _ = services.AddDbContext<DGAMLContext>(opt => contextBuilder(opt, DGAMLContextConnection));
                _ = services.AddDbContext<ArtDgAmlContext>(opt => contextBuilder(opt, connectionString));
            }

            if (modulesToApply.Contains("ECM"))
            {
                string DGECMContextConnection = config.GetConnectionString("DGECMContextConnection") ?? throw new InvalidOperationException("Connection string 'DGECMContextConnection' not found.");
                _ = services.AddDbContext<DGECMContext>(opt => contextBuilder(opt, DGECMContextConnection));
                _ = services.AddDbContext<EcmContext>(opt => contextBuilder(opt, connectionString));
            }

            if (modulesToApply.Contains("SASAML"))
            {
                string FCFCOREContextConnection = config.GetConnectionString("FCFCOREContextConnection") ?? throw new InvalidOperationException("Connection string 'FCFCOREContextConnection' not found.");
                string FCFKCContextConnection = config.GetConnectionString("FCFKCContextConnection") ?? throw new InvalidOperationException("Connection string 'FCFKCContextConnection' not found.");
                _ = services.AddDbContext<fcf71Context>(opt => contextBuilder(opt, FCFCOREContextConnection));
                _ = services.AddDbContext<FCFKC>(opt => contextBuilder(opt, FCFKCContextConnection));
                _ = services.AddDbContext<SasAmlContext>(opt => contextBuilder(opt, connectionString));
            }
            if (modulesToApply.Contains("DGAUDIT"))
            {

                string DGUSERMANAGMENTContextConnection = config.GetConnectionString("DGUSERMANAGMENTContextConnection") ?? throw new InvalidOperationException("Connection string 'DGUSERMANAGMENTContextConnection' not found.");
                _ = services.AddDbContext<AuditContext>(opt => contextBuilder(opt, DGUSERMANAGMENTContextConnection));
                _ = services.AddDbContext<ArtAuditContext>(opt => contextBuilder(opt, connectionString));
            }

            if (modulesToApply.Contains("AMLANALYSIS"))
            {
                string FCFCOREContextConnection = config.GetConnectionString("FCFCOREContextConnection") ?? throw new InvalidOperationException("Connection string 'FCFCOREContextConnection' not found.");
                string FCFKCContextConnection = config.GetConnectionString("FCFKCContextConnection") ?? throw new InvalidOperationException("Connection string 'FCFKCContextConnection' not found.");
                _ = services.AddDbContext<fcf71Context>(opt => contextBuilder(opt, FCFCOREContextConnection));
                _ = services.AddDbContext<FCFKCAmlAnalysisContext>(opt => contextBuilder(opt, FCFKCContextConnection));
                _ = services.AddDbContext<AmlAnalysisContext>(opt => contextBuilder(opt, connectionString));
                _ = services.AddAmlAnalysis();
            }

            if (modulesToApply.Contains("KYC"))
            {
                _ = services.AddDbContext<KYCContext>(opt => contextBuilder(opt, connectionString));
            }
            _ = services.AddScoped<IDbService, DBService>();
            return services;
        }

        public static IServiceCollection AddLicense(this IServiceCollection services, ConfigurationManager config)
        {
            List<string>? LicenseModules = config.GetSection("Modules").Get<List<string>>();
            _ = services.AddTransient<ILicenseReader, LicenseReader>();
            _ = services.AddAuthorization(opt =>
            {
                opt.AddPolicy(LicenseConstants.LICENSE_POLICY, p =>
                {
                    LicenseRequirment req = new();
                    if (LicenseModules is not null && LicenseModules.Count != 0)
                    {
                        req.Modules = LicenseModules;
                    }

                    _ = p.AddRequirements(req);

                }
                );
            });
            _ = services.AddScoped<IAuthorizationHandler, LicenseHandler>();
            return services;
        }


        public static IServiceCollection AddAmlAnalysis(this IServiceCollection services)
        {
            _ = services.AddScoped<IAmlAnalysis, AmlAnalysis>();
            _ = services.AddSingleton<AmlAnalysisUpdateTableIndecator>();
            _ = services.AddHostedService<AmlAnalysisWatcher>();
            _ = services.AddHostedService<AmlAnalysisTableCreateService>();

            return services;
        }

    }
}
