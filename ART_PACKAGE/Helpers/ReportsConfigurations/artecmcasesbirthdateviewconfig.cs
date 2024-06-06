using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artecmcasesbirthdateviewconfig : ReportConfig
    {
        public artecmcasesbirthdateviewconfig()
        {
            ReportTitle = "Cases BirthDate Report";
            ReportDescription = "The related customer's date or year of birth as below";


            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"CaseId" , new GridColumnConfiguration { DisplayName = "Case ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerNumber" , new GridColumnConfiguration { DisplayName = "Customer Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerName" , new GridColumnConfiguration { DisplayName = "Customer Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreateDate" , new GridColumnConfiguration { DisplayName = "Create Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"IsDateAvailable" , new GridColumnConfiguration { DisplayName = "Is Date Available"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchName" , new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerDateOfBirth" , new GridColumnConfiguration { DisplayName = "Customer Date Of Birth"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchNumber" , new GridColumnConfiguration { DisplayName = "Branch Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };



        }
    }
}