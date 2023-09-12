using System;
using System.Collections.Generic;

namespace Data.DGAML
{
    public partial class AcAlarm
    {
        public decimal AlarmId { get; set; }
        public string ProdType { get; set; } = null!;
        public string AlarmStatusCd { get; set; } = null!;
        public int MlRiskScore { get; set; }
        public int? TfRiskScore { get; set; }
        public string AlarmDesc { get; set; } = null!;
        public string PrimObjLevelCd { get; set; } = null!;
        public string AlarmedObjNo { get; set; } = null!;
        public string? AlarmedObjName { get; set; }
        public string PrimObjNo { get; set; } = null!;
        public decimal? PrimObjKey { get; set; }
        public string? PrimObjName { get; set; }
        public decimal? RoutineId { get; set; }
        public string? RoutineName { get; set; }
        public DateTime? SupprEndDate { get; set; }
        public string? ActualValueTxt { get; set; }
        public DateTime RunDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; } = null!;
        public string? EmpInd { get; set; }
        public int VerNo { get; set; }
        public string LogicDelInd { get; set; } = null!;
        public string? AlarmTypeCd { get; set; }
        public string? AlarmCategCd { get; set; }
        public string? AlarmSubcategCd { get; set; }
        public decimal? AlarmedObjKey { get; set; }
        public string? AlarmedObjLevelCd { get; set; }
        public string? AlarmType { get; set; }
        public int? AlarmScore { get; set; }
        public int? SScore { get; set; }
        public string? SAnlysis { get; set; }
        public int? UnSScore { get; set; }
        public string? UnSAnlysis { get; set; }
    }
}
