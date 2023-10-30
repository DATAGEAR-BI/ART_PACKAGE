import { makedynamicChart, makeDatesChart } from "./Modules/MakeDynamicChart.js"
var dateData = [];
var typeData = [];
var statusData = [];
var monthCaseData = [];
getData().then(x => {



    function colorFunc(fill, target) {
        var di = target.dataItem;
        console.log(di);
        if (di) {
            var x = target.dataItem.dataContext;
            console.log(x);
            if (x.caseStatus == "Hit")
                return am4core.color("#f08080")
            else if (x.caseStatus == "NoHit")
                return am4core.color("#20b2aa")
            else if (x.caseStatus == "Postponed")
                return am4core.color("#fafad2")
            else {
                return am4core.color("#ffffff");
            }
        }
        else {
            return fill;
        }
    }

    makeDatesChart(dateData, "date", "year", "value", "month", "value", "monthData", "Cases Per Year & Month", (di) => {
   
        var year = di.year;
        var yearedTypeData = typeData.filter(x => x.year == year);
        var yearedProductData = productsData.filter(x => x.year == year);
        var yearedStatuseData = statusData.filter(x => x.year == year);
        var _monthCaseData = monthCaseData.find(x => x.year == year);
        console.log(_monthCaseData);
        makedynamicChart(8, _monthCaseData.monthData, "Cases Per Month", "month", "value", "month", true);
        makedynamicChart(8, yearedTypeData, "Volume Distribution", "type", "numberOfCases", "caseType", true);
        makedynamicChart(8, yearedProductData, "Case product", "product", "numberOfCases", "Product", true);
        makedynamicChart(8, yearedStatuseData, "Cases Per Status", "status", "numberOfCases", "caseStatus", true);
    });



})


async function getData() {
    var data = await (await fetch("/home/getchartsdata")).json();
    dateData = data.dates;
    typeData = data.types;
    statusData = data.status;
    monthCaseData = data.monthCaseData;
    productsData = data.productsData;

}