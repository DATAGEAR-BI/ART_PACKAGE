using System;
using System.Collections.Generic;

namespace Data.Data.ECM
{
    public partial class ArtSwiftClearDetect
    {
        public DateTime? RequestDate { get; set; }
        public int RequestUid { get; set; }
        public string? Direction { get; set; }
        public string? Correspondent { get; set; }
        public string? Type { get; set; }
        public string? Reference { get; set; }
        public string? CurrencyAmount { get; set; }
        public string? InstanceType { get; set; }
        public string? Sender { get; set; }
        public string? Status { get; set; }
        public string? Branch { get; set; }
        public string? Body { get; set; }
    }
}
