import { makedynamicChart, makeDatesChart } from "./Modules/MakeDynamicChart.js"
var isChartChanged = false;
//var numberOfCustomers = document.getElementById("numberOfCustomers");
//var numberOfPepCustomers = document.getElementById("numberOfPepCustomers");
//var numberOfAccounts = document.getElementById("numberOfAccounts");
//var numberOfHighRiskCustomers = document.getElementById("numberOfHighRiskCustomers");



//fetch("/Home/CardsData").then(x => x.json()).then(x => {
//    numberOfCustomers.innerHTML = x.numberOfCustomers;
//    numberOfPepCustomers.innerHTML = x.numberOfPepCustomers;
//    numberOfAccounts.innerHTML = x.numberOfAccounts;
//    numberOfHighRiskCustomers.innerHTML = x.numberOfHighRiskCustomers;
//})
fetch("/Home/GetAmlChartsData").then(x => x.json()).then(
    x => {
       var statusData = x.statuses;
        var changeChart = (di) => {
         /*   var year = di.year;
            var yearedStatuseData = statusData.filter(x => x.year == year);
            if (!isChartChanged) {
                makedynamicChart(0, x.statuses, "Alerts Per Status", "alertPerStatus", "alertsCount", "alertStatus", true);
                isChartChanged = true;
            } else {
                makedynamicChart(0, yearedStatuseData, "Alerts Per Status", "alertPerStatus", "alertsCount", "alertStatus", true);
            }*/

        }
        makeDatesChart(x.dates, "alertPerDate", "year", "value", "month", "value", "monthData", "Alerts Per Year & Month", changeChart);
        makedynamicChart(0, x.statuses, "Alerts Per Status", "alertPerStatus", "alertsCount", "alertStatus", true);
    }
);