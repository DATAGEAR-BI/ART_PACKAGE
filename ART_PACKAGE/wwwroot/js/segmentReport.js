var ChartData = [];
var ChartDataCount = [];

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
    callCounters();

    if (TabName == "Cash") {
        document.getElementById("FirstTab").style.display = "block";
    }
    if (TabName == "Wire") {
        document.getElementById("SecondTab").style.display = "block";
    }
    if (TabName == "Cheque") {
        document.getElementById("ThirdTab").style.display = "block";
    }
    if (TabName == "Misc") {
        document.getElementById("ForthTab").style.display = "block";
    }
    if (TabName == "InternalTransfer") {
        document.getElementById("FifthTab").style.display = "block";
    }
    if (TabName == "Withdrawal") {
        document.getElementById("SexTab").style.display = "block";
    }
    //if (TabName == "Fees") {
    //    document.getElementById("SevinTab").style.display = "block";
    //}


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

    renderTabsCounter();


};

function renderTabsCounter() {


    var ActiveTab = document.querySelectorAll('.tablinks .active');
    //console.log($('.tablinks .active')['context']['activeElement']['id']);

    var monthkey = document.getElementById('month-key-spinner').value;
    var segment_id = document.getElementById('segment-id').value;

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
            data.forEach(function (myObj) {
                for (let prop in myObj) {
                    myObj[prop] = myObj[prop] === null ? 0 : myObj[prop];
                }
            });


            /* For Cash Credit*/

            let TotalCashCreditAmountVar = 0;
            let LowestCashCreditAmountVar = 0;
            let MaxCashCreditAmountVar = 0;
            let AverageCashCreditAmountVar = 0;
            let TotalCashCreditCountVar = 0;

            TotalCashCreditAmountVar = data[0]['TotalCashCAmt'];
            LowestCashCreditAmountVar = data[0]['MinCashCAmt'];
            MaxCashCreditAmountVar = data[0]['MaxCashCAmt'];
            AverageCashCreditAmountVar = data[0]['AvgCashCAmt'];
            TotalCashCreditCountVar = data[0]['TotalCashCCnt'];

            Tot_TotalCashCreditAmount.innerHTML = TotalCashCreditAmountVar;
            Min_LowestCashCreditAmount.innerHTML = LowestCashCreditAmountVar;
            Max_MaxCashCreditAmount.innerHTML = MaxCashCreditAmountVar;
            Avg_AverageCashCreditAmount.innerHTML = AverageCashCreditAmountVar;
            Cnt_TotalCashCreditCount.innerHTML = TotalCashCreditCountVar;

            /* For Cash Debit*/

            let TotalCashDebitAmountVar = 0;
            let LowestCashDebitAmountVar = 0;
            let MaxCashDebitAmountVar = 0;
            let AverageCashDebitAmountVar = 0;
            let TotalCashDebitCountVar = 0;

            TotalCashDebitAmountVar = data[0]['TotalCashDAmt'];
            LowestCashDebitAmountVar = data[0]['MinCashDAmt'];
            MaxCashDebitAmountVar = data[0]['MaxCashDAmt'];
            AverageCashDebitAmountVar = data[0]['AvgCashDAmt'];
            TotalCashDebitCountVar = data[0]['TotalCashDCnt'];

            Tot_TotalCashDebitAmount.innerHTML = TotalCashDebitAmountVar;
            Min_LowestCashDebitAmount.innerHTML = LowestCashDebitAmountVar;
            Max_MaxCashDebitAmount.innerHTML = MaxCashDebitAmountVar;
            Avg_AverageCashDebitAmount.innerHTML = AverageCashDebitAmountVar;
            Cnt_TotalCashDebitCount.innerHTML = TotalCashDebitCountVar;

            var Cash_Data = {
                "category": "Cash",
                "T_A_C": TotalCashCreditAmountVar,
                "L_A_C": LowestCashCreditAmountVar,
                "M_A_C": MaxCashCreditAmountVar,
                "A_A_C": AverageCashCreditAmountVar,
                "T_A_D": TotalCashDebitAmountVar,
                "L_A_D": LowestCashDebitAmountVar,
                "M_A_D": MaxCashDebitAmountVar,
                "A_A_D": AverageCashDebitAmountVar
            };

            var Cash_Data_Count = {
                "category": "Cash",
                "T_C_C": TotalCashCreditCountVar,
                "T_D_C": TotalCashDebitCountVar
            };
            /*For Wire Credit*/

            let TotalWireCreditAmountVar = 0;
            let LowestWireCreditAmountVar = 0;
            let MaxWireCreditAmountVar = 0;
            let AverageWireCreditAmountVar = 0;
            let TotalWireCreditCountVar = 0;

            TotalWireCreditAmountVar = data[0]['TotalWireCAmt'];
            LowestWireCreditAmountVar = data[0]['MinWireCAmt'];
            MaxWireCreditAmountVar = data[0]['MaxWireCAmt'];
            AverageWireCreditAmountVar = data[0]['AvgWireCAmt'];
            TotalWireCreditCountVar = data[0]['TotalWireCCnt'];

            Tot_TotalWireCreditAmount.innerHTML = TotalWireCreditAmountVar;
            Min_LowestWireCreditAmount.innerHTML = LowestWireCreditAmountVar;
            Max_MaxWireCreditAmount.innerHTML = MaxWireCreditAmountVar;
            Avg_AverageWireCreditAmount.innerHTML = AverageWireCreditAmountVar;
            Cnt_TotalWireCreditCount.innerHTML = TotalWireCreditCountVar;

            /*For Wire Debit*/

            let TotalWireDebitAmountVar = 0;
            let LowestWireDebitAmountVar = 0;
            let MaxWireDebitAmountVar = 0;
            let AverageWireDebitAmountVar = 0;
            let TotalWireDebitCountVar = 0;

            TotalWireDebitAmountVar = data[0]['TotalWireDAmt'];
            LowestWireDebitAmountVar = data[0]['MinWireDAmt'];
            MaxWireDebitAmountVar = data[0]['MaxWireDAmt'];
            AverageWireDebitAmountVar = data[0]['AvgWireDAmt'];
            TotalWireDebitCountVar = data[0]['TotalWireDCnt'];

            Tot_TotalWireDebitAmount.innerHTML = TotalWireDebitAmountVar;
            Min_LowestWireDebitAmount.innerHTML = LowestWireDebitAmountVar;
            Max_MaxWireDebitAmount.innerHTML = MaxWireDebitAmountVar;
            Avg_AverageWireDebitAmount.innerHTML = AverageWireDebitAmountVar;
            Cnt_TotalWireDebitCount.innerHTML = TotalWireDebitCountVar;

            var Wire_Data = {
                "category": "Wires",
                "T_A_C": TotalWireCreditAmountVar,
                "L_A_C": LowestWireCreditAmountVar,
                "M_A_C": MaxWireCreditAmountVar,
                "A_A_C": AverageWireCreditAmountVar,
                "T_A_D": TotalWireDebitAmountVar,
                "L_A_D": LowestWireDebitAmountVar,
                "M_A_D": MaxWireDebitAmountVar,
                "A_A_D": AverageWireDebitAmountVar
            };

            var Wire_Data_Count = {
                "category": "Wire",
                "T_C_C": TotalWireCreditCountVar,
                "T_D_C": TotalWireDebitCountVar
            };

            /*For Check Debit*/
            let TotalCheckDebitAmountVar = 0;
            let LowestCheckDebitAmountVar = 0;
            let MaxCheckDebitAmountVar = 0;
            let AverageCheckDebitAmountVar = 0;
            let TotalCheckDebitCountVar = 0;

            TotalCheckDebitAmountVar = data[0]['TotalCheckDAmt'];
            LowestCheckDebitAmountVar = data[0]['MinCheckDAmt'];
            MaxCheckDebitAmountVar = data[0]['MaxCheckDAmt'];
            AverageCheckDebitAmountVar = data[0]['AvgCheckDAmt'];
            TotalCheckDebitCountVar = data[0]['TotalCheckDCnt'];

            Tot_TotalCheckDebitAmount.innerHTML = TotalCheckDebitAmountVar;
            Min_LowestCheckDebitAmount.innerHTML = LowestCheckDebitAmountVar;
            Max_MaxCheckDebitAmount.innerHTML = MaxCheckDebitAmountVar;
            Avg_AverageCheckDebitAmount.innerHTML = AverageCheckDebitAmountVar;
            Cnt_TotalCheckDebitCount.innerHTML = TotalCheckDebitCountVar;

            var Check_Data = {
                "category": "Cheque",
                "T_A_D": TotalCheckDebitAmountVar,
                "L_A_D": LowestCheckDebitAmountVar,
                "M_A_D": MaxCheckDebitAmountVar,
                "A_A_D": AverageCheckDebitAmountVar
            };

            var Check_Data_Count = {
                "category": "Cheque",
                "T_D_C": TotalCheckDebitCountVar
            };

            /*For Misc Credit*/
            let TotalMiscCreditAmountVar = 0;
            let LowestMiscCreditAmountVar = 0;
            let MaxMiscCreditAmountVar = 0;
            let AverageMiscCreditAmountVar = 0;
            let TotalMiscCreditCountVar = 0;

            TotalMiscCreditAmountVar = data[0]['TotalMiscCAmt'];
            LowestMiscCreditAmountVar = data[0]['MinMiscCAmt'];
            MaxMiscCreditAmountVar = data[0]['MaxMiscCAmt'];
            AverageMiscCreditAmountVar = data[0]['AvgMiscCAmt'];
            TotalMiscCreditCountVar = data[0]['TotalMiscCCnt'];

            Tot_TotalMiscCreditAmount.innerHTML = TotalMiscCreditAmountVar;
            Min_LowestMiscCreditAmount.innerHTML = LowestMiscCreditAmountVar;
            Max_MaxMiscCreditAmount.innerHTML = MaxMiscCreditAmountVar;
            Avg_AverageMiscCreditAmount.innerHTML = AverageMiscCreditAmountVar;
            Cnt_TotalMiscCreditCount.innerHTML = TotalMiscCreditCountVar;

            var Misc_Data = {
                "category": "MISC",
                "T_A_C": TotalMiscCreditAmountVar,
                "L_A_C": LowestMiscCreditAmountVar,
                "M_A_C": MaxMiscCreditAmountVar,
                "A_A_C": AverageMiscCreditAmountVar
            };

            var Misc_Data_Count = {
                "category": "Misc",
                "T_C_C": TotalMiscCreditCountVar
            };


            /*For Internaltransfer Credit*/

            let TotalInternaltransferCreditAmountVar = 0;
            let LowestInternaltransferCreditAmountVar = 0;
            let MaxInternaltransferCreditAmountVar = 0;
            let AverageInternaltransferCreditAmountVar = 0;
            let TotalInternaltransferCreditCountVar = 0;

            TotalInternaltransferCreditAmountVar = data[0]['TotalInternaltransferCAmt'];
            LowestInternaltransferCreditAmountVar = data[0]['MinInternaltransferCAmt'];
            MaxInternaltransferCreditAmountVar = data[0]['MaxInternaltransferCAmt'];
            AverageInternaltransferCreditAmountVar = data[0]['AvgInternaltransferCAmt'];
            TotalInternaltransferCreditCountVar = data[0]['TotalInternaltransferCCnt'];

            Tot_TotalInternaltransferCreditAmount.innerHTML = TotalInternaltransferCreditAmountVar;
            Min_LowestInternaltransferCreditAmount.innerHTML = LowestInternaltransferCreditAmountVar;
            Max_MaxInternaltransferCreditAmount.innerHTML = MaxInternaltransferCreditAmountVar;
            Avg_AverageInternaltransferCreditAmount.innerHTML = AverageInternaltransferCreditAmountVar;
            Cnt_TotalInternaltransferCreditCount.innerHTML = TotalInternaltransferCreditCountVar;


            /*For Internaltransfer Debit*/

            let TotalInternaltransferDebitAmountVar = 0;
            let LowestInternaltransferDebitAmountVar = 0;
            let MaxInternaltransferDebitAmountVar = 0;
            let AverageInternaltransferDebitAmountVar = 0;
            let TotalInternaltransferDebitCountVar = 0;

            TotalInternaltransferDebitAmountVar = data[0]['TotalInternaltransferDAmt'];
            LowestInternaltransferDebitAmountVar = data[0]['MinInternaltransferDAmt'];
            MaxInternaltransferDebitAmountVar = data[0]['MaxInternaltransferDAmt'];
            AverageInternaltransferDebitAmountVar = data[0]['AvgInternaltransferDAmt'];
            TotalInternaltransferDebitCountVar = data[0]['TotalInternaltransferDCnt'];

            Tot_TotalInternaltransferDebitAmount.innerHTML = TotalInternaltransferDebitAmountVar;
            Min_LowestInternaltransferDebitAmount.innerHTML = LowestInternaltransferDebitAmountVar;
            Max_MaxInternaltransferDebitAmount.innerHTML = MaxInternaltransferDebitAmountVar;
            Avg_AverageInternaltransferDebitAmount.innerHTML = AverageInternaltransferDebitAmountVar;
            Cnt_TotalInternaltransferDebitCount.innerHTML = TotalInternaltransferDebitCountVar;

            var Internaltransfer_Data = {
                "category": "Internal Transfer",
                "T_A_C": TotalInternaltransferCreditAmountVar,
                "L_A_C": LowestInternaltransferCreditAmountVar,
                "M_A_C": MaxInternaltransferCreditAmountVar,
                "A_A_C": AverageInternaltransferCreditAmountVar,
                "T_A_D": TotalInternaltransferDebitAmountVar,
                "L_A_D": LowestInternaltransferDebitAmountVar,
                "M_A_D": MaxInternaltransferDebitAmountVar,
                "A_A_D": AverageInternaltransferDebitAmountVar
            };

            var Internaltransfer_Data_Count = {
                "category": "Internal Transfer",
                "T_C_C": TotalInternaltransferCreditCountVar,
                "T_D_C": TotalInternaltransferDebitCountVar
            };

            /*For Withdrawal DEBIT */

            let TotalWithdrawalDebitAmountVar = 0;
            let LowestWithdrawalDebitAmountVar = 0;
            let MaxWithdrawalDebitAmountVar = 0;
            let AverageWithdrawalDebitAmountVar = 0;
            let TotalWithdrawalDebitCountVar = 0;

            TotalWithdrawalDebitAmountVar = data[0]['TotalWithdrawalDAmt'];
            LowestWithdrawalDebitAmountVar = data[0]['MinWithdrawalDAmt'];
            MaxWithdrawalDebitAmountVar = data[0]['MaxWithdrawalDAmt'];
            AverageWithdrawalDebitAmountVar = data[0]['AvgWithdrawalDAmt'];
            TotalWithdrawalDebitCountVar = data[0]['TotalWithdrawalDCnt'];

            Tot_TotalWithdrawalDebitAmount.innerHTML = TotalWithdrawalDebitAmountVar;
            Min_LowestWithdrawalDebitAmount.innerHTML = LowestWithdrawalDebitAmountVar;
            Max_MaxWithdrawalDebitAmount.innerHTML = MaxWithdrawalDebitAmountVar;
            Avg_AverageWithdrawalDebitAmount.innerHTML = AverageWithdrawalDebitAmountVar;
            Cnt_TotalWithdrawalDebitCount.innerHTML = TotalWithdrawalDebitCountVar;

            var Withdrawal_Data = {
                "category": "Withdrawal",
                "T_A_D": TotalWithdrawalDebitAmountVar,
                "L_A_D": LowestWithdrawalDebitAmountVar,
                "M_A_D": MaxWithdrawalDebitAmountVar,
                "A_A_D": AverageWithdrawalDebitAmountVar
            };

            var Withdrawal_Data_Count = {
                "category": "Withdrawal",
                "T_D_C": TotalWithdrawalDebitCountVar
            };



            ///*For Fees DEBIT */

            //let TotalFeesDebitAmountVar = 0;
            //let LowestFeesDebitAmountVar = 0;
            //let MaxFeesDebitAmountVar = 0;
            //let AverageFeesDebitAmountVar = 0;
            //let TotalFeesDebitCountVar = 0;

            //TotalFeesDebitAmountVar = data[0]['TotalFeesDAmt'];
            //LowestFeesDebitAmountVar = data[0]['MinFeesDAmt'];
            //MaxFeesDebitAmountVar = data[0]['MaxFeesDAmt'];
            //AverageFeesDebitAmountVar = data[0]['AvgFeesDAmt'];
            //TotalFeesDebitCountVar = data[0]['TotalFeesDCnt'];

            //Tot_TotalFeesDebitAmount.innerHTML = TotalFeesDebitAmountVar;
            //Min_LowestFeesDebitAmount.innerHTML = LowestFeesDebitAmountVar;
            //Max_MaxFeesDebitAmount.innerHTML = MaxFeesDebitAmountVar;
            //Avg_AverageFeesDebitAmount.innerHTML = AverageFeesDebitAmountVar;
            //Cnt_TotalFeesDebitCount.innerHTML = TotalFeesDebitCountVar;

            //var Fees_Data = {
            //    "category": "Fees",
            //    "T_A_D": TotalFeesDebitAmountVar,
            //    "L_A_D": LowestFeesDebitAmountVar,
            //    "M_A_D": MaxFeesDebitAmountVar,
            //    "A_A_D": AverageFeesDebitAmountVar
            //};

            //var Fees_Data_Count = {
            //    "category": "Fees",
            //    "T_D_C": TotalFeesDebitCountVar
            //};

            ChartData.push(Cash_Data);
            ChartData.push(Wire_Data);
            ChartData.push(Check_Data);
            ChartData.push(Misc_Data);
            ChartData.push(Internaltransfer_Data);
            ChartData.push(Withdrawal_Data);
            //ChartData.push(Fees_Data);

            ChartDataCount.push(Cash_Data_Count);
            ChartDataCount.push(Wire_Data_Count);
            ChartDataCount.push(Check_Data_Count);
            ChartDataCount.push(Misc_Data_Count);
            ChartDataCount.push(Internaltransfer_Data_Count);
            ChartDataCount.push(Withdrawal_Data_Count);
            //ChartDataCount.push(Fees_Data_Count);

        }
    });

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
            am4core.useTheme(am4themes_animated);
            am4core.addLicense("ch-custom-attribution");
            var chart = am4core.create("IndustrySegmentChart", am4charts.XYChart3D);
            var title = chart.titles.create();
            if (type.toUpperCase() == "INDIVIDUAL".toUpperCase()) {
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
    });
}

function draw_Stacked_Col_Chart() {

    am4core.useTheme(am4themes_animated);
    am4core.addLicense("ch-custom-attribution");
    var chart = am4core.create("chartdiv", am4charts.XYChart3D);
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

function draw_Stacked_Col_Chart_Count() {

    am4core.useTheme(am4themes_animated);
    am4core.addLicense("ch-custom-attribution");
    var chart = am4core.create("chartCountdiv", am4charts.XYChart3D);
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

var selectedMonthKey = "";
var selectedSegmentType = "";
var selectedSegmentId = "";
var selectedFeature = "";
makeSpinner("/SegmentationCharts/MonthKeys", "month-key-spinner", "monthKey");

function onChangeMonthKey(e) {
    selectedMonthKey = e.value;
    makeSpinner("/SegmentationCharts/SegTypesPerKey?monthkey=" + selectedMonthKey, "segment-type", "segmentType");

}

function onChangeSegmentType(e) {
    selectedSegmentType = e.value;
    makeSpinnerSegmentId("/SegmentationCharts/Segs?monthkey=" + selectedMonthKey + "&Type=" + selectedSegmentType, "segment-id", "segmentId");

}

function onChangeSegmentId(e) {
    selectedSegmentId = e.value;
   document.getElementById("TabsID").style.display = "block";
    
    renderTabsCounter();
    
    $("#chartdiv").show()
    $("#chartCountdiv").show()
    $("#IndustrySegmentChart").show()
    setTimeout(function () {
        draw_Stacked_Col_Chart();
        draw_Stacked_Col_Chart_Count();
        RenderDataForCharts();
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
function makeSpinner(url, divId, spinnerDefaultValue) {
    $.ajax({
        type: "GET",
        url: url,
        data: {
        },
        success: function (data) {
            queueList = data;
            var select = document.getElementById(divId);
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
function makeSpinnerSegmentId(url, divId, spinnerDefaultValue) {
    $.ajax({
        type: "GET",
        url: url,
        data: {
        },
        success: function (data) {
            queueList = data;
            console.log(data);
            var select = document.getElementById(divId);
            select.innerHTML = "";
            var fopt = document.createElement('option');
            fopt.value = spinnerDefaultValue;
            fopt.innerHTML = spinnerDefaultValue;
            select.appendChild(fopt);
            queueList.forEach(q => {
                var opt = document.createElement('option');
                opt.value = q.SegmentSorted;
                opt.innerHTML = q.SegmentSorted + " , " + q.SegmentDescription;
                select.appendChild(opt);
            })
        },

    });
}
$(window).resize(function () {
    kendo.resize($("div.k-chart[data-role='chart']"));
});
