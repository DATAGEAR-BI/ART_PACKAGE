using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ECM
{
    public partial class ArtStSanctionListUpdate
    {
        public DateTime STATUS_DATE { get; set; }
        public string Entity_Number { get; set; } = null!; 
        public string? ENTITY_NAME { get; set; }

        public string WATCH_LIST_NAME { get; set; } = null!;
        public string? ENTITY_TYPE { get; set; }
        public string? PROGRAMS { get; set; }
        public int? Number_Of_Actions { get; set; }
        public string STATUS { get; set; } = null!;

    }
}
