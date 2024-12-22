using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artsuspectdetailviewConfig : ReportConfig
    {
        public artsuspectdetailviewConfig()
        {

            SkipList = new List<string>(){ "CustIdentExpDate",
"CustIdentIssDate",
"EmprName",
"TelNo1" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"SuspectNumber" , new GridColumnConfiguration { DisplayName = "Suspect Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SuspectName" , new GridColumnConfiguration { DisplayName = "Suspect Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchName" , new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ProfileRisk" , new GridColumnConfiguration { DisplayName = "Profile Risk"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NumberOfAlarms" , new GridColumnConfiguration { DisplayName = "Number Of Alerts"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AgeOfOldestAlert" , new GridColumnConfiguration { DisplayName = "Age Of Oldest Alert"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OwnerUserName" , new GridColumnConfiguration { DisplayName = "Owner User Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustBirthDate" , new GridColumnConfiguration { DisplayName = "Customer Birth Of Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PoliticalExpPrsnInd" , new GridColumnConfiguration { DisplayName = "PEP"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RiskClassification" , new GridColumnConfiguration { DisplayName = "Risk Classification"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CitizenCntryName" , new GridColumnConfiguration { DisplayName = "Citizenship Country"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustIdentId" , new GridColumnConfiguration { DisplayName = "Customer Identification ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustIdentTypeDesc" , new GridColumnConfiguration { DisplayName = "Customer Identification Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OccupDesc" , new GridColumnConfiguration { DisplayName = "Occupation Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustSinceDate" , new GridColumnConfiguration { DisplayName = "Customer Since Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };


            ReportTitle = "DGAML Suspect Details";
            ReportDescription = "Presents suspect details";




        }
    }
}