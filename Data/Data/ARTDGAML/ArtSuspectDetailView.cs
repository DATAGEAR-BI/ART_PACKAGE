using System;
using System.Collections.Generic;

namespace Data.Data.ARTDGAML
{
    public partial class ArtSuspectDetailView
    {
        public string? SuspectNumber { get; set; }
        public string? SuspectName { get; set; }
        public string? BranchName { get; set; }
        public string? ProfileRisk { get; set; }
        public int? NumberOfAlarms { get; set; }
        public int? AgeOfOldestAlert { get; set; }
        public string? OwnerUserId { get; set; }
        public DateTime? CustBirthDate { get; set; }
        public string? PoliticalExpPrsnInd { get; set; }
        public int? RiskClassification { get; set; }
        public string? CitizenCntryName { get; set; }
        public string? CustIdentId { get; set; }
        public string? CustIdentTypeDesc { get; set; }
        public DateTime? CustIdentExpDate { get; set; }
        public DateTime? CustIdentIssDate { get; set; }
        public string? EmprName { get; set; }
        public string? OccupDesc { get; set; }
        public string? TelNo1 { get; set; }
        public DateTime? CustSinceDate { get; set; }
    }
}
