using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ART_ST_YEARLY_STAFF_GOAML_SANCTION_PER_REGIONConfig : ReportConfig
    {
        public ART_ST_YEARLY_STAFF_GOAML_SANCTION_PER_REGIONConfig()
        {

            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "REGION", new GridColumnConfiguration { DisplayName = "Region" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            };
        }
    }
}
