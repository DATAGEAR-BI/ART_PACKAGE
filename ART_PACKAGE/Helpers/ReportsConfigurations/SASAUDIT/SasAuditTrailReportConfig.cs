using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class SasAuditTrailReportConfig : ReportConfig
    {
        public SasAuditTrailReportConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>()
    {
        {"UserId", new GridColumnConfiguration { DisplayName = "User ID", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
        {"UserName", new GridColumnConfiguration { DisplayName = "User Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
        {"Title", new GridColumnConfiguration { DisplayName = "Title", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
        {"ActionDate", new GridColumnConfiguration { DisplayName = "Action Date", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
        {"Description", new GridColumnConfiguration { DisplayName = "Description", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
        {"ActionType", new GridColumnConfiguration { DisplayName = "Action Type", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
        {"ActionOn", new GridColumnConfiguration { DisplayName = "Action On", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
        {"DateTime", new GridColumnConfiguration { DisplayName = "Date Time", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
        {"ObjectName", new GridColumnConfiguration { DisplayName = "Object Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
        {"ObjectType", new GridColumnConfiguration { DisplayName = "Object Type", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false }},
    };
        }
    }
}
