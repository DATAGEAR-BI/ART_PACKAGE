using System;
using System.Collections.Generic;

namespace Data.DGAMLAC
{
    public partial class AcRoutineParameter
    {
        public decimal RoutineId { get; set; }
        public string ParmName { get; set; } = null!;
        public string ParmValue { get; set; } = null!;
        public string ParmTypeDesc { get; set; } = null!;
        public string ParmDesc { get; set; } = null!;
        public string? ValueCate { get; set; }
        public string? ParamCondition { get; set; }
        public string? DayType { get; set; }
    }
}
