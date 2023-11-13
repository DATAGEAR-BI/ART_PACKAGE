using System;
using System.Collections.Generic;

namespace Data.Data.CRP
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
        public string CaseCurrentRate { get; set; } = null!;
        public string Casetargetrate { get; set; } = null!;
        public string? Action { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public int? DurationsInSeconds { get; set; }
        public int? DurationsInMinutes { get; set; }
        public int? DurationsInHours { get; set; }
        public int? DurationsInDays { get; set; }
    }
}
