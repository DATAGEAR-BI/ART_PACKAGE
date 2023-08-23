using ART_PACKAGE.Data.Attributes;

namespace ART_PACKAGE.Helpers.Aml_Analysis
{
    public enum AmlAnalysisAction
    {
        Close,
        Route,
        [Option(DisplayName = "No Action")]
        NoAction
    }
}
