using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Data.SASAudit
{
    public partial class VaLastLogin
    {
        public string Username { get; set; }
        public string Logindatetime { get; set; }
        public DateTime? Logindate { get; set; }
        public string Appname { get; set; }
    }
}
