using Data.Services.Grid;

namespace ART_PACKAGE.Helpers.DropDown.ReportDropDownMapper
{
    public interface IDropDownMapper
    {
        public Dictionary<string, List<SelectItem>>? GetDorpDownForReport(string controller);
    }
}
