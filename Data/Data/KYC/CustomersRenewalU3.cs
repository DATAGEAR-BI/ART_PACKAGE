namespace Data.Data.KYC
{
    public class CustomersRenewalU3
    {
        public string CustomerNumber { get; set; } = null!;
        public string? CustomerName { get; set; }
        public string Type { get; set; } = null!;
        public string? Occupation { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string? DateField { get; set; }
        public string? ActionRequired{get; set; }
        public DateTime? LastContactDate { get; set; }
        public DateTime? ChangeBeginDate { get; set; }
        public string? ChangeCurrentIND { get; set; } = null!;
        public string? KYCExpiryIND { get; set; }
        public string? RiskClassification { get; set; }


        public string? CustomerBranch { get; set; }
        public string? AccountOfficer { get; set; }
        public string? CustomerBusinessSegment { get; set; }

    }
}
