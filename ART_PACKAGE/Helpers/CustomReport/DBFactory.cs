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

            if (schemaName == DbSchema.DGCMGMT.ToString())
            {
                return _db.ECM;
            }

            if (schemaName == DbSchema.KC.ToString())
            {
                return _db.KC;
            }

            return schemaName == DbSchema.CORE.ToString() ? _db.CORE : (DbContext?)null;
        }
    }
}
