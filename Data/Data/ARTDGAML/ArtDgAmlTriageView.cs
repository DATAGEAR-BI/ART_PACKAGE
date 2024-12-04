using System;
using System.Collections.Generic;

namespace Data.Data.ARTDGAML
{
    public partial class ArtDgAmlTriageView
    {
        public string? AlertedEntityName { get; set; }
        public int? AlertedEntityNumber { get; set; }
        public string? BranchName { get; set; }
        public string? RiskScore { get; set; }
        public string? QueueCode { get; set; }
        public string? OwnerUserName { get; set; }
        public string? AlertedEntityLevel { get; set; }
        public decimal? AggregateAmt { get; set; }
        public int? AgeOldestAlert { get; set; }
        public int? AlertsCntSum { get; set; }
    }
}
