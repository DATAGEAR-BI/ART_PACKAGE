using System;
using System.Collections.Generic;

namespace Data.Data.SASAudit
{
    public partial class AuditTrailReport
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Title { get; set; }
        public string? ActionDate { get; set; }
        public string? Description { get; set; }
        public string? ActionType { get; set; }
        public string? ActionOn { get; set; }
        public DateTime? DateTime { get; set; }
        public string? ObjectName { get; set; }
        public string? ObjectType { get; set; }
    }
}
