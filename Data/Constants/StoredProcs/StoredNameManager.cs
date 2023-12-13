using Data.Constants.db;
using Data.Data.ECM;
using Data.Data.FTI;

namespace Data.Constants.StoredProcs
{
    public static class StoredNameManager
    {
        public static string GetStoredName<T>(string dbType)
        {
            return typeof(T) switch
            {
                Type t when t == typeof(ArtStTiOdcOutSta) && dbType == DbTypes.Oracle => ORACLESPName.ART_ST_TI_ODC_OUTSTA_REPORT,
                //Type t when t == typeof(ArtStTiOdcOutSta) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_TI_ODC_OUTSTA_REPORT,
                Type t when t == typeof(ArtStTiOdcOutStaSumDraftType) && dbType == DbTypes.Oracle => ORACLESPName.ART_TI_ODC_OUTSTA_SUMM_DRAFT_TYPE_REPORT,
                //Type t when t == typeof(ArtStTiOdcOutSta) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_TI_ODC_OUTSTA_REPORT,
                Type t when t == typeof(ArtStTiOdcOutStaSumDraftStatus) && dbType == DbTypes.Oracle => ORACLESPName.ART_TI_ODC_OUTSTA_SUMM_DRAFT_STATUS_REPORT,
                //Type t when t == typeof(ArtStTiOdcOutSta) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_TI_ODC_OUTSTA_REPORT,
                Type t when t == typeof(ArtStTiOdcOutStaSumCountry) && dbType == DbTypes.Oracle => ORACLESPName.ART_TI_ODC_OUTSTA_SUMM_COUNTRY_REPORT,
                //Type t when t == typeof(ArtStTiOdcOutSta) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ART_ST_TI_ODC_OUTSTA_REPORT,
                Type t when t == typeof(ArtUserPerformancePerActionUser) && dbType == DbTypes.SqlServer => SQLSERVERSPNames.ST_USER_PERFORMANCE_PER_ACTION_USER,
                // Add more cases for other types if needed
                _ => throw new ArgumentException("Invalid entity type or database type")
            };
        }

    }
}
