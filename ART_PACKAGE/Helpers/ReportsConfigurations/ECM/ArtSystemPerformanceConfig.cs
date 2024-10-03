using Data.Data.ECM;
using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtSystemPerformanceConfig : ReportConfig
    {
        public ArtSystemPerformanceConfig()
        {
            //ShowExportPdf = (s => true);
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID"}},
                    { "CaseType", new GridColumnConfiguration { DisplayName = "Case Type"}},
                    { "CaseDesc", new GridColumnConfiguration { DisplayName = "Case Description"}},
                    { "CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status"}},
                    { "Priority", new GridColumnConfiguration { DisplayName = "Priority"}},
                    { "HitsCount", new GridColumnConfiguration { DisplayName = "Hits Count"}},
                    { "TransactionDirection", new GridColumnConfiguration { DisplayName = "Transaction Direction"}},
                    { "TransactionType", new GridColumnConfiguration { DisplayName = "Transaction Type"}},
                    { "TransactionAmount", new GridColumnConfiguration { DisplayName = "Transaction Amount"}},
                    { "TransactionCurrency", new GridColumnConfiguration { DisplayName = "Transaction Currency"}},
                    { "SwiftReference", new GridColumnConfiguration { DisplayName = "Swift Reference"}},
                    { "ClientName", new GridColumnConfiguration { DisplayName = "Party Name"}},
                    { "IdentityNum", new GridColumnConfiguration { DisplayName = "Party Number"}},
                    { "LockedBy", new GridColumnConfiguration { DisplayName = "Locked By"}},
                    { "InvestrUserId", new GridColumnConfiguration { DisplayName = "Investigator"}},
                    { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date"}},
                    { "UpdateUserId", new GridColumnConfiguration { DisplayName = "Updated By"}},
                    { "EcmLastStatusDate", new GridColumnConfiguration { DisplayName = "Ecm Last Status Date"}},
                    { "DurationsInSeconds", new GridColumnConfiguration { DisplayName = "Durations In Seconds"}},
                    { "DurationsInMinutes", new GridColumnConfiguration { DisplayName = "Durations In Minutes"}},
                    { "DurationsInHours", new GridColumnConfiguration { DisplayName = "Durations In Hours"}},
                    { "DurationsInDays", new GridColumnConfiguration { DisplayName = "Durations In Days"}},
                    { "NumberOfComment", new GridColumnConfiguration { DisplayName = "Number of Comments"}},
                    { "NumberOfAttachments", new GridColumnConfiguration { DisplayName = "Number Of Attachments"}},
                    { "UpdatedDate", new GridColumnConfiguration { DisplayName = "Updated Date"}},
                    { "CreatedBy", new GridColumnConfiguration { DisplayName = "Created By"}},
                    { "LastComment", new GridColumnConfiguration { DisplayName = "Last Comment"}},
                    { nameof(ArtSystemPerformance.CreateUserId), new GridColumnConfiguration { DisplayName = "Create User Id"}},
            };

            ReportTitle = "System Performance Report";
            ReportDescription = "This report presents all sanction cases with the related information on case level as below";
            SkipList = new List<string>
            {
                   "LastStatus",
                   "CaseRk",
    "ValidFromDate",
    "LastCommentSubject"            };
        }
    }
}
