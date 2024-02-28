using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.BackGroundServices;
using ART_PACKAGE.Helpers.Aml_Analysis;
using ART_PACKAGE.Helpers.DBService;
using ART_PACKAGE.Helpers.License;
using ART_PACKAGE.Middlewares.License;
using ART_PACKAGE.Middlewares.Security;
using Data.Audit.DGMGMT;
using Data.Audit.DGMGMT_AUD;
using Data.Constants;
using Data.Constants.db;
using Data.Data.AmlAnalysis;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.Audit;
using Data.Data.CRP;
using Data.Data.ECM;
using Data.Data.FTI;
using Data.Data.KYC;
using Data.Data.SASAml;
using Data.Data.Segmentation;
using Data.DATA.FATCA;
using Data.DGAML;
using Data.DGECM;
using Data.DGFATCA;
using Data.FCFCORE;
using Data.FCFKC.AmlAnalysis;
using Data.FCFKC.SASAML;
using Data.GOAML;
using Data.TIZONE2;
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

            void contextBuilder(DbContextOptionsBuilder options, string conn, int commandTimeOut = 120)
            {
                _ = dbType switch
                {
                    DbTypes.SqlServer => options.UseSqlServer(
                        conn,
                        x => { _ = x.MigrationsAssembly("SqlServerMigrations"); _ = x.CommandTimeout(commandTimeOut); }
                        ),
                    DbTypes.Oracle => options.UseOracle(
                        conn,
                        x => { _ = x.MigrationsAssembly("OracleMigrations"); _ = x.CommandTimeout(commandTimeOut); }
                        ),
                    DbTypes.MySql => options.UseMySql(
                        conn,
                        new MySqlServerVersion(new Version( 8,0,36)),//ServerVersion.AutoDetect(config.GetValue<string>("MySqlVersion")),//new MySqlServerVersion(new Version( config.GetValue<string>("dbType"))),
                        x => { _ = x.MigrationsAssembly("MySqlMigrations"); _ = x.CommandTimeout(commandTimeOut); }
                        ),
                    _ => throw new Exception($"Unsupported provider: {dbType}")
                };
            }

            _ = services.AddDbContext<AuthContext>(opt => contextBuilder(opt, connectionString));
            if (modulesToApply is null)
            {
                _ = services.AddScoped<IDbService, DBService>();
                return services;
            }
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
                string TIZONEContextConnection = config.GetConnectionString("TIZONEContextConnection") ?? throw new InvalidOperationException("Connection string 'GOAMLContextConnection' not found.");
                _ = services.AddDbContext<TIZONE2Context>(opt => contextBuilder(opt, TIZONEContextConnection));
                _ = services.AddDbContext<FTIContext>(opt => contextBuilder(opt, connectionString));
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
            if (modulesToApply.Contains("FATCA"))
            {
                string DGFATCAContextConnection = config.GetConnectionString("DGFATCAContextConnection") ?? throw new InvalidOperationException("Connection string 'DGFATCAContextConnection' not found.");
                _ = services.AddDbContext<DGFATCAContext>(opt => contextBuilder(opt, DGFATCAContextConnection));
                _ = services.AddDbContext<FATCAContext>(opt => contextBuilder(opt, connectionString));
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

                string DGMGMTContextConnection = config.GetConnectionString("DGMGMTContextConnection") ?? throw new InvalidOperationException("Connection string 'DGMGMTContextConnection' not found.");
                string DGMGMTAUDContextConnection = config.GetConnectionString("DGMGMTAUDContextConnection") ?? throw new InvalidOperationException("Connection string 'DGMGMTAUDContextConnection' not found.");
                _ = services.AddDbContext<DGMGMTContext>(opt => contextBuilder(opt, DGMGMTContextConnection));
                _ = services.AddDbContext<DGMGMTAUDContext>(opt => contextBuilder(opt, DGMGMTAUDContextConnection));
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

            if (modulesToApply.Contains("CRP"))
            {
                _ = services.AddDbContext<CRPContext>(opt => contextBuilder(opt, connectionString));
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

        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
        {
            _ = services.AddAuthorization(opt =>
            {
                opt.AddPolicy("CustomAuthorization", p =>
                {
                    CustomAuthorizationRequirment req = new();


                    _ = p.AddRequirements(req);

                }
                );
            });
            _ = services.AddScoped<IAuthorizationHandler, CustomAuthorizationRequirmentHandler>();
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
