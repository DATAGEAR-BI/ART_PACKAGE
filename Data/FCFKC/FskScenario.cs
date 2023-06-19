using System;
using System.Collections.Generic;

namespace Data.FCFKC
{
    public partial class FskScenario
    {
        public decimal ScenarioId { get; set; }
        public decimal HeaderId { get; set; }
        public decimal? RootKey { get; set; }
        public string ScenarioName { get; set; } = null!;
        public string? ScenarioShortDescription { get; set; }
        public string? ScenarioDescription { get; set; }
        public string ScenarioCategoryCode { get; set; } = null!;
        public string ScenarioCodeLocationDesc { get; set; } = null!;
        public string ProductTypeCode { get; set; } = null!;
        public string ScenarioStatusCode { get; set; } = null!;
        public string CurrentInd { get; set; } = null!;
        public decimal DfltSuppressDurationCount { get; set; }
        public decimal ScenarioDurationCount { get; set; }
        public decimal MoneyLaunderingBayesWeight { get; set; }
        public decimal? TerrorFinancingBayesWeight { get; set; }
        public decimal ExecutionProbabilityRate { get; set; }
        public string? RiskFactorInd { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; } = null!;
        public DateTime EndDate { get; set; }
        public string? EndUserId { get; set; }
        public decimal VersionNumber { get; set; }
        public string LogicalDeleteInd { get; set; } = null!;
        public decimal? RoutingGroupId { get; set; }
        public decimal? OrderInHeader { get; set; }
        public string? AlertTypeCd { get; set; }
        public string? AlertCategoryCd { get; set; }
        public string? AlertSubcategoryCd { get; set; }
        public string? RoutingUserLongId { get; set; }
        public DateTime? LstupdateDate { get; set; }
        public string? ScenarioTypeCode { get; set; }
        public string? ScenarioRunFrequencyCode { get; set; }
        public string? SaveTrigTransInd { get; set; }
        public string? SkipIfNoTransCurrDayInd { get; set; }
        public string? EntityLevelCode { get; set; }
        public string? PrimaryEntityNumberVarName { get; set; }
        public string? VsdWindowName { get; set; }
        public string? VsdDeploymentName { get; set; }
        public string? LstupdateUserId { get; set; }
        public string? SegmentsEnabledInd { get; set; }
        public string? BtlEnabledInd { get; set; }
    }
}
