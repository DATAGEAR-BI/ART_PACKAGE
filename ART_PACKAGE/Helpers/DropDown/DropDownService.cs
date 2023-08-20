using Data.FCF71;

namespace ART_PACKAGE.Helpers.DropDown
{
    public class DropDownService : IDropDownService
    {
        private readonly IDbService _dbSrv;

        public DropDownService(IDbService dbSrv)
        {
            _dbSrv = dbSrv;
        }
        public List<string> GetBranchIDDropDown()
        {
            var distinct_value = _dbSrv.DGECM.CaseLives.Where(x => x.Behalfofbranch != null).Select(x => x.Behalfofbranch).Distinct().ToList();
            return distinct_value;
        }

        public List<string> GetCaseStatusDropDown()
        {
            return _dbSrv.DGECM.CaseLives.Where(x => x.CaseStatCd != null).Select(x => x.CaseStatCd).Distinct().ToList();
        }

        public List<string> GetCustomerNameDropDown()
        {
            return _dbSrv.DGECM.CaseLives.Where(x => x.Applicantname != null).Select(x => x.Applicantname).Distinct().ToList();
        }

        public List<string> GetECMREFERNCEDropDown()
        {
            return _dbSrv.DGECM.CaseLives.Where(x => x.CaseId != null).Select(x => x.CaseId).Distinct().ToList();
        }



        public List<string> GetProductDropDown()
        {
            return _dbSrv.DGECM.RefTableVals.Where(x => x.ValDesc != null && x.RefTableName == "ABK_FTI_PRODUCT").Select(x => x.ValDesc).Distinct().ToList();
        }

        public List<string> GetProductTypeDropDown()
        {
            return _dbSrv.DGECM.RefTableVals.Where(x => x.ValDesc != null && x.RefTableName == "ABK_FTI_PRODUCT_TYPE").Select(x => x.ValDesc).Distinct().ToList();
        }


    }
}
