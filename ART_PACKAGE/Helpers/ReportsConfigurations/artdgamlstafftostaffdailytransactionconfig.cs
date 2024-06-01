using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artdgamlstafftostaffdailytransactionconfig : ReportConfig
    {
        public artdgamlstafftostaffdailytransactionconfig()
        {






            SkipList = new List<string>() { };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){
{"EmployeeNumber" , new GridColumnConfiguration { DisplayName = "Employee Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EmployeeName" , new GridColumnConfiguration { DisplayName = "Employee Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Department" , new GridColumnConfiguration { DisplayName = "Department"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Division" , new GridColumnConfiguration { DisplayName = "Division"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Job" , new GridColumnConfiguration { DisplayName = "Job"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Grad" , new GridColumnConfiguration { DisplayName = "Grad"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Status" , new GridColumnConfiguration { DisplayName = "Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionReference" , new GridColumnConfiguration { DisplayName = "Transaction Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionType" , new GridColumnConfiguration { DisplayName = "Transaction Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionDate" , new GridColumnConfiguration { DisplayName = "Transaction Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BaseAmount" , new GridColumnConfiguration { DisplayName = "Base Amount"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BaseCurrency" , new GridColumnConfiguration { DisplayName = "Base Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EquivalentAmount" , new GridColumnConfiguration { DisplayName = "Equivalent Amount"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } ,
            { "EquivalentCurrency" , new GridColumnConfiguration { DisplayName = "Equivalent Currency", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
            { "OtherEmployeeNumber" , new GridColumnConfiguration { DisplayName = "Other Employee Number", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
            { "OtherEmployeeName" , new GridColumnConfiguration { DisplayName = "Other Employee Name", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
            { "OtherDepartment" , new GridColumnConfiguration { DisplayName = "Other Department", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
            { "OtherDivision" , new GridColumnConfiguration { DisplayName = "Other Division", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
            { "OtherJob" , new GridColumnConfiguration { DisplayName = "Other Job", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
            { "OtherGrad" , new GridColumnConfiguration { DisplayName = "Other Grad", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
            { "OtherStatus" , new GridColumnConfiguration { DisplayName = "Other Status", Format = "", Filter = "", Template = "", AggText = "", isLargeText = false } },
        };

            ReportTitle = "Staff To Staff Daily Transaction";
            ReportDescription = "presents all credit transactions for only staff to staff and for only 6 months (i.e. from system date to 6 months back) with the related information as below.";




        }
    }
}