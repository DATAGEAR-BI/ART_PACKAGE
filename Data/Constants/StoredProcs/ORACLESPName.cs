namespace Data.Constants.StoredProcs
{
    public static class ORACLESPName
    {
        //Sanction
        public static readonly string ST_SYSTEM_PERF_PER_DIRECTION = "ART.ART_ST_SYSTEM_PERF_PER_DIR";
        public static readonly string ST_SYSTEM_PERF_PER_DATE = "ART.ART_ST_SYSTEM_PERF_PER_DATE";
        public static readonly string ST_SYSTEM_PERF_PER_STATUS = "ART.ART_ST_SYSTEM_PERF_PER_STATUS";
        public static readonly string ST_SYSTEM_PERF_PER_TYPE = "ART.ART_ST_SYSTEM_PERF_PER_TYPE";
        public static readonly string ST_USER_PERFORMANCE_PER_ACTION_USER = "ART.ART_ST_USER_PERF_PER_ACT_USER";
        public static readonly string ST_USER_PERFORMANCE_PER_ACTION = "ART.ART_ST_USER_PERF_PER_ACTION";
        public static readonly string ST_USER_PERFORMANCE_PER_USER_AND_ACTION = "ART.ART_ST_USR_PRF_PER_USR_AND_ACT";
        //AML
        public static readonly string ART_ST_CASES_PER_CATEGORY = "ART.ART_ST_CASES_PER_CATEGORY";
        public static readonly string ART_ST_CASES_PER_PRIORITY = "ART.ART_ST_CASES_PER_PRIORITY";
        public static readonly string ART_ST_CASES_PER_STATUS = "ART.ART_ST_CASES_PER_STATUS";
        public static readonly string ART_ST_CASES_PER_SUBCAT = "ART.ART_ST_CASES_PER_SUBCAT";
        public static readonly string ART_ST_CUST_PER_BRANCH = "ART.ART_ST_CUST_PER_BRANCH";
        public static readonly string ART_ST_CUST_PER_RISK = "ART.ART_ST_CUST_PER_RISK";
        public static readonly string ART_ST_CUST_PER_TYPE = "ART.ART_ST_CUST_PER_TYPE";
        public static readonly string ART_ST_AML_PROP_RISK_CLASS = "ART.ART_ST_AML_PROP_RISK_CLASS";
        public static readonly string ART_ST_AML_RISK_CLASS = "ART.ART_ST_AML_RISK_CLASS";
        public static readonly string ART_ST_DGAML_ALERT_AGE_SUMMARY = "ART.ART_ST_ALERT_AGE_SUMMARY";
        public static readonly string ART_ST_AML_ALERT_AGE_SUMMARY = "ART.ART_ST_ALERT_AGE_SUMMARY";
        public static readonly string ART_ST_AML_ALERTS_PER_BRANCH = "ART.ART_ST_AML_ALERTS_PER_BRANCH";
        public static readonly string ART_ST_AML_ALERTS_PER_SCENARIO = "ART.ART_ST_AML_ALERTS_PER_SCENARIO";
        public static readonly string ART_ST_AML_ALERTS_PER_STATUS = "ART.ART_ST_AML_ALERTS_PER_STATUS";


        //GoAml
        public static readonly string ART_ST_GOAML_REPORTS_PER_TYPE = "ART.ART_ST_GOAML_REPORTS_PER_TYPE";
        public static readonly string ART_ST_GOAML_REPORTS_PER_STATUS = "ART.ART_ST_GOAML_REPORTS_PER_STATUS";
        public static readonly string ART_ST_GOAML_REPORTS_PER_INDICATOR = "ART.ART_ST_GOAML_REPORTS_PER_INDICATOR";
        public static readonly string ART_ST_GOAML_REPORTS_PER_CREATOR = "ART.ART_ST_GOAML_REPORTS_PER_CREATOR";


        //crp
        public static readonly string ART_ST_CRP_CUST_PER_RISK = "ART.ART_ST_CRP_CUST_PER_RISK";
        public static readonly string ART_ST_CRP_CASES_PER_STATUS = "ART.ART_ST_CRP_CASES_PER_STATUS";
        public static readonly string ART_ST_CRP_CASES_PER_RATE = "ART.ART_ST_CRP_CASES_PER_RATE";


        //FATCA
        public static readonly string ART_ST_FATCA_ALERTS_PER_BRANCH = "ART.ART_ST_FATCA_ALERTS_PER_BRANCH";
        public static readonly string ART_ST_FATCA_CASES_PER_BRANCH = "ART.ART_ST_FATCA_CASES_PER_BRANCH";
        public static readonly string ART_ST_FATCA_ALERTS_PER_TYPE = "ART.ART_ST_FATCA_ALERTS_PER_TYPE";
        public static readonly string ART_ST_FATCA_CASES_PER_TYPE = "ART.ART_ST_FATCA_CASES_PER_TYPE";
        public static readonly string ART_ST_FATCA_CUSTS_PER_NATION = "ART.ART_ST_FATCA_CUSTS_PER_NATION";
        public static readonly string ART_ST_FATCA_CASES_PER_STATUS = "ART.ART_ST_FATCA_CASES_PER_STATUS";


        //DGAML
        public static readonly string ART_ST_ALERT_PER_OWNER = "ART.ART_ST_ALERT_PER_OWNER";
        public static readonly string ART_ST_ALERTS_PER_STATUS = "ART.ART_ST_ALERTS_PER_STATUS";
        public static readonly string ART_ST_DGAML_ALARMS_PER_STATUS = "";
        public static readonly string ART_ST_DGAML_TOTAL_ALARMS_DETAIL = "";
        public static readonly string ART_ST_DGAML_PARTIES_LIST_DETAILS_REPORT = "";
        public static readonly string ART_ST_DGAML_POLITICALLY_EXPOSED_REPORT = "";
        public static readonly string ART_ST_DGAML_PARTIES_LIST_SUMMARY_REPORT = "";


        #region DGAML ALERTS Summary
        //DG AML
        public static readonly string ART_ST_DGAML_ALERT_PER_OWNER = "ART.ART_ST_DGAML_ALERT_PER_OWNER";
        public static readonly string ART_ST_DGAML_ALERTS_PER_STATUS = "ART.ART_ST_DGAML_ALERTS_PER_STATUS";
        public static readonly string ART_ST_DGAML_ALERTS_PER_BRANCH = "ART.ART_ST_DGAML_ALERTS_PER_BRANCH";
        public static readonly string ART_ST_DGAML_ALERTS_PER_SCENARIO = "ART.ART_ST_DGAML_ALERTS_PER_SCENARIO";
        #endregion

        #region DGAML CASES SUMMARY
        public static readonly string ART_ST_DGAML_CASES_PER_CATEGORY = "ART.ART_ST_DGAML_CASES_PER_CATEGORY";
        public static readonly string ART_ST_DGAML_CASES_PER_PRIORITY = "ART.ART_ST_DGAML_CASES_PER_PRIORITY";
        public static readonly string ART_ST_DGAML_CASES_PER_STATUS = "ART.ART_ST_DGAML_CASES_PER_STATUS";
        #endregion

        #region DGAML CUSOMER SUMMARY
        public static readonly string ART_ST_DGAML_CUSTOMER_PER_BRANCH = "ART.ART_ST_DGAML_CUSTOMER_PER_BRANCH";
        public static readonly string ART_ST_DGAML_CUSTOMER_PER_TYPE = "ART.ART_ST_DGAML_CUSTOMER_PER_TYPE";
        #endregion

        #region EXTERNAL CUSTOMER SUMMARY
        public static readonly string ART_ST_DGAML_EXTERNAL_CUSTOMER_PER_BRANCH = "ART.ART_ST_EXTERNAL_CUSTOMER_PER_BRANCH";
        public static readonly string ART_ST_DGAML_EXTERNAL_CUSTOMER_PER_TYPE = "ART.ART_ST_EXTERNAL_CUSTOMER_PER_TYPE";
        #endregion



    }
}
