using ART_PACKAGE.Controllers;
using ART_PACKAGE.Controllers.EXPORT_SCHEDULAR;
using ART_PACKAGE.Controllers.FTI.DraftsReport;
using ART_PACKAGE.Helpers.ExportTasks;
using Data.Data.ExportSchedular;

namespace ART_PACKAGE.Helpers.DropDown.ReportDropDownMapper
{
    public class DropDownMapper : IDropDownMapper
    {
        private readonly IDropDownService _dropDown;

        public DropDownMapper(IDropDownService dropDown)
        {
            _dropDown = dropDown;
        }

        public Dictionary<string, List<SelectItem>>? GetDorpDownForReport(string controller)
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
                },
                nameof(SumCountryController) => new Dictionary<string, List<SelectItem>>
                {
                    { "C7CNM".ToLower() , new List<SelectItem> { new SelectItem  { text = "brrrrr" , value = "brrrrr" }, new SelectItem { text = "brrrrr", value = "brrrrr" }, } }
                },
                nameof(TasksController) => new Dictionary<string, List<SelectItem>> {
                { nameof(ExportTaskDto.Period).ToLower(), Enum.GetNames(typeof(TaskPeriod)).Select((x, i) => new SelectItem { text = x, value = i.ToString() }).ToList() },
                { nameof(ExportTaskDto.DayOfWeek).ToLower(), Enum.GetNames(typeof(DayOfWeek)).Select((x, i) => new SelectItem { text = x, value = i.ToString() }).ToList() },
                { nameof(ExportTaskDto.Month).ToLower(), Enum.GetNames(typeof(MonthsOfYear)).Select((x, i) => new SelectItem { text = x, value = i.ToString() }).ToList() },
                },

                _ => null
            };
        }
    }
}
