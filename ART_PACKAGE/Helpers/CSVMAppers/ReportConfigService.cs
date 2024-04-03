using ART_PACKAGE.Extentions.IServiceCollectionExtentions;
using ART_PACKAGE.Helpers.ReportsConfigurations;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class ReportConfigService
    {
        private readonly ReportConfigResolver _reportsConfigResolver;

        public ReportConfigService(ReportConfigResolver reportsConfigResolver)
        {
            _reportsConfigResolver = reportsConfigResolver;

        }
        public ReportConfig GetConfigs(string name)
        {

            return _reportsConfigResolver(name + "Config");

        }

    }
}
