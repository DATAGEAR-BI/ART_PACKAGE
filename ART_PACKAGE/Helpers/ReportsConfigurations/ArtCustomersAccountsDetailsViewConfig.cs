using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtCustomersAccountsDetailsViewConfig : ReportConfig
    {
        public ArtCustomersAccountsDetailsViewConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ 
                {"Cid" , new GridColumnConfiguration { DisplayName = "CID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"IdentificationNumber" , new GridColumnConfiguration { DisplayName = "Identification Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"CustIdentExpDate" , new GridColumnConfiguration { DisplayName = "Cust Ident Exp Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"DateOfBirthOrIncorporation" , new GridColumnConfiguration { DisplayName = "Date Of Birth Or Incorporation"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"PhoneNumber" , new GridColumnConfiguration { DisplayName = "Phone Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"KraPin" , new GridColumnConfiguration { DisplayName = "KRA Pin"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"ForeignTaxIdentificationNumber" , new GridColumnConfiguration { DisplayName = "Foreign Tax Identification Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"Nationality" , new GridColumnConfiguration { DisplayName = "Nationality"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"Residence" , new GridColumnConfiguration { DisplayName = "Residence"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"RiskStatusOrRiskClassification" , new GridColumnConfiguration { DisplayName = "Risk Status Or Risk Classification"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"PepFlag" , new GridColumnConfiguration { DisplayName = "Pep Flag"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"NatureOfBusiness" , new GridColumnConfiguration { DisplayName = "Nature Of Business"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"EmailAddress" , new GridColumnConfiguration { DisplayName = "Email Address"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"DirectorIdentificationNumber" , new GridColumnConfiguration { DisplayName = "Director Identification Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"DirectorNationality" , new GridColumnConfiguration { DisplayName = "Director Nationality"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"DirectorDateOfBirth" , new GridColumnConfiguration { DisplayName = "Director Date Of Birth"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"DirectorPhoneNumber" , new GridColumnConfiguration { DisplayName = "Director Phone Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"DirectorPin" , new GridColumnConfiguration { DisplayName = "Director Pin"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"DirectorOccupation" , new GridColumnConfiguration { DisplayName = "Director Occupation"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"SignatoryIdentificationNumber" , new GridColumnConfiguration { DisplayName = "Signatory Identification Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"SignatoryNationality" , new GridColumnConfiguration { DisplayName = "Signatory Nationality"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"SignatoryDateOfBirth" , new GridColumnConfiguration { DisplayName = "Signatory Date Of Birth"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"SignatoryPhoneNumber" , new GridColumnConfiguration { DisplayName = "Signatory Phone Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"SignatoryPin" , new GridColumnConfiguration { DisplayName = "Signatory Pin"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"SignatoryOccupation" , new GridColumnConfiguration { DisplayName = "Signatory Occupation"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"UboName" , new GridColumnConfiguration { DisplayName = "UBO Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"UboId" , new GridColumnConfiguration { DisplayName = "UBO ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"IdentificationDocumentName" , new GridColumnConfiguration { DisplayName = "Identification Document Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"Title" , new GridColumnConfiguration { DisplayName = "Title"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"CustomerType" , new GridColumnConfiguration { DisplayName = "Customer Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"Industry" , new GridColumnConfiguration { DisplayName = "Industry"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"Sector" , new GridColumnConfiguration { DisplayName = "Sector"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"AccountName" , new GridColumnConfiguration { DisplayName = "Account Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"AccountNumber" , new GridColumnConfiguration { DisplayName = "Account Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"DateAccountOpened" , new GridColumnConfiguration { DisplayName = "Date Account Opened"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"AccountStatus" , new GridColumnConfiguration { DisplayName = "Account Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"DirectorName" , new GridColumnConfiguration { DisplayName = "Director Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"Branch" , new GridColumnConfiguration { DisplayName = "Branch"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"SignatoryName" , new GridColumnConfiguration { DisplayName = "Signatory Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
            };
            ReportTitle = "Customers Accounts Details Report";






        }
    }
}