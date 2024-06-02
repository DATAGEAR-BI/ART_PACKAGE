using System;
using System.Collections.Generic;

namespace Data.DGSASAUDIT
{
    public partial class VaGrouploginsInfo
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? UserId { get; set; }
        public string? Password { get; set; }
        public string? GroupId { get; set; }
        public string? AuthDomId { get; set; }
        public string? AuthDomName { get; set; }
        public string? AuthDomExtIdContext { get; set; }
        public string? AuthDomExtIdIdentifier { get; set; }
        public string? GroupExtIdIdentifier { get; set; }
        public string? GroupExtIdContext { get; set; }
    }
}
