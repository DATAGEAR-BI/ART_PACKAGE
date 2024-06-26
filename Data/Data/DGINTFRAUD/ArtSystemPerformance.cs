using System;
using System.Collections.Generic;

namespace Data.Data.DGINTFRAUD
{
    public partial class ArtSystemPerformance
    {
        public string CaseId { get; set; } = null!;
        public string? CaseType { get; set; }
        public string? CaseDescription { get; set; }
        public string? CaseStatus { get; set; }
        public string? Priority { get; set; }
        public string? CustomerNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? LockedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public string? PrimaryOwner { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? LastStatusDate { get; set; }
        public string? LastComment { get; set; }
        public string? LastCommentSubject { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public decimal? NumberOfComments { get; set; }
        public decimal? NumberOfAttachments { get; set; }
        public decimal? DurationsInSeconds { get; set; }
        public decimal? DurationsInMinutes { get; set; }
        public decimal? DurationsInHours { get; set; }
        public decimal? DurationsInDays { get; set; }
    }
}
