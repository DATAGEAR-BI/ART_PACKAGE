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
using System.Collections;
using System.Linq.Dynamic.Core;

namespace DataGear_RV_Ver_1._7.Controllers
{
    public class CustomersSummaryController : Controller
    {

        private readonly dbfcfcore.ModelContext dbfcfcore;

        public CustomersSummaryController(dbfcfcore.ModelContext dbfcfcore, IMemoryCache cache)
        {
            this.dbfcfcore = dbfcfcore;

        }

        public IActionResult GetData([FromBody] StoredReq para)
        {


            IQueryable<StCustomerPerType> chart1Data = Enumerable.Empty<StCustomerPerType>().AsQueryable();
            IQueryable<StCustomerPerRiskClass> chart2data = Enumerable.Empty<StCustomerPerRiskClass>().AsQueryable();
            IQueryable<StCustomerPerBranch> chart3Data = Enumerable.Empty<StCustomerPerBranch>().AsQueryable();


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

            var chart3output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            }; var chart1output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            }; var chart2output = new OracleParameter("out", OracleDbType.RefCursor, ParameterDirection.Output)
            {

            };

            chart3Data = dbfcfcore.ExecuteProc<StCustomerPerBranch>("ART_ST_CUST_SUMM_PER_BRANCH", chart3output, sdch3, edch3/*, ci, ct, cs*/);
            chart1Data = dbfcfcore.ExecuteProc<StCustomerPerType>("ART_ST_CUST_SUMM_PER_TYPE", chart1output, sdch1, edch1/*, cich1, ctch1, csch1*/);
            chart2data = dbfcfcore.ExecuteProc<StCustomerPerRiskClass>("ART_ST_CUST_SUMM_PER_RISK", chart2output, sdch2, edch2/*, cich2, ctch2, csch2*/);


            //var Data = data.CallData<StSystemCasesPerYearMonth>(para.req);
            var chartData = new ArrayList {
                new ChartData<StCustomerPerType>
                {
                    ChartId = "StCustomerPerType",
                    Data = chart1Data.ToList(),
                    Title = "Customer Per Type",
                    Cat = "CUSTOMER_TYPE",
                    Val = "NUMBER_OF_CUSTOMERS"
                },
                new ChartData<StCustomerPerRiskClass>
                {
                    ChartId = "StCustomerPerRiskClass",
                    Data = chart2data.ToList(),
                    Title = "Customer Per Risk Classification",
                    Cat = "RISK_CLASSIFICATION",
                    Val = "NUMBER_OF_CUSTOMERS"
                },
                new ChartData<StCustomerPerBranch>
                {
                    ChartId = "StCustomerPerBranch",
                    Data = chart3Data.OrderBy(x=>x.NUMBER_OF_CUSTOMERS).ToList(),
                    Title = "Customer Per Branch",
                    Cat = "BRANCH_NAME",
                    Val = "NUMBER_OF_CUSTOMERS"
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


        //public ContentResult Aml_Cust_Summ_Per_Branches()
        //{
        //    var result = db.AmlCustSummPerBranches.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}

        //public ContentResult Aml_Cust_Summ_Per_Cities()
        //{
        //    var result = db.AmlCustSummPerCities.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}

        //public ContentResult Aml_Cust_Summ_Per_Types()
        //{
        //    var result = db.AmlCustSummPerTypes.ToList();
        //    return Content(JsonConvert.SerializeObject(result), "application/json");
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}
