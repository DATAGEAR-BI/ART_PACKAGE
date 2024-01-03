import { URLS } from "./URLConsts.js"
var monthKeySelect = document.getElementById('MonthKey');
var partyTypeSelect = document.getElementById('PartyTypeDesc');
var segmentSelect = document.getElementById('Segment');
var grid = document.getElementById("outliers");
var chart1 = document.getElementById("ch1");
var chart2 = document.getElementById("ch2");
loadMonthKies().then(x => console.log('done'));
document.getElementById('MonthKey').onchange = async (e) => await onChangeMonthKey(e);
document.getElementById('PartyTypeDesc').onchange = async (e) => await onChangeSegmentType(e);
document.getElementById('Segment').onchange = async (e) => await onChangeSegment(e);
async function loadMonthKies() {
    await makeDropDown("/AllSegmentsOutliersNew/GetMonthKies", monthKeySelect);

}
async function makeDropDown(url, dropdown) {
    var items = await (await fetch(url)).json();

    var opts = [];
    items.forEach(q => {
        var opt = document.createElement('option');
        opt.value = q;
        opt.innerHTML = q;
        opts.push(opt)
    })
    dropdown.update([document.createElement('option'), ...opts]);
}

async function onChangeMonthKey(e) {
    var selectedMonthKey = e.target.value;
    await makeDropDown(`/AllSegmentsOutliersNew/SegTypesPerKey/${selectedMonthKey}`, partyTypeSelect);

}
async function onChangeSegmentType(e) {
    var selectedMonthKey = document.getElementById('MonthKey').value.value;
    var selectedType = e.target.value;
    var partyDescDropDown = document.getElementById('Segment');
    await makeDropDown(`/AllSegmentsOutliersNew/Segment/${selectedMonthKey}/${selectedType}`, partyDescDropDown);

}
async function onChangeSegment(e) {
    var selectedMonthKey = document.getElementById('MonthKey').value.value;
    var selectedSegmentType = document.getElementById('PartyTypeDesc').value.value;
    var selectedSegment = e.target.value;
    var baseUrl = URLS.AllSegmentsOutliersNew.split("?")[0];
    grid.url = baseUrl + `?MonthKey=${selectedMonthKey}&PartyTypeDesc=${selectedSegmentType}&Segment=${selectedSegment}`


    $(grid.gridDiv).data("kendoGrid").dataSource.read();
    var ch1res = fetch(`/AllSegmentsOutliersNew/GetSegmentOutliersChartData?MonthKey=${selectedMonthKey}&PartyTypeDesc=${selectedSegmentType}&Segment=${selectedSegment}`);
    var ch2res = fetch(`/AllSegmentsOutliersNew/GetSegentCustomersChartData?MonthKey=${selectedMonthKey}&PartyTypeDesc=${selectedSegmentType}&Segment=${selectedSegment}`);

    var res = await Promise.all([ch1res, ch2res]);

    if (res[0].ok) {
        chart1.setdata(await res[0].json());
        chart1.onSeriesDbClick = (e) => console.log(e);
    }

    if (res[1].ok)
        chart2.setdata(await res[1].json());
}