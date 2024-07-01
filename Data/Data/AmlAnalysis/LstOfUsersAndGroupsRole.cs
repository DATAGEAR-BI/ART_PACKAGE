using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.AmlAnalysis
{
    public partial class LstOfUsersAndGroupsRole
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string GroupName { get; set; }
        public string GroupDisplayName { get; set; }
        public string RoleName { get; set; }
        public string RoleDisplayName { get; set; }
    }
}
