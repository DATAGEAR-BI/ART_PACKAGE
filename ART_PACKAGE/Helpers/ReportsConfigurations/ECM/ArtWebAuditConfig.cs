using Data.Data.ECM;
using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtWebAuditConfig : ReportConfig
    {
        public ArtWebAuditConfig()
        {
           DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "RequestDate", new GridColumnConfiguration { DisplayName = "Request Date" } },
                { "MatchStatus", new GridColumnConfiguration { DisplayName = "Match Status" } },
                { "Name", new GridColumnConfiguration { DisplayName = "Name" } },
                { "Branch", new GridColumnConfiguration { DisplayName = "Branch" } },
                { "SearchUser", new GridColumnConfiguration { DisplayName = "Search User" } }
            };
        ReportTitle = "Web Search Audit Report";
            ReportDescription = "This report presents web search attempts with the related information below";
            SkipList = new List<string>
            {       };
        }
    }
}
