using System;
using System.Collections.Generic;

namespace Data.Data.SASAml
{
    public partial class SlaSummary
    {
        public string? UserName { get; set; }
        public string? DisplayName { get; set; }
        public string? Product { get; set; }
        public string? ViolationFlag { get; set; }
        public long? TotalNumberOfAlertsOrCases { get; set; }

    }
}
