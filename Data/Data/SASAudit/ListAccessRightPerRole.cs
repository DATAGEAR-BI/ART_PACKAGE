using System;
using System.Collections.Generic;

namespace Data.Data.SASAudit
{
    public partial class ListAccessRightPerRole
    {
        public string? UserId { get; set; }
        public string? Role { get; set; }
        public string? RoleDescription { get; set; }
        public string? CapabilityId { get; set; }
        public string? CapName { get; set; }
        public string? CapabilitiyGroupName { get; set; }
        public string? ComponentName { get; set; }
    }
}
