using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.SASAml
{
    public class SlaTbLevel2ViolatedWithoutAction
    {
        public string? UserName { get; set; }
        public string? DisplayName { get; set; }
        public long? AlertId { get; set; }
        public long? AlertedEntityNumber { get; set; }
        public string? AlertedEntityName { get; set; }
        public string? BranchName { get; set; }
        public long? BranchNumber { get; set; }
        public string? AlertStatus { get; set; }
        public DateTime? AssignedDate { get; set; }
        public string? InvestigationDays { get; set; }
        public string? LevelOfRisk { get; set; }

    }
}
