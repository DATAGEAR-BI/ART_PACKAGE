using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.FTI
{
    public class ArtEcmAssignee
    {
        public int CaseRk { get; set; }
        public string CaseId { get; set; }
        public string AssignedBy { get; set; }
        public string Assignee { get; set; }
        public DateTime? AssignedTime { get; set; }
    }
}
