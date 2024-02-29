using System;
using System.Collections.Generic;

namespace Data.Data.SASAml
{
    public partial class ArtAuditReportView
    {
        public string? Customer { get; set; }
        public DateTime? Date { get; set; }
        public string? Time { get; set; }
        public string? User { get; set; }
        public string? Ip { get; set; }
        public string? Action { get; set; }
        public string? Parameter { get; set; }
        public string? Details { get; set; }
        public decimal? DurationInSeconds { get; set; }
        public string? Alert { get; set; }
        public string? Case { get; set; }
        public string? RiskAssessment { get; set; }
    }
}
