using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DGAMLAC
{
    public partial class AcAlarm
    {

        public decimal AlarmId { get; set; }
        public string ProdType { get; set; }
        public string AlarmStatusCd { get; set; }
        public int MlRiskScore { get; set; }
        public int? TfRiskScore { get; set; }
        public string AlarmDesc { get; set; }
        public string PrimObjLevelCd { get; set; }
        public string AlarmedObjNo { get; set; }
        public string AlarmedObjName { get; set; }
        public string PrimObjNo { get; set; }
        public decimal? PrimObjKey { get; set; }
        public string PrimObjName { get; set; }
        public decimal? RoutineId { get; set; }
        public string RoutineName { get; set; }
        public DateTime? SupprEndDate { get; set; }
        public string ActualValueTxt { get; set; }
        public DateTime RunDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public char? EmpInd { get; set; }
        public int VerNo { get; set; }
        public char LogicDelInd { get; set; }
        public string AlarmTypeCd { get; set; }
        public string AlarmCategCd { get; set; }
        public string AlarmSubcategCd { get; set; }
        public decimal? AlarmedObjKey { get; set; }
        public string AlarmedObjLevelCd { get; set; }
        public string AlarmType { get; set; }
        public int? AlarmScore { get; set; }
        public int? SScore { get; set; }
        public string SAnlysis { get; set; }
        public int? UnSScore { get; set; }
        public string UnSAnlysis { get; set; }
    }
}
