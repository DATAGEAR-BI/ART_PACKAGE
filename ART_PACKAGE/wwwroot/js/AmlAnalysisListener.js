var connection = new signalR.HubConnectionBuilder().withUrl("/AmlAnalysisHub").build();
connection.start().then(x => {
    console.log("connection started");
});

connection.on("CloseResult", (res) => {
    console.log(res);
})