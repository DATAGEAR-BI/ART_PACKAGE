using ART_PACKAGE.Extentions.DbContextExtentions;
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

namespace ART_PACKAGE.Controllers.DGAML
{
    public class DGAMLAlarmSummaryController : Controller
    {
        private readonly ArtDgAmlContext _context;
        private readonly IConfiguration _config;
        private readonly string dbType;
        private readonly IDropDownService _dropDown;


        public DGAMLAlarmSummaryController(ArtDgAmlContext _context, IConfiguration config,IDropDownService dropDown)
        {
            this._context = _context;
            _config = config;
            dbType = _config.GetValue<string>("dbType").ToUpper();
            _dropDown = dropDown;


        }


        public IActionResult GetRoutineNameDropDown()
        {


            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(_dropDown.GetRoutineNameDropDown(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
            };
        }
        public IActionResult GetAlarmStatusDropDown()
        {


            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(_dropDown.GetAlarmStatusDropDown(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
            };
        }
        public IActionResult GetData([FromBody] StoredReq para)
        {


            IEnumerable<ArtStDgAmlAlarmsPerStatus> chart1Data = Enumerable.Empty<ArtStDgAmlAlarmsPerStatus>().AsQueryable();
            


            IEnumerable<System.Data.Common.DbParameter> chart1Params = para.procFilters.MapToParameters(dbType);
          
            if (dbType == DbTypes.SqlServer)
            {

                chart1Data = _context.ExecuteProc<ArtStDgAmlAlarmsPerStatus>(SQLSERVERSPNames.ART_ST_DGAML_ALARMS_PER_STATUS, chart1Params.ToArray());
              

            }

            if (dbType == DbTypes.Oracle)
            {
                chart1Data = _context.ExecuteProc<ArtStDgAmlAlarmsPerStatus>(ORACLESPName.ART_ST_DGAML_ALARMS_PER_STATUS, chart1Params.ToArray());
                
              

            }
            if (dbType == DbTypes.MySql)
            {

                chart1Data = _context.ExecuteProc<ArtStDgAmlAlarmsPerStatus>(MYSQLSPName.ART_ST_DGAML_ALARMS_PER_STATUS, chart1Params.ToArray());
                
            }

            ArrayList chartData = new()
            {
                new ChartData<ArtStDgAmlAlarmsPerStatus>
                {
                    ChartId = "StAlarmPerStatus",
                    Data = chart1Data.ToList(),
                    Title = "Alarms Per Status",
                    Cat = "ALARM_STATUS",
                    Val = "NUMBER_OF_ALARMS",
                    Type = ChartType.bar
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
