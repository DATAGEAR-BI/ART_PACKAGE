var connection = new signalR.HubConnectionBuilder().withUrl("/AmlAnalysisHub").build();
connection.start().then(x => {
    console.log("connection started");
});
connection.on("RouteResult", (res) => {
    console.log(res);
    var grid = document.getElementById("grid");
    if (grid)
        $("#grid").data("kendoGrid").dataSource.read();
    if (res.isSucceed) {
        toastObj.icon = 'success';
        toastObj.text = "Route ended successfully";
        toastObj.heading = "Route Status";
        $.toast(toastObj);
    } else {
        toastObj.icon = 'error';
        toastObj.text = "Something Wrong Happend Check with support";
        toastObj.heading = "Route Status";
        $.toast(toastObj);
    }

})
connection.on("CloseResult", (res) => {
    console.log(res);
    var grid = document.getElementById("grid");
    if (grid)
        $("#grid").data("kendoGrid").dataSource.read();
    if (res.isSucceed) {
        toastObj.icon = 'success';
        toastObj.text = "Close ended successfully";
        toastObj.heading = "Close Status";
        $.toast(toastObj);
    } else {
        toastObj.icon = 'error';
        toastObj.text = "Something Wrong Happend Check with support";
        toastObj.heading = "Close Status";
        $.toast(toastObj);
    }

})