using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Controllers;
using ART_PACKAGE.Helpers.CSVMAppers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using Data.Data;
using System.Collections.Generic;

namespace ART_PACKAGE.Helpers.CSVMAppers
{
    public class ReportsConfig
    {
        public static readonly Dictionary<string, ReportConfig> CONFIG = new Dictionary<string, ReportConfig>
        {
            { nameof(AlertedEntityController).ToLower(),
                new ReportConfig{
                                        SkipList =null ,
                                        DisplayNames = new Dictionary<string, DisplayNameAndFormat>
                                                        {
                                                                { "CaseId", new DisplayNameAndFormat { DisplayName = "Case ID"}},
                                                                { "CreateDate", new DisplayNameAndFormat { DisplayName = "Case Creation Date"}},
                                                                { "Name", new DisplayNameAndFormat { DisplayName = "Entity Name"}},
                                                                { "PepInd", new DisplayNameAndFormat { DisplayName = "PEP Flag"}},

                                                        }
                                }
            },
            { nameof(SystemPerformanceController).ToLower(),
                new ReportConfig{
                                        SkipList =null ,
                                        DisplayNames = new Dictionary<string, DisplayNameAndFormat>
                                                        {
                                                                 { "CaseId", new DisplayNameAndFormat { DisplayName = "Case ID"}},
                                                                { "CaseType", new DisplayNameAndFormat { DisplayName = "Case Type"}},
                                                                { "CaseDesc", new DisplayNameAndFormat { DisplayName = "Case Description"}},
                                                                { "CaseStatus", new DisplayNameAndFormat { DisplayName = "Case Status"}},
                                                                { "Priority", new DisplayNameAndFormat { DisplayName = "Priority"}},
                                                                { "HitsCount", new DisplayNameAndFormat { DisplayName = "Hits Count"}},
                                                                { "TransactionDirection", new DisplayNameAndFormat { DisplayName = "Transaction Direction"}},
                                                                { "TransactionType", new DisplayNameAndFormat { DisplayName = "Transaction Type"}},
                                                                { "TransactionAmount", new DisplayNameAndFormat { DisplayName = "Transaction Amount"}},
                                                                { "TransactionCurrency", new DisplayNameAndFormat { DisplayName = "Transaction Currency"}},
                                                                { "SwiftReference", new DisplayNameAndFormat { DisplayName = "Swift Reference"}},
                                                                { "ClientName", new DisplayNameAndFormat { DisplayName = "Party Name"}},
                                                                { "IdentityNum", new DisplayNameAndFormat { DisplayName = "Party Number"}},
                                                                { "LockedBy", new DisplayNameAndFormat { DisplayName = "Locked By"}},
                                                                { "CreateDate", new DisplayNameAndFormat { DisplayName = "Create Date"}},
                                                                { "UpdateUserId", new DisplayNameAndFormat { DisplayName = "Updated By"}},
                                                                { "EcmLastStatusDate", new DisplayNameAndFormat { DisplayName = "Ecm Last Status Date"}},
                                                                { "DurationsInSeconds", new DisplayNameAndFormat { DisplayName = "Durations In Seconds"}},
                                                                { "DurationsInMinutes", new DisplayNameAndFormat { DisplayName = "Durations In Minutes"}},
                                                                { "DurationsInHours", new DisplayNameAndFormat { DisplayName = "Durations In Hours"}},
                                                                { "DurationsInDays", new DisplayNameAndFormat { DisplayName = "Durations In Days"}}

                                                        }
                                }
            },
            {
                nameof(ReportController).ToLower(),new ReportConfig
                {
                   SkipList =  new List<string>()
            {
                  nameof(ArtSavedCustomReport.User),
                  nameof(ArtSavedCustomReport.UserId),
                nameof(ArtSavedCustomReport.Schema),
                nameof(ArtSavedCustomReport.Columns),
                nameof(ArtSavedCustomReport.Charts),

            }
    }
            },
        };

    }
}

