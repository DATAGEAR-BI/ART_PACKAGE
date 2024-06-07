using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtAuditUserAccessLogConfig : ReportConfig
    {
        public ArtAuditUserAccessLogConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    {"UserNumber", new GridColumnConfiguration { DisplayName ="User Number"}},
                    {"UserName", new GridColumnConfiguration { DisplayName ="User Name"}},
                    {"ReportName", new GridColumnConfiguration { DisplayName ="Report Name"}},
                    {"Department", new GridColumnConfiguration { DisplayName ="Department"}},
                    {"LastLoginDate", new GridColumnConfiguration { DisplayName ="Last Login Date"}},

            };
        }
    }
}
