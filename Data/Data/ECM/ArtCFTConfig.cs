namespace Data.Data.ECM
{
    public partial class ArtCFTConfig
    {

        public string CaseId { get; set; }
        public string Maker { get; set; }
        public DateTime MakerDate { get; set; }
        public string? Checker { get; set; }
        public DateTime? CheckerDate { get; set; }
        public string? CheckerAction { get; set; }
        public string? ActionDetail { get; set; }
    }
}
