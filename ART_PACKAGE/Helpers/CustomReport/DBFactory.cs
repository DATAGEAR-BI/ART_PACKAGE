using ART_PACKAGE.Areas.Identity.Data;
using Data.FCF71;
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Helpers.CustomReportHelpers
{
    public class DBFactory
    {

        private readonly IDbService _db;

        public DBFactory(IDbService db)
        {
            _db = db;
        }

        public DbContext GetDbInstance(string schemaName)
        {

            return schemaName == DbSchema.DGCMGMT.ToString()
                ? _db.ECM
                : schemaName == DbSchema.KC.ToString() ? _db.KC : schemaName == DbSchema.CORE.ToString() ? _db.CORE : (DbContext?)null;
        }
    }
}
