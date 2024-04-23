namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class arttiostransbygatewayreportConfig : ReportConfig
    {
        public arttiostransbygatewayreportConfig()
        {

            SkipList = new List<string>(){ "Descrip",
"Outccysei",
"SwBank",
"SwCtr",
"SwLoc",
"SwBranch",
"CusMnm",
"Gfcun",
"Country",
"Status",
"Relmstrref",
"Prodcode",
"Sovalue1",
"BhalfBrn",
"Typeflag" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"Fullname" , new GridColumnConfiguration { DisplayName = "Branch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Address1" , new GridColumnConfiguration { DisplayName = "Gateway Party"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Sovalue" , new GridColumnConfiguration { DisplayName = "Product"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MasterRef" , new GridColumnConfiguration { DisplayName = "Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Partptd" , new GridColumnConfiguration { DisplayName = "Participated?"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Revolving" , new GridColumnConfiguration { DisplayName = "Revlolving?"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Outstamt" , new GridColumnConfiguration { DisplayName = "Available Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Outstccy" , new GridColumnConfiguration { DisplayName = "Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OutstamtEgp" , new GridColumnConfiguration { DisplayName = "Available Amount EGP"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Amount" , new GridColumnConfiguration { DisplayName = "Transaction Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Ccy" , new GridColumnConfiguration { DisplayName = "Transaction Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AmountEgp" , new GridColumnConfiguration { DisplayName = "Transaction Amount EGP"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CtrctDate" , new GridColumnConfiguration { DisplayName = "Contract Issue Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RevNext" , new GridColumnConfiguration { DisplayName = "Next Revolve Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ExpiryDat" , new GridColumnConfiguration { DisplayName = "Expiry Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Descrip" , new GridColumnConfiguration { DisplayName = "Descrip"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Outccysei" , new GridColumnConfiguration { DisplayName = "Outccysei"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwBank" , new GridColumnConfiguration { DisplayName = "SwBank"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwCtr" , new GridColumnConfiguration { DisplayName = "SwCtr"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwLoc" , new GridColumnConfiguration { DisplayName = "SwLoc"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwBranch" , new GridColumnConfiguration { DisplayName = "SwBranch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CusMnm" , new GridColumnConfiguration { DisplayName = "CusMnm"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Gfcun" , new GridColumnConfiguration { DisplayName = "Gfcun"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Country" , new GridColumnConfiguration { DisplayName = "Country"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Status" , new GridColumnConfiguration { DisplayName = "Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Relmstrref" , new GridColumnConfiguration { DisplayName = "Relmstrref"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Prodcode" , new GridColumnConfiguration { DisplayName = "Prodcode"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Sovalue1" , new GridColumnConfiguration { DisplayName = "Sovalue1"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BhalfBrn" , new GridColumnConfiguration { DisplayName = "BhalfBrn"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Typeflag" , new GridColumnConfiguration { DisplayName = "Typeflag"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}