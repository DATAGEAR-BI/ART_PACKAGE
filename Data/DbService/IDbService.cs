using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.FCF71
{
    public interface IDbService
    {
        public ACTIVITIDB.ACTIVITIDBContext ACTIVITIDB { get; }
        public DGADMIN.DGADMINContext DGADMIN { get; }
        public DGCALENDAR.DGCALENDARContext DGCALENDAR { get; }
        public DGNOTIFICATION.DGNOTIFICATIONContext DGNOTIFICATION { get; }
        public DGECM.DGECMContext DGECM { get; }
        public DGECMMETADATA.DGECMMETADATAContext DGECMMETADATA { get; }
        public DGUSERMANAGEMENT.DGUSERMANAGEMENTContext DGUSERMANAGEMENT { get; }
        public TI.TIContext TI { get; }
    }
}
