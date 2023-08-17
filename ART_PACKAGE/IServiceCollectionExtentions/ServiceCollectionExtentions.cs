using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.License;
using ART_PACKAGE.Security;
using Data.ACTIVITIDB;
using Data.Constants;
using Data.Constants.db;
using Data.DGADMIN;
using Data.DGCALENDAR;
using Data.DGECM;
using Data.DGECMMETADATA;
using Data.DGNOTIFICATION;
using Data.DGUSERMANAGEMENT;
using Data.FCF71;
using Data.TI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.IServiceCollectionExtentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDbs(this IServiceCollection services, ConfigurationManager config)
        {
            string connectionString = config.GetConnectionString("AuthContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthContextConnection' not found.");
            string DGECMContextConnection = config.GetConnectionString("DGECMContextConnection") ?? throw new InvalidOperationException("Connection string 'DGECMContextConnection' not found.");
            string ACTIVITIDBContextConnection = config.GetConnectionString("ACTIVITIDBContextConnection") ?? throw new InvalidOperationException("Connection string 'ACTIVITIDBContextConnection' not found.");
            string DGADMINContextConnection = config.GetConnectionString("DGADMINContextConnection") ?? throw new InvalidOperationException("Connection string 'DGADMINContextConnection' not found.");
            string DGCALENDARContextConnection = config.GetConnectionString("DGCALENDARContextConnection") ?? throw new InvalidOperationException("Connection string 'DGCALENDARContextConnection' not found.");
            string DGUSERMANAGMENTContextConnection = config.GetConnectionString("DGUSERMANAGMENTContextConnection") ?? throw new InvalidOperationException("Connection string 'DGUSERMANAGMENTContextConnection' not found.");
            string DGNOTIFICATIONContextConnection = config.GetConnectionString("DGNOTIFICATIONContextConnection") ?? throw new InvalidOperationException("Connection string 'DGNOTIFICATIONContextConnection' not found.");
            string DGECMMETADATAContextConnection = config.GetConnectionString("DGECMMETADATAContextConnection") ?? throw new InvalidOperationException("Connection string 'DGECMMETADATAContextConnection' not found.");
            string TIContextConnection = config.GetConnectionString("TIContextConnection") ?? throw new InvalidOperationException("Connection string 'TIContextConnection' not found.");
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



            _ = services.AddDbContext<ACTIVITIDBContext>(options => _ = dbType switch
            {
                DbTypes.SqlServer => options.UseSqlServer(
                    ACTIVITIDBContextConnection,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    ACTIVITIDBContextConnection,
                    x => x.MigrationsAssembly("OracleMigrations")
                    ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            });
            _ = services.AddDbContext<DGADMINContext>(options => _ = dbType switch
            {
                DbTypes.SqlServer => options.UseSqlServer(
                    DGADMINContextConnection,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    DGADMINContextConnection,
                    x => x.MigrationsAssembly("OracleMigrations")
                    ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            });
            _ = services.AddDbContext<DGCALENDARContext>(options => _ = dbType switch
            {
                DbTypes.SqlServer => options.UseSqlServer(
                    DGCALENDARContextConnection,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    DGCALENDARContextConnection,
                    x => x.MigrationsAssembly("OracleMigrations")
                    ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            });
            _ = services.AddDbContext<DGUSERMANAGEMENTContext>(options => _ = dbType switch
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
            _ = services.AddDbContext<DGNOTIFICATIONContext>(options => _ = dbType switch
            {
                DbTypes.SqlServer => options.UseSqlServer(
                    DGNOTIFICATIONContextConnection,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    DGNOTIFICATIONContextConnection,
                    x => x.MigrationsAssembly("OracleMigrations")
                    ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            });
            _ = services.AddDbContext<DGECMMETADATAContext>(options => _ = dbType switch
            {
                DbTypes.SqlServer => options.UseSqlServer(
                    DGECMMETADATAContextConnection,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    DGECMMETADATAContextConnection,
                    x => x.MigrationsAssembly("OracleMigrations")
                    ),
                _ => throw new Exception($"Unsupported provider: {dbType}")
            });
            _ = services.AddDbContext<TIContext>(options => _ = dbType switch
            {
                DbTypes.SqlServer => options.UseSqlServer(
                    TIContextConnection,
                    x => x.MigrationsAssembly("SqlServerMigrations")
                    ),
                DbTypes.Oracle => options.UseOracle(
                    TIContextConnection,
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
