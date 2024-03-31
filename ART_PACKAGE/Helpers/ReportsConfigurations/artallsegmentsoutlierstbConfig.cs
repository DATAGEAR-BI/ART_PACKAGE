using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artallsegmentsoutlierstbConfig : ReportConfig
    {
        public artallsegmentsoutlierstbConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"SegmentSorted" , new GridColumnConfiguration { DisplayName = "Segment Sorted"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PartyTypeDesc" , new GridColumnConfiguration { DisplayName = "Party Type Desc"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MonthKey" , new GridColumnConfiguration { DisplayName = "Month Key"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Amount" , new GridColumnConfiguration { DisplayName = "Amount"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Feature" , new GridColumnConfiguration { DisplayName = "Feature"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchName" , new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchNumber" , new GridColumnConfiguration { DisplayName = "Branch Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PartyName" , new GridColumnConfiguration { DisplayName = "Party Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UpperOutlierLimit" , new GridColumnConfiguration { DisplayName = "Upper Outlier Limit"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"PartyNumber" , new GridColumnConfiguration { DisplayName = "Party Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}