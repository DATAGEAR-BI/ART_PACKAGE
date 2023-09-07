using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.DBService;
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
            if (schemaName == DbSchema.ACTIVITIDB.ToString())
            {
                return _db.ACTIVITIDB;
            }
            else if (schemaName == DbSchema.DGADMIN.ToString())
            {
                return _db.DGADMIN;
            }
            else if (schemaName == DbSchema.DGCALENDAR.ToString())
            {
                return _db.DGCALENDAR;
            }
            else if (schemaName == DbSchema.DGNOTIFICATION.ToString())
            {
                return _db.DGNOTIFICATION;
            }
            else if (schemaName == DbSchema.DGECMMETADATA.ToString())
            {
                return _db.DGECMMETADATA;
            }
            else if (schemaName == DbSchema.DGUSERMANAGMENT.ToString())
            {
                return _db.DGUSERMANAGEMENT;
            }
            else if (schemaName == DbSchema.TI.ToString())
            {
                return _db.TI;
            }
            else if (schemaName == DbSchema.DGECM.ToString())
            {
                return _db.DGECM;
            }
            return null;
        }

    }
}
