using ART_PACKAGE.Extentions.IServiceCollectionExtentions;
using ART_PACKAGE.Helpers.ReportsConfigurations;
using System.Reflection;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class ReportConfigService
    {
        private readonly ReportConfigResolver _reportsConfigResolver;

        public ReportConfigService(ReportConfigResolver reportsConfigResolver)
        {
            _reportsConfigResolver = reportsConfigResolver;

        }
        public static ReportConfig GetConfigs<TModel>()
        {
            string targetNamespace = "ART_PACKAGE.Helpers.ReportsConfigurations";
            Type type = Assembly.GetExecutingAssembly().GetTypes()
                // Filter types by namespace
                .Where(t => string.Equals(t.Namespace, targetNamespace, StringComparison.Ordinal))
                // Filter out non-public types if needed
                .Where(t => t.IsClass && t.IsPublic && t.Name.ToLower() == (typeof(TModel).Name + "Config").ToLower()).FirstOrDefault();
            string ass = "ART_PACKAGE.Helpers.ReportsConfigurations." + (typeof(TModel).Name + "Config").ToLower();
            // Get the Type object corresponding to the class name
            // Type type = typeof(ArtSystemPerformanceConfig);

            if (type != null)
            {
                // Create an instance of the class using reflection
                object modelConfiginstance = Activator.CreateInstance(type);

                // Check if the instance is not null
                if (modelConfiginstance != null)
                {
                    // You can cast the instance to the desired type if needed
                    ReportConfig reportConfiginstance = (ReportConfig)modelConfiginstance;

                    // Now you can use the instance
                    return reportConfiginstance;
                }
                else
                {
                    Console.WriteLine("Failed to create an instance of " + (typeof(TModel).Name + "Config").ToLower());
                }
            }
            else
            {
                Console.WriteLine("Type " + (typeof(TModel).Name + "Config").ToLower() + " not found.");
            }

            return null;

        }

    }
}
