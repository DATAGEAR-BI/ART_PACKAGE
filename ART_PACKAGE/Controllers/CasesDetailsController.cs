using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;
using DataGear_RV_Ver_1._7.Helpers;
using DataGear_RV_Ver_1._7.Helpers.CustomReportHelpers;
using DataGear_RV_Ver_1._7.Services;
using DataGear_RV_Ver_1._7.dbfcfkc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;
using DataGear_RV_Ver_1._7.Helpers;
using DataGear_RV_Ver_1._7.Helpers.CustomReportHelpers;
using DataGear_RV_Ver_1._7.dbfcfcore;
using DataGear_RV_Ver_1._7.Helpers.CSVMAppers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace DataGear_RV_Ver_1._7.Controllers
{
    public class CasesDetailsController : Controller
    {
        private readonly dbfcfkc.ModelContext dbfcfkc;

        private readonly IMemoryCache _cache;
        private readonly IDropDownService _dropDown;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public CasesDetailsController(dbfcfkc.ModelContext dbfcfkc, IMemoryCache cache, IDropDownService dropDown, IServiceScopeFactory serviceScopeFactory)
        {
            this.dbfcfkc = dbfcfkc;
            _cache = cache;
            this._dropDown = dropDown;
            _serviceScopeFactory = serviceScopeFactory;
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCases([FromBody] List<string> cases)
        {

            var errorDict = new Dictionary<int, string>();
            var batchSize = 1; // set the size of each batch
            var totalBatches = (int)Math.Ceiling((double)cases.Count / batchSize);

            Parallel.For(0, totalBatches, async (batchIndex, loopState) =>
            {
                var batchCases = cases.OrderBy(x => x).Skip(batchIndex * batchSize).Take(batchSize).ToList();
                using var scope = _serviceScopeFactory.CreateScope();
                using var batchContext = scope.ServiceProvider.GetRequiredService<dbfcfkc.ModelContext>();

                using var transaction = batchContext.Database.BeginTransaction();
                try
                {


                    var alertCases = batchContext.FskAlertCases.Where(ac => batchCases.Contains(ac.CaseId.ToString()));
                    var fskCases = batchContext.FskCases.Where(c => batchCases.Contains(c.CaseId.ToString()));
                    var casesEntities = batchContext.FskCaseEntities.Where(ca => batchCases.Contains(ca.CaseId.ToString()));
                    var CasesEvents = batchContext.FskCaseEvents.Where(ce => batchCases.Contains(ce.CaseId.ToString()));
                    batchContext.RemoveRange(alertCases);
                    batchContext.RemoveRange(fskCases);
                    batchContext.RemoveRange(casesEntities);
                    batchContext.RemoveRange(CasesEvents);

                    await batchContext.SaveChangesAsync();
                    await transaction.CommitAsync();



                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    errorDict[batchIndex] = ex.Message;
                    loopState.Stop();
                }

            });

            if (errorDict.Keys.Count == totalBatches)
                return BadRequest("Something went wrong try again in a minute");
            else if (errorDict.Keys.Count > 0 && errorDict.Keys.Count != totalBatches)
            {
                var sb = new StringBuilder();
                sb.AppendLine("not all cases deleted this batches failed : ");
                sb.AppendJoin(",", errorDict.Keys);
                return BadRequest(sb.ToString());
            }
            else
            {
                return Ok("Cases Deleted Successfully");
            }





            // Handle aggregate exception here...
            //foreach (var ex in ae.InnerExceptions)
            //{
            //    // Handle inner exception here...
            //}




        }


        public IActionResult GetData([FromBody] KendoRequest request)
        {
            IQueryable<AmlCaseDetailView> data = dbfcfkc.AmlCaseDetailViews.AsQueryable();

            Dictionary<string, DisplayNameAndFormat> DisplayNames = null;
            Dictionary<string, List<dynamic>> DropDownColumn = null;
            List<string> ColumnsToSkip = null;

            if (request.IsIntialize)
            {
                DisplayNames = ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].DisplayNames;
                DropDownColumn = new Dictionary<string, List<dynamic>>
                {
                    {"BranchName".ToLower(),_dropDown.GetBranchNameDropDown().ToDynamicList() },
                    {"CaseStatus".ToLower(),_dropDown.GetCaseStatusDropDown().ToDynamicList() },
                    {"CasePriority".ToLower(),_dropDown.GetCasePriorityDropDown().ToDynamicList() },
                    {"CaseCategory".ToLower(),_dropDown.GetCaseCategoryDropDown().ToDynamicList() },
                    {"CaseSubCategory".ToLower(),_dropDown.GetCaseSubCategoryDropDown().ToDynamicList() },
                    {"CreatedBy".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    {"Owner".ToLower(),_dropDown.GetOwnerDropDown().ToDynamicList() },
                    {"EntityLevel".ToLower(),_dropDown.GetEntityLevelDropDown().ToDynamicList() }

                };
                ColumnsToSkip = ReportsConfig.CONFIG[nameof(CasesDetailsController).ToLower()].SkipList;

            }

            var Data = data.CallData<AmlCaseDetailView>(request, DropDownColumn, DisplayNames: DisplayNames, ColumnsToSkip);
            var result = new
            {
                data = Data.Data,
                columns = Data.Columns,
                total = Data.Total,
                containsActions = false,
                toolbar = new List<dynamic>
                {
                    new
                    {
                        text = "Delete Cases",
                        id="dltCases",
                        show = User.IsInRole("Delete_Cases")
                    }
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
            var data = dbfcfkc.AmlCaseDetailViews.AsQueryable();
            var bytes = await data.ExportToCSV<AmlCaseDetailView, GenericCsvClassMapper<AmlCaseDetailView, CasesDetailsController>>(para.Req);
            return File(bytes, "text/csv");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
