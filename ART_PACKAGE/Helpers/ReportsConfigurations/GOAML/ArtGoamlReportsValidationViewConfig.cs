using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtGoamlReportsValidationViewConfig:ReportConfig
    {

        public ArtGoamlReportsValidationViewConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "Id", new GridColumnConfiguration { DisplayName = "Report ID" } },
                { "ReportCode", new GridColumnConfiguration { DisplayName = "Report Type" } },
                { "ReportIndicator", new GridColumnConfiguration { DisplayName = "Report / Indicator" } },
                { "CrimeProduct", new GridColumnConfiguration { DisplayName = "Crime Product",Template="mixedArabicAndEnglish" } },
                { "EmployeeInd", new GridColumnConfiguration { DisplayName = "Staff Indicator" } },
                { "Account", new GridColumnConfiguration { DisplayName = "Account" } },
                { "AccountType", new GridColumnConfiguration { DisplayName = "Customer Account Type" } },
                { "ReportStatusCode", new GridColumnConfiguration { DisplayName = "Report Status" } },
                { "TransactionNumber", new GridColumnConfiguration { DisplayName = "Transaction Number" } },
                { "ReportDate", new GridColumnConfiguration { DisplayName = "Reported Date" } },
                { "ReportCreatedDate", new GridColumnConfiguration { DisplayName = "Create Date" } },
                { "ReportClosedDate", new GridColumnConfiguration { DisplayName = "Close Date" } },
                { "SubmissionDate", new GridColumnConfiguration { DisplayName = "Submission Date" } },
                { "EntityReference", new GridColumnConfiguration { DisplayName = "Entity Reference Number" } },
                { "FiuRefNumber", new GridColumnConfiguration { DisplayName = "FIU Reference Number" } },
                { "PartyName", new GridColumnConfiguration { DisplayName = "Party Name" } },
                { "PartyID", new GridColumnConfiguration { DisplayName = "Party ID" } },
                { "PartyNumber", new GridColumnConfiguration { DisplayName = "Party Number" } },
                { "Branch", new GridColumnConfiguration { DisplayName = "Branch" } },
                { "Region", new GridColumnConfiguration { DisplayName = "Region" } },
                { "Activity", new GridColumnConfiguration { DisplayName = "Activity" } }
            };
            ReportTitle = "GOAML Reports Validation Details";
            ReportDescription = "presents details about the GOAML summary reports to validate them with the related information";

        }
    }
}
