using Microsoft.Extensions.Configuration;

namespace OracleMigrations.Migrations
{
    public class MigrationsModules
    {

        public static IEnumerable<string> GetModules()
        {
            IConfiguration _config;
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            _config = builder.Build();
            var Modules = _config.GetSection("Modules").AsEnumerable().Where(x => x.Value != null).Select(x => x.Value);
            return Modules;


        }

    }
}

