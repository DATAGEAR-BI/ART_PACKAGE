using System;
using System.Collections.Generic;

#nullable disable

namespace DataGear_RV_Ver_1._7.dbcmcaudit
{
    public partial class ListAccessRightPerRole
    {
        public string Role { get; set; }
        public string RoleDescription { get; set; }
        public string CapabilityId { get; set; }
        public string CapName { get; set; }
        public string CapabilitiyGroupName { get; set; }
        public string ComponentName { get; set; }
    }
}
