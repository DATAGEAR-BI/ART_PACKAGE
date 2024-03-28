using System;
using System.Collections.Generic;

namespace Data.Data.TRADE_BASE
{
    public partial class ArtTradeBaseSummary
    {
        public string EntityNumber { get; set; } = null!;
        public string? EntityName { get; set; }
        public int? Active { get; set; }
        public int? AddedToCase { get; set; }
        public int? Closed { get; set; }
        public int? SuppressedAlert { get; set; }
    }
}
