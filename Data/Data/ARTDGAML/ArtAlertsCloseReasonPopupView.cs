using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ARTDGAML
{
    public class ArtAlertsCloseReasonPopupView
    {
        public decimal AlarmId { get; set; }
        public string? AlarmStatus { get; set; }
        public string? CloseReason { get; set; }
        public DateTime CloseDate { get; set; }
        public string ClosedBy { get; set; } = null!;
    }
}
