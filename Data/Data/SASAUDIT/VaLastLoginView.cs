using System;
using System.Collections.Generic;

namespace Data.Data.SASAUDIT
{
    public partial class VaLastLoginView
    {
        public string? Username { get; set; }
        public string? Appname { get; set; }
        public DateTime? Logindatetime { get; set; }
        public DateTime? Logindate { get; set; }
        public string? Status { get; set; }
    }
}
