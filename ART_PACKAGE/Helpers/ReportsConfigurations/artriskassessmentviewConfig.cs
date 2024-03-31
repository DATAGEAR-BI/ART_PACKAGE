using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artriskassessmentviewConfig : ReportConfig
    {
        public artriskassessmentviewConfig()
        {

            SkipList = new List<string>(){ "RiskAssessmentDuration",
"VersionNumber",
"AssessmentCategoryCd",
"AssessmentSubcategoryCd" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"CreateDate" , new GridColumnConfiguration { DisplayName = "Create Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PartyNumber" , new GridColumnConfiguration { DisplayName = "Party Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PartyName" , new GridColumnConfiguration { DisplayName = "Party Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchName" , new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AssessmentTypeCd" , new GridColumnConfiguration { DisplayName = "Assessment Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RiskAssessmentId" , new GridColumnConfiguration { DisplayName = "Risk Assessment ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OwnerUserLongId" , new GridColumnConfiguration { DisplayName = "Owner"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreateUserId" , new GridColumnConfiguration { DisplayName = "Create By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RiskStatus" , new GridColumnConfiguration { DisplayName = "Risk Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RiskClass" , new GridColumnConfiguration { DisplayName = "Risk Classification"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ProposedRiskClass" , new GridColumnConfiguration { DisplayName = "Proposed Risk Classification"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}