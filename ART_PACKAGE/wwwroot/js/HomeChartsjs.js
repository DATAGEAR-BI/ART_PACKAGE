import { makedynamicChart } from "./Modules/MakeDynamicChart.js"
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




function makeDatesChart(data, divId, cat, val, subcat, subval, subListKey, ctitle) {
    /**
  * ---------------------------------------
  * This demo was created using amCharts 4.
  *
  * For more information visit:
  * https://www.amcharts.com/
  *
  * Documentation is available at:
  * https://www.amcharts.com/docs/v4/
  * ---------------------------------------
  */

    am4core.useTheme(am4themes_animated);
    am4core.useTheme(am4themes_kelly);
    /**
     * Source data
     */


    /**
     * Chart container
     */

    // Create chart instance
    var chart = am4core.create(divId, am4core.Container);
    chart.width = am4core.percent(100);
    chart.height = am4core.percent(100);
    chart.layout = "horizontal";
    chart.exporting.menu = new am4core.ExportMenu();
    chart.exporting.menu.items = [{
        "label": "...",
        "menu": [
            { "type": "svg", "label": "Save" },
        ]
    }];


    /**
     * Column chart
     */

    // Create chart instance
    var columnChart = chart.createChild(am4charts.XYChart);

    // Create axes
    var categoryAxis = columnChart.yAxes.push(new am4charts.CategoryAxis());
    categoryAxis.renderer.labels.template.fontSize = 20
    categoryAxis.dataFields.category = subcat;
    categoryAxis.renderer.grid.template.location = 0;
    categoryAxis.renderer.inversed = true;

    var valueAxis = columnChart.xAxes.push(new am4charts.ValueAxis());
    valueAxis.renderer.labels.template.fontSize = 20

    // Create series
    var columnSeries = columnChart.series.push(new am4charts.ColumnSeries());
    columnSeries.dataFields.valueX = subval;
    columnSeries.dataFields.categoryY = subcat;
    columnSeries.columns.template.strokeWidth = 0;
    columnSeries.columns.template.tooltipText = "{value}";



    var valueLabel = columnSeries.bullets.push(new am4charts.LabelBullet());
    valueLabel.label.text = "{value}";
    valueLabel.label.fontSize = 20;
    valueLabel.label.horizontalCenter = "left";
    valueLabel.label.hideOversized = false;
    valueLabel.label.truncate = false;
    valueLabel.label.dx = 10;


    /**
     * Pie chart
     */

    // Create chart instance
    var pieChart = chart.createChild(am4charts.PieChart);
    pieChart.data = data;
    pieChart.innerRadius = am4core.percent(50);
    var title = pieChart.titles.create();
    title.text = "Cases Per Year";
    title.fontSize = 25;
    pieChart.legend = new am4charts.Legend();
    pieChart.legend.maxHeight = 600;
    pieChart.legend.maxWidth = 300;
    pieChart.legend.scrollable = true;
    pieChart.legend.position = "bottom"; pieChart.legend.labels.template.text = "{name} : ({value})";
    // Add and configure Series
    var pieSeries = pieChart.series.push(new am4charts.PieSeries());
    pieSeries.dataFields.value = val;
    pieSeries.dataFields.category = cat;

    pieSeries.labels.template.disabled = true;

    // Set up labels
    //var label1 = pieChart.seriesContainer.createChild(am4core.Label);
    //label1.text = "";
    //label1.horizontalCenter = "middle";
    //label1.fontSize = 35;
    //label1.fontWeight = 600;
    //label1.dy = -30;
    //
    //
    //var label3 = pieChart.seriesContainer.createChild(am4core.Label);
    //label3.text = "";
    //label3.horizontalCenter = "middle";
    //label3.fontSize = 20;
    //label3.dy = 40;
    //
    //
    //var label2 = pieChart.seriesContainer.createChild(am4core.Label);
    //label2.text = "";
    //label2.horizontalCenter = "middle";
    //label2.fontSize = 20;
    //label2.dy = 20;

    // Auto-select first slice on load
    pieChart.events.on("ready", function (ev) {
        pieSeries.slices.getIndex(0).isActive = true;
    });

    // Set up toggling events
    pieSeries.slices.template.events.on("toggled", function (ev) {
        if (ev.target.isActive) {

            // Untoggle other slices
            pieSeries.slices.each(function (slice) {
                if (slice != ev.target) {
                    slice.isActive = false;
                }
            });

            // Update column chart
            columnSeries.appeared = false;
            columnChart.data = ev.target.dataItem.dataContext[subListKey];
            columnSeries.fill = ev.target.fill;
            columnSeries.reinit();

            // Update labels
            //label1.text = pieChart.numberFormatter.format(ev.target.dataItem.values.value.percent, "#.'%'");
            //label1.fill = ev.target.fill;
            //label3.text = ev.target.dataItem.dataContext[val];
            //label3.fill = ev.target.fill;
            //console.log(ev.target.dataItem);
            //label2.text = ev.target.dataItem.dataContext[cat];
        }
    });


}



