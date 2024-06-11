using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ART_ST_YEARLY_BOTTOM_GOAML_BRANCHESConfig : ReportConfig
    {
        public ART_ST_YEARLY_BOTTOM_GOAML_BRANCHESConfig()
        {

            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "REPORT_TYPE", new GridColumnConfiguration { DisplayName = "Report Type" } },
                { "BRANCH_NAME", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "MONTHLY_AVG_OF_ALERTS_OR_CASES", new GridColumnConfiguration { DisplayName = "Monthly Average Of Alerts Or Cases " } },
                { "RN", new GridColumnConfiguration { DisplayName = "RN" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            };
        }
    }
}
