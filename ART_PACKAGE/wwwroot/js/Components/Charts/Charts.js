import * as core from "../../../lib/Plugins/amcharts_4.10.18/amcharts4/core.js"
import * as charts from "../../../lib/Plugins/amcharts_4.10.18/amcharts4/charts.js";
import * as matrial from "../../../lib/Plugins/amcharts_4.10.18/amcharts4/themes/material.js";
import * as animated from "../../../lib/Plugins/amcharts_4.10.18/amcharts4/themes/animated.js";
import { URLS } from "../../URLConsts.js"

import { parametersConfig } from "../../QueryBuilderConfiguration/QuerybuilderParametersSettings.js"
import { mapParamtersToFilters, multiSelectOperation } from "../../QueryBuilderConfiguration/QuerybuilderConfiguration.js"

var btn = document.getElementById("gg");
var chart = document.getElementById("test");


am4core.useTheme(am4themes_animated);
am4core.useTheme(am4themes_material);
am4core.addLicense("ch-custom-attribution");



const exportMenu = [{
    "label": "...",
    "menu": [{
        "label": "Image",
        "menu": [
            { "type": "svg", "label": "Save" },
        ]
    }, {
        "label": "Data",
        "menu": [

            { "type": "csv", "label": "CSV" },
            { "type": "xlsx", "label": "XLSX" }

        ]
    }]
}];


class BaseCatValChart extends HTMLElement {
    chartDiv = document.createElement("div");
    loadingDiv = document.createElement("div");
    chart = undefined;
    data = [];
    dataUrl = "";
    chartTitle = "";
    chartCategory = "";
    chartValue = "";
    filterBuilder = undefined;
    filtersApplyBtn = undefined;
    constructor() {
        super();

    }
    connectedCallback() {
        this.classList.add("d-flex", "justify-content-center", "align-items-center")
        this.loadingDiv.classList.add("spinner-grow", "text-primary");
        this.chartDiv.classList.add("w-100", "h-100");
        this.appendChild(this.loadingDiv);
        this.appendChild(this.chartDiv);

        if (this.dataset.filterbuilderid) {
            this.filterBuilder = document.getElementById(this.dataset.filterbuilderid);
            this.filtersApplyBtn = document.getElementById(this.filterBuilder.dataset.applybtn);
            var rep = parametersConfig.find(x => x.reportName == this.filterBuilder.dataset.params);
            var customOps = [];
            var multifields = rep.parameters.filter(x => x.isMulti);
            multifields.forEach(p => {
                var vals = [];
                if (p.values.url) {
                    $.ajax({
                        url: p.values.url,
                        type: "GET",
                        async: false,
                        dataType: "json",
                        success: function (data) {
                            vals = data;
                        }
                    });
                }
                else
                    vals = p.values.static;

                customOps.push(multiSelectOperation(p.paraName, vals));
            })


            this.filterBuilder.customOperations = customOps;
            var filters = mapParamtersToFilters(rep.parameters);
            this.filterBuilder.fields = filters;
            if (rep.defaultFilter) {
                this.filterBuilder.value = rep.defaultFilter;
            }

            this.filtersApplyBtn.addEventListener('click', async () => {
                var flatted = this.filterBuilder.value.flat();
                var val = flatted.filter(x => x !== "or" && x !== "and").map(x => {
                    var val = x[2];
                    return {
                        Field: x[0],
                        Operator: x[1],
                        Value: val
                    }

                });
                await this.readData(val);
            });
        }


        this.chartDiv.hidden = true;
        //this.chartDiv.id = this.id + "-BarChart";
        this.dataUrl = URLS[this.dataset.dataurlkey];
        this.chartTitle = this.dataset.title;
        this.chartCategory = this.dataset.category;
        this.chartValue = this.dataset.value;

    }


    async readData(body) {
        this.toggleLoading();
        var method = "GET";
        if (body) {
            method = "POST";
        }

        try {
            var data = await (await fetch(this.dataUrl, {
                method: method,
                headers: {
                    "Content-Type": "application/json",
                    Accept: "application/json",
                },
                ...(body && { body: JSON.stringify(body) })
            })).json();
            console.log(this.chartValue, this.chartCategory, data);

            this.data = data;
            this.chart.data = this.data;
            this.chart.validateData();
        } catch (e) {
            console.error(e);
            toastObj.icon = 'error';
            toastObj.text = "failed to load data for the chart";
            toastObj.heading = "Chart Status";
            $.toast(toastObj);
        } finally {
            this.toggleLoading();
        }
    }


    setdata(data) {

        this.toggleLoading();
        this.data = data;
        this.chart.data = this.data;
        this.chart.validateData();
        this.toggleLoading();

    }

    toggleLoading() {
        this.loadingDiv.hidden = !this.loadingDiv.hidden
        this.chartDiv.hidden = !this.chartDiv.hidden;

    }

    makeTitle() {
        var title = this.chart.titles.create();
        title.text = this.chartTitle;
        title.fontSize = 25;
        title.marginBottom = 30;
    }
}

class PieChart extends BaseCatValChart {

    connectedCallback() {

        super.connectedCallback();
        this.chartDiv.id = this.id + "-PieChart";
        this.chart = am4core.create(this.id + "-PieChart", am4charts.PieChart);

        this.chart.data = this.data;
        this.chart.exporting.menu = new am4core.ExportMenu();
        this.chart.exporting.menu.items = exportMenu;

        var pieSeries = this.chart.series.push(new am4charts.PieSeries());
        pieSeries.dataFields.value = this.chartValue;
        pieSeries.dataFields.category = this.chartCategory;
        // Disable ticks and labels
        pieSeries.labels.template.disabled = true;
        pieSeries.ticks.template.disabled = true;

        this.chart.legend = new am4charts.Legend();
        this.chart.legend.maxHeight = 600;
        this.chart.legend.maxWidth = 300;
        this.chart.legend.scrollable = true;
        this.chart.legend.position = "bottom";
        this.chart.legend.labels.template.text = "{name} : ({value})";

        var title = this.chart.titles.create();
        title.text = this.chartTitle;
        title.fontSize = 25;
        title.marginBottom = 30;
        setTimeout(() => {
            this.toggleLoading();
        }, 3000);
    }
}

class BarChart extends BaseCatValChart {

    isHorizontal = false;

    connectedCallback() {

        super.connectedCallback();
        this.chartDiv.id = this.id + "-BarChart";

        if (!Object.keys(this.dataset).includes("horizontal"))
            this.makeBar();
        else
            this.makeHBar();
        this.chart.exporting.menu = new am4core.ExportMenu();
        this.chart.exporting.menu.items = exportMenu;


        //if (columnsColorFunc) {
        //    series.columns.template.adapter.add("fill", (fill, target) => columnsColorFunc(fill, target)
        //    );

        //} else {
        //    series.columns.template.adapter.add("fill", (fill, target) => {
        //        return this.chart.colors.getIndex(target.dataItem.index);
        //    });
        //}








        setTimeout(() => {
            this.toggleLoading();
        }, 3000);


        //var pieSeries = this.chart.series.push(new am4charts.PieSeries());
        //pieSeries.dataFields.value = this.chartValue;
        //pieSeries.dataFields.category = this.chartCategory;
        //// Disable ticks and labels
        //pieSeries.labels.template.disabled = true;
        //pieSeries.ticks.template.disabled = true;

        //this.chart.legend = new am4charts.Legend();
        //this.chart.legend.maxHeight = 600;
        //this.chart.legend.maxWidth = 300;
        //this.chart.legend.scrollable = true;
        //this.chart.legend.position = "bottom";
        //this.chart.legend.labels.template.text = "{name} : ({value})";

        //var title = this.chart.titles.create();
        //title.text = this.chartTitle;
        //title.fontSize = 25;
        //title.marginBottom = 30;
        //setTimeout(() => {
        //    this.toggleLoading();
        //}, 3000);
    }
    makeRotateButton() {
        let buttonContainer = this.chart.chartContainer.createChild(am4core.Container);
        let button = buttonContainer.createChild(am4core.Button);
        button.label.text = "Rotate Chart";
        button.align = "left";
        button.marginBottom = 15;
        button.events.on("hit", () => {

            this.toggleLoading();
            if (this.isHorizontal) {
                this.isHorizontal = false;
                this.makeBar()
            } else {
                this.isHorizontal = true;
                this.makeHBar();
            }
            setTimeout(() => {
                this.toggleLoading();
            }, 3000);
        });
    }
    makeBar() {

        this.chart = am4core.create(this.chartDiv, am4charts.XYChart);
        this.chart.data = this.data;
        var categoryAxis = this.chart.xAxes.push(new am4charts.CategoryAxis());

        categoryAxis.renderer.labels.template.fontSize = 20;
        categoryAxis.dataFields.category = this.chartCategory;


        categoryAxis.renderer.labels.template.dy = -5;
        categoryAxis.renderer.labels.template.adapter.add("dy", function (dy, target) {
            if (target.dataItem && target.dataItem.index & 2 == 2) {
                return dy + 25;
            }
            return dy;
        });
        var valueAxis = this.chart.yAxes.push(new am4charts.ValueAxis());
        valueAxis.renderer.labels.template.fontSize = 20;
        var series = this.chart.series.push(new am4charts.ColumnSeries());
        series.columns.template.fill = am4core.color("#104547");
        series.dataFields.valueY = this.chartValue;
        series.dataFields.categoryX = this.chartCategory;
        series.columns.template.adapter.add("fill", (fill, target) => {
            return this.chart.colors.getIndex(target.dataItem.index);
        });
        this.chart.maskBullets = false;
        this.chart.paddingTop = 25;
        var labelBullet = series.bullets.push(new am4charts.LabelBullet());
        labelBullet.label.text = "{valueY}";
        labelBullet.adapter.add("y", function (y) {
            return -15;
        });
        this.chart.cursor = new am4charts.XYCursor();
        this.chart.cursor.behavior = "zoomX";
        var scrollbar = new am4charts.XYChartScrollbar();

        this.chart.scrollbarX = scrollbar;

        this.makeRotateButton();
        this.makeTitle();
    }
    makeHBar() {
        this.chart = am4core.create(this.chartDiv, am4charts.XYChart);
        this.chart.data = this.data;
        var categoryAxis = this.chart.yAxes.push(new am4charts.CategoryAxis());
        categoryAxis.renderer.labels.template.fontSize = 20;
        categoryAxis.dataFields.category = this.chartCategory;
        categoryAxis.renderer.grid.template.location = 0;

        var valueAxis = this.chart.xAxes.push(new am4charts.ValueAxis());
        valueAxis.renderer.labels.template.fontSize = 20;
        var series = this.chart.series.push(new am4charts.ColumnSeries());
        series.dataFields.valueX = this.chartValue;
        series.dataFields.categoryY = this.chartCategory;
        series.columns.template.tooltipText = "{categoryY}: [bold]{valueX}[/]";
        series.sequencedInterpolation = true;
        series.defaultState.transitionDuration = 1000;
        series.sequencedInterpolationDelay = 100;
        series.columns.template.strokeOpacity = 0;
        series.tooltip.fontSize = 17;

        // Set cell size in pixels
        //var cellSize = 30;
        //chart.events.on("datavalidated", function (ev) {
        //    // Get objects of interest
        //    var chart = ev.target;
        //    var categoryAxis = chart.yAxes.getIndex(0);
        //    // Calculate how we need to adjust chart height
        //    var adjustHeight = chart.data.length * cellSize - categoryAxis.pixelHeight;
        //    // get current chart height
        //    var targetHeight = chart.pixelHeight + adjustHeight;
        //    // Set it on chart's container
        //    chart.svgContainer.htmlElement.style.height = targetHeight + "px";
        //});
        this.chart.cursor = new am4charts.XYCursor();
        this.chart.cursor.behavior = "zoomY";

        //set values on the bar without hover
        var labelBullet = series.bullets.push(new am4charts.LabelBullet())
        labelBullet.label.horizontalCenter = "right";
        labelBullet.label.dx = -5;
        labelBullet.label.text = "{valueX}";
        var valueLabel = series.bullets.push(new am4charts.LabelBullet());
        valueLabel.label.text = "{value}";
        valueLabel.label.fontSize = 20;
        valueLabel.label.horizontalCenter = "left";
        valueLabel.label.dx = 10;
        valueLabel.locationX = 1;
        var title = this.chart.titles.create();
        title.text = this.title;
        title.fontSize = 25;
        title.marginBottom = 30;
        //// Add scrollbar
        var scrollbar = new am4charts.XYChartScrollbar();
        this.chart.scrollbarY = scrollbar;
        this.chart.events.on("ready", () => {
            categoryAxis.zoomToIndexes(this.data.length - 5, this.data.length);
        });
        this.makeRotateButton();
        this.makeTitle();
    }
}

class DragDropChart extends BaseCatValChart {
    connectedCallback() {

        super.connectedCallback();

        var dumm = {
            disabled: true,
            color: am4core.color("#dadada"),
            opacity: 0.3,
            strokeDasharray: "4,4",
        };

        dumm[this.chartCategory] = "Dummy";
        dumm[this.chartValue] = 1000;

        this.data = [dumm, ...this.data];

        // cointainer to hold both charts
        var container = am4core.create(this.chartDiv, am4core.Container);
        container.width = am4core.percent(100);
        container.height = am4core.percent(100);
        container.layout = "horizontal";



        var chart1 = container.createChild(am4charts.PieChart);
        chart1.hiddenState.properties.opacity = 0; // this makes initial fade in effect
        chart1.data = this.data;
        chart1.radius = am4core.percent(70);
        chart1.innerRadius = am4core.percent(40);
        chart1.zIndex = 1;

        var series1 = chart1.series.push(new am4charts.PieSeries());
        series1.dataFields.value = this.chartCategory;
        series1.dataFields.category = this.chartValue;
        series1.colors.step = 2;

        var sliceTemplate1 = series1.slices.template;
        sliceTemplate1.cornerRadius = 5;
        sliceTemplate1.draggable = true;
        sliceTemplate1.inert = true;
        sliceTemplate1.propertyFields.fill = "color";
        sliceTemplate1.propertyFields.fillOpacity = "opacity";
        sliceTemplate1.propertyFields.stroke = "color";
        sliceTemplate1.propertyFields.strokeDasharray = "strokeDasharray";
        sliceTemplate1.strokeWidth = 1;
        sliceTemplate1.strokeOpacity = 1;

        var zIndex = 5;

        sliceTemplate1.events.on("down", function (event) {
            event.target.toFront();
            // also put chart to front
            var series = event.target.dataItem.component;
            series.chart.zIndex = zIndex++;
        });
        series1.labels.template.disabled = true;
        series1.ticks.template.disabled = true;
        //series1.labels.template.propertyFields.disabled = "disabled";
        //series1.ticks.template.propertyFields.disabled = "disabled";

        sliceTemplate1.states.getKey("active").properties.shiftRadius = 0;

        sliceTemplate1.events.on("dragstop", function (event) {
            handleDragStop(event);
        });

        // separator line and text
        var separatorLine = container.createChild(am4core.Line);
        separatorLine.x1 = 0;
        separatorLine.y2 = 300;
        separatorLine.strokeWidth = 3;
        separatorLine.stroke = am4core.color("#dadada");
        separatorLine.valign = "middle";
        separatorLine.strokeDasharray = "5,5";

        var dragText = container.createChild(am4core.Label);
        dragText.text = "Drag slices over the line";
        dragText.rotation = 90;
        dragText.valign = "middle";
        dragText.align = "center";
        dragText.paddingBottom = 5;

        var chartTitle = container.createChild(am4core.Label);
        chartTitle.text = this.title;
        chartTitle.valign = "top";
        chartTitle.align = "center";
        chartTitle.fontSize = 25;
        chartTitle.marginBottom = 30;

        // second chart
        var chart2 = container.createChild(am4charts.PieChart);
        chart2.hiddenState.properties.opacity = 0; // this makes initial fade in effect

        chart2.radius = am4core.percent(70);
        chart2.data = this.data;
        chart2.innerRadius = am4core.percent(40);
        chart2.zIndex = 1;

        var series2 = chart2.series.push(new am4charts.PieSeries());
        series2.dataFields.value = this.chartValue;
        series2.dataFields.category = this.chartCategory;
        series2.colors.step = 2;

        var sliceTemplate2 = series2.slices.template;
        sliceTemplate2.copyFrom(sliceTemplate1);
        series2.labels.template.disabled = true;
        series2.ticks.template.disabled = true;
        //series2.labels.template.propertyFields.disabled = "disabled";
        //series2.ticks.template.propertyFields.disabled = "disabled";
        container.events.on("maxsizechanged", function () {
            chart1.zIndex = 0;
            separatorLine.zIndex = 1;
            dragText.zIndex = 2;
            chart2.zIndex = 3;
        });
        function handleDragStop(event) {
            var targetSlice = event.target;
            var dataItem1;
            var dataItem2;
            var slice1;
            var slice2;

            if (series1.slices.indexOf(targetSlice) != -1) {
                slice1 = targetSlice;
                slice2 = series2.dataItems.getIndex(targetSlice.dataItem.index).slice;
            } else if (series2.slices.indexOf(targetSlice) != -1) {
                slice1 = series1.dataItems.getIndex(targetSlice.dataItem.index).slice;
                slice2 = targetSlice;
            }

            dataItem1 = slice1.dataItem;
            dataItem2 = slice2.dataItem;

            var series1Center = am4core.utils.spritePointToSvg(
                { x: 0, y: 0 },
                series1.slicesContainer
            );
            var series2Center = am4core.utils.spritePointToSvg(
                { x: 0, y: 0 },
                series2.slicesContainer
            );

            var series1CenterConverted = am4core.utils.svgPointToSprite(
                series1Center,
                series2.slicesContainer
            );
            var series2CenterConverted = am4core.utils.svgPointToSprite(
                series2Center,
                series1.slicesContainer
            );

            // tooltipY and tooltipY are in the middle of the slice, so we use them to avoid extra calculations
            var targetSlicePoint = am4core.utils.spritePointToSvg(
                { x: targetSlice.tooltipX, y: targetSlice.tooltipY },
                targetSlice
            );

            if (targetSlice == slice1) {
                if (targetSlicePoint.x > container.pixelWidth / 2) {
                    var value = dataItem1.value;

                    dataItem1.hide();

                    var animation = slice1.animate(
                        [
                            { property: "x", to: series2CenterConverted.x },
                            { property: "y", to: series2CenterConverted.y },
                        ],
                        400
                    );
                    animation.events.on("animationprogress", function (event) {
                        slice1.hideTooltip();
                    });

                    slice2.x = 0;
                    slice2.y = 0;

                    dataItem2.show();
                } else {
                    slice1.animate(
                        [
                            { property: "x", to: 0 },
                            { property: "y", to: 0 },
                        ],
                        400
                    );
                }
            }
            if (targetSlice == slice2) {
                if (targetSlicePoint.x < container.pixelWidth / 2) {
                    var value = dataItem2.value;

                    dataItem2.hide();

                    var animation = slice2.animate(
                        [
                            { property: "x", to: series1CenterConverted.x },
                            { property: "y", to: series1CenterConverted.y },
                        ],
                        400
                    );
                    animation.events.on("animationprogress", function (event) {
                        slice2.hideTooltip();
                    });

                    slice1.x = 0;
                    slice1.y = 0;
                    dataItem1.show();
                } else {
                    slice2.animate(
                        [
                            { property: "x", to: 0 },
                            { property: "y", to: 0 },
                        ],
                        400
                    );
                }
            }

            toggleDummySlice(series1);
            toggleDummySlice(series2);

            series1.hideTooltip();
            series2.hideTooltip();
        }

        function toggleDummySlice(series) {
            var show = true;
            for (var i = 1; i < series.dataItems.length; i++) {
                var dataItem = series.dataItems.getIndex(i);
                if (dataItem.slice.visible && !dataItem.slice.isHiding) {
                    show = false;
                }
            }

            var dummySlice = series.dataItems.getIndex(0);
            if (show) {
                dummySlice.show();
            } else {
                dummySlice.hide();
            }
        }

        series2.events.on("datavalidated", function () {
            var dummyDataItem = series2.dataItems.getIndex(0);
            dummyDataItem.show(0);
            dummyDataItem.slice.draggable = false;
            dummyDataItem.slice.tooltipText = undefined;

            for (var i = 1; i < series2.dataItems.length; i++) {
                series2.dataItems.getIndex(i).hide(0);
            }
        });

        series1.events.on("datavalidated", function () {
            var dummyDataItem = series1.dataItems.getIndex(0);
            dummyDataItem.hide(0);
            dummyDataItem.slice.draggable = false;
            dummyDataItem.slice.tooltipText = undefined;
        });

    }
}

class CurvedColumnChart extends BaseCatValChart {
    connectedCallback() {

        super.connectedCallback();


        this.chart = am4core.create(this.chartDiv, am4charts.XYChart3D);
        this.chart.data = this.data;
        this.chart.exporting.menu = new am4core.ExportMenu();
        this.chart.exporting.menu.items = exportMenu;

        var categoryAxis = this.chart.xAxes.push(new am4charts.CategoryAxis());

        categoryAxis.renderer.labels.template.fontSize = 20;
        categoryAxis.renderer.grid.template.location = 0;
        categoryAxis.dataFields.category = this.chartCategory;
        categoryAxis.renderer.minGridDistance = 40;

        var valueAxis = this.chart.yAxes.push(new am4charts.ValueAxis());
        valueAxis.renderer.labels.template.fontSize = 20
        var series = this.chart.series.push(new am4charts.CurvedColumnSeries());
        series.dataFields.categoryX = this.chartCategory;
        series.dataFields.valueY = this.chartValue;
        series.tooltipText = "{valueY.value}";
        series.columns.template.strokeOpacity = 0;

        series.columns.template.fillOpacity = 0.75;

        var hoverState = series.columns.template.states.create("hover");
        hoverState.properties.fillOpacity = 1;
        hoverState.properties.tension = 0.5;

        this.chart.cursor = new am4charts.XYCursor();
        this.chart.cursor.behavior = "panX";

        // Add distinctive colors for each column using adapter
        series.columns.template.adapter.add("fill", (fill, target) => {
            return this.chart.colors.getIndex(target.dataItem.index);
        });

        this.chart.scrollbarX = new am4core.Scrollbar();

        setTimeout(() => {
            this.toggleLoading();
        }, 3000);

        this.makeTitle();
        //chart.exporting.menu = new am4core.ExportMenu();
    }

}

class CylnderChart extends BaseCatValChart {
    connectedCallback() {

        super.connectedCallback();

        this.chart = am4core.create(this.chartDiv, am4charts.XYChart3D);
        this.chart.data = this.data;
        this.chart.exporting.menu = new am4core.ExportMenu();
        this.chart.exporting.menu.items = exportMenu;

        var categoryAxis = this.chart.xAxes.push(new am4charts.CategoryAxis());
        categoryAxis.renderer.labels.template.fontSize = 20;
        categoryAxis.renderer.grid.template.location = 0;
        categoryAxis.dataFields.category = this.chartCategory;
        categoryAxis.renderer.minGridDistance = 60;
        categoryAxis.renderer.grid.template.disabled = true;
        categoryAxis.renderer.baseGrid.disabled = true;
        categoryAxis.renderer.labels.template.dy = 20;

        var valueAxis = this.chart.yAxes.push(new am4charts.ValueAxis());
        valueAxis.renderer.labels.template.fontSize = 20
        valueAxis.renderer.grid.template.disabled = true;
        valueAxis.renderer.baseGrid.disabled = true;
        valueAxis.renderer.labels.template.disabled = true;
        valueAxis.renderer.minWidth = 0;

        var series = this.chart.series.push(new am4charts.ConeSeries());
        series.dataFields.categoryX = this.chartCategory;
        series.dataFields.valueY = this.chartValue;
        series.columns.template.tooltipText = "{valueY.value}";
        series.columns.template.tooltipY = 0;
        series.columns.template.strokeOpacity = 1;
        // as by default columns of the same series are of the same color, we add adapter which takes colors from chart.colors color set
        series.columns.template.adapter.add("fill", (fill, target) => {
            return this.chart.colors.getIndex(target.dataItem.index);
        });

        series.columns.template.adapter.add("stroke", (stroke, target) => {
            return this.chart.colors.getIndex(target.dataItem.index);
        });

        chart.cursor = new am4charts.XYCursor();
        this.makeTitle();
        setTimeout(() => {
            this.toggleLoading();
        }, 3000);
        //chart.exporting.menu = new am4core.ExportMenu();
    }
}


//class


customElements.define("m-pie-chart", PieChart);
customElements.define("m-bar-chart", BarChart);
customElements.define("m-drag-drop-chart", DragDropChart);
customElements.define("m-curved-column-chart", CurvedColumnChart);
customElements.define("m-clynder-chart", CylnderChart);


//export function makeDatesChart(data, divId, cat, val, subcat, subval, subListKey, ctitle, onDateChange) {
//    /**
//  * ---------------------------------------
//  * This demo was created using amCharts 4.
//  *
//  * For more information visit:
//  * https://www.amcharts.com/
//  *
//  * Documentation is available at:
//  * https://www.amcharts.com/docs/v4/
//  * ---------------------------------------
//  */

//    am4core.useTheme(am4themes_animated);
//    am4core.useTheme(am4themes_kelly);
//    /**
//     * Source data
//     */


//    /**
//     * Chart container
//     */

//    // Create chart instance
//    var chart = am4core.create(divId, am4core.Container);
//    chart.width = am4core.percent(100);
//    chart.height = am4core.percent(100);
//    chart.layout = "horizontal";
//    chart.exporting.menu = new am4core.ExportMenu();
//    chart.exporting.menu.items = exportMenu;


//    /**
//     * Column chart
//     */

//    // Create chart instance
//    var columnChart = chart.createChild(am4charts.XYChart);

//    // Create axes
//    var categoryAxis = columnChart.yAxes.push(new am4charts.CategoryAxis());
//    categoryAxis.renderer.labels.template.fontSize = 20
//    categoryAxis.dataFields.category = subcat;
//    categoryAxis.renderer.grid.template.location = 0;
//    categoryAxis.renderer.inversed = true;

//    var valueAxis = columnChart.xAxes.push(new am4charts.ValueAxis());
//    valueAxis.renderer.labels.template.fontSize = 20;

//    // Create series
//    var columnSeries = columnChart.series.push(new am4charts.ColumnSeries());
//    columnSeries.dataFields.valueX = subval;
//    columnSeries.dataFields.categoryY = subcat;
//    columnSeries.columns.template.strokeWidth = 0;
//    columnSeries.columns.template.tooltipText = "{value}";



//    var valueLabel = columnSeries.bullets.push(new am4charts.LabelBullet());
//    valueLabel.label.text = "{value}";
//    valueLabel.label.fontSize = 20;
//    valueLabel.label.horizontalCenter = "left";
//    valueLabel.label.hideOversized = false;
//    valueLabel.label.truncate = false;
//    valueLabel.label.dx = 10;
//    columnChart.cursor = new am4charts.XYCursor();
//    columnChart.cursor.behavior = "zoomX";
//    var scrollbar = new am4charts.XYChartScrollbar();

//    columnChart.scrollbarX = scrollbar;

//    /**
//     * Pie chart
//     */

//    // Create chart instance
//    var pieChart = chart.createChild(am4charts.PieChart);
//    pieChart.data = data;
//    pieChart.innerRadius = am4core.percent(50);
//    var title = pieChart.titles.create();
//    title.text = ctitle;
//    title.fontSize = 25;
//    pieChart.legend = new am4charts.Legend();
//    pieChart.legend.maxHeight = 600;
//    pieChart.legend.maxWidth = 300;
//    pieChart.legend.scrollable = true;
//    pieChart.legend.position = "bottom"; pieChart.legend.labels.template.text = "{name} : ({value})";
//    // Add and configure Series
//    var pieSeries = pieChart.series.push(new am4charts.PieSeries());
//    pieSeries.dataFields.value = val;
//    pieSeries.dataFields.category = cat;

//    pieSeries.labels.template.disabled = true;

//    // Set up labels
//    //var label1 = pieChart.seriesContainer.createChild(am4core.Label);
//    //label1.text = "";
//    //label1.horizontalCenter = "middle";
//    //label1.fontSize = 35;
//    //label1.fontWeight = 600;
//    //label1.dy = -30;
//    //
//    //
//    //var label3 = pieChart.seriesContainer.createChild(am4core.Label);
//    //label3.text = "";
//    //label3.horizontalCenter = "middle";
//    //label3.fontSize = 20;
//    //label3.dy = 40;
//    //
//    //
//    //var label2 = pieChart.seriesContainer.createChild(am4core.Label);
//    //label2.text = "";
//    //label2.horizontalCenter = "middle";
//    //label2.fontSize = 20;
//    //label2.dy = 20;

//    // Auto-select first slice on load
//    pieChart.events.on("ready", function (ev) {
//        pieSeries.slices.getIndex(0).isActive = true;
//    });

//    // Set up toggling events
//    pieSeries.slices.template.events.on("toggled", function (ev) {
//        if (ev.target.isActive) {

//            // Untoggle other slices
//            pieSeries.slices.each(function (slice) {
//                if (slice != ev.target) {
//                    slice.isActive = false;
//                }
//            });

//            // Update column chart
//            columnSeries.appeared = false;
//            columnChart.data = ev.target.dataItem.dataContext[subListKey];
//            columnSeries.fill = ev.target.fill;
//            columnSeries.reinit();
//            onDateChange(ev.target.dataItem.dataContext);
//            // Update labels
//            //label1.text = pieChart.numberFormatter.format(ev.target.dataItem.values.value.percent, "#.'%'");
//            //label1.fill = ev.target.fill;
//            //label3.text = ev.target.dataItem.dataContext[val];
//            //label3.fill = ev.target.fill;
//            //console.log(ev.target.dataItem);
//            //label2.text = ev.target.dataItem.dataContext[cat];
//        }
//    });


//}


//function callDonutChart(data, donuttitle, divId, chartValue, chartCategory) {
//    am4core.useTheme(am4themes_animated);
//    am4core.addLicense("ch-custom-attribution");
//    var chart = am4core.create(divId, am4charts.PieChart);
//    chart.data = data;
//    chart.exporting.menu = new am4core.ExportMenu();
//    chart.exporting.menu.items = exportMenu;

//    var pieSeries = chart.series.push(new am4charts.PieSeries3D());
//    pieSeries.dataFields.value = chartValue;
//    pieSeries.dataFields.category = chartCategory; // Disable ticks and labels
//    // Disable ticks and labels
//    pieSeries.labels.template.disabled = true;
//    pieSeries.ticks.template.disabled = true;

//    chart.innerRadius = am4core.percent(40);


//    chart.legend = new am4charts.Legend();
//    chart.legend.maxHeight = 600;
//    chart.legend.maxWidth = 300;
//    chart.legend.scrollable = true;
//    chart.legend.position = "bottom"; chart.legend.labels.template.text = "{name} : ({value})";

//    pieSeries.colors.list = [
//        am4core.color("#2799DB"),
//        am4core.color("#D61C4E"),
//        am4core.color("#FEB139"),
//        am4core.color("#3CCF4E"),
//        am4core.color("#7A4069"),
//        am4core.color("#F9F871"),
//        am4core.color("#FFE1C6"),
//        am4core.color("#D6FFE0"),
//        am4core.color("#E1E3FF"),
//        am4core.color("#3EF6FF"),
//        am4core.color("#EE6123"),
//        am4core.color("#00916E"),
//    ];
//    var title = chart.titles.create();
//    title.text = donuttitle;
//    title.fontSize = 25;
//    title.marginBottom = 30;
//}

//function callClusterd(data, clusterdtitle, chartId,) {


//    am4core.useTheme(am4themes_animated);
//    // Themes end



//    var chart = am4core.create(chartId, am4charts.XYChart)
//    chart.colors.step = 2;

//    chart.legend = new am4charts.Legend()
//    chart.legend.position = 'top'
//    chart.legend.paddingBottom = 20
//    chart.legend.labels.template.maxWidth = 95
//    chart.exporting.menu = new am4core.ExportMenu();
//    chart.exporting.menu.items = exportMenu;

//    var xAxis = chart.xAxes.push(new am4charts.CategoryAxis())
//    xAxis.renderer.labels.template.fontSize = 20;
//    xAxis.dataFields.category = 'cat';
//    xAxis.renderer.cellStartLocation = 0.1;
//    xAxis.renderer.cellEndLocation = 0.9;
//    xAxis.renderer.grid.template.location = 0;
//    xAxis.renderer.labels.template.rotation = 90;


//    var yAxis = chart.yAxes.push(new am4charts.ValueAxis());
//    yAxis.renderer.labels.template.fontSize = 20
//    // Make the labels vertical
//    yAxis.min = 0;

//    function createSeries(value, name) {
//        var series = chart.series.push(new am4charts.ColumnSeries())
//        series.dataFields.valueY = value
//        series.dataFields.categoryX = 'cat'
//        series.name = name
//        series.events.on("hidden", arrangeColumns);
//        series.events.on("shown", arrangeColumns);

//        //var labelBullet = series.bullets.push(new am4charts.LabelBullet());
//        //labelBullet.label.text = "{valueY}";
//        //labelBullet.adapter.add("y", function (y) {
//        //    return -15;
//        //});

//        var bullet = series.bullets.push(new am4charts.LabelBullet())
//        bullet.interactionsEnabled = false
//        bullet.label.text = '{valueY}'
//        bullet.label.fill = am4core.color('#000000')
//        bullet.adapter.add("y", function (y) {
//            return 15;
//        });

//        return series;
//    }

//    chart.data = data;
//    if (data[0]) {
//        Object.keys(data[0]).forEach(item => {
//            if (item != "cat")
//                createSeries(item, item);
//        })
//    }
//    /*createSeries('first', 'The First');
//    createSeries('second', 'The Second');
//    createSeries('third', 'The Third');*/

//    function arrangeColumns() {

//        var series = chart.series.getIndex(0);

//        var w = 1 - xAxis.renderer.cellStartLocation - (1 - xAxis.renderer.cellEndLocation);
//        if (series.dataItems.length > 1) {
//            var x0 = xAxis.getX(series.dataItems.getIndex(0), "categoryX");
//            var x1 = xAxis.getX(series.dataItems.getIndex(1), "categoryX");
//            var delta = ((x1 - x0) / chart.series.length) * w;
//            if (am4core.isNumber(delta)) {
//                var middle = chart.series.length / 2;

//                var newIndex = 0;
//                chart.series.each(function (series) {
//                    if (!series.isHidden && !series.isHiding) {
//                        series.dummyData = newIndex;
//                        newIndex++;
//                    }
//                    else {
//                        series.dummyData = chart.series.indexOf(series);
//                    }
//                })
//                var visibleCount = newIndex;
//                var newMiddle = visibleCount / 2;

//                chart.series.each(function (series) {
//                    var trueIndex = chart.series.indexOf(series);
//                    var newIndex = series.dummyData;

//                    var dx = (newIndex - trueIndex + middle - newMiddle) * delta

//                    series.animate({ property: "dx", to: dx }, series.interpolationDuration, series.interpolationEasing);
//                    series.bulletsContainer.animate({ property: "dx", to: dx }, series.interpolationDuration, series.interpolationEasing);
//                })
//            }
//        }
//    }
//    var title = chart.titles.create();
//    title.text = clusterdtitle;
//    title.fontSize = 25;
//    title.marginBottom = 30;
//    chart.cursor = new am4charts.XYCursor();
//    chart.cursor.behavior = "zoomX";
//    var scrollbar = new am4charts.XYChartScrollbar();

//    chart.scrollbarX = scrollbar;


//}

//export function makedynamicChart(
//    chartType,
//    data,
//    title,
//    divId,
//    chartValue,
//    chartCategory,
//    dontRotateCat,
//    columnsColorFunc
//) {
//    var chart = document.getElementById(divId);
//    chart.style.height = "600px";
//    switch (chartType) {
//        case types.pie:
//            callPieChart(data, title, divId, chartValue, chartCategory);
//            break;
//        case types.bar:
//            callBarChart(data, title, divId, chartValue, chartCategory, dontRotateCat, columnsColorFunc);
//            break;
//        case types.hbar:
//            callHBar(data, title, divId, chartValue, chartCategory);
//            break;
//        case types.dragdrop:
//            callDragDropChart(data, title, divId, chartValue, chartCategory);
//            break;
//        case types.curvy:
//            callCurvyChart(data, title, divId, chartValue, chartCategory);
//            break;
//        case types.clynder:
//            callClyChart(data, title, divId, chartValue, chartCategory);
//            break;
//        case types.donut:
//            callDonutChart(data, title, divId, chartValue, chartCategory);
//            break;
//        case types.clusteredbar:
//            chart.style.height = "800px";
//            callClusterd(data, title, divId);
//            break;
//        case types.line:
//            chart.style.height = "800px";
//            callLineChart(data, title, divId, chartValue, chartCategory);
//            break;
//        default:
//            console.log("eror");
//            break;
//    }
//}