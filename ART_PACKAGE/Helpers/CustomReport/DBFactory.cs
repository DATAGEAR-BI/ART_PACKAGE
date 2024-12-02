using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.DBService;
using Data.Services;
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
                : schemaName == DbSchema.DGAMLCORE.ToString() ? _db.DGAMLCORE
                : schemaName == DbSchema.DGAMLAC.ToString() ? _db.DGAMLAC
                : schemaName == DbSchema.GoAml.ToString() ? _db.GOAML
                : schemaName == DbSchema.DGMGMT.ToString() ? _db.DGMGMT
                : schemaName == DbSchema.DGMGMT_AUDIT.ToString() ? _db.DGMGMT
                : schemaName == DbSchema.ART.ToString() ? _db.ARTCustomReport
                : (DbContext?)null;
        }
    }
}
