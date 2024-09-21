using ART_PACKAGE.Helpers.CustomReport;
using ART_PACKAGE.Helpers.StoredProcsHelpers;
using Data.Constants.db;
using Data.Constants.StoredProcs;
using Data.Data.ARTDGAML;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using ART_PACKAGE.Areas.Identity.Data;
using ART_PACKAGE.Helpers.DropDown;
using ART_PACKAGE.Extentions.DbContextExtentions;
using Data.Services.Grid;
using ART_PACKAGE.Models;

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLPartiesListSummaryController : Controller
    {
        private readonly ArtDgAmlContext _context;
        private readonly IConfiguration _config;
        private readonly string dbType;
        private readonly IDropDownService _dropDown;


        public DGAMLPartiesListSummaryController(ArtDgAmlContext _context, IConfiguration config,IDropDownService dropDown)
        {
            this._context = _context;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();
            _dropDown = dropDown;


        }
        public IActionResult GetCitizenshipCountryDropDown()
        {


            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(_dropDown.GetCitizenshipCountryDropDown(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
            };
        }
        public IActionResult GetPoliticalExposedDropDown()
        {
            List<SelectItem> Result = new()
            {
                    new SelectItem(){ text="Yes" , value="Yes" },
                    new SelectItem(){ text="No" , value="No" },
            };
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(Result, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
            };
        }
        public IActionResult GetData([FromBody] StoredReq para)
        {
            IEnumerable<ArtStDgAmlPartiesListSummary> chart1Data = Enumerable.Empty<ArtStDgAmlPartiesListSummary>().AsQueryable();
            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
            if (dbType == DbTypes.SqlServer)
            {
                chart1Data = _context.ExecuteProc<ArtStDgAmlPartiesListSummary>(SQLSERVERSPNames.ART_ST_DGAML_PARTIES_LIST_SUMMARY_REPORT, chart1Params.ToArray());
            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = _context.ExecuteProc<ArtStDgAmlPartiesListSummary>(ORACLESPName.ART_ST_DGAML_PARTIES_LIST_SUMMARY_REPORT, chart1Params.ToArray());
            }
            if (dbType == DbTypes.MySql)
            {
                chart1Data = _context.ExecuteProc<ArtStDgAmlPartiesListSummary>(MYSQLSPName.ART_ST_DGAML_PARTIES_LIST_SUMMARY_REPORT, chart1Params.ToArray());
            }

            ArrayList chartData = new()
            {
                new ChartData<GenericModelChart>
                {
                    ChartId = "StDgAmlPartiesList",
                    Data = chart1Data.Select(x => new GenericModelChart{ Category = "Customer Count" , Value=x.Customer_Count } ).ToList(),
                    Title = "Customer Count",
                    Cat = "Category",
                    Val = "Value",
                    Type = ChartType.pie
                },
            };


            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(chartData, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

                }),

            };



        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
