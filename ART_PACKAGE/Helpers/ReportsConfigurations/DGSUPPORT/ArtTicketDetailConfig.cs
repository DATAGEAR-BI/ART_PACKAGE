using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtTicketDetailConfig:ReportConfig
    {
        public ArtTicketDetailConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "TicketNumber", new GridColumnConfiguration { DisplayName = "Ticket Number" }},
                { "Status", new GridColumnConfiguration { DisplayName = "Status" }},
                { "Title", new GridColumnConfiguration { DisplayName = "Title" }},
                { "PendingReason", new GridColumnConfiguration { DisplayName = "Pending Reason" }},
                { "ClientName", new GridColumnConfiguration { DisplayName = "Client Name" }},
                { "ServiceName", new GridColumnConfiguration { DisplayName = "Service Name" }},
                { "ServiceSubcategoryName", new GridColumnConfiguration { DisplayName = "Service Subcategory Name" }},
                { "OpenDate", new GridColumnConfiguration { DisplayName = "Open Date" }},
                { "LastUpdate", new GridColumnConfiguration { DisplayName = "Last Update" }},
                { "CloseDate", new GridColumnConfiguration { DisplayName = "Close Date" }}
            };
        }
    }
}
