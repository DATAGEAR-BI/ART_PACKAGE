using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ARTDGAML
{
    public partial class ArtAlertsCommentsPopupView
    {
        public decimal AlarmId { get; set; }
        public decimal? AlarmedObjKey { get; set; }
        public string? Comment { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? StateIndicator { get; set; }
    }
}
