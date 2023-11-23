using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.Audit
{
    public class ListOfUsersAndGroupsRole
    {
        public string UserName { get; set; } = null!;
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string? MemberOfGroup { get; set; }
        public string? RoleOfGroup { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool? AccountStatus { get; set; }
    }
}
