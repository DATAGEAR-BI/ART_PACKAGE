using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ECM
{
    public class ArtUserPerformance
    {
        public decimal CaseRk { get; set; }
        public string CaseId { get; set; } = null!;
        public DateTime? ValidFromDate { get; set; }
        public string? CaseType { get; set; }
        public string? CaseStatus { get; set; }
        public string? Priority { get; set; }
        public string? CaseDesc { get; set; }
        public string? LockedBy { get; set; }
        public string? CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string? UpdateUserId { get; set; }
        public DateTime? AsssignedTime { get; set; }
        public string? ActionUser { get; set; }
        public string? Action { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public int? DurationsInSeconds { get; set; }
        public int? DurationsInMinutes { get; set; }
        public int? DurationsInHours { get; set; }
        public int? DurationsInDays { get; set; }
    }
}
