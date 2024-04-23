using ART_PACKAGE.Data.Attributes;

namespace Data.Services.AmlAnalysis
{
    public enum AmlAnalysisAction
    {
        Close,
        Route,
        [Option(DisplayName = "No Action")]
        NoAction
    }
}
