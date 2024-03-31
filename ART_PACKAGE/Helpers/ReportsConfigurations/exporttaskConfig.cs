using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class exporttaskConfig : ReportConfig
    {
        public exporttaskConfig()
        {

            SkipList = new List<string>(){ "Mails",
"Name",
"UserId",
"Deleted",
"ParametersJson",
"Day",
"Month",
"EndOfMonth",
"Hour",
"Minute",
"CornExpression",
"Deleted",
"DayOfWeek",
"Id" };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){ {"Period" , new GridColumnConfiguration { DisplayName = "Period"  , Format = ""  ,  Filter = "" , Template = "TaskPeriodTemplate" , AggText = ""  , isLargeText = false   } },
{"DisplayName" , new GridColumnConfiguration { DisplayName = "Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
{"MailsSerialized" , new GridColumnConfiguration { DisplayName = "Mails"  , Format = ""  ,  Filter = "" , Template = "TaskMails" , AggText = ""  , isLargeText = false   } } };

            ContainsActions = true;

            Actions = new List<GridButton>(){ new GridButton { action = "editTask" , text = "Edit" ,icon = "k-i-edit" },
new GridButton { action = "deleteTask" , text = "Delete" ,icon = "k-i-trash" },
new GridButton { action = "runNow" , text = "Run Now" ,icon = "k-i-video-external" } };

            Toolbar = new List<GridButton>() { new GridButton { action = "addTask", text = "Add New Task", icon = "k-i-edit" } };

        }
    }
}