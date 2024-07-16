using System;
using System.Collections.Generic;

namespace Data.FCFKC.SASAML
{
    public partial class Fsk_EntityQueue
    {
        public string? QueueCode { get; set; }
        public string AlertedEntityLevelCode { get; set; } = null!;
        public string AlertedEntityNumber { get; set; } = null!;
        public string? OwnerUserid { get; set; }
    }
}
