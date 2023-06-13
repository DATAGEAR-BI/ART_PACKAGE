using DataGear_RV_Ver_1._7.dbfcfcore;
using Microsoft.AspNetCore.Mvc;
using DataGear_RV_Ver_1._7.dbdgcmgmt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;
using Newtonsoft.Json;

using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
//using MimeKit;
using DataGear_RV_Ver_1._7.Utils;
using DataGear_RV_Ver_1._7.Helpers;
using DataGear_RV_Ver_1._7.Helpers.CustomReportHelpers;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Text;
using DataGear_RV_Ver_1._7.StoredProcBase;
using Microsoft.Extensions.Caching.Memory;
using Oracle.ManagedDataAccess.Client;
using DataGear_RV_Ver_1._7.Helpers.StoredProcsHelpers;
using DataGear_RV_Ver_1._7.Helpers.CustomReportHelpers;
using System.Collections;

namespace DataGear_RV_Ver_1._7.Controllers
{
    public class RiskSummaryController : Controller
    {
        private readonly dbfcfcore.ModelContext dbfcfcore;
        private readonly IMemoryCache _cache;
        public RiskSummaryController(dbfcfcore.ModelContext dbfcfcore, IMemoryCache cache)
        {
            this.dbfcfcore = dbfcfcore;
            _cache = cache;
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {

            var cacheKey = para.procFilters is null || para.procFilters.Count == 0 ? string.Empty : para.GetCacheKey();
            IQueryable<StRiskClassSummary> chart1Data = Enumerable.Empty<StRiskClassSummary>().AsQueryable();
            IQueryable<StPropRiskClassSummary> chart2data = Enumerable.Empty<StPropRiskClassSummary>().AsQueryable();


            var startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value;
            var endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value;
            //var case_id = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_id".ToLower())?.value ?? "";
            //var case_type = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_type".ToLower())?.value ?? "";
            //var case_status = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_status".ToLower())?.value ?? "";

            var sdch1 = new OracleParameter("startDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = startDate
            };
            var edch1 = new OracleParameter("endDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = endDate
            };
            //var cich1 = new OracleParameter("case_id", OracleDbType.Varchar2, ParameterDirection.Input)
            //{
            //    Value = case_id

            //};
            //var ctch1 = new OracleParameter("case_type", OracleDbType.Varchar2, ParameterDirection.Input)
            //{
            //    Value = case_type

            //};
            //var csch1 = new OracleParameter("case_status", OracleDbType.Varchar2, ParameterDirection.Input)
            //{
            //    Value = case_status

            //};
            var sdch2 = new OracleParameter("startDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = startDate
            };
            var edch2 = new OracleParameter("endDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = endDate
            };
            //var cich2 = new OracleParameter("case_id", OracleDbType.Varchar2, ParameterDirection.Input)
            //{
            //    Value = case_id

            //};
            //var ctch2 = new OracleParameter("case_type", OracleDbType.Varchar2, ParameterDirection.Input)
            //{
            //    Value = case_type

            //};
            //var csch2 = new OracleParameter("case_status", OracleDbType.Varchar2, ParameterDirection.Input)
            //{
            //    Value = case_status

            //};

            var chart1output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            }; var chart2output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            };

            chart1Data = dbfcfcore.ExecuteProc<StRiskClassSummary>("ART_ST_AML_RISK_CLASS_SUMMARY", chart1output, sdch1, edch1/*, cich1, ctch1, csch1*/);
            chart2data = dbfcfcore.ExecuteProc<StPropRiskClassSummary>("ART_ST_AML_PROP_RISK_CLASS_SUMMARY", chart2output, sdch2, edch2/*, cich2, ctch2, csch2*/);


            //var Data = data.CallData<StSystemCasesPerYearMonth>(para.req);
            var chartData = new ArrayList {
                new ChartData<StRiskClassSummary>
                {
                    ChartId = "StRiskClassSummary",
                    Data = chart1Data.ToList(),
                    Title = "Number OF Customers Per Risk Classification",
                    Cat = "RISK_CLASSIFICATION",
                    Val = "NUMBER_OF_CUSTOMERS"

                },
                new ChartData<StPropRiskClassSummary>
                {
                    ChartId = "StPropRiskClassSummary",
                    Data = chart2data.ToList(),
                    Title = "Number OF Customers Per Proposed Risk Classification",
                    Cat = "PROPOSED_RISK_CLASS",
                    Val = "NUMBER_OF_CUSTOMERS"
                }
            };



            //var result = new
            //{
            //    data = Data.Data,
            //    columns = Data.Columns?.Where(x => x.name == "YEAR" || x.name == "TOTAL_NUMBER_OF_CASES"),
            //    grouplist = new List<string> {

            //        "YEAR",
            //        "MONTH"
            //    },
            //    vallist = new List<string>
            //    {
            //        "TOTAL_NUMBER_OF_CASES",
            //        "TOTAL_NUMBER_OF_CASES"
            //    },
            //    total = Data.Total,
            //    chartdata = chartData
            //};
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(chartData, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

                }),

            };
        }

        //public ContentResult RiskClassSummary()
        //{
        //    var result = dbfcfcore.AmlRiskClassSummaries.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        //public ContentResult PropRiskClassSummary()
        //{
        //    var result = dbfcfcore.AmlPropRiskClassSummaries.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}
