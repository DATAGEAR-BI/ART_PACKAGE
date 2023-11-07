//commented by ehab azab 23-07-2023
//const { Tab } = require("../../../../../../../node_modules/@mui/material/index");
var ChartData = [];
var ChartDataCount = [];
var ChartIndustryAndOccuipation = [];
var allTypesNames = [];
var typesLength = 0;

$(window).on("load", function () {
        HiddenMultiSelect();

});
$('#seriesIdIndustry').on('changed.bs.select', function (e, clickedIndex, isSelected, previousValue) {
    setTimeout(function () {
        if (!isSelected) {
            // This code runs when an option is deselected
            console.log('Option deselected');
            var unselected = $('#seriesIdIndustry option').eq(clickedIndex).val();
            if (unselected === 'select-all') {
                ToggleSelectAll("#seriesIdIndustry");
                OnChangeSeriesIndustry(this);
            }
            else {
                $(`#seriesIdIndustry option[value="select-all"]`).prop('selected', false);

                // Refresh the SelectPicker to reflect the changes
                $("#seriesIdIndustry").selectpicker('refresh');
                OnChangeSeriesIndustry(this);
            }
        }
        else {
            if (e.target.value === 'select-all') {
                ToggleSelectAll("#seriesIdIndustry");
            }
            OnChangeSeriesIndustry(this);

        }
    }, 0);

});
$('#seriesIdCount').on('changed.bs.select', function (e, clickedIndex, isSelected, previousValue) {
    setTimeout(function () {
        if (!isSelected) {
            // This code runs when an option is deselected
            console.log('Option deselected');
            var unselected = $('#seriesIdCount option').eq(clickedIndex).val();
            if (unselected === 'select-all') {
               ToggleSelectAll("#seriesIdCount");
                OnChangeSeriesTransactionTypeCount(this);
            }
            else {
                $(`#seriesIdCount option[value="select-all"]`).prop('selected', false);

                // Refresh the SelectPicker to reflect the changes
                $("#seriesIdCount").selectpicker('refresh');
                OnChangeSeriesTransactionTypeCount(this);
            }
        }
        else {
            if (e.target.value === 'select-all') {
                ToggleSelectAll("#seriesIdCount");
            }
            OnChangeSeriesTransactionTypeCount(this);

        }
    }, 0);

});
$('#seriesIdAmount').on('changed.bs.select', function (e, clickedIndex, isSelected, previousValue) {
    console.log("Hello select change");
    setTimeout(function () {
        if (!isSelected) {
            // This code runs when an option is deselected
            var unselected = $('#seriesIdAmount option').eq(clickedIndex).val();
            if (unselected === 'select-all') {
                ToggleSelectAll("#seriesIdAmount");
                OnChangeSeriesTransactionTypeAmount(this);
            }
            else {
                $(`#seriesIdAmount option[value="select-all"]`).prop('selected', false);

                // Refresh the SelectPicker to reflect the changes
                $("#seriesIdAmount").selectpicker('refresh');
                OnChangeSeriesTransactionTypeAmount(this);
            }
        }
        else {
            if (e.target.value === 'select-all') {
                ToggleSelectAll("#seriesIdAmount");
            }
            OnChangeSeriesTransactionTypeAmount(this);
        }
    }, 0);

});
function callCounters() {
    // DOM Element's
    const counters = document.querySelectorAll('.counter');

    for (let n of counters) {
        const updateCount = () => {
            const target = + n.getAttribute('data-target');
            const count = + n.innerText;
            const speed = 650;
            const inc = target / speed;
            if (count < target) {
                n.innerText = Math.ceil(count + inc);
                setTimeout(updateCount, 1);
            } else {
                n.innerText = target;
            }
        }
        updateCount();
    };
};

function openTab(evt, TabName) {
    //commented by Ehab Azab 23-07-2023
    //callCounters();

    allTypesNames.forEach((i) => {
        document.getElementById(`${i}TabParent`).style.display = "none";
        document.getElementById(`${i}`).className = document.getElementById(`${i}`).className.replace(" active", "");
    });
    document.getElementById(`${TabName}TabParent`).style.display = "block";
    evt.currentTarget.className += " active";

    //commented by Ehab Azab 23--7-2023
/*
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(TabName).style.display = "block";
    evt.currentTarget.className += " active";
*/
    //renderTabsCounter();


};

function renderTabsCounter() {


    var ActiveTab = document.querySelectorAll('.tablinks .active');
    //console.log($('.tablinks .active')['context']['activeElement']['id']);

    var monthkey = document.getElementById('month-key-spinner').value;
    var segment_id = selectedSegmentId;
    console.log(segment_id);

    console.log("/SegmentationCharts/DataForTabs?monthKey=" + monthkey + "&segment=" + segment_id);
    function calcSum(array) {
        var total = 0;
        for (var i = 0; i < array.length; i++) {
            total += array[i];
        }
        return total;
    }

    function calcMean(array) {
        var arraySum = calcSum(array);
        return arraySum / array.length;
    }

    function calcMedian(array) {
        array = array.sort();
        if (array.length % 2 === 0) { // array with even number elements
            return (array[array.length / 2] + array[(array.length / 2) - 1]) / 2;
        }
        else {
            return array[(array.length - 1) / 2]; // array with odd number elements
        }
    }
    $.ajax({
        type: "GET",
        url: "/SegmentationCharts/DataForTabs?monthKey=" + monthkey + "&segment=" + segment_id,
        data: {
        },
        success: function (data) {

            //replace null with 0 
            console.log("seg data",data);
            /*data[.forEach(function (myObj) {
                for (let prop in myObj) {
                    myObj[prop] = myObj[prop] === null ? 0 : myObj[prop];
                }
            });*/
            document.getElementById("TabsButtonsContainer").innerHTML="";
            document.getElementById("tabContentContainer").innerHTML = "";
            ChartData = [];
            ChartDataCount = [];
            
            typesLength = data["Types"].length;
            console.log('Hello');
            console.log(data["Types"]);
            data["Types"].forEach((obj) => {
                allTypesNames.push(obj["name"]);
                createTap(obj);
            });
            

        }
    });

}

function createTap(typeObj) {

    var buttonOfTabString = `<button class="tablinks col-sm-1 container-fluid" style="color:#013459; text-align: center; font-weight: 600; width: ${100 / typesLength}%;" id="${typeObj["name"]}" onclick="openTab(event, '${typeObj["name"]}')">${typeObj["name"]}</button>`;
    const TabsButtonsContainerDiv = document.getElementById("TabsButtonsContainer");
    TabsButtonsContainerDiv.innerHTML += buttonOfTabString;

    var tabsDivString = `
        <div id="${typeObj["name"]}TabParent" class="tabcontent"style=";display:none;">
            <section class="counters text-center" style="font-size:16px;" id="${typeObj["name"]}TabContainer">
                
            <div class="" id="${typeObj["name"]}Tab"></div>
            </section>
        </div>
    `;
    const tabsDiv = document.getElementById("tabContentContainer");
    tabsDiv.innerHTML += tabsDivString;
    var debitFlag = false;
    var Type_Data = {
        "category": `${typeObj["name"]}`
    }
    var Type_Data_Count = {
        "category": `${typeObj["name"]}`
    }
    const tabDiv = document.getElementById(`${typeObj["name"]}Tab`);
    if (Object.entries(typeObj["debit"]["Cnt"]).length !== 0) {
        Type_Data["T_A_D"] = typeObj["debit"]["Amt"]["Tot"];
        Type_Data["L_A_D"] = typeObj["debit"]["Amt"]["Min"];
        Type_Data["M_A_D"] = typeObj["debit"]["Amt"]["Max"];
        Type_Data["A_A_D"] = typeObj["debit"]["Amt"]["Avg"];
        Type_Data_Count["T_D_C"] = typeObj["debit"]["Cnt"]["Tot"];
        
        debitFlag = true;
        var debitDivString = `
            <h4 style="color: #013459; text-align: left; font-weight: 600; font-style: italic "> Debit: </h4>
            <div class="row">
                <div class='col-md-1'>
                    <h4>Total</h4>
                    <div class='counter' id="Tot_${typeObj["name"]}_D_Amt">${typeObj["debit"]["Amt"]["Tot"]}</div>
                </div>
                <div class='col-md-3'>
                    <h4>Lowest Amount</h4>
                    <div class='counter' id="Min_${typeObj["name"]}_D_Amt">${typeObj["debit"]["Amt"]["Min"]}</div>
                </div>
                <div class="col-md-3">
                    <h4>Average Amount</h4>
                    <div class="counter" id="Avg_${typeObj["name"]}_D_Amt">${typeObj["debit"]["Amt"]["Avg"]}</div>
                </div>
                <div class="col-md-3">
                    <h4>Highest Amount</h4>
                    <div class="counter" id="Max_${typeObj["name"]}_D_Amt">${typeObj["debit"]["Amt"]["Max"]}</div>
                </div>
                <div class="col-md-1">
                    <h4>Count</h4>
                    <div class="counter" id="Tot_${typeObj["name"]}_D_Cnt">${typeObj["debit"]["Cnt"]["Tot"]}</div>
                </div>
            </div>
         `;
        tabDiv.innerHTML += debitDivString;
    }
    if (Object.entries(typeObj["credit"]["Cnt"]).length !== 0) {
        Type_Data["T_A_C"] = typeObj["credit"]["Amt"]["Tot"];
        Type_Data["L_A_C"] = typeObj["credit"]["Amt"]["Min"];
        Type_Data["M_A_C"] = typeObj["credit"]["Amt"]["Max"];
        Type_Data["A_A_C"] = typeObj["credit"]["Amt"]["Avg"];
        Type_Data_Count["T_C_C"] = typeObj["credit"]["Cnt"]["Tot"];
        if (debitFlag) {
            var hrElementString = `<hr style="border:3px ;border-top: 3px solid #013459 ">`;
            tabDiv.innerHTML += hrElementString;
        }
        var creditDivString = `
            <h4 style="color: #013459; text-align: left; font-weight: 600; font-style: italic "> Credit: </h4>
            <div class="row">
               <div class='col-md-1'>
                    <h4>Total</h4>
                    <div class='counter' id="Tot_${typeObj["name"]}_C_Amt">${typeObj["credit"]["Amt"]["Tot"]}</div>
                </div>
                <div class='col-md-3'>
                    <h4>Lowest Amount</h4>
                    <div class='counter' id="Min_${typeObj["name"]}_C_Amt">${typeObj["credit"]["Amt"]["Min"]}</div>
                </div>
                <div class="col-md-3">
                    <h4>Average Amount</h4>
                    <div class="counter" id="Avg_${typeObj["name"]}_C_Amt">${typeObj["credit"]["Amt"]["Avg"]}</div>
                </div>
                <div class="col-md-3">
                    <h4>Highest Amount</h4>
                    <div class="counter" id="Max_${typeObj["name"]}_C_Amt">${typeObj["credit"]["Amt"]["Max"]}</div>
                </div>
                <div class="col-md-1">
                    <h4>Count</h4>
                    <div class="counter" id="Tot_${typeObj["name"]}_C_Cnt">${typeObj["credit"]["Cnt"]["Tot"]}</div>
                </div>
            </div>`;
        tabDiv.innerHTML += creditDivString;
    }
    ChartData.push(Type_Data);
    ChartDataCount.push(Type_Data_Count);
}
function RenderDataForCharts() {
    var monthkey = document.getElementById('month-key-spinner').value;
    var segment_id = document.getElementById('segment-id').value;

    var type = document.getElementById('segment-type').value;
    console.log(type);
    $.ajax({
        type: "GET",
        url: "/SegmentationCharts/ArtIndustrySegments?monthKey=" + monthkey + "&segment=" + segment_id + "&type=" + type,
        data: {
        },
        success: function (data) {
            ChartIndustryAndOccuipation = data;

        }
    });
}

function draw_Stacked_Col_Chart() {

    am4core.useTheme(am4themes_animated);
    am4core.addLicense("ch-custom-attribution");
    var chart = am4core.create("chartdiv", am4charts.XYChart);
    var title = chart.titles.create();
    title.text = "Transaction Type Amounts Comparison";
    title.fontSize = 25;
    title.marginBottom = 30;
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
    categoryAxis.dataFields.category = "category";
    categoryAxis.renderer.minGridDistance = 35;
    categoryAxis.renderer.grid.template.location = 0;
    categoryAxis.interactionsEnabled = true;
    categoryAxis.renderer.labels.template.fontSize = 17;
    categoryAxis.renderer.labels.template.fontSize = 17;

    var valueAxis = chart.xAxes.push(new am4charts.ValueAxis());
    valueAxis.tooltip.disabled = true;
    valueAxis.renderer.grid.template.strokeOpacity = 0.05;
    valueAxis.renderer.minGridDistance = 40;
    valueAxis.interactionsEnabled = true;
    valueAxis.min = 0;
    valueAxis.renderer.minWidth = 30;
    valueAxis.renderer.labels.template.fontSize = 17;
    valueAxis.renderer.labels.template.disabled = true;
    chart.scrollbarY = new am4core.Scrollbar();
    chart.legend.fontSize = 17;
    return chart;
};

function draw_Stacked_Col_Chart_Count() {

    am4core.useTheme(am4themes_animated);
    am4core.addLicense("ch-custom-attribution");
    var chart = am4core.create("chartCountdiv", am4charts.XYChart);
    var title = chart.titles.create();
    title.text = "Transaction Type Counts Comparison";
    title.fontSize = 25;
    title.marginBottom = 30;
    chart.data = ChartDataCount;
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
    categoryAxis.dataFields.category = "category";
    categoryAxis.renderer.minGridDistance = 30;
    categoryAxis.renderer.grid.template.location = 0;
    categoryAxis.interactionsEnabled = false;
    categoryAxis.renderer.labels.template.fontSize = 17;

    var valueAxis = chart.xAxes.push(new am4charts.ValueAxis());
    valueAxis.tooltip.disabled = true;
    valueAxis.renderer.grid.template.strokeOpacity = 0.05;
    valueAxis.renderer.minGridDistance = 30;
    valueAxis.interactionsEnabled = false;
    valueAxis.min = 0;
    valueAxis.renderer.minWidth = 35;
    valueAxis.renderer.labels.template.fontSize = 17;
    valueAxis.renderer.labels.template.disabled = true;
    chart.scrollbarY = new am4core.Scrollbar();

    chart.legend.fontSize = 17;
    return chart; 


};
function drawIndustryAndOccuipation() {
    am4core.useTheme(am4themes_animated);
    am4core.addLicense("ch-custom-attribution");
    var chart = am4core.create("IndustrySegmentChart", am4charts.XYChart);
    var title = chart.titles.create();
    var type = document.getElementById('segment-type').value;
    if (type.toUpperCase() == "INDIVIDUAL".toUpperCase()) {
        title.text = " Occupation Statistics";
    }
    else {
        title.text = " Industry Statistics";
    }

    title.fontSize = 25;
    title.marginBottom = 30;
    chart.data = ChartIndustryAndOccuipation;
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
    categoryAxis.dataFields.category = "IndustryDesc";
    categoryAxis.renderer.minGridDistance = 10;
    categoryAxis.renderer.grid.template.location = 1;
    categoryAxis.interactionsEnabled = false;
    // categoryAxis.renderer.labels.template.rotation = 45;
    categoryAxis.renderer.labels.template.horizontalCenter = "right";
    categoryAxis.renderer.labels.template.verticalCenter = "middle";
    categoryAxis.renderer.labels.template.fontSize = 17;

    var valueAxis = chart.xAxes.push(new am4charts.ValueAxis());
    valueAxis.tooltip.disabled = true;
    valueAxis.renderer.grid.template.strokeOpacity = 0.05;
    valueAxis.renderer.minGridDistance = 15;
    valueAxis.interactionsEnabled = true;
    valueAxis.min = 5;
    valueAxis.renderer.minWidth = 35;
    valueAxis.renderer.labels.template.fontSize = 17;

    valueAxis.renderer.labels.template.disabled = true;


    chart.scrollbarY = new am4core.Scrollbar();


    return chart;
}

var selectedMonthKey = "";
var selectedSegmentType = "";
var selectedSegmentId = "";
var selectedFeature = "";
loadMonthKies().then(x => console.log('done'));
document.getElementById('month-key-spinner').onchange = async (e) => await onChangeMonthKey(e);
document.getElementById('segment-type').onchange = async (e) => await onChangeSegmentType(e);
document.getElementById('segment-id').onchange = async (e) => await onChangeSegmentId(e);
async function loadMonthKies() {
    var monthKeySelect = document.getElementById('month-key-spinner');
    await makeDropDown("/SegmentationCharts/MonthKeys", monthKeySelect);

}
async function onChangeMonthKey(e) {
    selectedMonthKey = e.target.value;
    var segmentTypeDropDown = document.getElementById('segment-type');
    await makeDropDown("/SegmentationCharts/SegTypesPerKey?monthkey=" + selectedMonthKey, segmentTypeDropDown);

}

async function onChangeSegmentType(e) {
    selectedSegmentType = e.target.value;
    var segmentIdDropDown = document.getElementById('segment-id');
    await makeDropDown("/SegmentationCharts/Segs?monthkey=" + selectedMonthKey + "&Type=" + selectedSegmentType, segmentIdDropDown);

}

async function onChangeSegmentId(e) {
    selectedSegmentId = e.target.value;
    document.getElementById("TabsID").style.display = "block";
    renderTabsCounter();
    RenderDataForCharts();
    $("#chartdiv").show();
    $("#chartCountdiv").show();
    $("#IndustrySegmentChart").show();
    ShowMultiSelect();
    setTimeout(function () {
        InitalMultiSelectValues();
        RunAllSeriesMultiSelect();
    }, 1500);

}

function fillCards(url, divId) {
    $.ajax({
        type: "GET",
        url: url,
        data: {
        },
        success: function (data) {
            var responseData = data;
            var mydiv = document.getElementById(divId);
            mydiv.innerHTML = "";

            for (const [key, value] of Object.entries(responseData)) {
                var mylist = "";
                for (const [key2, value2] of Object.entries(responseData[key])) {
                    //console.log(`${key2}: ${value2}`);
                    mylist += `<li><p class="card-text"><b>${key2} : </b> ${value2}</p> </li>`;
                }
                if (mylist) {
                    mydiv.innerHTML += `
                                                        <div class="card col-md-4">
                                                            <div class="container">
                                                                <h4><b>Segment ${key} </b></h4>
                                                                <div>
                                                                    <ul>
                                                                        ${mylist}
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>`;


                } else {
                    mydiv.innerHTML += `
                                                        <div class="card col-md-4">
                                                            <div class="container">
                                                                <h4><b>Segment ${key} </b></h4>
                                                                <div>
                                                                    ${value}
                                                                    <ul hidden>
                                                                        <li><li/><li><li/><li><li/><li><li/><li><li/><li><li/>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>`;
                }

            }

        },
    });
}
async function makeDropDown(url, dropdown) {
    var items = await (await fetch(url)).json();
    console.log(items);
    dropdown.innerHTML = "";
    var fopt = document.createElement('option');
    fopt.value = '';
    fopt.innerHTML = '-- Not Selected --';
    dropdown.appendChild(fopt);
    items.forEach(q => {
        var opt = document.createElement('option');
        
        if (q.SegmentDescription != null) {
            opt.innerHTML = q.SegmentSorted + " , " + q.SegmentDescription;
            opt.value = q.SegmentSorted;
        } else {
            opt.innerHTML = q;
            opt.value = q;
        }
        dropdown.appendChild(opt);
    })
}
$(window).resize(function () {
    kendo.resize($("div.k-chart[data-role='chart']"));
});
function InitalMultiSelectValues() {   // Inital MultiSelect For Series Segment Type Amount
        var newOptionsHTML = `<option value="select-all">-- Select All --</option>`;
        $("#seriesIdAmount").empty();
    var select = $("#seriesIdAmount");
    console.log(ChartData);
        Object.entries(ChartData[0]).forEach((x) => {
            if (x[0] !== "category") {
                fillSeriesMultiSelect(x[0]);
            }
        });
        select.html(newOptionsHTML);
        select.selectpicker('refresh');
        function fillSeriesMultiSelect(v) {
            var firstChar = v.split("_")[0];
            var secondChar = v.split("_")[1];
            var thirdChar = v.split("_")[2];
            var seriesName = "";
            if (firstChar === "T") {
                seriesName += "Total ";
            } else if (firstChar === "L") {
                seriesName += "Lowest ";
            } else if (firstChar === "M") {
                seriesName += "Highest ";
            } else if (firstChar === "A") {
                seriesName += "Average ";
            }

            if (thirdChar === "C") {
                seriesName += "Credit ";
            } else if (thirdChar === "D") {
                seriesName += "Debit ";
            }
            seriesName += "Amount";
            var value = v;
            var text = seriesName;
            newOptionsHTML += `<option value="${value}">${text}</option>`;
            
        }
        
    }    
// Multi Select Series---------------------------------------------------------//

function InitalMultiSelect() {
    SelectAll("#seriesIdIndustry");
    SelectAll("#seriesIdAmount");
    SelectAll("#seriesIdCount");
}
function HiddenMultiSelect() {
    $("#seriesIdCount").selectpicker("hide");
    $("#seriesIdAmount").selectpicker("hide");
    $("#seriesIdIndustry").selectpicker("hide");
}
function ShowMultiSelect() {
    $("#seriesIdCount").selectpicker("show");
    $("#seriesIdAmount").selectpicker("show");
    $("#seriesIdIndustry").selectpicker("show");
}
function ToggleSelectAll(selectId) {
    var selectAllSelected = $(`${selectId} option[value="select-all"]`).prop('selected');

    // Set the selected state of all other options accordingly
    $(`${selectId} option[value!="select-all"]`).prop('selected', selectAllSelected);

    // Refresh the SelectPicker to reflect the changes
    $(selectId).selectpicker('refresh');
}
function SelectAll(selectId) {
    // Set selected for all option
    $(`${selectId} option`).prop('selected', true);

    // Refresh the SelectPicker to reflect the changes
    $(selectId).selectpicker('refresh');
}

//-----------------------------------------------------------------//

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
    console.log(series);
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
function OnChangeSeriesTransactionTypeCount(e) {
    var chart = draw_Stacked_Col_Chart_Count();
    AddMultipleSeries(chart, "seriesIdCount", "category");

}
function OnChangeSeriesTransactionTypeAmount(e) {
    var chart = draw_Stacked_Col_Chart();
    console.log(chart);
    AddMultipleSeries(chart, "seriesIdAmount", "category");
}
function OnChangeSeriesIndustry(e) {
    var chart = drawIndustryAndOccuipation();
    AddMultipleSeries(chart, "seriesIdIndustry", "IndustryDesc");

}
function OnChangeSeries(e) { // For Segment Comparison Chart
    var chart = DrawSegmentComparisonChart();
    AddMultipleSeries(chart, "seriesId", "SegmentDescription");
}
function RunAllSeriesMultiSelect() {
    InitalMultiSelect();
    OnChangeSeriesTransactionTypeCount(this);
    OnChangeSeriesTransactionTypeAmount(this);
    OnChangeSeriesIndustry(this);
}
