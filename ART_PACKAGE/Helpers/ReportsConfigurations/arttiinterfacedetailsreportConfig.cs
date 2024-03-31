using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class arttiinterfacedetailsreportConfig : ReportConfig
    {
        public arttiinterfacedetailsreportConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"CorrelationId" , new GridColumnConfiguration { DisplayName = "Correlation ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DrSeq" , new GridColumnConfiguration { DisplayName = "Dr Seq"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CrSeq" , new GridColumnConfiguration { DisplayName = "Cr Seq"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Status" , new GridColumnConfiguration { DisplayName = "Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Error" , new GridColumnConfiguration { DisplayName = "Error"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Xref" , new GridColumnConfiguration { DisplayName = "X Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MstRef" , new GridColumnConfiguration { DisplayName = "Master Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EvtRef" , new GridColumnConfiguration { DisplayName = "Event Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ValueDate" , new GridColumnConfiguration { DisplayName = "Value Date"  , Format = "{0:dd/MM/yyyy}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"FromType" , new GridColumnConfiguration { DisplayName = "From Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ToType" , new GridColumnConfiguration { DisplayName = "To Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"FromCcy" , new GridColumnConfiguration { DisplayName = "From Ccy"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ToCcy" , new GridColumnConfiguration { DisplayName = "To Ccy"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"FromAmount" , new GridColumnConfiguration { DisplayName = "From Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ToAmount" , new GridColumnConfiguration { DisplayName = "To Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"FromAccount" , new GridColumnConfiguration { DisplayName = "From Account"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ToAccount" , new GridColumnConfiguration { DisplayName = "To Account"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"FromBranch" , new GridColumnConfiguration { DisplayName = "From Branch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ToBranch" , new GridColumnConfiguration { DisplayName = "To Branch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}