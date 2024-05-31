using System;
using System.Collections.Generic;

namespace Data.DGSASAUDIT
{
    public partial class VaLocationInfo
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? Area { get; set; }
        public string? City { get; set; }
        public string? PostCode { get; set; }
        public string? Country { get; set; }
        public string? LocationType { get; set; }
        public string? PersonId { get; set; }
        public string? PersonExtIdIdentifier { get; set; }
        public string? PersonExtIdContext { get; set; }
    }
}
