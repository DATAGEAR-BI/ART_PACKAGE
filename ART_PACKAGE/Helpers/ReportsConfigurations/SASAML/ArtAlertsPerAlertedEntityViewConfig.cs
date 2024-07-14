using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtAlertsPerAlertedEntityViewConfig:ReportConfig
    {

        public ArtAlertsPerAlertedEntityViewConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "AlertedEntityNumber", new GridColumnConfiguration { DisplayName = "Alerted Entity Number" } },
                { "AlertedEntityName", new GridColumnConfiguration { DisplayName = "Alerted Entity Name" } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "BranchNumber", new GridColumnConfiguration { DisplayName = "Branch Number" } },
                { "OwnerUserId", new GridColumnConfiguration { DisplayName = "Owner User ID" } },
                { "NumberOfAlerts", new GridColumnConfiguration { DisplayName = "Number of Alerts" } }
            };
        }


    }
}
