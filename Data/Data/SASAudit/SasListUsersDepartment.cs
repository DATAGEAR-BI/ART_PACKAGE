using System;
using System.Collections.Generic;

namespace Data.Data.SASAudit
{
    public partial class SasListUsersDepartment
    {
        public string? UserId { get; set; }
        public string? UserDisplayName { get; set; }
        public string? UserTitle { get; set; }
        public string? UserDesccription { get; set; }
        public string? Department { get; set; }
        public string? Appname { get; set; }
        public DateTime? Logindatetime { get; set; }
    }
}
