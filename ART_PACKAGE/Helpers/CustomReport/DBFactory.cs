
using Microsoft.EntityFrameworkCore;

namespace ART_PACKAGE.Helpers.CustomReport
{
    public class DBFactory
    {

        private readonly IDbService _db;

        public DBFactory(IDbService db)
        {
            _db = db;
        }

        public DbContext? GetDbInstance(string schemaName)
        {

            return schemaName == DbSchema.DGCMGMT.ToString()
                ? _db.ECM
                : schemaName == DbSchema.KC.ToString() ? _db.KC
                : schemaName == DbSchema.CORE.ToString() ? _db.CORE
                : schemaName == DbSchema.FTI.ToString() ? _db.TI
                : schemaName == DbSchema.DGAML.ToString() ? _db.DGAML
                : schemaName == DbSchema.GoAml.ToString() ? _db.GOAML
                : (DbContext?)null;
        }
    }
}
