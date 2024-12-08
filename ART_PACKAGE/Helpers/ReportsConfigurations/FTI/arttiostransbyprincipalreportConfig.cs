using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class arttiostransbyprincipalreportConfig : ReportConfig
    {
        public arttiostransbyprincipalreportConfig()
        {

            SkipList = new List<string>(){ "Code79",
"Outccyspt",
"Outccysei",
"Fullname",
"SwBank",
"SwCtr",
"SwLoc",
"SwBranch",
"CusMnm",
"Gfcun",
"Country",
"Status",
"Outccyced",
"CcyCed",
"Relmstrref",
"Sovalue1",
"Typeflag" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"BhalfBrn" , new GridColumnConfiguration { DisplayName = "Behalf Of Branch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Address1" , new GridColumnConfiguration { DisplayName = "Principal Party"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Sovalue" , new GridColumnConfiguration { DisplayName = "Product"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Descrip" , new GridColumnConfiguration { DisplayName = "Product Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MasterRef" , new GridColumnConfiguration { DisplayName = "Master Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Partptd" , new GridColumnConfiguration { DisplayName = "Participated?"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Revolving" , new GridColumnConfiguration { DisplayName = "Revolving?"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Outstamt" , new GridColumnConfiguration { DisplayName = "Avaialble Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Outstccy" , new GridColumnConfiguration { DisplayName = "Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OutstamtEgp" , new GridColumnConfiguration { DisplayName = "Avaialble Amount Egp"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Amount" , new GridColumnConfiguration { DisplayName = "Transaction Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Ccy" , new GridColumnConfiguration { DisplayName = "Transaction Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AmountEgp" , new GridColumnConfiguration { DisplayName = "Transaction Amount Egp"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CtrctDate" , new GridColumnConfiguration { DisplayName = "Contrace Issue Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RevNext" , new GridColumnConfiguration { DisplayName = "Next Revolve Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ExpiryDat" , new GridColumnConfiguration { DisplayName = "Expiry Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Code79" , new GridColumnConfiguration { DisplayName = "Code79"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Outccyspt" , new GridColumnConfiguration { DisplayName = "Outccyspt"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Outccysei" , new GridColumnConfiguration { DisplayName = "Outccysei"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Fullname" , new GridColumnConfiguration { DisplayName = "Full Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwBank" , new GridColumnConfiguration { DisplayName = "SwBank"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwCtr" , new GridColumnConfiguration { DisplayName = "SwCtr"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwLoc" , new GridColumnConfiguration { DisplayName = "SwLoc"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwBranch" , new GridColumnConfiguration { DisplayName = "SwBranch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CusMnm" , new GridColumnConfiguration { DisplayName = "CusMnm"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Gfcun" , new GridColumnConfiguration { DisplayName = "Gfcun"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Country" , new GridColumnConfiguration { DisplayName = "Country"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Status" , new GridColumnConfiguration { DisplayName = "Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Outccyced" , new GridColumnConfiguration { DisplayName = "Outccyced"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CcyCed" , new GridColumnConfiguration { DisplayName = "CcyCed"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Relmstrref" , new GridColumnConfiguration { DisplayName = "Relmstrref"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Sovalue1" , new GridColumnConfiguration { DisplayName = "Sovalue1"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Typeflag" , new GridColumnConfiguration { DisplayName = "Typeflag"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };



            ReportTitle = "OS Transactions By Principal Report";
            ReportDescription = "This report produces list information for master records that are not yet booked off or cancelled";



        }
    }
}