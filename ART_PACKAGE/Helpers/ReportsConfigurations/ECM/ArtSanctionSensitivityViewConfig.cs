using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtSanctionSensitivityViewConfig : ReportConfig
    {
        public ArtSanctionSensitivityViewConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    { "Id", new GridColumnConfiguration { DisplayName = "ID"}},
                    { "Date", new GridColumnConfiguration { DisplayName = "Date"}},
                    { "UserName", new GridColumnConfiguration { DisplayName = "User Name"}},
                    { "Category", new GridColumnConfiguration { DisplayName = "Category"}},
                    { "ActionName", new GridColumnConfiguration { DisplayName = "Action Name"}},
                    { "ActionDetails", new GridColumnConfiguration { DisplayName = "Action Details"}},
            };

            ReportTitle = "Sanction Sensitivity Report";
            ReportDescription = "";
            SkipList = new List<string>
            { };
        }
    }
}
