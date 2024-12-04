namespace Data.Data.CRP
{
    public partial class ArtCrpConfig
    {
        public string CaseId { get; set; } = null!;

        public string? Maker { get; set; }

        public DateTime MakerDate { get; set; }

        public string? Checker { get; set; }

        public DateTime? CheckerDate { get; set; }

        public string? CheckerAction { get; set; }

        public string? ActionDetail { get; set; }
    }
}
