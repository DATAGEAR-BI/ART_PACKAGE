using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ARTDGAML
{
    public partial class ArtStDgAmlCommentsDetail
    {
        public Decimal ALARM_ID { get; set; }
        public DateTime RUN_DATE { get; set; } 
        public string? COMMENT { get; set; }

        public Decimal? COMMENT_USER { get; set; }

        public DateTime? COMMENT_DATE { get; set; }
    }
}
