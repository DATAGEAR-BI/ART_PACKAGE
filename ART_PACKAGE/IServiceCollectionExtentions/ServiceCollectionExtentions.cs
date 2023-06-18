using ART_PACKAGE.Areas.Identity.Data;
using Data.Constants.db;
using Data.DGECM;
using Data.FCF71;
using Data.FCFCORE;
using Data.FCFKC;
using Data.GOAML;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.IServiceCollectionExtentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDbs(this IServiceCollection services, ConfigurationManager config)
        {
            var connectionString = config.GetConnectionString("AuthContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthContextConnection' not found.");
            var DGECMContextConnection = config.GetConnectionString("DGECMContextConnection") ?? throw new InvalidOperationException("Connection string 'DGECMContextConnection' not found.");
            var FCFCOREContextConnection = config.GetConnectionString("FCFCOREContextConnection") ?? throw new InvalidOperationException("Connection string 'FCFCOREContextConnection' not found.");
            var FCFKCContextConnection = config.GetConnectionString("FCFKCContextConnection") ?? throw new InvalidOperationException("Connection string 'FCFKCContextConnection' not found.");
            var GOAMLContextConnection = config.GetConnectionString("GOAMLContextConnection") ?? throw new InvalidOperationException("Connection string 'GOAMLContextConnection' not found.");
            var migrationsToApply = config.GetSection("migrations").Get<List<string>>();
            var dbType = config.GetValue<string>("dbType").ToUpper();
            var migrationPath = dbType == DbTypes.SqlServer ? "SqlServerMigrations" : "OracleMigrations";


            services.AddDbContext<AuthContext>(options => _ = dbType switch
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


            services.AddDbContext<DGECMContext>(options => _ = dbType switch
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



            services.AddDbContext<fcf71Context>(options => _ = dbType switch
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
            services.AddDbContext<FCFKC>(options => _ = dbType switch
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
            services.AddDbContext<GoAmlContext>(options => _ = dbType switch
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

            services.AddScoped<IDbService, DBService>();
            return services;
        }
    }
}
