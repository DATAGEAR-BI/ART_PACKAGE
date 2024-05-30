using System;
using System.Collections.Generic;

#nullable disable

namespace DataGear_RV_Ver_1._7.dbcmcaudit
{
    public partial class VaLastLoginView
    {
        public string Username { get; set; }
        public string Appname { get; set; }
        public DateTime? Logindatetime { get; set; }
        public DateTime? Logindate { get; set; }
        public string Status { get; set; }
    }
}
