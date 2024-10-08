using System;
using System.Collections.Generic;

namespace Data.Data.SASAml
{
    public partial class SlaClosedAlertsExceeded45Day
    {
        public decimal? AlertId { get; set; }
        public string? EntityNumber { get; set; }
        public string? EntityName { get; set; }
        public string? BranchNumber { get; set; }
        public string? BranchName { get; set; }
        public decimal? LevelOfRisk { get; set; }
        public string? UserLevel1 { get; set; }
        public DateTime? AlertCreateDate { get; set; }
        public DateTime? RoutingDate { get; set; }
        public string? InvestigationDaysLevel1 { get; set; }
        public string? UserLevel2 { get; set; }
        public DateTime? AddToCaseDate { get; set; }
        public string? InvestigationDaysLevel2 { get; set; }
        public string? UserLevel3 { get; set; }
        public DateTime? CaseCloseDate { get; set; }
        public string? InvestigationDaysLevel3 { get; set; }
        public decimal? TotalInvestigationDays { get; set; }
    }
}
