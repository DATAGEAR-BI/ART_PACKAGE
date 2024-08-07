using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ART_ST_YEARLY_SANCTION_PER_PRODUCTConfig : ReportConfig
    {
        public ART_ST_YEARLY_SANCTION_PER_PRODUCTConfig()
        {

            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "year", new GridColumnConfiguration { DisplayName = "Year" } },
                { "CASE_TYPE", new GridColumnConfiguration { DisplayName = "Case Type" } },


                { "NUMBER_OF_CASES", new GridColumnConfiguration { DisplayName = "Number Of Cases" } }
            };
        }
    }
}
