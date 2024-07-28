using ART_PACKAGE.Helpers.ReportsConfigurations;

namespace ART_PACKAGE.Helpers
{
    public class ReportConfigResolver2
    {
        

        public static ReportConfig GetConfigs<T>()
        {
            Type type = typeof(ReportConfig);

            // Get the full name of the type (namespace + class name)
            string typeName = type.FullName;

            // Get the assembly name
            string assemblyName = type.Assembly.GetName().Name;

            // Combine them to get the fully qualified type name
            string fullyQualifiedTypeName = $"{SliceUntilLastPeriod(typeName)}{typeof(T).Name}Config, {assemblyName}";
            Type ConfigType = Type.GetType(fullyQualifiedTypeName);
            if (ConfigType != null)
            {
                // Create an instance of the type
                object ConfigInstance = Activator.CreateInstance(ConfigType);
                if (ConfigInstance == null)
                {
                    return null;
                }
                return (ReportConfig)ConfigInstance;
            }
            fullyQualifiedTypeName = $"{SliceUntilLastPeriod(typeName)}{typeof(T).Name.ToLower()}Config, {assemblyName}";
            ConfigType = Type.GetType(fullyQualifiedTypeName);
            if (ConfigType != null)
            {
                // Create an instance of the type
                object ConfigInstance = Activator.CreateInstance(ConfigType);
                if (ConfigInstance == null)
                {
                    return null;
                }
                return (ReportConfig)ConfigInstance;
            }
            return null;





        }
        private static string SliceUntilLastPeriod(string input)
        {
            // Find the index of the last occurrence of the period
            int lastIndex = input.LastIndexOf('.');

            // If there is no period in the string, return the original string or handle accordingly
            if (lastIndex == -1)
            {
                return input;
            }

            // Use Substring to get the portion of the string until (and including) the last period
            return input.Substring(0, lastIndex + 1);
        }

    }
}
