namespace ART_PACKAGE.Helpers.DropDown
{
    public interface IDropDownService
    {
        public List<string> GetECMREFERNCEDropDown();
        public List<string> GetBranchIDDropDown();
        public List<string> GetCustomerNameDropDown();
        public List<string> GetProductDropDown();
        public List<string> GetProductTypeDropDown();
        public List<string> GetCaseStatusDropDown();

    }
}
