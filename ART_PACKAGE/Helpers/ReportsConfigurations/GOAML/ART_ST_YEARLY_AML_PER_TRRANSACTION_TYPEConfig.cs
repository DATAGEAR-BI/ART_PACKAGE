using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ART_ST_YEARLY_AML_PER_TRRANSACTION_TYPEConfig : ReportConfig
    {
        public ART_ST_YEARLY_AML_PER_TRRANSACTION_TYPEConfig()
        {

            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "YEAR", new GridColumnConfiguration { DisplayName = "Year" } },
                { "TRRANSACTION_TYPE", new GridColumnConfiguration { DisplayName = "Transaction Type" } },
                { "NUMBER_OF_CASES", new GridColumnConfiguration { DisplayName = "Number Of Cases" } }
            };
        }
    }
}
