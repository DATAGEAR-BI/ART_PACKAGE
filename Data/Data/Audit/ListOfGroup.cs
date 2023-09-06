using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.Audit
{
    public class ListOfGroup
    {
        public string GroupName { get; set; } = null!;
        public string? Description { get; set; }
        public string GroupType { get; set; } = null!;
        public string? DisplayName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
