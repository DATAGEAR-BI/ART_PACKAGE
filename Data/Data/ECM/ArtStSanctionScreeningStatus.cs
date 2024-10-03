using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ECM
{
    public partial class ArtStSanctionScreeningStatus
    {
        public int REQUEST_ID { get; set; }
        public DateTime? REQUEST_DATE { get; set; } 
        public string? MATCH_STATUS { get; set; }

        public string? SEARCH_MESSAGE { get; set; }

        public string? SOURCE_TYPE { get; set; }
        public string? Screening_List { get; set; }
    }
}
