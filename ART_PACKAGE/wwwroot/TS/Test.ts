import * as am4core from "@amcharts/amcharts4/core";
import * as am4charts from "@amcharts/amcharts4/charts";

let chart = am4core.create("chartDiv", am4charts.PieChart);

chart.data = [{
    "country": "Lithuania",
    "litres": 501.9
}, {
    "country": "Czech Republic",
    "litres": 301.9
}, {
    "country": "Ireland",
    "litres": 201.1
}, {
    "country": "Germany",
    "litres": 165.8
}, {
    "country": "Australia",
    "litres": 139.9
}, {
    "country": "Austria",
    "litres": 128.3
}, {
    "country": "UK",
    "litres": 99
}, {
    "country": "Belgium",
    "litres": 60
}, {
    "country": "The Netherlands",
    "litres": 50
}];
let pieSeries = chart.series.push(new am4charts.PieSeries());

pieSeries.dataFields.value = "litres";
pieSeries.dataFields.category = "country";