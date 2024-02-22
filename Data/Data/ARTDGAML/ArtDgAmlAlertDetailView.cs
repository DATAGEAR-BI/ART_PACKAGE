using System;
using System.Collections.Generic;

namespace Data.Data.ARTDGAML
{
    public partial class ArtDgAmlAlertDetailView
    {
        public decimal AlarmId { get; set; }
        public string AlertedEntityNumber { get; set; } = null!;
        public string? AlertedEntityName { get; set; }
        public string AlertDescription { get; set; } = null!;
        public string? ActualValuesText { get; set; }
        public string? BranchName { get; set; }
        public decimal? ScenarioId { get; set; }
        public string? ScenarioName { get; set; }
        public int MoneyLaunderingRiskScore { get; set; }
        public string? AlertCategory { get; set; }
        public string? AlertSubcategory { get; set; }
        public string? AlertStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime RunDate { get; set; }
        public string? PoliticallyExposedPersonInd { get; set; }
        public string? EmpInd { get; set; }
        public string? ClosedUserId { get; set; }
        public string? CloseUserName { get; set; }
        public DateTime? CloseDate { get; set; }
        public string? CloseReason { get; set; }
        public int? InvestigationDays { get; set; }
        public string? ForwardBy { get; set; }
    }
}
