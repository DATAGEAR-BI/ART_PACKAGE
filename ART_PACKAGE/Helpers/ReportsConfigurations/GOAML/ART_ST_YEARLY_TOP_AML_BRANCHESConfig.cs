using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ART_ST_YEARLY_TOP_AML_BRANCHESConfig : ReportConfig
    {
        public ART_ST_YEARLY_TOP_AML_BRANCHESConfig()
        {

            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "region", new GridColumnConfiguration { DisplayName = "Region" } },
                { "BRANCH_NAME", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "NUMBER_OF_CASES", new GridColumnConfiguration { DisplayName = "Number Of Cases" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            };
        }
    }
}
