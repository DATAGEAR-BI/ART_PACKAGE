using System;
using System.Collections.Generic;

namespace Data.DGSASAUDIT
{
    public partial class VaLocation
    {
        public string? Keyid { get; set; }
        public string? LocationName { get; set; }
        public string? LocationType { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Postalcode { get; set; }
        public string? Area { get; set; }
        public string? Country { get; set; }
        public string? Objid { get; set; }
        public int? Externalkey { get; set; }
    }
}
