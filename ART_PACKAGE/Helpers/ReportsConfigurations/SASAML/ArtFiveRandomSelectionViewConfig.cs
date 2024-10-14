using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtFiveRandomSelectionViewConfig : ReportConfig
    {
        public ArtFiveRandomSelectionViewConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "Module", new GridColumnConfiguration { DisplayName = "Module" } },
                { "AlertCaseId", new GridColumnConfiguration { DisplayName = "Alert Case ID" } },
                { "AlertCaseStatus", new GridColumnConfiguration { DisplayName = "Alert Case Status" } },
                { "EntityNumber", new GridColumnConfiguration { DisplayName = "Entity Number" } },
                { "EntityName", new GridColumnConfiguration { DisplayName = "Entity Name" } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "BranchNumber", new GridColumnConfiguration { DisplayName = "Branch Number" } },
                { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date" } },
                { "CloseDate", new GridColumnConfiguration { DisplayName = "Close Date" } },
                { "ClosedBy", new GridColumnConfiguration { DisplayName = "Closed By" } },
            };
            ReportTitle = "5% Random Selection Report";

        }
    }
}
