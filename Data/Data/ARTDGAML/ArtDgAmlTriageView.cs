using System;
using System.Collections.Generic;

namespace Data.Data.ARTDGAML
{
    public partial class ArtDgAmlTriageView
    {
        public string? AlertedEntityName { get; set; }
        public string? AlertedEntityNumber { get; set; }
        
        public string? BranchName { get; set; }
        public string? RiskScore { get; set; }
        public string? QueueCode { get; set; }
        public string? OwnerUserid { get; set; }
        public string? AlertedEntityLevel { get; set; }
        public string? AlertStatus { get; set; }
        public int? AlertsCount { get; set; }
        public int? InvestigationDays { get; set; }
        public string? LastComment { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? NumberOfComments { get; set; }
        public int? NumberOfAttachments { get; set; }
    }
}
