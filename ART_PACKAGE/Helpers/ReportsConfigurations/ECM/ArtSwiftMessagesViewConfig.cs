using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtSwiftMessagesViewConfig : ReportConfig
    {
        public ArtSwiftMessagesViewConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
    {
        {"CaseId", new GridColumnConfiguration { DisplayName = "Case ID" } },
        {"CreateDate", new GridColumnConfiguration { DisplayName = "Create Date" } },
        {"CreateUserId", new GridColumnConfiguration { DisplayName = "Create User ID" } },
        {"CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status" } },
        {"Direction", new GridColumnConfiguration { DisplayName = "Direction" } },
        {"SwiftMessage", new GridColumnConfiguration { DisplayName = "Swift Message" } },
        {"IncidentsCount", new GridColumnConfiguration { DisplayName = "Incidents Count" } },
        {"IncidentId", new GridColumnConfiguration { DisplayName = "Incident ID" } },
        {"IncidentName", new GridColumnConfiguration { DisplayName = "Incident Name" } },
        {"Sender", new GridColumnConfiguration { DisplayName = "Sender" } },
        {"Receiver", new GridColumnConfiguration { DisplayName = "Receiver" } },
        {"TransType", new GridColumnConfiguration { DisplayName = "Trans Type" } },
        {"TransAmount", new GridColumnConfiguration { DisplayName = "Trans Amount" } },
        {"Maker", new GridColumnConfiguration { DisplayName = "Maker" } },
        {"Checker", new GridColumnConfiguration { DisplayName = "Checker" } }
    };

            defaultSortOption = new()
            {
                field = "CreateDate",
                dir = "asc"
            };
        }
    }
}
