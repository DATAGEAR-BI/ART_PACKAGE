namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class arttichargesdetailsreportConfig : ReportConfig
    {
        public arttichargesdetailsreportConfig()
        {

            SkipList = new List<string>(){ "Gfcun",
"CusMnm",
"SwBank",
"SwCtr",
"SwLoc",
"SwBranch",
"Reduction",
"TaxAmt",
"TaxCcy",
"TaxFor",
"RefnoPfix1",
"RefnoSerl1",
"StartDate",
"StartTime",
"BhalfBrn",
"SchCcySpt",
"SchCcySei" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"Hvbad1" , new GridColumnConfiguration { DisplayName = "Branch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Longname" , new GridColumnConfiguration { DisplayName = "Product"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MasterRef" , new GridColumnConfiguration { DisplayName = "Master Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Address1" , new GridColumnConfiguration { DisplayName = "Customer"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Status" , new GridColumnConfiguration { DisplayName = "Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Descr" , new GridColumnConfiguration { DisplayName = "Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ParticChg" , new GridColumnConfiguration { DisplayName = "Share with Principal"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EventRef" , new GridColumnConfiguration { DisplayName = "Event Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Action" , new GridColumnConfiguration { DisplayName = "Action"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CgbasAmt" , new GridColumnConfiguration { DisplayName = "Basis Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ChgbasCcy" , new GridColumnConfiguration { DisplayName = "Basis Amount Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ChgbasAmtEgp" , new GridColumnConfiguration { DisplayName = "Basis Amount EGP"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SchAmt" , new GridColumnConfiguration { DisplayName = "Charge Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SchCcy" , new GridColumnConfiguration { DisplayName = "Charge Amount Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SchAmtEgp" , new GridColumnConfiguration { DisplayName = "Charge Amount EGP"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SchRate" , new GridColumnConfiguration { DisplayName = "Rate"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ChgDue" , new GridColumnConfiguration { DisplayName = "Amount to Collect"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ChgCcy" , new GridColumnConfiguration { DisplayName = "Amount to Collect Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ChgDueEgp" , new GridColumnConfiguration { DisplayName = "Amount to Collect EGP"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Gfcun" , new GridColumnConfiguration { DisplayName = "Gfcun"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CusMnm" , new GridColumnConfiguration { DisplayName = "CusMnm"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwBank" , new GridColumnConfiguration { DisplayName = "SwBank"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwCtr" , new GridColumnConfiguration { DisplayName = "SwCtr"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwLoc" , new GridColumnConfiguration { DisplayName = "SwLoc"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SwBranch" , new GridColumnConfiguration { DisplayName = "SwBranch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Reduction" , new GridColumnConfiguration { DisplayName = "Reduction"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TaxAmt" , new GridColumnConfiguration { DisplayName = "TaxAmt"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TaxCcy" , new GridColumnConfiguration { DisplayName = "TaxCcy"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TaxFor" , new GridColumnConfiguration { DisplayName = "TaxFor"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RefnoPfix1" , new GridColumnConfiguration { DisplayName = "RefnoPfix1"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RefnoSerl1" , new GridColumnConfiguration { DisplayName = "RefnoSerl1"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"StartDate" , new GridColumnConfiguration { DisplayName = "StartDate"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"StartTime" , new GridColumnConfiguration { DisplayName = "StartTime"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BhalfBrn" , new GridColumnConfiguration { DisplayName = "BhalfBrn"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SchCcySpt" , new GridColumnConfiguration { DisplayName = "SchCcySpt"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"SchCcySei" , new GridColumnConfiguration { DisplayName = "SchCcySei"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}