import * as core from "../lib/Plugins/amcharts_4.10.18/amcharts4/core.js"
import * as charts from "../lib/Plugins/amcharts_4.10.18/amcharts4/charts.js";
import * as matrial from "../lib/Plugins/amcharts_4.10.18/amcharts4/themes/material.js";
import * as animated from "../lib/Plugins/amcharts_4.10.18/amcharts4/themes/animated.js";

let segData = {};

function draw_Stacked_Col_Chart(data) {

    am4core.useTheme(am4themes_animated);
    am4core.useTheme(am4themes_material);
    am4core.addLicense("ch-custom-attribution");
    var chart = am4core.create("chartdiv", am4charts.XYChart3D);
    var title = chart.titles.create();
    title.text = "Transaction Type Amounts Comparison";
    title.fontSize = 25;
    title.marginBottom = 30;
    chart.data = data;
    chart.exporting.menu = new am4core.ExportMenu();
    chart.exporting.menu.items = [{
        "label": "...",
        "menu": [
            { "type": "svg", "label": "Save" },
        ]
    }];
    chart.padding(30, 30, 10, 30);
    chart.legend = new am4charts.Legend();

    chart.colors.step = 2;

    var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
    categoryAxis.dataFields.category = "category";
    categoryAxis.renderer.minGridDistance = 35;
    categoryAxis.renderer.grid.template.location = 0;
    categoryAxis.interactionsEnabled = true;
    categoryAxis.renderer.labels.template.fontSize = 17;
    categoryAxis.renderer.labels.template.fontSize = 17;

    var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
    valueAxis.tooltip.disabled = true;
    valueAxis.renderer.grid.template.strokeOpacity = 0.05;
    valueAxis.renderer.minGridDistance = 40;
    valueAxis.interactionsEnabled = true;
    valueAxis.min = 0;
    valueAxis.renderer.minWidth = 30;
    valueAxis.renderer.labels.template.fontSize = 17;

    var series1 = chart.series.push(new am4charts.ColumnSeries3D());
    series1.columns.template.width = am4core.percent(80);
    series1.columns.template.tooltipText = "{name}: {valueY.value}";
    series1.name = "Total Credit Amount";
    series1.dataFields.categoryX = "category";
    series1.dataFields.valueY = "T_A_C";
    series1.tooltip.fontSize = 17;
    //series1.stacked = true;

    var series5 = chart.series.push(new am4charts.ColumnSeries3D());
    series5.columns.template.width = am4core.percent(80);
    series5.columns.template.tooltipText = "{name}: {valueY.value}";
    series5.name = "Total Debit Amount";
    series5.dataFields.categoryX = "category";
    series5.dataFields.valueY = "T_A_D";
    series5.tooltip.fontSize = 17;
    //series5.stacked = true;

    var series2 = chart.series.push(new am4charts.ColumnSeries3D());
    series2.columns.template.width = am4core.percent(80);
    series2.columns.template.tooltipText = "{name}: {valueY.value}";
    series2.name = "Lowest Credit Amount";
    series2.dataFields.categoryX = "category";
    series2.dataFields.valueY = "L_A_C";
    series2.tooltip.fontSize = 17;
    // series2.stacked = true;

    var series6 = chart.series.push(new am4charts.ColumnSeries3D());
    series6.columns.template.width = am4core.percent(80);
    series6.columns.template.tooltipText = "{name}: {valueY.value}";
    series6.name = "Lowest Debit Amount";
    series6.dataFields.categoryX = "category";
    series6.dataFields.valueY = "L_A_D";
    series6.tooltip.fontSize = 17;
    // series6.stacked = true;

    var series3 = chart.series.push(new am4charts.ColumnSeries3D());
    series3.columns.template.width = am4core.percent(80);
    series3.columns.template.tooltipText = "{name}: {valueY.value}";
    series3.name = "Highest Credit Amount";
    series3.dataFields.categoryX = "category";
    series3.dataFields.valueY = "M_A_C";
    series3.tooltip.fontSize = 17;
    //series3.stacked = true;

    var series7 = chart.series.push(new am4charts.ColumnSeries3D());
    series7.columns.template.width = am4core.percent(80);
    series7.columns.template.tooltipText = "{name}: {valueY.value}";
    series7.name = "Highest Debit Amount";
    series7.dataFields.categoryX = "category";
    series7.dataFields.valueY = "M_A_D";
    series7.tooltip.fontSize = 17;
    //series7.stacked = true;

    var series4 = chart.series.push(new am4charts.ColumnSeries3D());
    series4.columns.template.width = am4core.percent(80);
    series4.columns.template.tooltipText = "{name}: {valueY.value}";
    series4.name = "Average Credit Amount";
    series4.dataFields.categoryX = "category";
    series4.dataFields.valueY = "A_A_C";
    series4.tooltip.fontSize = 17;
    //series4.stacked = true;

    var series8 = chart.series.push(new am4charts.ColumnSeries3D());
    series8.columns.template.width = am4core.percent(80);
    series8.columns.template.tooltipText = "{name}: {valueY.value}";
    series8.name = "Average Debit Amount";
    series8.dataFields.categoryX = "category";
    series8.dataFields.valueY = "A_A_D";
    series8.tooltip.fontSize = 17;
    // series8.stacked = true;

    chart.scrollbarX = new am4core.Scrollbar();
    chart.legend.fontSize = 17;
};

function draw_Stacked_Col_Chart_Count(data) {

    am4core.useTheme(am4themes_material);
    am4core.useTheme(am4themes_animated);
    am4core.addLicense("ch-custom-attribution");
    var chart = am4core.create("chartCountdiv", am4charts.XYChart3D);
    var title = chart.titles.create();
    title.text = "Transaction Type Counts Comparison";
    title.fontSize = 25;
    title.marginBottom = 30;
    chart.data = data;
    chart.exporting.menu = new am4core.ExportMenu();
    chart.exporting.menu.items = [{
        "label": "...",
        "menu": [
            { "type": "svg", "label": "Save" },
        ]
    }];
    chart.padding(30, 30, 10, 30);
    chart.legend = new am4charts.Legend();

    chart.colors.step = 2;

    var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
    categoryAxis.dataFields.category = "category";
    categoryAxis.renderer.minGridDistance = 30;
    categoryAxis.renderer.grid.template.location = 0;
    categoryAxis.interactionsEnabled = false;
    categoryAxis.renderer.labels.template.fontSize = 17;

    var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
    valueAxis.tooltip.disabled = true;
    valueAxis.renderer.grid.template.strokeOpacity = 0.05;
    valueAxis.renderer.minGridDistance = 30;
    valueAxis.interactionsEnabled = false;
    valueAxis.min = 0;
    valueAxis.renderer.minWidth = 35;
    valueAxis.renderer.labels.template.fontSize = 17;

    var series1 = chart.series.push(new am4charts.ColumnSeries3D());
    series1.columns.template.width = am4core.percent(80);
    series1.columns.template.tooltipText = "{name}: {valueY.value}";
    series1.name = "Total Credit Count";
    series1.dataFields.categoryX = "category";
    series1.dataFields.valueY = "T_C_C";
    series1.tooltip.fontSize = 17;
    //series1.stacked = true;

    var series2 = chart.series.push(new am4charts.ColumnSeries3D());
    series2.columns.template.width = am4core.percent(80);
    series2.columns.template.tooltipText = "{name}: {valueY.value}";
    series2.name = "Total Debit Count";
    series2.dataFields.categoryX = "category";
    series2.dataFields.valueY = "T_D_C";
    series2.tooltip.fontSize = 17;
    // series2.stacked = true;

    chart.scrollbarX = new am4core.Scrollbar();

    chart.legend.fontSize = 17;


};





async function renderTabsCounter() {
    try {
        var res = await fetch("/SegmentationCharts/DataForTabs?monthKey=" + monthkey + "&segment=" + segment_id);
        var industryData = await (await fetch("/SegmentationCharts/ArtIndustrySegments?monthKey=" + monthkey + "&segment=" + segment_id + "&type=" + segType)).json()
        
        segData = await res.json();
        var loaders = document.getElementsByClassName("spinner-grow");
        console.log(segData);
        [...loaders].forEach(l => {
            l.hidden = true
        });
        var dataForChart = segData.Types.map( x => {
            let obj = {};
            obj.category = x.name;
            obj.T_A_D = x.debit.Amt.Tot;
            obj.L_A_D = x.debit.Amt.Min;
            obj.M_A_D = x.debit.Amt.Max;
            obj.T_A_D = x.debit.Amt.Avg;
            obj.T_D_C = x.debit.Cnt.Tot;
            obj.T_A_C = x.credit.Amt.Tot;
            obj.L_A_C = x.credit.Amt.Min;
            obj.M_A_C = x.credit.Amt.Max;
            obj.A_A_C = x.credit.Amt.Avg;
            
            
            return obj;
        } )
        
        var countChartData = segData.Types.map( x => {
            let obj = {};
            obj.category = x.name;
            obj.T_C_C = x.credit.Cnt.Tot;
            return obj;
        });

        draw_Stacked_Col_Chart(dataForChart);
        draw_Stacked_Col_Chart_Count(countChartData);
        RenderDataForCharts(industryData);
        var debitData = segData.Types.find(x=> x.name == "Wire").debit;
        var creditData = segData.Types.find(x=> x.name == "Wire").credit;
        
        var aggs = [...document.querySelectorAll("p.aggText")]
        
            
        // debit
        aggs.find(x=>x.id == "D-total").innerText = debitData.Amt.Tot;
        aggs.find(x=>x.id == "D-min").innerText = debitData.Amt.Max;
        aggs.find(x=>x.id == "D-max").innerText = debitData.Amt.Min;
        aggs.find(x=>x.id == "D-avg").innerText = debitData.Amt.Avg;
        aggs.find(x=>x.id == "D-Tcount").innerText = debitData.Cnt.Tot;
        
        // credit
        aggs.find(x=>x.id == "C-total").innerText = creditData.Amt.Tot;
        aggs.find(x=>x.id == "C-min").innerText = creditData.Amt.Max;
        aggs.find(x=>x.id == "C-max").innerText = creditData.Amt.Min;
        aggs.find(x=>x.id == "C-avg").innerText = creditData.Amt.Avg;
        aggs.find(x=>x.id == "C-Tcount").innerText = creditData.Cnt.Tot;
        
        
        var buttons = document.querySelectorAll("button[role='tab']");
        
        buttons.forEach(b => {
            b.addEventListener('click' , e => {
                var type = e.target.parentElement.dataset.aggcat;
                var debitData = segData.Types.find(x=> x.name == type).debit;
                var creditData = segData.Types.find(x=> x.name == type).credit;
                // debit
                aggs.find(x=>x.id == "D-total").innerText = debitData.Amt.Tot ?? 0;
                aggs.find(x=>x.id == "D-min").innerText = debitData.Amt.Max ?? 0;
                aggs.find(x=>x.id == "D-max").innerText = debitData.Amt.Min ?? 0;
                aggs.find(x=>x.id == "D-avg").innerText = debitData.Amt.Avg ?? 0;
                aggs.find(x=>x.id == "D-Tcount").innerText = debitData.Cnt.Tot ?? 0;

                // credit
                aggs.find(x=>x.id == "C-total").innerText = creditData.Amt.Tot ?? 0;
                aggs.find(x=>x.id == "C-min").innerText = creditData.Amt.Max ?? 0;
                aggs.find(x=>x.id == "C-max").innerText = creditData.Amt.Min ?? 0;
                aggs.find(x=>x.id == "C-avg").innerText = creditData.Amt.Avg ?? 0;
                aggs.find(x=>x.id == "C-Tcount").innerText = creditData.Cnt.Tot ?? 0;
            })
        })
        console.log(buttons)
        
    }catch (err){
        console.error(err)
    }
  
    
    

}
function RenderDataForCharts(data) {
            am4core.useTheme(am4themes_animated);
            am4core.useTheme(am4themes_material);
            am4core.addLicense("ch-custom-attribution");
            var chart = am4core.create("IndustrySegmentChart", am4charts.XYChart3D);
            var title = chart.titles.create();
            if (segType.toUpperCase() == "INDIVIDUAL".toUpperCase()) {
                title.text = " Occupation Statistics";
            }
            else {
                title.text = " Industry Statistics";
            }

            title.fontSize = 25;
            title.marginBottom = 30;
            chart.data = data;
            chart.exporting.menu = new am4core.ExportMenu();
            chart.exporting.menu.items = [{
                "label": "...",
                "menu": [
                    { "type": "svg", "label": "Save" },
                ]
            }];
            chart.padding(30, 30, 10, 30);
            chart.legend = new am4charts.Legend();

            chart.colors.step = 2;

            var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
            categoryAxis.dataFields.category = "IndustryDesc";
            categoryAxis.renderer.minGridDistance = 10;
            categoryAxis.renderer.grid.template.location = 1;
            categoryAxis.interactionsEnabled = false;
            categoryAxis.renderer.labels.template.rotation = -45;
            categoryAxis.renderer.labels.template.horizontalCenter = "right";
            categoryAxis.renderer.labels.template.verticalCenter = "middle";
            categoryAxis.renderer.labels.template.fontSize = 17;

            var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
            valueAxis.tooltip.disabled = true;
            valueAxis.renderer.grid.template.strokeOpacity = 0.05;
            valueAxis.renderer.minGridDistance = 15;
            valueAxis.interactionsEnabled = true;
            valueAxis.min = 5;
            valueAxis.renderer.minWidth = 35;
            valueAxis.renderer.labels.template.fontSize = 17;

            var series1 = chart.series.push(new am4charts.ColumnSeries3D());
            series1.columns.template.width = am4core.percent(80);
            series1.columns.template.tooltipText = "{name}: {valueY.value}";
            series1.name = "Total Amount";
            series1.dataFields.categoryX = "IndustryDesc";
            series1.dataFields.valueY = "TotalAmount";
            series1.tooltip.fontSize = 17;

            var series2 = chart.series.push(new am4charts.ColumnSeries3D());
            series2.columns.template.width = am4core.percent(80);
            series2.columns.template.tooltipText = "{name}: {valueY.value}";
            series2.name = "Total Credit Amount";
            series2.dataFields.categoryX = "IndustryDesc";
            series2.dataFields.valueY = "TotalCreditAmount";
            series2.tooltip.fontSize = 17;

            var series3 = chart.series.push(new am4charts.ColumnSeries3D());
            series3.columns.template.width = am4core.percent(80);
            series3.columns.template.tooltipText = "{name}: {valueY.value}";
            series3.name = "Total Debit Amount";
            series3.dataFields.categoryX = "IndustryDesc";
            series3.dataFields.valueY = "TotalDebitAmount";
            series3.tooltip.fontSize = 17;

            chart.scrollbarX = new am4core.Scrollbar();
            chart.legend.fontSize = 17;

        
  
}
renderTabsCounter().then(x=>  console.log("done") );

