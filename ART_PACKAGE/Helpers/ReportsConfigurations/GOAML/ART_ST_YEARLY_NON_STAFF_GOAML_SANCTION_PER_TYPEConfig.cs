using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_TYPEConfig : ReportConfig
    {
        public ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_TYPEConfig()
        {

            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "year", new GridColumnConfiguration { DisplayName = "Year" } },
                { "REPORT_TYPE", new GridColumnConfiguration { DisplayName = "Report Type" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            };
        }
    }
}
