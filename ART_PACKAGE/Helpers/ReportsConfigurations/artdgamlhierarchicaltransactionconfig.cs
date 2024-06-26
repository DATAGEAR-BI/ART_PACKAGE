using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artdgamlhierarchicaltransactionconfig : ReportConfig
    {
        public artdgamlhierarchicaltransactionconfig()
        {




            SkipList = new List<string>() { };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){
{"EmployeeNumber" , new GridColumnConfiguration { DisplayName = "Employee Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CustomerId" , new GridColumnConfiguration { DisplayName = "Customer ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EmployeeName" , new GridColumnConfiguration { DisplayName = "Employee Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Role" , new GridColumnConfiguration { DisplayName = "Role"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"StaffRelativeInd" , new GridColumnConfiguration { DisplayName = "Staff Relative Ind"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Department" , new GridColumnConfiguration { DisplayName = "Department"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Division" , new GridColumnConfiguration { DisplayName = "Division"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Job" , new GridColumnConfiguration { DisplayName = "Job"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Grad" , new GridColumnConfiguration { DisplayName = "Grad"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"Status" , new GridColumnConfiguration { DisplayName = "Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionReference" , new GridColumnConfiguration { DisplayName = "Transaction Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionType" , new GridColumnConfiguration { DisplayName = "Transaction Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"TransactionDate" , new GridColumnConfiguration { DisplayName = "Transaction Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BaseAmountEgp" , new GridColumnConfiguration { DisplayName = "Base Amount(Egp)"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EquivalentAmount" , new GridColumnConfiguration { DisplayName = "Equivalent Amount"  , Format = "{0:n2}"  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EquivalentCurrency" , new GridColumnConfiguration { DisplayName = "Equivalent Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
        };

            ReportTitle = "Hierarchical Transaction";
            ReportDescription = "presents all transactions with staff hierarchy i.e. (subordinates not have access to managers transactions) whereas Regional Delegate can not excluded any staff, Group Head not have access to see Regional Delegate, Head of Support not have the access to see the accounts by Heads of Retail,SMEs and Corporate, Group Head, and Regional Delegate, and Branch Manager not have the access to see the accounts Heads of Retail,SMEs and Corporate, Group Head, Regional Delegate, and Head Of support as below";






        }
    }
}