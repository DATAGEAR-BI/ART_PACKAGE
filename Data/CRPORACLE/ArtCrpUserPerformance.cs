using System;
using System.Collections.Generic;

namespace Data.CRPORACLE
{
    public partial class ArtCrpUserPerformance
    {
        public string CaseId { get; set; } = null!;
        public string? CaseType { get; set; }
        public string? CaseStatus { get; set; }
        public string? CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? AsssignedTime { get; set; }
        public string? ActionUser { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerNumber { get; set; }
        public string? CaseCurrentRate { get; set; }
        public string? Casetargetrate { get; set; }
        public string? Action { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public decimal? DurationsInSeconds { get; set; }
        public decimal? DurationsInMinutes { get; set; }
        public decimal? DurationsInHours { get; set; }
        public decimal? DurationsInDays { get; set; }
    }
}
