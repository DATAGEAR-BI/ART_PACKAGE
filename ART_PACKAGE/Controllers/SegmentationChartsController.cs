using ART_PACKAGE.Areas.Identity.Data;
using Data.SEGMODEL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ART_PACKAGE.Controllers
{
    //[Authorize(Roles = "SegmentationCharts", Policy = "Licensed")]
    public class SegmentationChartsController : Controller
    {

        private readonly AuthContext db;
        public SegmentationChartsController(AuthContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SingleSegmentReport(int monthkey, string SegType, int SegID)
        {
            ViewBag.monthkey = monthkey;
            ViewBag.SegID = SegID;
            ViewBag.SegType = SegType;
            return View();
        }

        public IActionResult SegmentCompare()
        {
            return View();
        }

        public IActionResult SegmentReport()
        {
            return View();
        }

        //public ContentResult getTotalsData(int monthKey, int segment)
        //{

        //    var data = db.ArtMebSegmentsV3Tbs.Select(f => new
        //    {
        //        f.TotalAmount,
        //        f.TotalCreditAmount,
        //        f.TotalDebitAmount,
        //        f.TotalWiresCreditAmt,
        //        f.TotalWiresDebitAmt,
        //        f.Segment,
        //        f.MonthKey
        //    }).Where(s => s.MonthKey == monthKey && s.Segment == segment).ToList();

        //    return Content(JsonConvert.SerializeObject(data), "application/json");

        //}

        public ContentResult MonthKeys()
        {
            var keys = db.ArtAllSegsFeatrsStatcsTbs.Select(s => s.MonthKey).Distinct();
            return Content(JsonConvert.SerializeObject(keys), "application/json");
        }

        public ContentResult SegTypesPerKey(int? monthkey)
        {
            var types = db.ArtAllSegsFeatrsStatcsTbs.Where(s => s.MonthKey == monthkey.ToString()).Select(s => s.PartyTypeDesc).Distinct();
            return Content(JsonConvert.SerializeObject(types), "application/json");
        }

        public ContentResult Segs(int? monthkey, string Type)
        {
            var segs = db.ArtAllSegsFeatrsStatcsTbs.Where(s => s.MonthKey == monthkey.ToString() && s.PartyTypeDesc == Type).Select(s =>  new { SegmentSorted= s.SegmentSorted}).Distinct();
            return Content(JsonConvert.SerializeObject(segs), "application/json");
        }

        public ContentResult DataForTabs(int? monthkey, int segment)
        {
            var result = db.ArtAllSegsFeatrsStatcsTbs
                .Where(s => s.MonthKey == monthkey.ToString() && s.SegmentSorted == segment.ToString()).ToList();
            var props = result[0].GetType().GetProperties().Where(s => (s.Name.EndsWith("CCnt") || s.Name.EndsWith("CAmt") || s.Name.EndsWith("DCnt") || s.Name.EndsWith("DAmt"))
            && (s.Name.StartsWith("Total") || s.Name.StartsWith("Avg") || s.Name.StartsWith("Min") || s.Name.StartsWith("Max"))).Select(s => s.Name);
            var distinctTypes = props.Select(s => s.Replace("Total", "").Replace("Avg", "").Replace("Min", "").Replace("Max", "")
                    .Replace("CCnt", "").Replace("CAmt", "").Replace("DCnt", "").Replace("DAmt", "")).Distinct();


            JObject SegObj = new JObject();
            var skipProps = result[0].GetType().GetProperties().Where(s => !props.Contains(s.Name)).Select(s => s.Name) ;
            foreach (var item in skipProps)
            {
                SegObj[item] = (string)result[0].GetType().GetProperty(item).GetValue(result[0]);
            }
            SegObj["typs"] =new JArray();
            var counter = 0;
            foreach (var t in distinctTypes)
            {   
                string maxOrMinOrAvg = t.Substring(0,3);
                string type = t.Replace("Total", "").Replace("Avg", "").Replace("Min", "").Replace("Max", "")
                    .Replace("CCnt", "").Replace("CAmt", "").Replace("DCnt", "").Replace("DAmt", "");
                string credOrDebit= t.Substring(t.Length-4, 1);
                var credit = props.Where(s => s.Contains(t) && (s.EndsWith("CCnt") || s.EndsWith("CAmt")));
                var debit = props.Where(s => s.Contains(t) && (s.EndsWith("DCnt") || s.EndsWith("DAmt")));

                var typeObj = new JObject();
                var creditObj = new JObject();
                var debitObj = new JObject();
                var AmtObj = new JObject();
                var CntObj = new JObject();
                foreach (var item in credit)
                {
                    if (item.EndsWith("Amt"))
                    {
                        AmtObj[item.Substring(0, 3)] = (double)result[0].GetType().GetProperty(item).GetValue(result[0]);
                    }
                    else if (item.EndsWith("Cnt"))
                    {
                        CntObj[item.Substring(0, 3)] = (double)result[0].GetType().GetProperty(item).GetValue(result[0]);
                    }
                }
                creditObj["Amt"] = AmtObj;
                creditObj["Cnt"] = CntObj;
                AmtObj = new JObject();
                CntObj = new JObject();
                foreach (var item in debit)
                {
                    if (item.EndsWith("Amt"))
                    {
                        AmtObj[item.Substring(0, 3)] = (double)result[0].GetType().GetProperty(item).GetValue(result[0]);
                    }
                    else if (item.EndsWith("Cnt"))
                    {
                        CntObj[item.Substring(0, 3)] = (double)result[0].GetType().GetProperty(item).GetValue(result[0]);
                    }
                }
                debitObj["Amt"] = AmtObj;
                debitObj["Cnt"] = CntObj;
                typeObj["name"] = t;
                typeObj["credit"] = creditObj;
                typeObj["debit"] = debitObj;
                SegObj["types"][counter++] = typeObj;
            }


            
            return Content(JsonConvert.SerializeObject(SegObj), "application/json");
        }
        private dynamic GetValueOfProp<T>(string propertyName)
        {
            Type myClassType = typeof(T);
            PropertyInfo propertyInfo = myClassType.GetProperty(propertyName);
            T instance = Activator.CreateInstance<T>(); 
            string propertyValue = (string)propertyInfo.GetValue(instance);
            return propertyValue;
        }
        public ContentResult ArtIndustrySegments(int? monthkey, int segment, string type)
        {
            var result = db.ArtIndustrySegmentTbs.Where(s => s.MonthKey == monthkey.ToString() && s.SegmentSorted == segment.ToString() && s.PartyTypeDesc == type).OrderByDescending(k => k.TotalAmount).Take(10);
            return Content(JsonConvert.SerializeObject(result), "application/json");
        }
        //public ContentResult Features()
        //{
        //    var Fs = db.ArtSegsAggregates.Select(s => s.Feature).Distinct();
        //    return Content(JsonConvert.SerializeObject(Fs), "application/json");
        //}

        /*for segment compare*/
        public ContentResult GetAllSegmentData(int? monthkey, string Type)
        {
            var result = db.ArtAllSegsFeatrsStatcsTbs.Where(s => s.MonthKey == monthkey.ToString() && s.PartyTypeDesc == Type).OrderBy(t=>t.SegmentSorted).ToList();
            return Content(JsonConvert.SerializeObject(result), "application/json");
        }

        public ContentResult GetAllSegmentCustCount(int? monthkey, string Type)
        {
            var result = db.ArtAllSegmentCustCountTbs.Where(s => s.MonthKey == monthkey.ToString() && s.PartyTypeDesc == Type).OrderBy(t=>t.SegmentSorted).ToList();
            return Content(JsonConvert.SerializeObject(result), "application/json");
        }
        public ContentResult GetAllSegmentAlertsCount(int? monthkey, string Type)
        {
            var result = db.ArtAlertsPerSegmentTbs.Where(s => s.MonthKey == monthkey.ToString() && s.PartyTypeDesc == Type).OrderBy(t=>t.SegmentSorted).ToList();
            return Content(JsonConvert.SerializeObject(result), "application/json");
        }

        public ContentResult GetCustCountPerType(int? monthkey)
        {
            var result = db.ArtCustsPerTypeTbs.Where(s => s.MonthKey == monthkey.ToString()).GroupBy(s => new { s.PartyTypeDesc, s.MonthKey }).Select(s => new
            {
                MonthKey = s.Key.MonthKey,
                PartyTypeDesc = s.Key.PartyTypeDesc,
                NumberOfCustomers = s.Sum(x => x.NumberOfCustomers)
            }).OrderBy(t=>t.NumberOfCustomers).ToList();
            return Content(JsonConvert.SerializeObject(result), "application/json");
        }
    }
}
