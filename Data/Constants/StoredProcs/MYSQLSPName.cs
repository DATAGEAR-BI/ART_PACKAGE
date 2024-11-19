namespace Data.Constants.StoredProcs
{
    public static class MYSQLSPName
    {
        //Sanction
        public static readonly string ST_SYSTEM_PERF_PER_DIRECTION = "ART_DB.ART_ST_SYSTEM_PERF_PER_DIRECTION";
        public static readonly string ST_SYSTEM_PERF_PER_DATE = "ART_DB.ART_ST_SYSTEM_PERF_PER_DATE";
        public static readonly string ST_SYSTEM_PERF_PER_STATUS = "ART_DB.ART_ST_SYSTEM_PERF_PER_STATUS";
        public static readonly string ST_SYSTEM_PERF_PER_TYPE = "ART_DB.ART_ST_SYSTEM_PERF_PER_TYPE";
        public static readonly string ART_ST_USER_PERFORMANCE_PER_ACTION_USER = "ART_DB.ART_ST_USER_PERFORMANCE_PER_ACTION_USER";
        public static readonly string ART_ST_USER_PERFORMANCE_PER_ACTION = "ART_DB.ART_ST_USER_PERFORMANCE_PER_ACTION";
        public static readonly string ART_ST_USER_PERFORMANCE_PER_USER_AND_ACTION = "ART_DB.ART_ST_USER_PERFORMANCE_PER_USER_AND_ACTION";

        #region DGAML ALERTS Summary
        //DG AML
        public static readonly string ART_ST_DGAML_ALERT_PER_OWNER = "ART_DB.ART_ST_DGAML_ALERT_PER_OWNER";
        public static readonly string ART_ST_DGAML_ALERTS_PER_STATUS = "ART_DB.ART_ST_DGAML_ALERTS_PER_STATUS";
        public static readonly string ART_ST_DGAML_ALERTS_PER_BRANCH = "ART_DB.ART_ST_DGAML_ALERTS_PER_BRANCH";
        public static readonly string ART_ST_DGAML_ALERTS_PER_SCENARIO = "ART_DB.ART_ST_DGAML_ALERTS_PER_SCENARIO";
        public static readonly string ART_ST_DGAML_ALERTS_PER_STATUS_NON_STAFF = "ART_DB.ART_ST_DGAML_ALERTS_PER_STATUS_NON_STAFF";
        public static readonly string ART_ST_DGAML_ALERTS_PER_STATUS_STAFF = "ART_DB.ART_ST_DGAML_ALERTS_PER_STATUS_STAFF";
        public static readonly string ART_ST_DGAML_ALERT_PER_OWNER_NON_STAFF = "ART_DB.ART_ST_DGAML_ALERT_PER_OWNER_NON_STAFF";
        public static readonly string ART_ST_DGAML_ALERT_PER_OWNER_STAFF = "ART_DB.ART_ST_DGAML_ALERT_PER_OWNER_STAFF";
        public static readonly string ART_ST_DGAML_ALERTS_PER_SCENARIO_NON_STAFF = "ART_DB.ART_ST_DGAML_ALERTS_PER_SCENARIO_NON_STAFF";
        public static readonly string ART_ST_DGAML_ALERTS_PER_SCENARIO_STAFF = "ART_DB.ART_ST_DGAML_ALERTS_PER_SCENARIO_STAFF";
        public static readonly string ART_ST_DGAML_ALERTS_PER_BRANCH_NON_STAFF = "ART_DB.ART_ST_DGAML_ALERTS_PER_BRANCH_NON_STAFF";
        public static readonly string ART_ST_DGAML_ALERTS_PER_BRANCH_STAFF = "ART_DB.ART_ST_DGAML_ALERTS_PER_BRANCH_STAFF";
        public static readonly string ART_ST_USER_PERFORMANCE_PER_USER = "ART_DB.ART_ST_USER_PERFORMANCE_PER_USER";
        #endregion
        #region DGAML CASES SUMMARY
        public static readonly string ART_ST_DGAML_CASES_PER_CATEGORY = "ART_DB.ART_ST_DGAML_CASES_PER_CATEGORY";
        public static readonly string ART_ST_DGAML_CASES_PER_PRIORITY = "ART_DB.ART_ST_DGAML_CASES_PER_PRIORITY";
        public static readonly string ART_ST_DGAML_CASES_PER_STATUS = "ART_DB.ART_ST_DGAML_CASES_PER_STATUS";
        #endregion


        public static readonly string ART_ST_ALERTS_PER_BRANCH = "ART_DB.ART_ST_ALERTS_PER_BRANCH";
        public static readonly string ART_ST_ALERTS_PER_SCENARIO = "ART_DB.ART_ST_ALERTS_PER_SCENARIO";



        #region DGAML CUSOMER SUMMARY
        public static readonly string ART_ST_DGAML_CUSTOMER_PER_BRANCH = "ART_DB.ART_ST_DGAML_CUSTOMER_PER_BRANCH";
        public static readonly string ART_ST_DGAML_CUSTOMER_PER_TYPE = "ART_DB.ART_ST_DGAML_CUSTOMER_PER_TYPE";
        #endregion
        #region EXTERNAL CUSTOMER SUMMARY
        public static readonly string ART_ST_DGAML_EXTERNAL_CUSTOMER_PER_BRANCH = "ART_DB.ART_ST_EXTERNAL_CUSTOMER_PER_BRANCH";
        public static readonly string ART_ST_DGAML_EXTERNAL_CUSTOMER_PER_TYPE = "ART_DB.ART_ST_EXTERNAL_CUSTOMER_PER_TYPE";
        #endregion

        public static readonly string ART_ST_EXTERNAL_CUSTOMER_PER_BRANCH = "ART_DB.ART_ST_EXTERNAL_CUSTOMER_PER_BRANCH";
        public static readonly string ART_ST_EXTERNAL_CUSTOMER_PER_TYPE = "ART_DB.ART_ST_EXTERNAL_CUSTOMER_PER_TYPE";
        public static readonly string ART_ST_CASES_PER_SUBCAT = "ART_DB.ART_ST_CASES_PER_SUBCAT";
        public static readonly string ART_ST_CUST_PER_BRANCH = "ART_DB.ART_ST_CUST_PER_BRANCH";
        public static readonly string ART_ST_CUST_PER_RISK = "ART_DB.ART_ST_CUST_PER_RISK";
        public static readonly string ART_ST_CUST_PER_TYPE = "ART_DB.ART_ST_CUST_PER_TYPE";
        public static readonly string ART_ST_CUST_PER_INDUSTRY = "ART_DB.ART_ST_CUST_PER_INDUSTRY";
        public static readonly string ART_ST_CUST_PER_OCCUPATION = "ART_DB.ART_ST_CUST_PER_OCCUPATION";
        public static readonly string ART_ST_CUST_PER_STATUS = "ART_DB.ART_ST_CUST_PER_STATUS";
        public static readonly string ART_ST_AML_PROP_RISK_CLASS = "ART_DB.ART_ST_AML_PROP_RISK_CLASS";
        public static readonly string ART_ST_AML_RISK_CLASS = "ART_DB.ART_ST_AML_RISK_CLASS";

        public static readonly string ART_ST_AML_ALERT_AGE_SUMMARY = "ART_DB.ART_ST_AML_ALERT_AGE_SUMMARY";
        public static readonly string ART_ST_AML_ALERTS_PER_SCENARIO = "ART_DB.ART_ST_AML_ALERTS_PER_SCENARIO";
        public static readonly string ART_ST_AML_ALERTS_PER_BRANCH = "ART_DB.ART_ST_AML_ALERTS_PER_BRANCH";
        public static readonly string ART_ST_AML_ALERTS_PER_STATUS = "ART_DB.ART_ST_AML_ALERTS_PER_STATUS";


        // SAS AML 
        public static readonly string ART_ST_ALERTS_PER_STATUS = "ART_DB.ART_ST_ALERTS_PER_STATUS";
        public static readonly string ART_ST_ALERT_PER_OWNER = "ART_DB.ART_ST_ALERT_PER_OWNER";
        public static readonly string ART_ST_CASES_PER_STATUS = "ART_DB.ART_ST_CASES_PER_STATUS";
        public static readonly string ART_ST_CASES_PER_CATEGORY = "ART_DB.ART_ST_CASES_PER_CATEGORY";
        public static readonly string ART_ST_CASES_PER_PRIORITY = "ART_DB.ART_ST_CASES_PER_PRIORITY";
        public static readonly string ART_ST_CASES_PER_BRANCH = "ART_DB.ART_ST_CASES_PER_BRANCH";
        public static readonly string ART_ST_AML_ALERTS_PER_STATUS_NON_STAFF = "";
        public static readonly string ART_ST_AML_ALERTS_PER_SCENARIO_NON_STAFF = "";
        public static readonly string ART_ST_AML_ALERT_PER_OWNER_NON_STAFF = "";
        public static readonly string ART_ST_AML_ALERTS_PER_BRANCH_NON_STAFF = "";
        //GoAml
        public static readonly string ART_ST_GOAML_REPORTS_PER_TYPE = "ART_DB.ART_ST_GOAML_REPORTS_PER_TYPE";
        public static readonly string ART_ST_GOAML_REPORTS_PER_STATUS = "ART_DB.ART_ST_GOAML_REPORTS_PER_STATUS";
        public static readonly string ART_ST_GOAML_REPORTS_PER_INDICATOR = "ART_DB.ART_ST_GOAML_REPORTS_PER_INDICATOR";
        public static readonly string ART_ST_GOAML_REPORTS_PER_CREATOR = "ART_DB.ART_ST_GOAML_REPORTS_PER_CREATOR";


        //crp
        public static readonly string ART_ST_CRP_CUST_PER_RISK = "ART_DB.ART_ST_CRP_CUST_PER_RISK";
        public static readonly string ART_ST_CRP_CASES_PER_STATUS = "ART_DB.ART_ST_CRP_CASES_PER_STATUS";
        public static readonly string ART_ST_CRP_CASES_PER_RATE = "ART_DB.ART_ST_CRP_CASES_PER_RATE";
        public static readonly string ART_ST_CRP_CUST_PER_PROP_RISK = "ART_DB.ART_ST_CRP_CUST_PER_PROP_RISK";


        //FATCA
        public static readonly string ART_ST_FATCA_ALERTS_PER_BRANCH = "ART.ART_ST_FATCA_ALERTS_PER_BRANCH";
        public static readonly string ART_ST_FATCA_CASES_PER_BRANCH = "ART.ART_ST_FATCA_CASES_PER_BRANCH";
        public static readonly string ART_ST_FATCA_ALERTS_PER_TYPE = "ART.ART_ST_FATCA_ALERTS_PER_TYPE";
        public static readonly string ART_ST_FATCA_CASES_PER_TYPE = "ART.ART_ST_FATCA_CASES_PER_TYPE";
        public static readonly string ART_ST_FATCA_CUSTS_PER_NATION = "ART.ART_ST_FATCA_CUSTS_PER_NATION";
        public static readonly string ART_ST_FATCA_CASES_PER_STATUS = "ART.ART_ST_FATCA_CASES_PER_STATUS";



    }
}
