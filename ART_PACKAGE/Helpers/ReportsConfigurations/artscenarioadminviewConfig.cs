using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artscenarioadminviewConfig : ReportConfig
    {
        public artscenarioadminviewConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"ScenarioName" , new GridColumnConfiguration { DisplayName = "Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ScenarioShortDesc" , new GridColumnConfiguration { DisplayName = "Short Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ScenarioDesc" , new GridColumnConfiguration { DisplayName = "Scenario Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ScenarioStatus" , new GridColumnConfiguration { DisplayName = "Scenario Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ScenarioCategory" , new GridColumnConfiguration { DisplayName = "Scenario Category"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ProductType" , new GridColumnConfiguration { DisplayName = "Product Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RiskFact" , new GridColumnConfiguration { DisplayName = "Risk Fact"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreateDate" , new GridColumnConfiguration { DisplayName = "Create Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"EndDate" , new GridColumnConfiguration { DisplayName = "End Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreateUserId" , new GridColumnConfiguration { DisplayName = "Create User ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ScenarioType" , new GridColumnConfiguration { DisplayName = "Scenario Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ScenarioFrequency" , new GridColumnConfiguration { DisplayName = "Scenario Frequency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ScenarioMessage" , new GridColumnConfiguration { DisplayName = "Scenario Message"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ObjectLevel" , new GridColumnConfiguration { DisplayName = "Object Level"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlarmType" , new GridColumnConfiguration { DisplayName = "Alarm Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlarmCategory" , new GridColumnConfiguration { DisplayName = "Alarm Category"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlarmSubcategory" , new GridColumnConfiguration { DisplayName = "Alarm Subcategory"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"DependedData" , new GridColumnConfiguration { DisplayName = "Depended Data"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ParmName" , new GridColumnConfiguration { DisplayName = "Parameter Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ParmValue" , new GridColumnConfiguration { DisplayName = "Parameter Value"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ParmDesc" , new GridColumnConfiguration { DisplayName = "Parameter Desc"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ParmTypeDesc" , new GridColumnConfiguration { DisplayName = "Parameter Type Desc"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ParamCondition" , new GridColumnConfiguration { DisplayName = "Parameter Condition"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ScorParmName" , new GridColumnConfiguration { DisplayName = "Score Parameter Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"ScorDependAttribute" , new GridColumnConfiguration { DisplayName = "Score Depend Attribute"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };



            ReportTitle = "Data Gear Aml Art Scenario Admin";
            ReportDescription = "Presents the art scenario admin details";



        }
    }
}