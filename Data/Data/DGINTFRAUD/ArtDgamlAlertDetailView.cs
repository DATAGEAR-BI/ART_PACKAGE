using System;
using System.Collections.Generic;

namespace Data.Data.DGINTFRAUD
{
    public partial class ArtDgamlAlertDetailView
    {
        public long? AlertId { get; set; }
        public string? CustomerNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? AlertDescription { get; set; }
        public string? BranchName { get; set; }
        public long? ScenarioId { get; set; }
        public string? ScenarioName { get; set; }
        public int? MoneyLaunderingRiskScore { get; set; }
        public string? AlertStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? RunDate { get; set; }
        public string? ClosedUserId { get; set; }
        public string? ClosedUserName { get; set; }
        public DateTime? CloseDate { get; set; }
        public string? ReportCloseReason { get; set; }
        public decimal? InvestigationDays { get; set; }
    }
}
