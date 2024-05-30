using System;
using System.Collections.Generic;

#nullable disable

namespace DataGear_RV_Ver_1._7.dbcmcaudit
{
    public partial class ListAccessUsersGroupsCap
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Ggroup { get; set; }
        public string Rrole { get; set; }
        public string Capabilities { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LoginDate { get; set; }
    }
}
