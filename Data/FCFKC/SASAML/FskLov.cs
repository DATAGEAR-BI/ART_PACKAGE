namespace Data.FCFKC.SASAML
{
    public partial class FskLov
    {
        public string LovTypeName { get; set; } = null!;
        public string LovTypeCode { get; set; } = null!;
        public string LovLanguageDesc { get; set; } = null!;
        public string? LovTypeDesc { get; set; }
        public int? LovSortPositionNumber { get; set; }
        public string ActiveFlg { get; set; } = null!;
    }
}
