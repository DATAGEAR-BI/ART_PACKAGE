using System;
using System.Collections.Generic;

namespace Data.DGAML
{
    public partial class AcScenarioEvent
    {
        public decimal EventId { get; set; }
        public decimal ScenarioRootKey { get; set; }
        public string? EventTypeCd { get; set; }
        public string? EventDesc { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; } = null!;
    }
}
