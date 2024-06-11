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
        //DG AML
        public static readonly string ART_ST_DGAML_ALERT_PER_OWNER = "ART_DB.ART_ST_DGAML_ALERT_PER_OWNER";
        public static readonly string ART_ST_DGAML_ALERTS_PER_STATUS = "ART_DB.ART_ST_DGAML_ALERTS_PER_STATUS";
        public static readonly string ART_ST_ALERTS_PER_BRANCH = "ART_DB.ART_ST_ALERTS_PER_BRANCH";
        public static readonly string ART_ST_ALERTS_PER_SCENARIO = "ART_DB.ART_ST_ALERTS_PER_SCENARIO";
        public static readonly string ART_ST_DGAML_CASES_PER_CATEGORY = "ART_DB.ART_ST_DGAML_CASES_PER_CATEGORY";
        public static readonly string ART_ST_DGAML_CASES_PER_PRIORITY = "ART_DB.ART_ST_DGAML_CASES_PER_PRIORITY";
        public static readonly string ART_ST_DGAML_CASES_PER_STATUS = "ART_DB.ART_ST_DGAML_CASES_PER_STATUS";
        public static readonly string ART_ST_DGAML_CUSTOMER_PER_BRANCH = "ART_DB.ART_ST_DGAML_CUSTOMER_PER_BRANCH";
        public static readonly string ART_ST_DGAML_CUSTOMER_PER_TYPE = "ART_DB.ART_ST_DGAML_CUSTOMER_PER_TYPE";
        public static readonly string ART_ST_EXTERNAL_CUSTOMER_PER_BRANCH = "ART_DB.ART_ST_EXTERNAL_CUSTOMER_PER_BRANCH";
        public static readonly string ART_ST_EXTERNAL_CUSTOMER_PER_TYPE = "ART_DB.ART_ST_EXTERNAL_CUSTOMER_PER_TYPE";
        public static readonly string ART_ST_CASES_PER_SUBCAT = "ART_DB.ART_ST_CASES_PER_SUBCAT";
        public static readonly string ART_ST_CUST_PER_BRANCH = "ART_DB.ART_ST_CUST_PER_BRANCH";
        public static readonly string ART_ST_CUST_PER_RISK = "ART_DB.ART_ST_CUST_PER_RISK";
        public static readonly string ART_ST_CUST_PER_TYPE = "ART_DB.ART_ST_CUST_PER_TYPE";
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
        public static readonly string ART_ST_YEARLY_AML_PER_SCENARIO = "ART_DB.ART_ST_YEARLY_AML_PER_SCENARIO";
        //GoAml
        public static readonly string ART_ST_GOAML_REPORTS_PER_TYPE = "ART.ART_ST_GOAML_REPORTS_PER_TYPE";
        public static readonly string ART_ST_GOAML_REPORTS_PER_STATUS = "ART.ART_ST_GOAML_REPORTS_PER_STATUS";
        public static readonly string ART_ST_GOAML_REPORTS_PER_INDICATOR = "ART.ART_ST_GOAML_REPORTS_PER_INDICATOR";
        public static readonly string ART_ST_GOAML_REPORTS_PER_CREATOR = "ART.ART_ST_GOAML_REPORTS_PER_CREATOR";


        //crp
        public static readonly string ART_ST_CRP_CUST_PER_RISK = "";
        public static readonly string ART_ST_CRP_CASES_PER_STATUS = "ART_DB.ART_ST_CRP_CASES_PER_STATUS";
        public static readonly string ART_ST_CRP_CASES_PER_RATE = "ART_DB.ART_ST_CRP_CASES_PER_RATE";


        //FATCA
        public static readonly string ART_ST_FATCA_ALERTS_PER_BRANCH = "ART.ART_ST_FATCA_ALERTS_PER_BRANCH";
        public static readonly string ART_ST_FATCA_CASES_PER_BRANCH = "ART.ART_ST_FATCA_CASES_PER_BRANCH";
        public static readonly string ART_ST_FATCA_ALERTS_PER_TYPE = "ART.ART_ST_FATCA_ALERTS_PER_TYPE";
        public static readonly string ART_ST_FATCA_CASES_PER_TYPE = "ART.ART_ST_FATCA_CASES_PER_TYPE";
        public static readonly string ART_ST_FATCA_CUSTS_PER_NATION = "ART.ART_ST_FATCA_CUSTS_PER_NATION";
        public static readonly string ART_ST_FATCA_CASES_PER_STATUS = "ART.ART_ST_FATCA_CASES_PER_STATUS";



        ///////////////-----------------------------------------
        ///

        public static readonly string ART_ST_YEARLY_STAFF_GOAML_AML_PER_CRIME = "ART.ART_ST_YEARLY_STAFF_GOAML_AML_PER_CRIME";
        public static readonly string ART_ST_YEARLY_STAFF_GOAML_AML_PER_PRODUCT = "ART.ART_ST_YEARLY_STAFF_GOAML_AML_PER_PRODUCT";
        public static readonly string ART_ST_YEARLY_STAFF_GOAML_AML_PER_REGION = "ART.ART_ST_YEARLY_STAFF_GOAML_AML_PER_REGION";
        public static readonly string ART_ST_YEARLY_STAFF_GOAML_SANCTION_PER_PRODUCT = "ART.ART_ST_YEARLY_STAFF_GOAML_SANCTION_PER_PRODUCT";
        public static readonly string ART_ST_YEARLY_STAFF_GOAML_SANCTION_PER_REGION = "ART.ART_ST_YEARLY_STAFF_GOAML_SANCTION_PER_REGION";
        public static readonly string ART_ST_YEARLY_STAFF_GOAML_SANCTION_PER_TYPE = "ART.ART_ST_YEARLY_STAFF_GOAML_SANCTION_PER_TYPE";
        public static readonly string ART_ST_YEARLY_TOP_AML_BRANCHES = "ART.ART_ST_YEARLY_TOP_AML_BRANCHES";
        public static readonly string ART_ST_YEARLY_TOP_GOAML_BRANCHES = "ART.ART_ST_YEARLY_TOP_GOAML_BRANCHES";
        public static readonly string ART_ST_YEARLY_TOP_SANCTION_BRANCHES = "ART.ART_ST_YEARLY_TOP_SANCTION_BRANCHES";
        public static readonly string ART_ST_YEARLY_UNUSAL_ACTIVITIES = "ART.ART_ST_YEARLY_UNUSAL_ACTIVITIES";


        //////////////////////////////
        ///
        public static readonly string ART_ST_YEARLY_AML_PER_REGION = "ART.ART_ST_YEARLY_AML_PER_REGION";
        public static readonly string ART_ST_YEARLY_AML_PER_TRRANSACTION_TYPE = "ART.ART_ST_YEARLY_AML_PER_TRRANSACTION_TYPE";
        public static readonly string ART_ST_YEARLY_BOTTOM_AML_BRANCHES = "ART.ART_ST_YEARLY_BOTTOM_AML_BRANCHES";
        public static readonly string ART_ST_YEARLY_BOTTOM_GOAML_BRANCHES = "ART.ART_ST_YEARLY_BOTTOM_GOAML_BRANCHES";
        public static readonly string ART_ST_YEARLY_BOTTOM_SANCTION_BRANCHES = "ART.ART_ST_YEARLY_BOTTOM_SANCTION_BRANCHES";
        public static readonly string ART_ST_YEARLY_NON_STAFF_GOAML_AML_PER_CRIME = "ART.ART_ST_YEARLY_NON_STAFF_GOAML_AML_PER_CRIME";
        public static readonly string ART_ST_YEARLY_NON_STAFF_GOAML_AML_PER_PRODUCT = "ART.ART_ST_YEARLY_NON_STAFF_GOAML_AML_PER_PRODUCT";
        public static readonly string ART_ST_YEARLY_NON_STAFF_GOAML_AML_PER_REGION = "ART.ART_ST_YEARLY_NON_STAFF_GOAML_AML_PER_REGION";



        ////////////////////////////////////////
        ///

        public static readonly string ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT = "ART.ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_PRODUCT";
        public static readonly string ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_REGION = "ART.ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_REGION";
        public static readonly string ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_TYPE = "ART.ART_ST_YEARLY_NON_STAFF_GOAML_SANCTION_PER_TYPE";
        public static readonly string ART_ST_YEARLY_SANCTION_PER_PRODUCT = "ART.ART_ST_YEARLY_SANCTION_PER_PRODUCT";
        public static readonly string ART_ST_YEARLY_SANCTION_PER_REGION = "ART.ART_ST_YEARLY_SANCTION_PER_REGION";
        public static readonly string ART_ST_YEARLY_SANCTION_PER_YEAR = "ART.ART_ST_YEARLY_SANCTION_PER_YEAR";



    }
}
