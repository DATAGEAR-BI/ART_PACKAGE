using System;
using System.Collections.Generic;

namespace Data.Data.SASAml
{
    public partial class SlaDailyClosedAlertsFromLevel2
    {
        public string? UserName { get; set; }

        public string? DisplayName { get; set; }
        public long? AlertId { get; set; }
        public string? EntityNumber { get; set; }
        public string? EntityName { get; set; }
        public string? BranchNumber { get; set; }
        public string? BranchName { get; set; }
        public DateTime? AssignedDate { get; set; }
        public string? AlertStatus { get; set; }
        public DateTime? LastActionDate { get; set; }
        public string? LevelOfRisk { get; set; }
        
    }
}
