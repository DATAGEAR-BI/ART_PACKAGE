using System;
using System.Collections.Generic;

namespace Data.Data.SASAml
{
    public partial class SlaLevel3NonStaffViolatedWithoutAction
    {
        public string? UserName { get; set; }
        public string? DisplayName { get; set; }
        public decimal? AlertId { get; set; }
        public decimal? CaseId { get; set; }
        public string? AlertedEntityNumber { get; set; }
        public string? AlertedEntityName { get; set; }
        public string? BranchName { get; set; }
        public string? BranchNumber { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? CaseCloseDate { get; set; }
        public string? LevelOfRisk { get; set; }
        public string? InvestigationDays { get; set; }
        
    }
}
