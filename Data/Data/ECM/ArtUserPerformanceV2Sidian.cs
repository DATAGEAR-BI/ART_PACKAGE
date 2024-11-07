using System;
using System.Collections.Generic;

namespace Data.Data.ECM
{
    public partial class ArtUserPerformanceV2Sidian
    {
        public decimal CaseRk { get; set; }
        public string CaseId { get; set; } = null!;
        public DateTime? ValidFromDate { get; set; }
        public string? CaseTypeCd { get; set; }
        public string? CaseStatus { get; set; }
        public string? CaseDesc { get; set; }
        public string? LockedBy { get; set; }
        public string? CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string? UpdateUserId { get; set; }
        public DateTime? AsssignedTime { get; set; }
        public string? ActionUser { get; set; }
        public string? Action { get; set; }
        public DateTime? ReleasedDate { get; set; }
    }
}
