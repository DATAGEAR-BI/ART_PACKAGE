using System;
using System.Collections.Generic;

namespace Data.DGAMLAC
{
    public partial class AcRoutine
    {
        public decimal RoutineId { get; set; }
        public decimal? HeaderId { get; set; }
        public decimal? RootKey { get; set; }
        public string RoutineName { get; set; } = null!;
        public string RoutineShortDesc { get; set; } = null!;
        public string RoutineDesc { get; set; } = null!;
        public string RoutineCategCd { get; set; } = null!;
        public string? RoutineCdLocDesc { get; set; }
        public string ProdTypeCd { get; set; } = null!;
        public string RoutineStatusCd { get; set; } = null!;
        public string CurrentInd { get; set; } = null!;
        public int DfltSupprDurCount { get; set; }
        public int RoutineDurCount { get; set; }
        public decimal MlBayesWeight { get; set; }
        public decimal? TfBayesWeight { get; set; }
        public decimal? ExecProbRate { get; set; }
        public string? RiskFactInd { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; } = null!;
        public DateTime EndDate { get; set; }
        public string? EndUserId { get; set; }
        public int VerNo { get; set; }
        public string? LogicDelInd { get; set; }
        public decimal? RouteGrpId { get; set; }
        public int? OrderInHeader { get; set; }
        public string? AlarmTypeCd { get; set; }
        public string? AlarmCategCd { get; set; }
        public string? AlarmSubcategCd { get; set; }
        public string? RouteUserLongId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string? RoutineTypeCd { get; set; }
        public string? RoutineRunFreqCd { get; set; }
        public string? SaveTrigTransInd { get; set; }
        public string? SkipIfNoTransCcyDayInd { get; set; }
        public string? ObjLevelCd { get; set; }
        public string? PrimObjNoVarName { get; set; }
        public string? VsdWinName { get; set; }
        public string? VsdInstallationName { get; set; }
        public string? LastUpdateUserId { get; set; }
        public string RoutineMsgTxt { get; set; } = null!;
        public string? CorrespondingViewNm { get; set; }
        public string? ComparedDateAttribute { get; set; }
        public string? AdminStatusCd { get; set; }
    }
}
