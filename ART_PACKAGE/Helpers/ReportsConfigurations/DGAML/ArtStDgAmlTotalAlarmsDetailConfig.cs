using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtStDgAmlTotalAlarmsDetailConfig:ReportConfig
    {

        public ArtStDgAmlTotalAlarmsDetailConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){
                {"Alarm_ID" , new GridColumnConfiguration { DisplayName = "Alarm ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"Alarm_level" , new GridColumnConfiguration { DisplayName = "Alarm Level"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"Alarm_Status" , new GridColumnConfiguration { DisplayName = "Alarm Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"Alarm_Message" , new GridColumnConfiguration { DisplayName = "Alarm Message"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"Scenario_Name" , new GridColumnConfiguration { DisplayName = "Scenario Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"Scenario_Description" , new GridColumnConfiguration { DisplayName = "Scenario Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"Run_date" , new GridColumnConfiguration { DisplayName = "Run Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"Closed_USER_ID" , new GridColumnConfiguration { DisplayName = "Closed User ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"close_date" , new GridColumnConfiguration { DisplayName = "Close Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"close_reason" , new GridColumnConfiguration { DisplayName = "Close Reason"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"customer_name" , new GridColumnConfiguration { DisplayName = "Customer Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"customer_number" , new GridColumnConfiguration { DisplayName = "Customer Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"customer_identification_id" , new GridColumnConfiguration { DisplayName = "Customer Identification ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"customer_date_of_birth" , new GridColumnConfiguration { DisplayName = "Customer Date Of Birth"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"PHONE_NUMBER" , new GridColumnConfiguration { DisplayName = "Phone Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"MONEY_LAUNDERING_RISK_SCORE" , new GridColumnConfiguration { DisplayName = "Money Laundering Risk Score"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"occupation_desc" , new GridColumnConfiguration { DisplayName = "Occupation Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"CUSTOMER_SINCE_DATE" , new GridColumnConfiguration { DisplayName = "Customer Since Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"Loan_Numbers" , new GridColumnConfiguration { DisplayName = "Loan Numbers"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },



            };
            ReportTitle = "Total Alarm Detail";

        }
    }
}
