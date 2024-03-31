using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artuserperformanceConfig : ReportConfig
    {
        public artuserperformanceConfig()
        {

            SkipList = new List<string>(){ "CaseRk",
"ValidFromDate",
"CreateUserId" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"CaseId" , new GridColumnConfiguration { DisplayName = "Case ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CaseTypeCd" , new GridColumnConfiguration { DisplayName = "Case Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CaseDesc" , new GridColumnConfiguration { DisplayName = "Case Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CaseStatus" , new GridColumnConfiguration { DisplayName = "Case Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Priority" , new GridColumnConfiguration { DisplayName = "Priority"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LockedBy" , new GridColumnConfiguration { DisplayName = "Locked By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreateDate" , new GridColumnConfiguration { DisplayName = "Create Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UpdateUserId" , new GridColumnConfiguration { DisplayName = "Updated By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AsssignedTime" , new GridColumnConfiguration { DisplayName = "Assigned Time"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ActionUser" , new GridColumnConfiguration { DisplayName = "Action User"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Action" , new GridColumnConfiguration { DisplayName = "Action"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ReleasedDate" , new GridColumnConfiguration { DisplayName = "Released Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DurationsInSeconds" , new GridColumnConfiguration { DisplayName = "Durations In Seconds"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DurationsInMinutes" , new GridColumnConfiguration { DisplayName = "Durations In Minutes"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DurationsInHours" , new GridColumnConfiguration { DisplayName = "Durations In Hours"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DurationsInDays" , new GridColumnConfiguration { DisplayName = "Durations In Days"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}