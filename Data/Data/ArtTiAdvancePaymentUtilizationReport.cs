using System;
using System.Collections.Generic;

namespace Data.Data
{
    public partial class ArtTiAdvancePaymentUtilizationReport
    {
        public string? Branch { get; set; }
        public string? AdvReference { get; set; }
        public string? PrincipalParty { get; set; }
        public string? NonPrincipalParty { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? UtilizationTrn { get; set; }
        public long? AdvAmount { get; set; }
        public string? AdvCurrency { get; set; }
        public long? UtilizationAmount { get; set; }
        public string? UtilizationCurrency { get; set; }
        public decimal? OutstandingAmount { get; set; }
    }
}
