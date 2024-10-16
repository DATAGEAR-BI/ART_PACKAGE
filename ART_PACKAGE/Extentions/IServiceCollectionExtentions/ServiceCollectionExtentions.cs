using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.BackGroundServices;
using ART_PACKAGE.Helpers.DBService;
using ART_PACKAGE.Helpers.License;
using ART_PACKAGE.Helpers.ReportsConfigurations;
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
using Data.Data.TRADE_BASE;
using Data.Data.FATCA;
using Data.DGAMLCORE;
using Data.DGECM;
using Data.DGFATCA;
using Data.FCFCORE;
using Data.FCFKC.AmlAnalysis;
using Data.FCFKC.SASAML;
using Data.GOAML;
using Data.Services.AmlAnalysis;
using Data.TIZONE2;
using Microsoft.EntityFrameworkCore;
using Data.DGAMLAC;
using Data.Setting;
using Data.Services;
using Data.Services.Tenat;

namespace ART_PACKAGE.Extentions.IServiceCollectionExtentions
{
    public delegate ReportConfig ReportConfigResolver(string key);
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDbs(this IServiceCollection services, ConfigurationManager config)
        {
            string connectionString = config.GetConnectionString("AuthContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthContextConnection' not found.");
            List<string>? modulesToApply = config.GetSection("Modules").Get<List<string>>();
            string dbType = config.GetValue<string>("dbType").ToUpper();
            TenantSettings tenatSittings = new();
            config.GetSection(nameof(TenantSettings)).Bind(tenatSittings);

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
                    DbTypes.MySql => options.UseMySQL(
                    conn,
                    x => { _ = x.MigrationsAssembly("MySqlMigrations"); _ = x.CommandTimeout(commandTimeOut); }
                    ),
                    _ => throw new Exception($"Unsupported provider: {dbType}")
                };
            }
            void tenatContextBuilder(DbContextOptionsBuilder options)
            {
                int commandTimeOut = tenatSittings.Defaults.CommandTimeOut==null?120: tenatSittings.Defaults.CommandTimeOut;
                _ = tenatSittings.Defaults.DBProvider switch
                {
                    DbTypes.SqlServer => options.UseSqlServer(
                        x => { _ = x.MigrationsAssembly("SqlServerMigrations"); _ = x.CommandTimeout(commandTimeOut); }
                        ),
                    DbTypes.Oracle => options.UseOracle(
                        x => { _ = x.MigrationsAssembly("OracleMigrations"); _ = x.CommandTimeout(commandTimeOut); }
                        ),
                    DbTypes.MySql => options.UseMySQL(
                    x => { _ = x.MigrationsAssembly("MySqlMigrations"); _ = x.CommandTimeout(commandTimeOut); }
                    ),
                    _ => throw new Exception($"Unsupported provider: {dbType}")
                };
            }

            _ = services.AddDbContext<AuthContext>(opt => tenatContextBuilder(opt));


            if (modulesToApply is null)
            {
                _ = services.AddScoped<IDbService, DBService>();
                return services;
            }

            if (modulesToApply.Contains("SEG"))
            {
                string FCFKCContextConnection = config.GetConnectionString("FCFKCContextConnection") ?? throw new InvalidOperationException("Connection string 'FCFKCContextConnection' not found.");
                //_ = services.AddDbContext<SEGFCFKCContext>(opt => contextBuilder(opt, FCFKCContextConnection));
                _ = services.AddDbContext<SegmentationContext>(opt => tenatContextBuilder(opt));
            }

            if (modulesToApply.Contains("GOAML"))
            {
             
                _ = services.AddDbContext<GoAmlContext>(opt => tenatContextBuilder(opt));
                _ = services.AddDbContext<ArtGoAmlContext>(opt => tenatContextBuilder(opt));
            }

            if (modulesToApply.Contains("FTI"))
            {
                _ = services.AddDbContext<TIZONE2Context>(opt => tenatContextBuilder(opt));
                _ = services.AddDbContext<FTIContext>(opt => tenatContextBuilder(opt));
            }

            if (modulesToApply.Contains("DGAML"))
            {
                _ = services.AddDbContext<DGAMLCOREContext>(opt => tenatContextBuilder(opt));
                _ = services.AddDbContext<DGAMLACContext>(opt => tenatContextBuilder(opt));
                _ = services.AddDbContext<ArtDgAmlContext>(opt => tenatContextBuilder(opt));
            }

            if (modulesToApply.Contains("ECM"))
            {
                _ = services.AddDbContext<DGECMContext>(opt => tenatContextBuilder(opt));
                _ = services.AddDbContext<EcmContext>(opt => tenatContextBuilder(opt));
            }

            if (modulesToApply.Contains("FATCA"))
            {
                _ = services.AddDbContext<DGFATCAContext>(opt => tenatContextBuilder(opt));
                _ = services.AddDbContext<FATCAContext>(opt => tenatContextBuilder(opt));
            }
            if (modulesToApply.Contains("CRP"))
            {
                _ = services.AddDbContext<CRPContext>(opt => tenatContextBuilder(opt));
            }
            if (modulesToApply.Contains("TRADE_BASE"))
            {
                _ = services.AddDbContext<TRADE_BASEContext>(opt => tenatContextBuilder(opt));
            }
            if (modulesToApply.Contains("SASAML"))
            {
                _ = services.AddDbContext<fcf71Context>(opt => tenatContextBuilder(opt));
                _ = services.AddDbContext<FCFKC>(opt => tenatContextBuilder(opt));
                _ = services.AddDbContext<SasAmlContext>(opt => tenatContextBuilder(opt));
            }
            if (modulesToApply.Contains("DGAUDIT"))
            {
                _ = services.AddDbContext<DGMGMTContext>(opt => tenatContextBuilder(opt));
                _ = services.AddDbContext<DGMGMTAUDContext>(opt => tenatContextBuilder(opt));
                _ = services.AddDbContext<ArtAuditContext>(opt => tenatContextBuilder(opt));
            }

            if (modulesToApply.Contains("AMLANALYSIS"))
            {
                _ = services.AddDbContext<fcf71Context>(opt => tenatContextBuilder(opt));
                _ = services.AddDbContext<FCFKCAmlAnalysisContext>(opt => tenatContextBuilder(opt));
                _ = services.AddDbContext<AmlAnalysisContext>(opt => tenatContextBuilder(opt));
                _ = services.AddAmlAnalysis();
            }

            if (modulesToApply.Contains("KYC"))
            {
                _ = services.AddDbContext<KYCContext>(opt => tenatContextBuilder(opt));
            }

            // if (modulesToApply.Contains("EXPORT_SCHEDULAR"))
            // {
            //
            //     _ = services.AddDbContext<ExportSchedularContext>(opt => contextBuilder(opt, connectionString));
            //     _ = services.AddScoped<ITaskPerformer, TaskPerformer>();
            //
            //
            //     _ = services.AddHangfire(
            //     configuration =>
            //     {
            //         _ = configuration
            //                     .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            //                     .UseSimpleAssemblyNameTypeSerializer()
            //                     .UseRecommendedSerializerSettings();
            //         switch (dbType)
            //         {
            //             case DbTypes.SqlServer:
            //                 _ = configuration.UseSqlServerStorage(connectionString);
            //                 break;
            //             default:
            //                 _ = configuration.UseStorage(new OracleStorage(connectionString,
            //                      new OracleStorageOptions
            //                      {
            //                          // Optional settings
            //                          QueuePollInterval = TimeSpan.FromSeconds(15),
            //                          JobExpirationCheckInterval = TimeSpan.FromHours(1),
            //                          SchemaName = "ART"
            //                      }
            //                  )
            //                                                             );
            //                 break;
            //         }
            //     });
            //
            //     _ = services.AddHangfireServer();
            // }
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
                });
            });
            _ = services.AddScoped<IAuthorizationHandler, CustomAuthorizationRequirmentHandler>();
            return services;
        }
        public static IServiceCollection AddAmlAnalysis(this IServiceCollection services)
        {
            _ = services.AddScoped<IAmlAnalysis, AmlAnalysis>();
            _ = services.AddScoped<IAmlAnalysisRepo, AmlAnalysisRepo>();
            _ = services.AddScoped<IAutoRulesRepo, AutoRulesRepo>();

            _ = services.AddSingleton<AmlAnalysisUpdateTableIndecator>();
            //_ = services.AddHostedService<AmlAnalysisWatcher>();
            _ = services.AddHostedService<AmlAnalysisTableCreateService>();
            return services;
        }
        public static IServiceCollection AddTenancy(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddSingleton<TenantConstants>();
            services.AddScoped<ITenantService, TenantService>();
            services.Configure<TenantSettings>(configuration.GetSection(nameof(TenantSettings)));

            return services;
        }

        public static IServiceCollection AddReportsConfiguratons(this IServiceCollection services)
        {
            IEnumerable<Type> configTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass && t.Namespace == "ART_PACKAGE.Helpers.ReportsConfigurations");
            foreach (Type? type in configTypes)
            {
                _ = services.AddSingleton(type);
            }

            _ = services.AddTransient<ReportConfigResolver>(serviceProvider => key =>
            {
                Type? configType = configTypes.FirstOrDefault(x => x.Name.ToLower() == key.ToLower());
                return (ReportConfig)serviceProvider.GetService(configType);
            });
            return services;
        }

    }
}
