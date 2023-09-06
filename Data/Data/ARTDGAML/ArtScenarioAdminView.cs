using System;
using System.Collections.Generic;

namespace Data.Data.ARTDGAML
{
    public partial class ArtScenarioAdminView
    {
        public string ScenarioName { get; set; } = null!;
        public string ScenarioShortDesc { get; set; } = null!;
        public string ScenarioDesc { get; set; } = null!;
        public string? ScenarioStatus { get; set; }
        public string? ScenarioCategory { get; set; }
        public string? ProductType { get; set; }
        public string? RiskFact { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreateUserId { get; set; } = null!;
        public string? ScenarioType { get; set; }
        public string? ScenarioFrequency { get; set; }
        public string ScenarioMessage { get; set; } = null!;
        public string? ObjectLevel { get; set; }
        public string? AlarmType { get; set; }
        public string? AlarmCategory { get; set; }
        public string? AlarmSubcategory { get; set; }
        public string? DependedData { get; set; }
        public string? ParmName { get; set; }
        public string? ParmValue { get; set; }
        public string? ParmDesc { get; set; }
        public string? ParmTypeDesc { get; set; }
        public string? ParamCondition { get; set; }
        public string? ScorParmName { get; set; }
        public string? ScorDependAttribute { get; set; }
    }
}
