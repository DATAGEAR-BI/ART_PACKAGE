using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtStDgAmlCommentsDetailConfig : ReportConfig
    {

        public ArtStDgAmlCommentsDetailConfig()
        {
            SkipList = new List<string>(){ };

            DisplayNames = new Dictionary<string, GridColumnConfiguration>(){
                {"ALARM_ID" , new GridColumnConfiguration { DisplayName = "Alarm ID"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"RUN_DATE" , new GridColumnConfiguration { DisplayName = "Run Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"COMMENT" , new GridColumnConfiguration { DisplayName = "Comment"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"COMMENT_USER" , new GridColumnConfiguration { DisplayName = "Comment User"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"COMMENT_DATE" , new GridColumnConfiguration { DisplayName = "Comment Date"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"ALARM_LEVEL" , new GridColumnConfiguration { DisplayName = "Alarm Level"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"ALARM_STATUS" , new GridColumnConfiguration { DisplayName = "Alarm Status"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"ALARM_MESSAGE" , new GridColumnConfiguration { DisplayName = "Alarm Message"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"SCENARIO_NAME" , new GridColumnConfiguration { DisplayName = "Scenario Name"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
                {"SCENARIO_DESCRIPTION" , new GridColumnConfiguration { DisplayName = "Scenario Description"  , Format = ""  ,  Filter = "" , Template = "" , AggText = ""  , isLargeText = false   } },                                                                                 
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
            };
            ReportTitle = "Comments Detail Report";
            ReportDescription = "";

        }
    }
}
