using System;
using System.Collections.Generic;

namespace Data.Data.SASAml
{
    public partial class SlaLevel3StaffViolatedWithoutAction
    {
        public string? UserName { get; set; }
        public long? AlertId { get; set; }
        public DateTime? AssignedDate { get; set; }
        public string? AlertStatus { get; set; }
        public DateTime? AlertCloseDate { get; set; }
        public long? CaseId { get; set; }
        public string? CaseStatus { get; set; }
        public DateTime? CaseCloseDate { get; set; }
        public decimal? LevelOfRisk { get; set; }
        public string? InvestigationDays { get; set; }
    }
}
