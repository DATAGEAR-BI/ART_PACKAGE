using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class ListOfUsersAndGroupsRole
    {
        public string UserName { get; set; } = null!;
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string? MemberOfGroup { get; set; }
        public string? RoleOfGroup { get; set; }
    }
}
