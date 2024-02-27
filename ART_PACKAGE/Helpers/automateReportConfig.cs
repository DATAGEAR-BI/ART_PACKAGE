using ART_PACKAGE.Helpers.CSVMAppers;

namespace ART_PACKAGE.Helpers
{
    public static class automateReportConfig
    {
        public static void automate()
        {
            string baseFolder = "E:\\reportconfigs";
            foreach (KeyValuePair<string, ReportConfig> config in ReportsConfig.CONFIG)
            {
                string name = config.Key;
                string skiplist = config.Value.SkipList is not null &&
                               config.Value.SkipList.Count > 0
                    ? string.Join(",\n", config.Value.SkipList.Select(x => $"\"{x}\""))
                    : "";

                string displaynames = config.Value.DisplayNames is not null &&
                                   config.Value.DisplayNames.Count > 0
                    ? string.Join(",\n", config.Value.DisplayNames.Select(x => $@"{{""{x.Key}"" , new GridColumnConfiguration {{ DisplayName = ""{x.Value.DisplayName}""  , Format = ""{x.Value.Format}""  ,  Filter = ""{x.Value.Filter}"" , Template = ""{x.Value.Template}"" , AggText = ""{x.Value.AggText}""  , isLargeText = {x.Value.isLargeText}   }} }}")) : "";
                string actionbtns = config.Value.Actions is not null &&
                                    config.Value.Actions.Count > 0 ? string.Join(",\n", config.Value.Actions.Select(x => $"new GridButton {{ action = \"{x.action}\" , text = \"{x.text}\" ,icon = \"{x.icon}\" }}"))
                                                                    : "";
                string toolbarbtns = config.Value.Toolbar is not null &&
                                    config.Value.Toolbar.Count > 0 ? string.Join(",\n", config.Value.Toolbar.Select(x => $"new GridButton {{ action = \"{x.action}\" , text = \"{x.text}\" ,icon = \"{x.icon}\" }}"))
                                                                    : "";
                string skip = !string.IsNullOrEmpty(skiplist) ? string.Format("this.SkipList = new List<string>(){{ {0} }};", skiplist) : "";
                string display = !string.IsNullOrEmpty(displaynames) ? string.Format("this.DisplayNames = new Dictionary<string, GridColumnConfiguration>(){{ {0} }};", displaynames) : "";
                string containsActions = config.Value.ContainsActions ? "this.ContainsActions = true;" : "";
                string actions = !string.IsNullOrEmpty(actionbtns) ? string.Format("this.Actions = new List<GridButton>(){{ {0} }};", actionbtns) : "";
                string toolbar = !string.IsNullOrEmpty(toolbarbtns) ? string.Format("this.Toolbar = new List<GridButton>(){{ {0} }};", toolbarbtns) : "";
                string classTemplate = @$"using System;
using System.Collections.Generic;
namespace ART_PACKAGE.Helpers.ReportsConfigurations
{{
public class {name}Config : ReportConfig
{{
    public {name}Config()
    {{
       
            {skip}

            {display}

            {containsActions}

            {actions}
            
            {toolbar}
        
   }}
}}
}}";

                string filepath = Path.Combine(baseFolder, $"{name}Config.cs");
                File.WriteAllText(filepath, classTemplate);
            }
        }
    }
}