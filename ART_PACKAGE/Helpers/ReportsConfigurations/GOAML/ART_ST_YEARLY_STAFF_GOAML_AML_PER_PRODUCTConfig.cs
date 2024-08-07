using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ART_ST_YEARLY_STAFF_GOAML_AML_PER_PRODUCTConfig : ReportConfig
    {
        public ART_ST_YEARLY_STAFF_GOAML_AML_PER_PRODUCTConfig()
        {

            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "year", new GridColumnConfiguration { DisplayName = "Year" } },
                { "PRODUCT", new GridColumnConfiguration { DisplayName = "Product" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            };
        }
    }
}
