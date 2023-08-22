using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.Audit
{
    public class ArtGroupsAuditView
    {
        public string? GroupName { get; set; }
        public string? Action { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string? SubGroupNames { get; set; }
        public string? RoleNames { get; set; }
        public string? MemberUsers { get; set; }
    }
}
