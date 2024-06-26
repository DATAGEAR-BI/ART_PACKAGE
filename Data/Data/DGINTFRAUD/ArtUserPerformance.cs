using System;
using System.Collections.Generic;

namespace Data.Data.DGINTFRAUD
{
    public partial class ArtUserPerformance
    {
        public int CaseRk { get; set; }
        public string CaseId { get; set; } = null!;
        public string? CaseType { get; set; }
        public string? CaseDescription { get; set; }
        public string? CaseStatus { get; set; }
        public string? Priority { get; set; }
        public string? CustomerNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? LockedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? AsssignedTime { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public string? ActionUser { get; set; }
        public string? Action { get; set; }
        public decimal? DurationsInSeconds { get; set; }
        public decimal? DurationsInMinutes { get; set; }
        public decimal? DurationsInHours { get; set; }
        public decimal? DurationsInDays { get; set; }
    }
}
