using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.KYC
{
    public partial class ArtCustomerRenewalDetails
    {

        public string? PartyName { get; set; }
        public string? PartyNumber { get; set; }
        public string PartyType { get; set; } = null!;  // Non-nullable
        public string? PartyOccupation { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string? DateField { get; set; }
        public string? ActionRequired { get; set; }
        public DateTime? LastContactDate { get; set; }
        public DateTime? ChangeBeginDate { get; set; }
        public char ChangeCurrentInd { get; set; }       // Non-nullable
        public char? KycExpiryInd { get; set; }
        public char? RiskClassification { get; set; }
    }
}
