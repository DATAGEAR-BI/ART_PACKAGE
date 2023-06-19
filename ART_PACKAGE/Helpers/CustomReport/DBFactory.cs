using ART_PACKAGE.Areas.Identity.Data;
using Data.DGCMGMT;
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
                return _db.ECM;
            if (schemaName == DbSchema.KC.ToString())
                return _db.KC;
            if (schemaName == DbSchema.CORE.ToString())
                return _db.CORE;
            else
                return null;
        }
    }
}
