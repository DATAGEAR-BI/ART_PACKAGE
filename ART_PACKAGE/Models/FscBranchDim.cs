namespace ART_PACKAGE.Models
{
    public partial class FscBranchDim
    {
        public long BranchKey { get; set; }
        public string? BranchTypeDesc { get; set; }
        public string? BranchNumber { get; set; }
        public string? BranchName { get; set; }
        public string? StreetAddress1 { get; set; }
        public string? StreetAddress2 { get; set; }
        public string? StreetCityName { get; set; }
        public string? StreetStateCode { get; set; }
        public string? StreetStateName { get; set; }
        public string? StreetPostalCode { get; set; }
        public string? StreetCountryCode { get; set; }
        public string? StreetCountryName { get; set; }
        public DateTime? ChangeBeginDate { get; set; }
        public DateTime ChangeEndDate { get; set; }
        public string ChangeCurrentInd { get; set; } = null!;
    }
}
