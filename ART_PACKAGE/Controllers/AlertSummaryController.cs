using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataGear_RV_Ver_1._7.dbdgcmgmt;
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
    public class AlertSummaryController : Controller
    {
        private readonly dbfcfkc.ModelContext dbfcfkc;
        private readonly IMemoryCache _cache;
        public AlertSummaryController(dbfcfkc.ModelContext dbfcfkc, IMemoryCache cache)
        {
            this.dbfcfkc = dbfcfkc;
            _cache = cache;
        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IQueryable<StAlertsPerStatus> chart1Data = Enumerable.Empty<StAlertsPerStatus>().AsQueryable();
            IQueryable<StAlertPerOwner> chart2data = Enumerable.Empty<StAlertPerOwner>().AsQueryable();


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

            var chart3output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            }; var chart1output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            }; var chart2output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            };

            chart1Data = dbfcfkc.ExecuteProc<StAlertsPerStatus>("ART_ST_ALERT_PER_STATUS", chart1output, sdch1, edch1/*, cich1, ctch1, csch1*/);
            chart2data = dbfcfkc.ExecuteProc<StAlertPerOwner>("ART_ST_ALERT_PER_OWNER", chart2output, sdch2, edch2/*, cich2, ctch2, csch2*/);


            //var Data = data.CallData<StSystemCasesPerYearMonth>(para.req);
            var chartData = new ArrayList {
                new ChartData<StAlertsPerStatus>
                {
                    ChartId = "StAlertsPerStatus",
                    Data = chart1Data.ToList(),
                    Title = "Alerts Per Status",
                    Cat = "ALERT_STATUS",
                    Val = "ALERTS_COUNT"

                },
                new ChartData<StAlertPerOwner>
                {
                    ChartId = "StAlertPerOwner",
                    Data = chart2data.ToList(),
                    Title = "Alerts Per Owner",
                    Cat = "OWNER_USERID",
                    Val = "ALERTS_CNT_SUM"
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

        public IActionResult Index()
        {
            return View();
        }
    }
}
