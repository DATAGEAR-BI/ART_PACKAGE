using System;
using System.Collections.Generic;

namespace Data.GOAML
{
    public partial class ReportIndicatorType
    {
        public int ReportId { get; set; }
        public string? Indicator { get; set; }

        public virtual Report Report { get; set; } = null!;
    }
}
