using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ART_ST_YEARLY_STAFF_GOAML_AML_PER_CRIMEConfig : ReportConfig
    {
        public ART_ST_YEARLY_STAFF_GOAML_AML_PER_CRIMEConfig()
        {

            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "year", new GridColumnConfiguration { DisplayName = "Year" } },
                { "CRIME", new GridColumnConfiguration { DisplayName = "Crime" } },
                { "NUMBER_OF_REPORTS", new GridColumnConfiguration { DisplayName = "Number Of Reports" } }
            };
        }
    }
}
