using System;
using System.Collections.Generic;

namespace Data.Data.SASAml
{
    public partial class SlaLevel3NonStaffViolatedWithoutAction
    {
        public string? UserName { get; set; }
        public decimal? AlertId { get; set; }
        public long? CaseId { get; set; }
        public string? AlertedEntityNumber { get; set; }
        public string? AlertedEntityName { get; set; }
        public string? BranchName { get; set; }
        public string? BranchNumber { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? CaseCloseDate { get; set; }
        public decimal? LevelOfRisk { get; set; }
        public string? InvestigationDays { get; set; }
    }
}
