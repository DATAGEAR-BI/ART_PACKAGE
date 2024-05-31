using System;
using System.Collections.Generic;

namespace Data.DGSASAUDIT
{
    public partial class VaLogin
    {
        public string? Keyid { get; set; }
        public string? Userid { get; set; }
        public string? Password { get; set; }
        public string? Authdomkeyid { get; set; }
        public string? Objid { get; set; }
        public int? Externalkey { get; set; }
    }
}
