using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtFatcaAlertConfig : ReportConfig
    {
        public ArtFatcaAlertConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID" } },
                { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date" } },
                { "CustomerId", new GridColumnConfiguration { DisplayName = "Customer Id" } },
                { "CustomerName", new GridColumnConfiguration { DisplayName = "Customer Name" } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "IncidentId", new GridColumnConfiguration { DisplayName = "IncidentId" } },
                { "Type", new GridColumnConfiguration { DisplayName = "Type" } },
                { "Description", new GridColumnConfiguration { DisplayName = "Description" } },
            };
            ReportTitle = "FATCA Alerts Details";
            ReportDescription = "Presents all FATCA alerts details";
        }
    }
}
