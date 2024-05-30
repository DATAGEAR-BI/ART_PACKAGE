using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artcasestransactionssummaryconfig: ReportConfig
    {
        public artcasestransactionssummaryconfig()
        {

            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "Employee_Number", new GridColumnConfiguration { DisplayName = "Employee Number" } },
                { "Employee_Name", new GridColumnConfiguration { DisplayName = "Employee Name" } },
                { "Month", new GridColumnConfiguration { DisplayName = "Month" } },
                { "Amount", new GridColumnConfiguration { DisplayName = "Amount" } },
                { "Count", new GridColumnConfiguration { DisplayName = "Count" } },
                { "Alerts_Count", new GridColumnConfiguration { DisplayName = "Alerts Count" } },
                { "Closed_Cases", new GridColumnConfiguration { DisplayName = "Closed Cases" } },
                { "Cases_Count", new GridColumnConfiguration { DisplayName = "Cases Count" } }
            };
        }
    }
}
