using System;
using System.Collections.Generic;

namespace Data.Data.SASAudit
{
    public partial class SasUsersAndGroupsRole
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? DisplayName { get; set; }
        public string? JobTitle { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? MemberOfGroup { get; set; }
        public string? UserRole { get; set; }
    }
}
