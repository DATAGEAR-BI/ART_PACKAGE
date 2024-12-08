using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtFatcaCaceConfig : ReportConfig
    {
        public ArtFatcaCaceConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID" } },
                { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date" } },
                { "CustomerId", new GridColumnConfiguration { DisplayName = "Customer Id" } },
                { "CustomerName", new GridColumnConfiguration { DisplayName = "Customer Name" } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status" } },
                { "CaseType", new GridColumnConfiguration { DisplayName = "CaseType" } },



            };
            ReportTitle = "FATCA Cases Details";
            ReportDescription = "Presents all FATCA cases details";
        }
    }
}