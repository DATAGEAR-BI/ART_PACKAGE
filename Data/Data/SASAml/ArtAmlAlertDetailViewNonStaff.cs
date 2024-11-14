using System;
using System.Collections.Generic;

namespace Data.Data.SASAml
{
    public partial class ArtAmlAlertDetailViewNonStaff
    {
        public string AlertedEntityNumber { get; set; } = null!;
        public string? AlertedEntityName { get; set; }
        public string? BranchName { get; set; }
        public string? BranchNumber { get; set; }
        public string? PartyTypeDesc { get; set; }
        public decimal AlertId { get; set; }
        public string? AlertDescription { get; set; }
        public string? ActualValuesText { get; set; }
        public string? AlertStatus { get; set; }
        public string? AlertSubCat { get; set; }
        public string? AlertTypeCd { get; set; }
        public string? ScenarioName { get; set; }
        public decimal? ScenarioId { get; set; }
        public decimal MoneyLaunderingRiskScore { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime RunDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string? ClosedBy { get; set; }
        public string? ReportCloseRsn { get; set; }
        public string? OwnerUserid { get; set; }
        public string? Queue { get; set; }
        public string PoliticallyExposedPersonInd { get; set; } = null!;
        public string? EmployeeInd { get; set; }
        public int? NumberOfComments { get; set; }
        public string? LastComment { get; set; }
        public int? InvestigationDays { get; set; }
    }
}
