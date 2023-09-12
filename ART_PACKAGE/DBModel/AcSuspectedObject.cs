namespace ART_PACKAGE.DBModel
{
    public partial class AcSuspectedObject
    {
        public string AlarmedObjLevelCd { get; set; } = null!;
        public decimal AlarmedObjKey { get; set; }
        public string? AlarmedObjNo { get; set; }
        public string? AlarmedObjName { get; set; }
        public int? AlarmsCount { get; set; }
        public int? TransCount { get; set; }
        public decimal? AggAmt { get; set; }
        public int? AgeOldAlarm { get; set; }
        public string? RiskScoreCd { get; set; }
        public int? MlScore { get; set; }
        public string? EmpInd { get; set; }
        public string? OwnerUid { get; set; }
        public string? PoliticalExpPersonInd { get; set; }
        public DateTime? CreateTimestamp { get; set; }
        public string? SuspectIdentity { get; set; }
        public string? SuspectQueue { get; set; }
        public string? Branch { get; set; }
        public string? ProdType { get; set; }
    }
}
