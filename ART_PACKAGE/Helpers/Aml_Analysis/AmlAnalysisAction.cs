using ART_PACKAGE.Data.Attributes;

namespace ART_PACKAGE.Helpers
{
    public enum AmlAnalysisAction
    {
        Close,
        Route,
        [Option(DisplayName = "No Action", IsHidden = false)]
        NoAction
    }
}
