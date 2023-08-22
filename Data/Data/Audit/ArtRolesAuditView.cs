using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.Audit
{
    public class ArtRolesAuditView
    {
        public string? RoleName { get; set; }
        public string? Action { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string? GroupNames { get; set; }
        public string? MemberUsers { get; set; }
    }
}
