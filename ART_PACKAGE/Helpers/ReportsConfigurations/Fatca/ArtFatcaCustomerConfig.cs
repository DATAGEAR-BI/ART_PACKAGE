using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtFatcaCustomerConfig :ReportConfig
    {
        public ArtFatcaCustomerConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID" } },
                { "CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status" } },
                { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date" } },
                { "CustKey", new GridColumnConfiguration { DisplayName = "Cust Key" } },
                { "CustomerId", new GridColumnConfiguration { DisplayName = "Customer Id" } },
                { "CustomerName", new GridColumnConfiguration { DisplayName = "Customer Name" } },
                { "BranchName", new GridColumnConfiguration { DisplayName = "Branch Name" } },
                { "CustClsFlag", new GridColumnConfiguration { DisplayName = "Cust Cls Flag" } },
                { "MainNationality", new GridColumnConfiguration { DisplayName = "Main Nationality" } },
                { "SignW8", new GridColumnConfiguration { DisplayName = "SignW8" } },
                { "SignW9", new GridColumnConfiguration { DisplayName = "SignW9" } },
                { "W9SignDate", new GridColumnConfiguration { DisplayName = "W9Sign Date" } },
                { "W8SignDate", new GridColumnConfiguration { DisplayName = "W8Sign Date" } },



            };
            ReportTitle = "FATCA Customers Details";
            ReportDescription = "Presents all FATCA Customers details";
        }
    }
}