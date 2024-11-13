using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class SlaSummaryConfig : ReportConfig
    {

        public SlaSummaryConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "TotalNumberOfAlertsOrCases", new GridColumnConfiguration { DisplayName = "Total Number Of Alerts Or Cases" } },
                { "UserName", new GridColumnConfiguration { DisplayName = "User Name" } },
                { "Product", new GridColumnConfiguration { DisplayName = "Product" } },
                { "ViolationFlag", new GridColumnConfiguration { DisplayName = "Violation Flag" } },
                { "DisplayName", new GridColumnConfiguration { DisplayName = "Display Name" } },
            };
            ReportTitle = "SLA Summary Report";
            ReportDescription = "";
        }


    }
}
