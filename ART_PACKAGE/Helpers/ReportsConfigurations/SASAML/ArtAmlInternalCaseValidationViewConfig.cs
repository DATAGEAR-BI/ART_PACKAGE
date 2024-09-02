using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtAmlInternalCaseValidationViewConfig:ReportConfig
    {

        public ArtAmlInternalCaseValidationViewConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID" } },
                { "TransactionType", new GridColumnConfiguration { DisplayName = "Transaction Type" } },
                { "EntityName", new GridColumnConfiguration { DisplayName = "Entity Name" } },
                { "EntityNumber", new GridColumnConfiguration { DisplayName = "Entity Number" } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "BranchNumber", new GridColumnConfiguration { DisplayName = "Branch Number" } },
                { "Region", new GridColumnConfiguration { DisplayName = "Region" } },
                { "CasePriority", new GridColumnConfiguration { DisplayName = "Case Priority" } },
                { "CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status" } },
                { "CaseCategory", new GridColumnConfiguration { DisplayName = "Case Category" } },
                { "CaseSubCategory", new GridColumnConfiguration { DisplayName = "Case Sub-Category" } },
                { "EntityLevel", new GridColumnConfiguration { DisplayName = "Entity Level" } },
                { "CreatedBy", new GridColumnConfiguration { DisplayName = "Created By" } },
                { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date" } },
                { "Owner", new GridColumnConfiguration { DisplayName = "Owner" } },
                { "ClosedDate", new GridColumnConfiguration { DisplayName = "Closed Date" } }
            };
            ReportTitle = "AML Internal Cases Validation";
            ReportDescription = "presents details about the AML Internal Cases reports to validate them with the related information";


        }
    }
}
