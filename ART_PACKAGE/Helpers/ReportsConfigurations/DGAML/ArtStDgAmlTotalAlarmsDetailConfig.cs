using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtStDgAmlTotalAlarmsDetailConfig:ReportConfig
    {

        public ArtStDgAmlTotalAlarmsDetailConfig()
        {
            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){
                {"ALARM_ID" , new GridColumnConfiguration { DisplayName = "Alarm ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"ALARM_LEVEL" , new GridColumnConfiguration { DisplayName = "Alarm Level"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"ALARM_STATUS" , new GridColumnConfiguration { DisplayName = "Alarm Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"ALARM_MESSAGE" , new GridColumnConfiguration { DisplayName = "Alarm Message"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"SCENARIO_NAME" , new GridColumnConfiguration { DisplayName = "Scenario Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"SCENARIO_DESCRIPTION" , new GridColumnConfiguration { DisplayName = "Scenario Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"RUN_DATE" , new GridColumnConfiguration { DisplayName = "Run Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"CLOSED_USER_ID" , new GridColumnConfiguration { DisplayName = "Closed User ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"CLOSE_DATE" , new GridColumnConfiguration { DisplayName = "Close Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"CLOSE_REASON" , new GridColumnConfiguration { DisplayName = "Close Reason"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"CUSTOMER_NAME" , new GridColumnConfiguration { DisplayName = "Customer Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"CUSTOMER_NUMBER" , new GridColumnConfiguration { DisplayName = "Customer Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"CUSTOMER_IDENTIFICATION_ID" , new GridColumnConfiguration { DisplayName = "Customer Identification ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"CUSTOMER_DATE_OF_BIRTH" , new GridColumnConfiguration { DisplayName = "Customer Date Of Birth"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"PHONE_NUMBER" , new GridColumnConfiguration { DisplayName = "Phone Number"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"MONEY_LAUNDERING_RISK_SCORE" , new GridColumnConfiguration { DisplayName = "Money Laundering Risk Score"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"OCCUPATION_DESC" , new GridColumnConfiguration { DisplayName = "Occupation Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"CUSTOMER_SINCE_DATE" , new GridColumnConfiguration { DisplayName = "Customer Since Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"LOAN_NUMBERS" , new GridColumnConfiguration { DisplayName = "Loan Numbers"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"POLITICALLY_EXPOSED" , new GridColumnConfiguration { DisplayName = "Politically Exposed"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"TRANSACTION_REFERENCE" , new GridColumnConfiguration { DisplayName = "Transaction Reference"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"TRANSACTION_TYPE" , new GridColumnConfiguration { DisplayName = "Transaction Type"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"TRANSACTION_DATE" , new GridColumnConfiguration { DisplayName = "Transaction Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"EQUIVALENT_AMOUNT" , new GridColumnConfiguration { DisplayName = "Equivalent Amount"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },
                {"EQUIVALENT_CURRENCY" , new GridColumnConfiguration { DisplayName = "Equivalent Currency"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },



            };
            ReportTitle = "Total Alarm Detail";

        }
    }
}
