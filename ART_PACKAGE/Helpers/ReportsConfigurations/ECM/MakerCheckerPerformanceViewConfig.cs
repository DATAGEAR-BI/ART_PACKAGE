using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class MakerCheckerPerformanceViewConfig : ReportConfig
    {
        public MakerCheckerPerformanceViewConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
        { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID" } },
        { "CaseTypeCd", new GridColumnConfiguration { DisplayName = "Case Type Code" } },
        { "Program", new GridColumnConfiguration { DisplayName = "Program" } },
        { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date" } },
        { "NewState", new GridColumnConfiguration { DisplayName = "New State" } },
        { "CaseUser", new GridColumnConfiguration { DisplayName = "Case User" } },
        { "Status", new GridColumnConfiguration { DisplayName = "Status" } },
        { "NewCaseStatus", new GridColumnConfiguration { DisplayName = "New Case Status" } },
        { "ReleasedDate", new GridColumnConfiguration { DisplayName = "Released Date" } }
    };
        }
    }
}
