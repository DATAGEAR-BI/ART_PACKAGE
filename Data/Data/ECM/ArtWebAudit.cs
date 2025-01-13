using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.ECM
{
    public partial class ArtWebAudit
    {
        public DateTime? RequestDate { get; set; }
        public string MatchStatus { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public string SearchUser { get; set; }
    }
}
