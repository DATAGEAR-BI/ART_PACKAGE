using Data.Constants.db;
using Data.Data.ARTDGAML;
using Data.Data.ARTGOAML;
using Data.Data.ECM;
using Data.Data.SASAml;

namespace Data.Constants.StoredProcs
{

    public static class StoredNameManager
    {
        public static string GetStoredName<T>(string dbType)
        {
            return typeof(T) switch
            {

                /*Type t when t == typeof(ArtStTiOdcOutSta) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_TI_ODC_OUTSTA_REPORT,
                //Type t when t == typeof(ArtStTiOdcOutSta) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_TI_ODC_OUTSTA_REPORT,
                Type t when t == typeof(ArtStTiOdcOutStaSumDraftType) && dbType == DbTypes.Oracle => ORACLESPName.ART_TI_ODC_OUTSTA_SUMM_DRAFT_TYPE_REPORT,
                //Type t when t == typeof(ArtStTiOdcOutSta) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_TI_ODC_OUTSTA_REPORT,

*/
                Type t when t == typeof(ArtStAlertsPerStatus) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_ALERTS_PER_STATUS,
                Type t when t == typeof(ArtStAlertsPerStatus) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_ALERTS_PER_STATUS,
                Type t when t == typeof(ArtStAlertPerOwner) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_ALERT_PER_OWNER,
                Type t when t == typeof(ArtStAlertPerOwner) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_ALERT_PER_OWNER,

                Type t when t == typeof(ArtStCasesPerStatus) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_CASES_PER_STATUS,
                Type t when t == typeof(ArtStCasesPerCategory) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_CASES_PER_CATEGORY,
                Type t when t == typeof(ArtStCasesPerSubcat) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_CASES_PER_SUBCAT,
                Type t when t == typeof(ArtStCasesPerPriority) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_CASES_PER_PRIORITY,
                Type t when t == typeof(ArtStCasesPerStatus) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_CASES_PER_STATUS,
                Type t when t == typeof(ArtStCasesPerCategory) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_CASES_PER_CATEGORY,
                Type t when t == typeof(ArtStCasesPerSubcat) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_CASES_PER_SUBCAT,
                Type t when t == typeof(ArtStCasesPerPriority) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_CASES_PER_PRIORITY,
                Type t when t == typeof(ArtStCasesPerBranch) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_CASES_PER_BRANCH,
                Type t when t == typeof(ArtStCasesPerBranch) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_CASES_PER_BRANCH,



                Type t when t == typeof(ArtStCustPerType) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_CUST_PER_TYPE,
                Type t when t == typeof(ArtStCustPerRisk) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_CUST_PER_RISK,
                Type t when t == typeof(ArtStCustPerBranch) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_CUST_PER_BRANCH,
                Type t when t == typeof(ArtStCustPerType) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_CUST_PER_TYPE,
                Type t when t == typeof(ArtStCustPerRisk) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_CUST_PER_RISK,
                Type t when t == typeof(ArtStCustPerBranch) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_CUST_PER_BRANCH,

                Type t when t == typeof(ArtStAmlRiskClass) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_AML_RISK_CLASS,
                Type t when t == typeof(ArtStAmlPropRiskClass) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_AML_PROP_RISK_CLASS,
                Type t when t == typeof(ArtStAmlRiskClass) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_AML_RISK_CLASS,
                Type t when t == typeof(ArtStAmlPropRiskClass) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_AML_PROP_RISK_CLASS,

                Type t when t == typeof(ArtStGoAmlReportsPerStatus) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_GOAML_REPORTS_PER_STATUS,
                Type t when t == typeof(ArtStGoAmlReportsPerType) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_GOAML_REPORTS_PER_TYPE,
                Type t when t == typeof(ArtStGoAmlReportsPerCreator) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_GOAML_REPORTS_PER_CREATOR,
                Type t when t == typeof(ArtStGoAmlReportsPerStatus) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_GOAML_REPORTS_PER_STATUS,
                Type t when t == typeof(ArtStGoAmlReportsPerType) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_GOAML_REPORTS_PER_TYPE,
                Type t when t == typeof(ArtStGoAmlReportsPerCreator) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_GOAML_REPORTS_PER_CREATOR,


                Type t when t == typeof(ArtSystemPerfPerDate) && dbType == DbTypes.Oracle => ORACLESPName.ST_SYSTEM_PERF_PER_DATE,
                Type t when t == typeof(ArtSystemPerfPerType) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ST_SYSTEM_PERF_PER_TYPE,
                Type t when t == typeof(ArtSystemPerfPerType) && dbType == DbTypes.Oracle => ORACLESPName.ST_SYSTEM_PERF_PER_TYPE,
                Type t when t == typeof(ArtSystemPrefPerStatus) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ST_SYSTEM_PERF_PER_STATUS,
                Type t when t == typeof(ArtSystemPrefPerStatus) && dbType == DbTypes.Oracle => ORACLESPName.ST_SYSTEM_PERF_PER_STATUS,
                Type t when t == typeof(ArtSystemPrefPerDirection) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ST_SYSTEM_PERF_PER_DIRECTION,
                Type t when t == typeof(ArtSystemPrefPerDirection) && dbType == DbTypes.Oracle => ORACLESPName.ST_SYSTEM_PERF_PER_DIRECTION,


                /*Type t when t == typeof(ArtStTiOdcOutStaSumDraftStatus) && dbType == DbTypes.Oracle => ORACLESPName.ART_TI_ODC_OUTSTA_SUMM_DRAFT_STATUS_REPORT,
                //Type t when t == typeof(ArtStTiOdcOutSta) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_TI_ODC_OUTSTA_REPORT,
                Type t when t == typeof(ArtStTiOdcOutStaSumCountry) && dbType == DbTypes.Oracle => ORACLESPName.ART_TI_ODC_OUTSTA_SUMM_COUNTRY_REPORT,
                //Type t when t == typeof(ArtStTiOdcOutSta) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_TI_ODC_OUTSTA_REPORT,
                */
                Type t when t == typeof(ArtUserPerformancePerActionUser) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_ACTION_USER,
                Type t when t == typeof(ArtUserPerformancePerActionUser) && dbType == DbTypes.Oracle => ORACLESPName.ST_USER_PERFORMANCE_PER_ACTION_USER,
                Type t when t == typeof(ArtUserPerformPerUserAndAction) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_USER_AND_ACTION,
                Type t when t == typeof(ArtUserPerformPerUserAndAction) && dbType == DbTypes.Oracle => ORACLESPName.ST_USER_PERFORMANCE_PER_USER_AND_ACTION,
                Type t when t == typeof(ArtUserPerformPerAction) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_ACTION,
                Type t when t == typeof(ArtUserPerformPerAction) && dbType == DbTypes.Oracle => ORACLESPName.ST_USER_PERFORMANCE_PER_ACTION,
                Type t when t == typeof(ArtStAmlAlertAgeSummery) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_DGAML_ALERT_AGE_SUMMARY,
                Type t when t == typeof(ArtStAmlAlertAgeSummery) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_AML_ALERT_AGE_SUMMARY,


                Type t when t == typeof(ArtStAmlAlertsPerScenario) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_AML_ALERTS_PER_SCENARIO,
                Type t when t == typeof(ArtStAmlAlertsPerScenario) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_AML_ALERTS_PER_SCENARIO,

                Type t when t == typeof(ArtStAmlAlertsPerBranch) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_AML_ALERTS_PER_BRANCH,
                Type t when t == typeof(ArtStAmlAlertsPerBranch) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_AML_ALERTS_PER_BRANCH,

                Type t when t == typeof(ArtStAmlAlertsPerStatus) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_AML_ALERTS_PER_STATUS,
                Type t when t == typeof(ArtStAmlAlertsPerStatus) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_AML_ALERTS_PER_STATUS,

                // Add more cases for other types if needed
                _ => throw new ArgumentException("Invalid entity type or database type")
            };
        }

    }
}
