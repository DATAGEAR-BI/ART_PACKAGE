import { makedynamicChart, makeDatesChart } from "./Modules/MakeDynamicChart.js"
var dateData = [];
var typeData = [];
var statusData = [];
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

    makeDatesChart(dateData, "date", "year", "value", "month", "value", "monthData", "Cases Per Year & Month");
    makedynamicChart(0, typeData, "Cases Per Type", "type", "numberOfCases", "caseType");
    makedynamicChart(0, statusData, "Cases Per Status", "status", "numberOfCases", "caseStatus", true);


})


async function getData() {
    var data = await (await fetch("/home/getchartsdata")).json();
    dateData = data.dates;
    typeData = data.types;
    statusData = data.status;
}








