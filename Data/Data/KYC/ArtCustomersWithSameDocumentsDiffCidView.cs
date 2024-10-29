using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.KYC
{
    public class ArtCustomersWithSameDocumentsDiffCidView
    {
        public string CustNo { get; set; } = null!;
        public string? CustIdentId { get; set; }
        public string? PassPortNumber { get; set; }
        public string? KraPin { get; set; }
        public string SimilarDocument { get; set; } = null!;

    }
}
