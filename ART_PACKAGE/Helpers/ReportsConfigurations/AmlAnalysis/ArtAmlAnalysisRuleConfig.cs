namespace ART_PACKAGE.Helpers.ReportsConfigurations
{
    public class ArtAmlAnalysisRuleConfig : ReportConfig
    {
        public ArtAmlAnalysisRuleConfig()
        {
            SkipList = new List<string>() { nameof(ArtAmlAnalysisRule.Deleted) };
            DisplayNames = new Dictionary<string, GridColumnConfiguration>()
            {
                {
                    nameof(ArtAmlAnalysisRule.Active),
                    new GridColumnConfiguration() { Template = "activeSwitch" }
                }
            };

            Selectable = true;

            Toolbar = new List<GridButton>()
            {
                new GridButton { text = "Test Rules", action = "testRules" },
                new GridButton { text = "Create A rule", action = "crtrule" },
            };
            ContainsActions = true;

            Actions = new List<GridButton>()
            {
                new GridButton() { action = "deleteRule", text = "Delete Rule" }
            };
        }
    }
}
