using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtCaseIncidentsInfoConfig : ReportConfig
    {
        public ArtCaseIncidentsInfoConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID"}},
                    { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date"}},
                    { "Amount", new GridColumnConfiguration { DisplayName = "Amount"}},
                    { "DebtorBankName", new GridColumnConfiguration { DisplayName = "Debtor Bank Name"}},
                    { "DebtorBranchName", new GridColumnConfiguration { DisplayName = "Debtor Branch Name"}},
                    { "DebtorBranchBic", new GridColumnConfiguration { DisplayName = "Debtor Branch Bic"}},
                    { "DebtorAcctype", new GridColumnConfiguration { DisplayName = "Debtor Account Type"}},
                    { "DebtorAccno", new GridColumnConfiguration { DisplayName = "Debtor Account No"}},
                    { "DebtorName", new GridColumnConfiguration { DisplayName = "Debtor Name"}},
                    { "CreditorBankName", new GridColumnConfiguration { DisplayName = "Creditor Bank Name"}},
                    { "CreditorBranchName", new GridColumnConfiguration { DisplayName = "Creditor Branch Name"}},
                    { "CreditorBranchBic", new GridColumnConfiguration { DisplayName = "Creditor Branch Bic"}},
                    { "CreditorName", new GridColumnConfiguration { DisplayName = "Creditor Name"}},
                    { "CreditorAccType", new GridColumnConfiguration { DisplayName = "Creditor Account Type"}},
                    { "CreditorAccNo", new GridColumnConfiguration { DisplayName = "Creditor Account No"}},
                    { "CreditorNationalId", new GridColumnConfiguration { DisplayName = "Creditor National ID"}},
                    { "XIncidentId", new GridColumnConfiguration { DisplayName = "XIncident ID"}},
                    { "XSourceName", new GridColumnConfiguration { DisplayName = "XSource Name"}},
                    { "XPartynameMaxrank", new GridColumnConfiguration { DisplayName = "XParty Name Max Rank"}},
                    { "XIncidentDesc", new GridColumnConfiguration { DisplayName = "XIncident Desc"}},
            };

            ReportTitle = "ACH Case Details Report";
            ReportDescription = "";
            SkipList = new List<string>
            {"CaseRk" };
        }
    }
}
