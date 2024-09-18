using System.Reflection;

namespace ART_PACKAGE.Helpers
{
    public static class AssemblyConfigurationReader
    {

        public static object GetAppSettingFromAssembly(string key)
        {
            // Load appsettings.json from the executing assembly location
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            var d = configuration.GetValue<object>(key, null);
            return configuration.GetValue<object>(key,null);
        }
    }
}
