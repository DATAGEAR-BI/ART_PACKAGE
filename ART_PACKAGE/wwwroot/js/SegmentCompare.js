var selectedMonthKey = "";
var selectedSegmentType = "";
var ChartData = [];
$(window).on("load", function () {
    $("#seriesId").selectpicker("hide");

});
makeSpinner("/SegmentationCharts/MonthKeys", "month-key-spinner", "monthKey");
function onChangeMonthKey(e) {
    selectedMonthKey = e.value;
    makeSpinner("/SegmentationCharts/SegTypesPerKey?monthkey=" + selectedMonthKey, "segment-type", "segmentType");
    DrawOnMonthCharts();
}
function onChangeSegmentType(e) {
    selectedSegmentType = e.value;
    makeSpinner("/SegmentationCharts/Segs?monthkey=" + selectedMonthKey + "&Type=" + selectedSegmentType);
    PrepDataDrawChart(selectedSegmentType);
    $("#seriesId").selectpicker("show");
    setTimeout(function () {
        OnChangeSeries();
    }, 1500);
    DrawCharts(selectedSegmentType);
}



function makeSpinner(url, divId, spinnerDefaultValue) {
    $.ajax({
        type: "GET",
        url: url,
        data: {
        },
        success: function (data) {
           var queueList = data;

            var select = document.getElementById(divId);
            if (select == null)
                return;
            select.innerHTML = "";
            var fopt = document.createElement('option');
            fopt.value = spinnerDefaultValue;
            fopt.innerHTML = spinnerDefaultValue;
            select.appendChild(fopt);
            queueList.forEach(q => {
                var opt = document.createElement('option');
                opt.value = q;
                opt.innerHTML = q;
                select.appendChild(opt);
            })
        },

    });
}
function PrepDataDrawChart(SegmentType) {

    //start get the current selected monthKey & current Type
    var monthkey = document.getElementById('month-key-spinner').value;
    var Type = SegmentType;
    //End

    //display elments
  

    //start getting all segments data from api according to the current selected
    $.ajax({
        type: "GET",
        url: "/SegmentationCharts/GetAllSegmentData?monthKey=" + monthkey + "&Type=" + Type,
        data: {
        },
        success: function (data) {
            ChartData = data;           
            InitalMultiSelectValues();
            function InitalMultiSelectValues() {
                var newOptionsHTML = `<option value="select-all">-- Select All --</option>`;
                var select = $("#seriesId").empty();

                Object.entries(data[0]).filter(checkForType).forEach((s) => {
                    var value = s[0];
                    var text = s[0].replace(/([a-z0-9])([A-Z])/g, '$1 $2');
                    newOptionsHTML += `<option value="${value}">${text}</option>`;
                });
                select.html(newOptionsHTML);
                select.selectpicker('refresh');

                function checkForType(prop) {
                    return (prop[0].startsWith("Tot") || prop[0].startsWith("Min") || prop[0].startsWith("Max") || prop[0].startsWith("Avg")) && (prop[0].endsWith('CAmt') || prop[0].endsWith('DAmt'));
                }



            }
        },

    });
    //end



}
function DrawSegmentComparisonChart() {
    am4core.useTheme(am4themes_animated);
    am4core.addLicense("ch-custom-attribution");
    var chart = am4core.create("SegmentsComparisonChart", am4charts.XYChart);
    chart.data = ChartData;
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
    var categoryAxis = chart.yAxes.push(new am4charts.CategoryAxis());
    categoryAxis.dataFields.category = "SegmentDescription";
    categoryAxis.renderer.minGridDistance = 10;
    categoryAxis.renderer.grid.template.location = 1;
    categoryAxis.interactionsEnabled = false;

    var valueAxis = chart.xAxes.push(new am4charts.ValueAxis());
    valueAxis.tooltip.disabled = true;
    valueAxis.renderer.grid.template.strokeOpacity = 0.05;
    valueAxis.renderer.minGridDistance = 15;
    valueAxis.interactionsEnabled = true;
    valueAxis.min = 5;
    valueAxis.renderer.minWidth = 35;
    valueAxis.renderer.labels.template.fontSize = 17;
    valueAxis.renderer.labels.template.disabled = true;
    var title = chart.titles.create();
    title.text = "Segments Comparison Chart";
    title.fontSize = 25;
    title.marginBottom = 30;


    chart.scrollbarY = new am4core.Scrollbar();
    chart.legend.fontSize = 17;
    return chart;
}

function DrawCharts(SegmentType) {
    //start get the current selected monthKey & current Type
    var monthkey = document.getElementById('month-key-spinner').value;
    var Type = SegmentType;
    //End

    $.ajax({
        type: "GET",
        url: "/SegmentationCharts/GetAllSegmentCustCount?monthKey=" + monthkey + "&Type=" + Type,
        data: {
        },
        success: function (data) {
            //display elments
           

            am4core.useTheme(am4themes_animated);
            am4core.addLicense("ch-custom-attribution");
            var chart = am4core.create("SegmentsCustCountChart", am4charts.PieChart3D);
            chart.exporting.menu = new am4core.ExportMenu();
            chart.exporting.menu.items = [{
                "label": "...",
                "menu": [
                    { "type": "svg", "label": "Save" },
                ]
            }];
            chart.legend = new am4charts.Legend();
            chart.legend.maxHeight = 600;
            chart.legend.maxWidth = 300;
            chart.legend.scrollable = true;
            chart.legend.position = "bottom";
            chart.legend.labels.template.text = "( {name} , {SegmentDescription} ) : ({value})";

            chart.data = data;
            chart.innerRadius = am4core.percent(40);
            var series = chart.series.push(new am4charts.PieSeries3D());
            series.dataFields.value = "NumberOfCustomers";
            series.dataFields.category = "SegmentSorted";
            // Disable ticks and labels
            series.labels.template.disabled = true;
            series.ticks.template.disabled = true;
            series.labels.template.fontSize = 17;
            chart.legend.fontSize = 17;
            series.tooltip.fontSize = 17;
            //series.stroke = am4core.color("#000000");//red
            //series.slices.template.stroke = am4core.color("#000000"); // red outline
            //series.slices.template.fill = am4core.color("#00ff00"); // green fill

            series.slices.template.events.on("doublehit", function (ev) {
                window.open("/SegmentationCharts/SingleSegmentReport?monthkey=" + selectedMonthKey + "&SegType=" + Type + "&SegID=" + ev.target.dataItem.category)
            });
            var title = chart.titles.create();
            title.text = "Number of Customers Per Segment";
            title.fontSize = 25;
            title.marginBottom = 30;
        },

    });

    $.ajax({
        type: "GET",
        url: "/SegmentationCharts/GetAllSegmentAlertsCount?monthKey=" + monthkey + "&Type=" + Type,
        data: {
        },
        success: function (data) {
            //display elments
            

            am4core.useTheme(am4themes_animated);
            am4core.addLicense("ch-custom-attribution");
            var chart = am4core.create("SegmentsAlertCountChart", am4charts.PieChart3D);
            chart.exporting.menu = new am4core.ExportMenu();
            chart.exporting.menu.items = [{
                "label": "...",
                "menu": [
                    { "type": "svg", "label": "Save" },
                ]
            }];
            chart.legend = new am4charts.Legend();
            chart.legend.maxHeight = 600;
            chart.legend.maxWidth = 300;
            chart.legend.scrollable = true;
            chart.legend.position = "bottom";
            chart.legend.labels.template.text = "({name} , {SegmentDescription} ): ({value})";

            chart.data = data;
            chart.innerRadius = am4core.percent(40);
            var series = chart.series.push(new am4charts.PieSeries3D());
            series.dataFields.value = "NumberOfAlerts";
            series.dataFields.category = "SegmentSorted";
            series.labels.template.fontSize = 17;
            chart.legend.fontSize = 17;
            // Disable ticks and labels
            series.labels.template.disabled = true;
            series.ticks.template.disabled = true;
            series.slices.template.events.on("doublehit", function (ev) {
                window.open("/SegmentationCharts/SingleSegmentReport?monthkey=" + selectedMonthKey + "&SegType=" + Type + "&SegID=" + ev.target.dataItem.category)
            });

            var title = chart.titles.create();
            title.text = "Number of Alerts Per Segment";
            title.fontSize = 25;
            title.marginBottom = 30;
        },

    });


}
function DrawOnMonthCharts() {
    var monthkey = document.getElementById('month-key-spinner').value;
    $.ajax({
        type: "GET",
        url: "/SegmentationCharts/GetCustCountPerType?monthKey=" + monthkey,
        data: {
        },
        success: function (data) {
            //display elments
           

            am4core.useTheme(am4themes_animated);
            am4core.addLicense("ch-custom-attribution");
            var chart = am4core.create("CustCountPerTypeChart", am4charts.PieChart3D);
            chart.exporting.menu = new am4core.ExportMenu();
            chart.exporting.menu.items = [{
                "label": "...",
                "menu": [
                    { "type": "svg", "label": "Save" },
                ]
            }];
            chart.legend = new am4charts.Legend();
            chart.legend.maxHeight = 600;
            chart.legend.maxWidth = 300;
            chart.legend.scrollable = true;
            chart.legend.position = "bottom";
            chart.legend.labels.template.text = "{name} : ({value})";
            chart.data = data;
            chart.innerRadius = am4core.percent(40);
            var series = chart.series.push(new am4charts.PieSeries3D());
            series.dataFields.value = "NumberOfCustomers";
            series.dataFields.category = "PartyTypeDesc";
            series.labels.template.fontSize = 17;
            chart.legend.fontSize = 17;
            series.tooltip.fontSize = 17;
            // Disable ticks and labels
            series.labels.template.disabled = true;
            series.ticks.template.disabled = true;
            var title = chart.titles.create();
            title.text = "Number of Customers Per Type";
            title.fontSize = 25;
            title.marginBottom = 30;



            var label = chart.chartContainer.createChild(am4core.Label);
            label.text = "You can double click any type slice to display other charts";
            label.align = "center";
            //chart.legend.itemContainers.template.events.on("hit", function (ev) {
            //    console.log("clicked on ");
            //});


            series.slices.template.events.on("doublehit", function (ev) {
                

                makeSpinner("/SegmentationCharts/Segs?monthkey=" + selectedMonthKey + "&Type=" + ev.target.dataItem.category);
                PrepDataDrawChart(ev.target.dataItem.category);
                DrawCharts(ev.target.dataItem.category);
                $("#seriesId").selectpicker("show");
                setTimeout(function () {
                    OnChangeSeries();
                }, 1500);

                // window.open("/SegmentationCharts/SingleSegmentReport?monthkey=" + selectedMonthKey + "&SegType=" + ev.target.dataItem.category )
            });


        },

    });
}


//-----------------------------------------------------------------------------//

function drawLabelBulletHorizontal(series) {
    var valueLabel = series.bullets.push(new am4charts.LabelBullet());
    valueLabel.label.text = "{valueX}";
    valueLabel.label.hideOversized = false;
    valueLabel.label.truncate = false;
    valueLabel.label.fontSize = 17;
    valueLabel.label.adapter.add('horizontalCenter', function (x, target) {
        if (!target.dataItem) {
            return x;
        }
        var width = target.dataItem.itemWidth;
        //console.log(width);
        if (width >= 800) { // display number inside graph
            return 'right';
        } else {
            //console.log('left');
            return 'left';
        }
    });
}
function AddSeries(chart, name, value, category) {
    var series = new am4charts.ColumnSeries();
    series.columns.template.width = am4core.percent(80);
    series.columns.template.tooltipText = "{name}: {valueX}";
    series.name = name;//"Total Debit Count";
    series.dataFields.categoryY = category;
    series.dataFields.valueX = value;//"T_D_C";
    series.tooltip.fontSize = 17;
    series.events.on("datavalidated", function (event) {
        var dataItems = event.target.dataItems;
        dataItems.each(function (dataItem) {
            if (dataItem.values.valueX.value == 0)
                dataItem.values.valueX.value = undefined;  // hidden zero values 
        });
    });
    chart.series.push(series);

    // series2.stacked = true;

    drawLabelBulletHorizontal(series);
}
function AddMultipleSeries(chart, selectId, category) {
    var selectedValues = $("#" + selectId).val(); // Get All option selected
    var select = document.getElementById(selectId);
    for (var i = 0; i < select.options.length; i++) {
        if (selectedValues != null && selectedValues.indexOf(select.options[i].value) != -1) {
            var value = select.options[i].value;
            var name = select.options[i].text;    // get text for each option
            if (value != 'select-all') {
                AddSeries(chart, name, value, category);
            }
        }
    }
}
function OnChangeSeries(e) { // For Segment Comparison Chart
    var chart = DrawSegmentComparisonChart();
    AddMultipleSeries(chart, "seriesId", "SegmentDescription");
}
function ToggleSelectAll(selectId) {
    var selectAllSelected = $(`${selectId} option[value="select-all"]`).prop('selected');

    // Set the selected state of all other options accordingly
    $(`${selectId} option[value!="select-all"]`).prop('selected', selectAllSelected);

    // Refresh the SelectPicker to reflect the changes
    $(selectId).selectpicker('refresh');
}
$('#seriesId').on('changed.bs.select', function (e, clickedIndex, isSelected, previousValue) {
    setTimeout(function () {
        if (!isSelected) {
            // This code runs when an option is deselected
            var unselected = $('#seriesId option').eq(clickedIndex).val();
            if (unselected === 'select-all') {
                ToggleSelectAll("#seriesId");
                OnChangeSeries(this);
            }
            else {
                $(`#seriesId option[value="select-all"]`).prop('selected', false);

                // Refresh the SelectPicker to reflect the changes
                $("#seriesId").selectpicker('refresh');
                OnChangeSeries(this);
            }
        }
        else {
            if (e.target.value === 'select-all') {
                ToggleSelectAll("#seriesId");
            }
            OnChangeSeries(this);

        }
    }, 0);

});
