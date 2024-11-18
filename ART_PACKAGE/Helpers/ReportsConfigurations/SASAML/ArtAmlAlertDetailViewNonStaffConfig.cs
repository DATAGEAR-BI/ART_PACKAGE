using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtAmlAlertDetailViewNonStaffConfig : ReportConfig
    {
        public ArtAmlAlertDetailViewNonStaffConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "AlertedEntityNumber", new GridColumnConfiguration { DisplayName = "Alerted Entity Number" } },
                { "AlertedEntityName", new GridColumnConfiguration { DisplayName = "Alerted Entity Name" } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "BranchNumber", new GridColumnConfiguration { DisplayName = "Branch Number" } },
                { "PartyTypeDesc", new GridColumnConfiguration { DisplayName = "Party Type Description" } },
                { "AlertId", new GridColumnConfiguration { DisplayName = "Alert ID" } },
                { "AlertDescription", new GridColumnConfiguration { DisplayName = "Alert Description" } },
                { "ActualValuesText", new GridColumnConfiguration { DisplayName = "Actual Values Text" } },
                { "AlertStatus", new GridColumnConfiguration { DisplayName = "Alert Status" } },
                { "AlertSubCat", new GridColumnConfiguration { DisplayName = "Alert Sub Cat" } },
                { "AlertTypeCd", new GridColumnConfiguration { DisplayName = "Alert Type Cd" } },
                { "ScenarioName", new GridColumnConfiguration { DisplayName = "Scenario Name" } },
                { "ScenarioId", new GridColumnConfiguration { DisplayName = "Scenario ID" } },
                { "MoneyLaunderingRiskScore", new GridColumnConfiguration { DisplayName = "Money Laundering Risk Score" } },
                { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date" } },
                { "RunDate", new GridColumnConfiguration { DisplayName = "Run Date" } },
                { "CloseDate", new GridColumnConfiguration { DisplayName = "Close Date" } },
                { "ClosedBy", new GridColumnConfiguration { DisplayName = "Closed By" } },
                { "ReportCloseRsn", new GridColumnConfiguration { DisplayName = "Report Close Reason" } },
                { "OwnerUserid", new GridColumnConfiguration { DisplayName = "Owner User ID" } },
                { "Queue", new GridColumnConfiguration { DisplayName = "Queue" } },
                { "PoliticallyExposedPersonInd", new GridColumnConfiguration { DisplayName = "Politically Exposed Person Ind" } },
                { "EmployeeInd", new GridColumnConfiguration { DisplayName = "Employee Ind" } },
                { "NumberOfComments", new GridColumnConfiguration { DisplayName = "Number Of Comments" } },
                { "LastComment", new GridColumnConfiguration { DisplayName = "Last Comment" } },
                { "InvestigationDays", new GridColumnConfiguration { DisplayName = "Investigation Days" } },
            };
            ReportTitle = "Alert Details Non Staff";

        }
    }
}
