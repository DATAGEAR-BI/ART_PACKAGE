using System;
using System.Collections.Generic;

namespace Data.Data.SASAml
{
    public partial class SlaMedHighClosedAlertsExceeded10Day
    {
        public long? AlertId { get; set; }
        public string? EntityNumber { get; set; }
        public string? EntityName { get; set; }
        public string? BranchNumber { get; set; }
        public string? BranchName { get; set; }
        public string? LevelOfRisk { get; set; }
        public string? UserLevel1 { get; set; }
        public string? UserLevel1ID { get; set; }
        public DateTime? AlertCreateDate { get; set; }
        public DateTime? RoutingDate { get; set; }
        public string? InvestigationDaysLevel1 { get; set; }
        public string? UserLevel2 { get; set; }
        public string? UserLevel2ID { get; set; }
        public DateTime? LastActionDate { get; set; }
        public string? AlertStatus { get; set; }
        public string? InvestigationDaysLevel2 { get; set; }
        public string? TotalInvestigationDays { get; set; }
        
        
    }
}
