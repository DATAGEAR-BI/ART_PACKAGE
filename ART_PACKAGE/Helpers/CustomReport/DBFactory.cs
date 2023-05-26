using ART_PACKAGE.Areas.Identity.Data;
using Data.DGCMGMT;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Helpers.CustomReportHelpers
{
    public class DBFactory
    {

        private readonly AuthContext _db;
        
        public DBFactory(AuthContext db)
        {
            _db = db;
        }

        public DbContext GetDbInstance(string schemaName)
        {

            if (schemaName == DbSchema.DGCMGMT.ToString())
                return _db;
            else
                return null;
        }
    }
}
