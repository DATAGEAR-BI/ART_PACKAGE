using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class SlaEcmCasesViolatedConfig : ReportConfig
    {
        public SlaEcmCasesViolatedConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "CaseReportId", new GridColumnConfiguration { DisplayName = "Case/Report ID" } },
                { "ClientName", new GridColumnConfiguration { DisplayName = "Client Name" } },
                { "ClientNumber", new GridColumnConfiguration { DisplayName = "Client Number" } },
                { "CaseReportType", new GridColumnConfiguration { DisplayName = "Case/Report Type" } },
                { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date" } },
                { "CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status" } },
                { "LastActionBy", new GridColumnConfiguration { DisplayName = "Last Action By" } },
                { "LastActionDate", new GridColumnConfiguration { DisplayName = "Last Action Date" } },
                { "NumberOfActions", new GridColumnConfiguration { DisplayName = "Number Of Actions" } },
                { "ViolatedBy", new GridColumnConfiguration { DisplayName = "Violated By" } },
                { "ViolatedTime", new GridColumnConfiguration { DisplayName = "Violated Time" } },
                { "TotalTime", new GridColumnConfiguration { DisplayName = "Total Time" } },
                { "Formattedtime", new GridColumnConfiguration { DisplayName = "Formatted Time" } },
            };
            ReportTitle = "SLA Violated Cases Report";

        }
    }
}
