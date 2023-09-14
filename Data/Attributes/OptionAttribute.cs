using Microsoft.Extensions.Configuration;

namespace ART_PACKAGE.Data.Attributes
{

    public class OptionAttribute : Attribute
    {
        private readonly List<string> modules;
        public OptionAttribute()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");
            IConfiguration configuration = builder.Build();

            modules = configuration.GetSection("Modules").AsEnumerable().Where(x => x.Value != null).Select(x => x.Value).ToList();
        }

        public string ModuleNames { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public bool IsHidden
        {
            get
            {
                return modules != null && modules.Any(x => ModuleNames.Split(",").Contains(x));
            }
        }
    }
