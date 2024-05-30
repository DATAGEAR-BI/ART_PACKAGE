using System;
using System.Collections.Generic;

#nullable disable

namespace DataGear_RV_Ver_1._7.dbcmcaudit
{
    public partial class ListOfUsersAndGroupsRole
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string MemberOfGroup { get; set; }
        public string UserRole { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string ExtLogin { get; set; }
        public string IntLogin { get; set; }
    }
}
