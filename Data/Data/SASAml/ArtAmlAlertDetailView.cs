using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.SASAml
{
    public class ArtAmlAlertDetailView
    {
        public string? AlertedEntityNumber { get; set; }
        public string? AlertedEntityName { get; set; }
        public string? PartyTypeDesc { get; set; }
        public string? BranchName { get; set; }
        public string? BranchNumber { get; set; }
        public long? AlertId { get; set; }
        public string? AlertDescription { get; set; }
        public string? ActualValuesText { get; set; }
        public string? AlertStatus { get; set; }
        public string? AlertSubCat { get; set; }
        public string? AlertTypeCd { get; set; }
        public string? ScenarioName { get; set; }
        public long? ScenarioId { get; set; }
        public int? MoneyLaunderingRiskScore { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? RunDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string? OwnerUserid { get; set; }
        public string? ReportCloseRsn { get; set; }
        public string? PoliticallyExposedPersonInd { get; set; }
        public string? EmployeeInd { get; set; }
        public int? InvestigationDays { get; set; }
    }
}
