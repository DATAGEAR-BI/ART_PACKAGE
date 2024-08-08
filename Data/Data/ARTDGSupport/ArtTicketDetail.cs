using System;
using System.Collections.Generic;

namespace Data.Data.ARTDGSupport
{
    public partial class ArtTicketDetail
    {
        public string? TicketNumber { get; set; }
        public string? Status { get; set; }
        public string? Title { get; set; }
        public string? PendingReason { get; set; }
        public string? ClientName { get; set; }
        public string? ServiceName { get; set; }
        public string? ServiceSubcategoryName { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public DateTime? CloseDate { get; set; }
    }
}
