using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtStDgAmlPoliticallyExposedConfig : ReportConfig
    {

        public ArtStDgAmlPoliticallyExposedConfig()
        {
            SkipList = new List<string>(){ };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){
                {"Customer_Name" , new GridColumnConfiguration { DisplayName = "Customer Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"Customer_Number" , new GridColumnConfiguration { DisplayName = "Customer number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"Address" , new GridColumnConfiguration { DisplayName = "Address"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"Date_of_Birth" , new GridColumnConfiguration { DisplayName = "Date Of Birth"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"Politically_exposed" , new GridColumnConfiguration { DisplayName = "Politically Exposed"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"Citizenship" , new GridColumnConfiguration { DisplayName = "Citizenship"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"Identification_Document" , new GridColumnConfiguration { DisplayName = "Identification Document"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"Identification_Number" , new GridColumnConfiguration { DisplayName = "Identification Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"Identification_Issue_Date" , new GridColumnConfiguration { DisplayName = "Identification Issue Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"Identification_Expiry_Date" , new GridColumnConfiguration { DisplayName = "Identification Expiry Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"Employer_Name" , new GridColumnConfiguration { DisplayName = "Employee Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"Occupation" , new GridColumnConfiguration { DisplayName = "Occupation"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"Telephone" , new GridColumnConfiguration { DisplayName = "Telephone"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"Dealing_with_the_bank_since_date" , new GridColumnConfiguration { DisplayName = "Dealing With The Company Since Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
                {"Related_Accounts" , new GridColumnConfiguration { DisplayName = "Related Accounts"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                              
            };
            ReportTitle = "Politically Exposed Report";
            ReportDescription = "";

        }
    }
}
