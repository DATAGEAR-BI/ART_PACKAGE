using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.Audit
{
    public class ArtUsersAuditView
    {
        public string? UserName { get; set; }
        public string? Action { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastFailedLogin { get; set; }
        public bool? Enable { get; set; }
        public string? GroupNames { get; set; }
        
      
        public string? RoleNames { get; set; }
        public string? DomainAccounts { get; set; }
    }
}
