using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artsystemperformanceconfig : ReportConfig
    {
        public artsystemperformanceconfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>
            {
                    { "CaseId", new GridColumnConfiguration { DisplayName = "Case ID"}},
                    { "CaseType", new GridColumnConfiguration { DisplayName = "Case Type"}},
                    { "CaseDescription", new GridColumnConfiguration { DisplayName = "Case Description"}},
                    { "CaseStatus", new GridColumnConfiguration { DisplayName = "Case Status"}},
                    { "Priority", new GridColumnConfiguration { DisplayName = "Priority"}},
                    { "CustomerNumber", new GridColumnConfiguration { DisplayName = "Customer Number"}},
                    { "CustomerName", new GridColumnConfiguration { DisplayName = "Customer Name"}},
                    { "LockedBy", new GridColumnConfiguration { DisplayName = "Locked By"}},
                    { "CreateDate", new GridColumnConfiguration { DisplayName = "Create Date"}},
                    { "PrimaryOwner", new GridColumnConfiguration { DisplayName = "Primary Owner"}},
                    { "UpdatedBy", new GridColumnConfiguration { DisplayName = "Updated By"}},
                    { "LastStatusDate", new GridColumnConfiguration { DisplayName = "Last Status Date"}},
                    { "LastComment", new GridColumnConfiguration { DisplayName = "Last Comment"}},
                    { "LastCommentSubject", new GridColumnConfiguration { DisplayName = "Last Comment Subject"}},
                    { "UpdatedDate", new GridColumnConfiguration { DisplayName = "Updated Date"}},
                    { "NumberOfComments", new GridColumnConfiguration { DisplayName = "Number Of Comments"}},
                    { "NumberOfAttachments", new GridColumnConfiguration { DisplayName = "Number Of Attachments"}},
                    { "DurationsInSeconds", new GridColumnConfiguration { DisplayName = "Durations In Seconds"}},
                    { "DurationsInMinutes", new GridColumnConfiguration { DisplayName = "Durations In Minutes"}},
                    { "DurationsInHours", new GridColumnConfiguration { DisplayName = "Durations In Hours"}},
                    { "DurationsInDays", new GridColumnConfiguration { DisplayName = "Durations In Days"}},
            };

            ReportTitle = "System Performance Report";
            ReportDescription = "This report presents all sanction cases with the related information on case level as below";
            SkipList = new List<string>
            {"CreateBy"};
        }
    }
}
