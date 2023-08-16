using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class ArtFtiEcmTransaction
    {
        public string EcmReference { get; set; } = null!;
        public string? Product { get; set; }
        public string? ProductType { get; set; }
        public double? Amount { get; set; }
        public string? Currency { get; set; }
        public string? FtiReference { get; set; }
        public string? EventName { get; set; }
        public string? EventStatus { get; set; } 
        public DateTime? EventCreationDate { get; set; }
        public string? FirstLineParty { get; set; }

    }
}
