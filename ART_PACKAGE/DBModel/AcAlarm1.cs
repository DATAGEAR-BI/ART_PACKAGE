namespace ART_PACKAGE.DBModel
{
    public partial class AcAlarm1
    {
        public long AlarmId { get; set; }
        public string? ActualValuesText { get; set; }
        public string? AlarmCategoryCd { get; set; }
        public string? AlarmDescription { get; set; }
        public string? AlarmStatusCode { get; set; }
        public string? AlarmSubcategoryCd { get; set; }
        public string? AlarmTypeCd { get; set; }
        public decimal? AlarmedObjKey { get; set; }
        public string? AlarmedObjLevelCode { get; set; }
        public string? AlarmedObjName { get; set; }
        public string? AlarmedObjNumber { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateUserId { get; set; }
        public string? EmployeeInd { get; set; }
        public string? LogicalDeleteInd { get; set; }
        public decimal? MoneyLaunderingRiskScore { get; set; }
        public decimal? PrimaryObjKey { get; set; }
        public string? PrimaryObjLevelCode { get; set; }
        public string? PrimaryObjName { get; set; }
        public string? PrimaryObjNumber { get; set; }
        public string? ProductType { get; set; }
        public decimal? RoutineId { get; set; }
        public string? RoutineName { get; set; }
        public DateTime? RunDate { get; set; }
        public DateTime? SuppressionEndDate { get; set; }
        public decimal? TerrorFinancingRiskScore { get; set; }
        public decimal? VersionNumber { get; set; }
    }
}
