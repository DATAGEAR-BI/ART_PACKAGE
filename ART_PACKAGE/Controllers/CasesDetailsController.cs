using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;
using ART_PACKAGE.Helpers;
using ART_PACKAGE.Helpers.CustomReportHelpers;
using ART_PACKAGE.Services;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

using ART_PACKAGE.Helpers.CSVMAppers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.DropDown;
using Data.Data;

namespace ART_PACKAGE.Controllers
{
    public class CasesDetailsController : Controller
    {
        private readonly AuthContext dbfcfkc;

        private readonly IMemoryCache _cache;
        private readonly IDropDownService _dropDown;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public CasesDetailsController(AuthContext dbfcfkc, IMemoryCache cache/*, IDropDownService dropDown*/, IServiceScopeFactory serviceScopeFactory)
        {
            this.dbfcfkc = dbfcfkc;
            _cache = cache;
            /*this._dropDown = dropDown;*/
            _serviceScopeFactory = serviceScopeFactory;
        }
       


        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<ArtAmlCaseDetailsView> data = dbfcfkc.ArtAmlCaseDetailsViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                //DisplayNames = ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    //commented untill resolve drop down 
                    /*{"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    {"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() },
                    {"CasePriority".ToLower(),_dropDown.GetCasePriorityDropDown().ToDynamicList() },
                    {"CaseCategory".ToLower(),_dropDown.GetCaseCategoryDropDown().ToDynamicList() },
                    {"CaseSubCategory".ToLower(),_dropDown.GetCaseSubCategoryDropDown().ToDynamicList() },
                    {"CreatedBy".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    {"Owner".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    {"EntityLevel".ToLower(),_dropDown.GetEntityLevelDropDown().ToDynamicList() }*/

                };
               // ColumnsToSkip = ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].SkipList;

            }

            var Data = data.CallData<ArtAmlCaseDetailsView>(request, DropDownColumn/*, DisplayNames: DisplayNames, ColumnsToSkip*/);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {
                    /*new
                    {
                        text = "Delete Cases",
                        id="dltCases",
                        show = User.IsInRole("Delete_Cases")
                    }*/
                },
                selectable = true,
            };

            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(result)
            };
        }

        /*public IActionResult Export([FromBody] ExportDto<decimal> req)
        {
            var data = dbfcfkc.AmlCaseDetailViews.AsQueryable();
            var bytes = data.ExportToCSV<AmlCaseDetailView>(req.Req);
            return File(bytes, "test/csv");
        }*/
        public async Task<IActionResult> Export([FromBody] ExportDto<int> para)
        {
            var data = dbfcfkc.ArtAmlCaseDetailsViews.AsQueryable();
            var bytes = await data.ExportToCSV<ArtAmlCaseDetailsView, GenericCsvClassMapper<ArtAmlCaseDetailsView, CasesDetailsController>>(para.Req);
            return File(bytes, "text/csv");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
