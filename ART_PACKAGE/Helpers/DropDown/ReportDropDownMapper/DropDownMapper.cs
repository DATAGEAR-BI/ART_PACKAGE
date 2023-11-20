using ART_PACKAGE.Controllers;

namespace ART_PACKAGE.Helpers.DropDown.ReportDropDownMapper
{
    public class DropDownMapper : IDropDownMapper
    {
        private readonly IDropDownService _dropDown;

        public DropDownMapper(IDropDownService dropDown)
        {
            _dropDown = dropDown;
        }

        public Dictionary<string, List<SelectItem>> GetDorpDownForReport(string controller)
        {
            return controller switch
            {
                nameof(GridController) => new Dictionary<string, List<SelectItem>>
                {
                    {"AlertStatus".ToLower(),_dropDown.GetAlertStatusDropDown()},
                    {"AlertSubCat".ToLower(),_dropDown.GetCaseSubCategoryDropDown() },
                    //{"OwnerUserid".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown()},
                    {"PartyTypeDesc".ToLower(),_dropDown.GetPartyTypeDropDown() },
                    {"PoliticallyExposedPersonInd".ToLower(), new List<string>(){"Y","N"}.Select(x=> new SelectItem{ text = x,value = x }).ToList()  },
                    {"ScenarioName".ToLower(),_dropDown.GetScenarioNameDropDown() }
                }
            };
        }
    }
}
