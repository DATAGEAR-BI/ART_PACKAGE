using Data.ACTIVITIDB;
using Data.Audit;
using Data.DGADMIN;
using Data.DGAML;
using Data.DGCALENDAR;
using Data.DGECM;
using Data.DGECMMETADATA;
using Data.DGNOTIFICATION;
using Data.DGUSERMANAGEMENT;
using Data.GOAML;
using Data.TI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.FCF71
{
    public class DBService : IDbService
    {
        private readonly ACTIVITIDB.ACTIVITIDBContext _act;
        private readonly DGADMIN.DGADMINContext _admin;
        private readonly DGCALENDAR.DGCALENDARContext _calendar;
        private readonly DGNOTIFICATION.DGNOTIFICATIONContext _notify;
        private readonly DGECM.DGECMContext _ecm;
        private readonly DGECMMETADATA.DGECMMETADATAContext _ecmmetadata;
        private readonly DGUSERMANAGEMENT.DGUSERMANAGEMENTContext _usermanagement;
        private readonly TI.TIContext _ti;

        public DBService(ACTIVITIDBContext act, DGADMINContext admin, DGCALENDARContext calendar, DGNOTIFICATIONContext notify, DGECMContext ecm, DGECMMETADATAContext ecmmetadata, DGUSERMANAGEMENTContext usermanagement, TIContext ti)
        {
            _act = act;
            _admin = admin;
            _calendar = calendar;
            _notify = notify;
            _ecm = ecm;
            _ecmmetadata = ecmmetadata;
            _usermanagement = usermanagement;
            _ti = ti;
        }

        public ACTIVITIDBContext ACTIVITIDB => _act;

        public DGADMINContext DGADMIN => _admin;

        public DGCALENDARContext DGCALENDAR => _calendar;

        public DGNOTIFICATIONContext DGNOTIFICATION => _notify;

        public DGECMContext DGECM => _ecm;

        public DGECMMETADATAContext DGECMMETADATA => _ecmmetadata;

        public DGUSERMANAGEMENTContext DGUSERMANAGEMENT => _usermanagement;

        public TIContext TI => _ti;
    }
}
