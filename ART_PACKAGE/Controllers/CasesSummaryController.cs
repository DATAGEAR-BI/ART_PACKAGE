using DataGear_RV_Ver_1._7.dbdgcmgmt;
using Microsoft.AspNetCore.Mvc;
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
    public class CasesSummaryController : Controller
    {
        private readonly dbfcfkc.ModelContext dbfcfkc;

        public CasesSummaryController(dbfcfkc.ModelContext dbfcfkc, IMemoryCache cache)
        {
            this.dbfcfkc = dbfcfkc;

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IQueryable<StCasesPerStatus> chart1Data = Enumerable.Empty<StCasesPerStatus>().AsQueryable();
            IQueryable<StCasesPerCategory> chart2data = Enumerable.Empty<StCasesPerCategory>().AsQueryable();
            IQueryable<StCasesPerSubCategory> chart3Data = Enumerable.Empty<StCasesPerSubCategory>().AsQueryable();
            IQueryable<StCasesPerPriority> chart4Data = Enumerable.Empty<StCasesPerPriority>().AsQueryable();



            var startDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "startdate".ToLower())?.value;
            var endDate = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "endDate".ToLower())?.value;
            //var case_id = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_id".ToLower())?.value ?? "";
            //var case_type = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_type".ToLower())?.value ?? "";
            //var case_status = para.procFilters.FirstOrDefault(x => x.id.ToLower() == "case_status".ToLower())?.value ?? "";
            var sdch3 = new OracleParameter("startDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = startDate
            };
            var edch3 = new OracleParameter("endDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = endDate
            };
            //var ci = new OracleParameter("case_id", OracleDbType.Varchar2, ParameterDirection.Input)
            //{
            //    Value = case_id

            //};
            //var ct = new OracleParameter("case_type", OracleDbType.Varchar2, ParameterDirection.Input)
            //{
            //    Value = case_type

            //};
            //var cs = new OracleParameter("case_status", OracleDbType.Varchar2, ParameterDirection.Input)
            //{
            //    Value = case_status

            //};
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
            var sdch4 = new OracleParameter("startDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = startDate
            };
            var edch4 = new OracleParameter("endDate", OracleDbType.Varchar2, ParameterDirection.Input)
            {
                Value = endDate
            };

            var chart3output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            }; var chart1output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            }; var chart2output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            }; var chart4output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            };

            chart4Data = dbfcfkc.ExecuteProc<StCasesPerPriority>("ART_ST_CASES_PER_PRIORITY", chart4output, sdch4, edch4/*, ci, ct, cs*/);
            chart3Data = dbfcfkc.ExecuteProc<StCasesPerSubCategory>("ART_ST_CASES_PER_SUBCAT", chart3output, sdch3, edch3/*, ci, ct, cs*/);
            chart1Data = dbfcfkc.ExecuteProc<StCasesPerStatus>("ART_ST_CASES_PER_STATUS", chart1output, sdch1, edch1/*, cich1, ctch1, csch1*/);
            chart2data = dbfcfkc.ExecuteProc<StCasesPerCategory>("ART_ST_CASES_PER_CATEGORY", chart2output, sdch2, edch2/*, cich2, ctch2, csch2*/);


            //var Data = data.CallData<StSystemCasesPerYearMonth>(para.req);
            var chartData = new ArrayList {
                new ChartData<StCasesPerStatus>
                {
                    ChartId = "StCasesPerStatus",
                    Data = chart1Data.ToList(),
                    Title = "Cases Per Status",
                    Cat = "CASE_STATUS",
                    Val = "NUMBER_OF_CASES"

                },
                new ChartData<StCasesPerCategory>
                {
                    ChartId = "StCasesPerCategory",
                    Data = chart2data.ToList(),
                    Title = "Cases Per Category",
                    Cat = "CASE_CATEGORY",
                    Val = "NUMBER_OF_CASES"
                },
                new ChartData<StCasesPerSubCategory>
                {
                    ChartId = "StCasesPerSubCategory",
                    Data = chart3Data.ToList(),
                    Title = "Cases Per Sub Category",
                    Cat = "CASE_SUB_CATEGORY",
                    Val = "NUMBER_OF_CASES"
                },
                new ChartData<StCasesPerPriority>
                {
                    ChartId = "StCasesPerPriority",
                    Data = chart4Data.ToList(),
                    Title = "Cases Per Priority",
                    Cat = "CASE_PRIORITY",
                    Val = "NUMBER_OF_CASES"
                }
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
