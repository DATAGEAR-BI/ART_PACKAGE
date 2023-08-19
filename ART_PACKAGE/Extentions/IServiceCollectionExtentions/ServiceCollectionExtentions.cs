using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.License;
using ART_PACKAGE.Security;
using Data.Audit;
using Data.Constants;
using Data.Constants.db;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.ECM;
using Data.Data.Segmentation;
using Data.DGAML;
using Data.DGECM;
using Data.FCF71;
using Data.FCFCORE;
using Data.FCFKC;
using Data.GOAML;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Extentions.IServiceCollectionExtentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDbs(this IServiceCollection services, ConfigurationManager config)
        {
            string connectionString = config.GetConnectionString("AuthContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthContextConnection' not found.");
            string DGECMContextConnection = config.GetConnectionString("DGECMContextConnection") ?? throw new InvalidOperationException("Connection string 'DGECMContextConnection' not found.");
            string FCFCOREContextConnection = config.GetConnectionString("FCFCOREContextConnection") ?? throw new InvalidOperationException("Connection string 'FCFCOREContextConnection' not found.");
            string FCFKCContextConnection = config.GetConnectionString("FCFKCContextConnection") ?? throw new InvalidOperationException("Connection string 'FCFKCContextConnection' not found.");
            string GOAMLContextConnection = config.GetConnectionString("GOAMLContextConnection") ?? throw new InvalidOperationException("Connection string 'GOAMLContextConnection' not found.");
            string DGUSERMANAGMENTContextConnection = config.GetConnectionString("DGUSERMANAGMENTContextConnection") ?? throw new InvalidOperationException("Connection string 'DGUSERMANAGMENTContextConnection' not found.");
            string DGAMLContextConnection = config.GetConnectionString("DGAMLContextConnection") ?? throw new InvalidOperationException("Connection string 'DGAMLContextConnection' not found.");
            List<string>? migrationsToApply = config.GetSection("migrations").Get<List<string>>();
            string dbType = config.GetValue<string>("dbType").ToUpper();
            string migrationPath = dbType == DbTypes.SqlServer ? "SqlServerMigrations" : "OracleMigrations";


            _ = services.AddDbContext<AuthContext>(options => _ = dbType switch
            {
                DbTypes.SqlServer => options.UseSqlServer(
                    connectionString,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    connectionString,
                    x => x.MigrationsAssembly("OracleMigrations")
                    ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            }).AddDbContext<SegmentationContext>(options => _ = dbType switch
            {


                DbTypes.SqlServer => options.UseSqlServer(
                    connectionString,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    connectionString,
                    x => x.MigrationsAssembly("OracleMigrations")
                    ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            }).AddDbContext<ArtGoAmlContext>(options => _ = dbType switch
            {


                DbTypes.SqlServer => options.UseSqlServer(
                    connectionString,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    connectionString,
                    x => x.MigrationsAssembly("OracleMigrations")
                    ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            }).AddDbContext<ArtDgAmlContext>(options => _ = dbType switch
            {


                DbTypes.SqlServer => options.UseSqlServer(
                    connectionString,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    connectionString,
                    x => x.MigrationsAssembly("OracleMigrations")
                    ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            }).AddDbContext<EcmContext>(options => _ = dbType switch
            {


                DbTypes.SqlServer => options.UseSqlServer(
                    connectionString,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    connectionString,
                    x => x.MigrationsAssembly("OracleMigrations")
                    ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            });


            _ = services.AddDbContext<DGECMContext>(options => _ = dbType switch
            {
                DbTypes.SqlServer => options.UseSqlServer(
                    DGECMContextConnection,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    DGECMContextConnection,
                    x => x.MigrationsAssembly("OracleMigrations")
                    ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            });



            _ = services.AddDbContext<fcf71Context>(options => _ = dbType switch
            {
                DbTypes.SqlServer => options.UseSqlServer(
                    FCFCOREContextConnection,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    FCFCOREContextConnection,
                    x => x.MigrationsAssembly("OracleMigrations")
                    ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            });
            _ = services.AddDbContext<FCFKC>(options => _ = dbType switch
            {
                DbTypes.SqlServer => options.UseSqlServer(
                    FCFKCContextConnection,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    FCFKCContextConnection,
                    x => x.MigrationsAssembly("OracleMigrations")
                    ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            });
            _ = services.AddDbContext<GoAmlContext>(options => _ = dbType switch
            {
                DbTypes.SqlServer => options.UseSqlServer(
                    GOAMLContextConnection,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    GOAMLContextConnection,
                    x => x.MigrationsAssembly("OracleMigrations")
                    ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            });
            _ = services.AddDbContext<AuditContext>(options => _ = dbType switch
            {
                DbTypes.SqlServer => options.UseSqlServer(
                    DGUSERMANAGMENTContextConnection,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    DGUSERMANAGMENTContextConnection,
                    x => x.MigrationsAssembly("OracleMigrations")
                    ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            });
            _ = services.AddDbContext<DGAMLContext>(options => _ = dbType switch
            {
                DbTypes.SqlServer => options.UseSqlServer(
                    DGAMLContextConnection,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    DGAMLContextConnection,
                    x => x.MigrationsAssembly("OracleMigrations")
                    ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            });

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
    }
}
