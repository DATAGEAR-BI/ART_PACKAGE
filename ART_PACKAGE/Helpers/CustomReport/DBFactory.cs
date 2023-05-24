using ART_PACKAGE.Areas.Identity.Data;
using Data.DGCMGMT;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Helpers.CustomReportHelpers
{
    public class DBFactory
    {

        private readonly DGCMGMTContext _DGCMGMT;

        public DBFactory(DGCMGMTContext dGCMGMT)
        {
            _DGCMGMT = dGCMGMT;
        }

        public DbContext GetDbInstance(string schemaName)
        {

            if (schemaName == DbSchema.DGCMGMT.ToString())
                return _DGCMGMT;
            else
                return null;
        }
    }
}
