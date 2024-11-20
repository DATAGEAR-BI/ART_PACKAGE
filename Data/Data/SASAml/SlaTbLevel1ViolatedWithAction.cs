using System;
using System.Collections.Generic;

namespace Data.Data.SASAml
{
    public partial class SlaTbLevel1ViolatedWithAction
    {
        public string? UserName { get; set; }
        public string? DisplayName { get; set; }
        public long? AlertId { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? RoutingDate { get; set; }
        public long? AlertedEntityNumber { get; set; }
        public string? AlertedEntityName { get; set; }
        public string? BranchName { get; set; }
        public long? BranchNumber { get; set; }
        public string? InvestigationDays { get; set; }
        public string? LevelOfRisk { get; set; }
    }
}
