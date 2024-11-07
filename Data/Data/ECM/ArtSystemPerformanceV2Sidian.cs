using System;
using System.Collections.Generic;

namespace Data.Data.ECM
{
    public partial class ArtSystemPerformanceV2Sidian
    {
        public string CaseId { get; set; } = null!;
        public decimal CaseRk { get; set; }
        public DateTime? ValidFromDate { get; set; }
        public string? CaseType { get; set; }
        public string? CaseStatus { get; set; }
        public string? CaseDesc { get; set; }
        public string? CreateUserId { get; set; }
        public string? InvestrUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string? UpdateUserId { get; set; }
        public string? ClientName { get; set; }
        public string? IdentityNum { get; set; }
        public string? LockedBy { get; set; }
        public DateTime? EcmLastStatusDate { get; set; }
        public string? LastStatus { get; set; }
        public string? HitsCount { get; set; }
        public string? LastComment { get; set; }
        public string? LastCommentSubject { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public int? NumberOfComments { get; set; }
        public string? IncidentId { get; set; }
        public string? WatchListName { get; set; }
    }
}
