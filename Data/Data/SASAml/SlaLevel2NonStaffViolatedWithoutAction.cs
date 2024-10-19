using System;
using System.Collections.Generic;

namespace Data.Data.SASAml
{
    public partial class SlaLevel2NonStaffViolatedWithoutAction
    {
        public string? UserName { get; set; }
        public long? AlertId { get; set; }
        public string? AlertedEntityNumber { get; set; }
        public string? AlertedEntityName { get; set; }
        public string? BranchName { get; set; }
        public string? BranchNumber { get; set; }
        public string? AlertStatus { get; set; }
        public DateTime? AssignedDate { get; set; }
        public string? InvestigationDays { get; set; }
        public string? LevelOfRisk { get; set; }
    }
}
