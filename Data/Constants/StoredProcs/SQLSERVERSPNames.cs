using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Constants.StoredProcs
{
    public static class SQLSERVERSPNames
    {
        //Sanction
        public static readonly string ST_SYSTEM_PERF_PER_DIRECTION = "[ART_DB].[ART_ST_SYSTEM_PERF_PER_DIRECTION]";
        public static readonly string ST_SYSTEM_PERF_PER_STATUS = "[ART_DB].[ART_ST_SYSTEM_PERF_PER_STATUS]";
        public static readonly string ST_SYSTEM_PERF_PER_TYPE = "[ART_DB].[ART_ST_SYSTEM_PERF_PER_TYPE]";
        public static readonly string ST_USER_PERFORMANCE_PER_ACTION_USER = "[ART_DB].[ART_ST_USER_PERFORMANCE_PER_ACTION_USER]";
        public static readonly string ST_USER_PERFORMANCE_PER_ACTION = "[ART_DB].[ART_ST_USER_PERFORMANCE_PER_ACTION]";
        public static readonly string ST_USER_PERFORMANCE_PER_USER_AND_ACTION = "[ART_DB].[ART_ST_USER_PERFORMANCE_PER_USER_AND_ACTION]";

        //AML
        public static readonly string ART_ST_ALERT_PER_OWNER = "[ART_DB].[ART_ST_ALERT_PER_OWNER]";
        public static readonly string ART_ST_ALERTS_PER_STATUS = "[ART_DB].[ART_ST_AML_ALERTS_PER_STATUS]";
        public static readonly string ART_ST_CASES_PER_CATEGORY = "[ART_DB].[ART_ST_CASES_PER_CATEGORY]";
        public static readonly string ART_ST_CASES_PER_PRIORITY = "[ART_DB].[ART_ST_CASES_PER_PRIORITY]";
        public static readonly string ART_ST_CASES_PER_STATUS = "[ART_DB].[ART_ST_CASES_PER_STATUS]";
        public static readonly string ART_ST_CASES_PER_SUBCAT = "[ART_DB].[ART_ST_CASES_PER_SUBCAT]";
        public static readonly string ART_ST_CUST_PER_BRANCH = "[ART_DB].[ART_ST_CUST_PER_BRANCH]";
        public static readonly string ART_ST_CUST_PER_RISK = "[ART_DB].[ART_ST_CUST_PER_RISK]";
        public static readonly string ART_ST_CUST_PER_TYPE = "[ART_DB].[ART_ST_CUST_PER_TYPE]";
        public static readonly string ART_ST_AML_PROP_RISK_CLASS = "[ART_DB].[ART_ST_AML_PROP_RISK_CLASS]";
        public static readonly string ART_ST_AML_RISK_CLASS = "[ART_DB].[ART_ST_AML_RISK_CLASS]";

        //GoAml
        public static readonly string ART_ST_GOAML_REPORTS_PER_TYPE = "[ART_DB].[ART_ST_GOAML_REPORTS_PER_TYPE]";
        public static readonly string ART_ST_GOAML_REPORTS_PER_STATUS = "[ART_DB].[ART_ST_GOAML_REPORTS_PER_STATUS]";
        public static readonly string ART_ST_GOAML_REPORTS_PER_INDICATOR = "[ART_DB].[ART_ST_GOAML_REPORTS_PER_INDICATOR]";
        public static readonly string ART_ST_GOAML_REPORTS_PER_CREATOR = "[ART_DB].[ART_ST_GOAML_REPORTS_PER_CREATOR]";

        //DGAML
        public static readonly string ART_ST_DGAML_ALERT_PER_OWNER = "[ART_DB].[ART_ST_DGAML_ALERT_PER_OWNER]";
        public static readonly string ART_ST_DGAML_ALERTS_PER_STATUS = "[ART_DB].[ART_ST_DGAML_ALERTS_PER_STATUS]";
        public static readonly string ART_ST_DGAML_ALERTS_PER_BRANCH = "[ART_DB].[ART_ST_ALERTS_PER_BRANCH]";
        public static readonly string ART_ST_DGAML_ALERTS_PER_SCENARIO = "[ART_DB].[ART_ST_ALERTS_PER_SCENARIO]";
        public static readonly string ART_ST_DGAML_CUSTOMER_PER_BRANCH = "[ART_DB].[ART_ST_DGAML_CUSTOMER_PER_BRANCH]";
        public static readonly string ART_ST_DGAML_EXTERNAL_CUSTOMER_PER_BRANCH = "[ART_DB].[ART_ST_EXTERNAL_CUSTOMER_PER_BRANCH]";
        public static readonly string ART_ST_DGAML_CUSTOMER_PER_TYPE = "[ART_DB].[ART_ST_DGAML_CUSTOMER_PER_TYPE]";
        public static readonly string ART_ST_DGAML_EXTERNAL_CUSTOMER_PER_TYPE = "[ART_DB].[ART_ST_EXTERNAL_CUSTOMER_PER_TYPE]";
        public static readonly string ART_ST_DGAML_CASES_PER_CATEGORY = "[ART_DB].[ART_ST_DGAML_CASES_PER_CATEGORY]";
        public static readonly string ART_ST_DGAML_CASES_PER_PRIORITY = "[ART_DB].[ART_ST_DGAML_CASES_PER_PRIORITY]";
        public static readonly string ART_ST_DGAML_CASES_PER_STATUS = "[ART_DB].[ART_ST_DGAML_CASES_PER_STATUS]";

        //FTI
        public static readonly string ART_ST_CASES_YEAR_TO_YEAR = "[ART_DB].[ART_ST_CASES_YEAR_TO_YEAR]";
        public static readonly string ART_ST_CASES_PER_PRODUCT = "[ART_DB].[ART_ST_CASES_PER_PRODUCT]";
        public static readonly string ART_ST_CASES_PER_TYPE = "[ART_DB].[ART_ST_CASES_PER_TYPE]";
        

    }
}
