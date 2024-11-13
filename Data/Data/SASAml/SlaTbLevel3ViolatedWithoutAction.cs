using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.SASAml
{
    public class SlaTbLevel3ViolatedWithoutAction
    {
        public string? UserName { get; set; }
        public string? DisplayName { get; set; }
        public long? AlertId { get; set; }
        public long? CaseId { get; set; }
        public string? AlertedEntityNumber { get; set; }
        public string? AlertedEntityName { get; set; }
        public string? BranchName { get; set; }
        public string? BranchNumber { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? CaseCloseDate { get; set; }
        public string? LevelOfRisk { get; set; }
        public string? InvestigationDays { get; set; }
        public string? CaseStatusCode { get; set; }
    }
}
