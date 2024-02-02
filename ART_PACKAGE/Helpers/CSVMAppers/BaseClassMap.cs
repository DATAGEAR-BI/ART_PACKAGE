using System.Reflection;
using CsvHelper.Configuration;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public abstract class BaseClassMap<T> : ClassMap<T>
    {
        protected List<string> _inculdedColumns;
        protected readonly Dictionary<string, (string displayName, PropertyInfo propInfo)> propNameMap;

        protected BaseClassMap(List<string>? includedColumns = null)
        {
            Type modelType = typeof(T);
            string modelName = modelType.Name.ToLower();
            PropertyInfo[] properties = modelType.GetProperties();

            if (includedColumns is null)
            {
                List<string> skipList = null;
                if (ReportsConfig.CONFIG.TryGetValue(modelName, out ReportConfig? config))
                {
                    skipList = config.SkipList;
                }

                _inculdedColumns = typeof(T).GetProperties().Where(x => !skipList.Contains(x.Name)).Select(x => x.Name)
                    .ToList();
            }
            else
            {
                _inculdedColumns = includedColumns;

            }
            propNameMap = _inculdedColumns
                .Select(columnName => properties.FirstOrDefault(prop => string.Equals(prop.Name, columnName, StringComparison.OrdinalIgnoreCase)))
                .Where(prop => prop != null)
                .ToDictionary(
                    prop => prop.Name,
                    prop =>
                    {
                        string displayName = prop.Name;
                        if (ReportsConfig.CONFIG.TryGetValue(modelName, out ReportConfig? config) && config.DisplayNames.TryGetValue(prop.Name, out GridColumnConfiguration? displayNameConfig))
                        {
                            displayName = displayNameConfig.DisplayName;
                        }
                        return (displayName, prop);
                    }
                );
            ConfigureCsv();
        }


        public abstract void ConfigureCsv();
    }
}