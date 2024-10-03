using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class artdgamltriageviewConfig : ReportConfig
    {
        public artdgamltriageviewConfig()
        {



            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"AlertedEntityName" , new GridColumnConfiguration { DisplayName = "Alerted Entity Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlertedEntityNumber" , new GridColumnConfiguration { DisplayName = "Alerted Entity Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlertedEntityLevel" , new GridColumnConfiguration { DisplayName = "Alerted Entity Level"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"BranchName" , new GridColumnConfiguration { DisplayName = "Branch Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlertStatus" , new GridColumnConfiguration { DisplayName = "Alert Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"RiskScore" , new GridColumnConfiguration { DisplayName = "Risk Score"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"QueueCode" , new GridColumnConfiguration { DisplayName = "Queue Code"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"OwnerUserid" , new GridColumnConfiguration { DisplayName = "Owner User ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"AlertsCount" , new GridColumnConfiguration { DisplayName = "Alerts Count"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"InvestigationDays" , new GridColumnConfiguration { DisplayName = "Investigation Days"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"LastComment" , new GridColumnConfiguration { DisplayName = "Last Comment"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"CreatedBy" , new GridColumnConfiguration { DisplayName = "Created By"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NumberOfComments" , new GridColumnConfiguration { DisplayName = "Number Of Comments"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"NumberOfAttachments" , new GridColumnConfiguration { DisplayName = "Number Of Attachments"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"UpdatedDate" , new GridColumnConfiguration { DisplayName = "Updated Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } } };

            ReportTitle = "Data Gear AML Triage Report";
            ReportDescription = "Presents each entity with the related active alerts count";





        }
    }
}