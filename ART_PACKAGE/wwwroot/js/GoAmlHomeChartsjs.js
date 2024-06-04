console.log("T7T Elbatannia")
var dateData = [];
var typeData = [];
var statusData = [];
getData().then(x => {






    var dateChart = document.getElementById("goAmldateChart");
    var typeChart = document.getElementById("goAmltype");
    dateChart.setData(dateData);
    dateChart.onSeriesChanged = (e) => {
        typeChart.setdata(typeData.filter(x => x.year == e.year));
    }
})


async function getData() {
    var data = await (await fetch("/home/GetGOAmlChartsData")).json();
    dateData = data.dates;
    typeData = data.types;
}








