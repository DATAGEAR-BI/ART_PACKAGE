console.log("T7T Elbatannia")
var dateData = [];


var statuses       = [];
var clients        = [];
var products       = [];
var ages           = [];
var modules = [];
getData().then(x => {






    var dateChart = document.getElementById("dgSupportdateChart");
    var ageChart = document.getElementById("dgSupportAge"    );
    var clientChart = document.getElementById("dgSupportClient" );
    var moduleChart = document.getElementById("dgSupportModule" );
    var productChart = document.getElementById("dgSupportProduct");
    var statusChart = document.getElementById("dgSupportStatus");
    dateChart.setData(dateData);
    dateChart.onSeriesChanged = (e) => {
        ageChart.setdata(ages.filter(x => x.year == e.year));
        clientChart.setdata(clients.filter(x => x.year == e.year));
        moduleChart.setdata(modules.filter(x => x.year == e.year));
        productChart.setdata(products.filter(x => x.year == e.year));
        statusChart.setdata(statuses.filter(x => x.year == e.year));
    }
})


async function getData() {
    var data = await (await fetch("/home/GetDGSupportChartsData")).json();
    dateData = data.dates;
    statuses = data.statuses;
    clients  = data.clients;
    products = data.products;
    ages     = data.ages;
    modules  = data.modules;


}








