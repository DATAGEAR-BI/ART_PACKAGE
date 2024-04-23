namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artdgamlcasedetailviewConfig : ReportConfig
    {
        public artdgamlcasedetailviewConfig()
        {

            SkipList = new List<string>(){ "CaseStatusCode",
"CaseCategoryCode",
"CaseSubCategoryCode" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"CaseId" , new GridColumnConfiguration { DisplayName = "Case ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EntityName" , new GridColumnConfiguration { DisplayName = "Entity Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EntityNumber" , new GridColumnConfiguration { DisplayName = "Entity Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchName" , new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CasePriority" , new GridColumnConfiguration { DisplayName = "Case Priority"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CaseStatus" , new GridColumnConfiguration { DisplayName = "Case Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CaseCategory" , new GridColumnConfiguration { DisplayName = "Case Category"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EntityLevel" , new GridColumnConfiguration { DisplayName = "Entity Level"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreatedBy" , new GridColumnConfiguration { DisplayName = "Created By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreateDate" , new GridColumnConfiguration { DisplayName = "Create Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };







        }
    }
}