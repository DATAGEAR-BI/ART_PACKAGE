using System;
using System.Collections.Generic;

namespace Data.Data.SASAUDIT
{
    public partial class SasListAccessRightPerRole
    {
        public string? Role { get; set; }
        public string? RoleDescription { get; set; }
        public string? CapabilityId { get; set; }
        public string? CapName { get; set; }
        public string? CapabilitiyGroupName { get; set; }
        public string? ComponentName { get; set; }
    }
}
