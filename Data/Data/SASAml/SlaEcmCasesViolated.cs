using System;
using System.Collections.Generic;

namespace Data.Data.SASAml
{
    public partial class SlaEcmCasesViolated
    {
        public string CaseId { get; set; } = null!;
        public string? ClientName { get; set; }
        public string? ClientNumber { get; set; }
        public string? CaseType { get; set; }
        public DateTime CreateDate { get; set; }
        public string? CaseStatus { get; set; }
        public string? LastActionBy { get; set; }
        public DateTime? LastActionDate { get; set; }
        public decimal? NumberOfActions { get; set; }
        public string? ViolatedBy { get; set; }
        public string? ViolatedTime { get; set; }
        public decimal? TotalTime { get; set; }
        public string? Formattedtime { get; set; }
    }
}
