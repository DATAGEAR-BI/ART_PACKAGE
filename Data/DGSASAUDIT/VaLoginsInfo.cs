using System;
using System.Collections.Generic;

namespace Data.DGSASAUDIT
{
    public partial class VaLoginsInfo
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Description { get; set; }
        public string? UserId { get; set; }
        public string? Password { get; set; }
        public string? PersonId { get; set; }
        public string? AuthDomId { get; set; }
        public string? AuthDomName { get; set; }
        public string? AuthDomExtIdContext { get; set; }
        public string? AuthDomExtIdIdentifier { get; set; }
        public string? PersonExtIdIdentifier { get; set; }
        public string? PersonExtIdContext { get; set; }
    }
}
