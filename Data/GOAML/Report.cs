using System;
using System.Collections.Generic;

namespace Data.GOAML
{
    public partial class Report
    {
        public int Id { get; set; }
        public string? Action { get; set; }
        public string? CurrencyCodeLocal { get; set; }
        public string? EntityReference { get; set; }
        public string? FiuRefNumber { get; set; }
        public string? Location { get; set; }
        public string? Reason { get; set; }
        public string? RentityBranch { get; set; }
        public int RentityId { get; set; }
        public string? ReportClosedDate { get; set; }
        public string? ReportCode { get; set; }
        public string? ReportCreatedBy { get; set; }
        public string ReportCreatedDate { get; set; } = null!;
        public string? ReportRiskSignificance { get; set; }
        public string? ReportStatusCode { get; set; }
        public string? ReportUserLockId { get; set; }
        public string? ReportXml { get; set; }
        public string? SubmissionCode { get; set; }
        public string? SubmissionDate { get; set; }
        public string? Version { get; set; }
        public string? Priority { get; set; }
        public string? ReportingPersonType { get; set; }
        public bool? IsValid { get; set; }
    }
}
