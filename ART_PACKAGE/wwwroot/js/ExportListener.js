var exportConnection = new signalR.HubConnectionBuilder().withUrl("/ExportHub").configureLogging(signalR.LogLevel.Warning).build();
exportConnection.start().then(x => {
    console.log("connection started");
});

exportConnection.on("csvErrorRecevied", async (batch) => {

    toastObj.icon = 'error';
    toastObj.text = "something wrong happend in batch number " + batch;
    toastObj.heading = "Export Status";
    $.toast(toastObj);

});


exportConnection.on("csvRecevied", async (file, fileName) => {
    // Assuming you have a byte array called 'byteArray' containing the bytes
    // You can also get the 'byteArray' from a server response, FileReader, or other sources.

    // Convert bytes to a Uint8Array (assuming the byteArray is Uint8Array)
    const uint8Array = atob(file);

    // Create a Blob from the Uint8Array data
    const csvBlob = new Blob([uint8Array], { type: 'text/csv' });

    // Create an object URL from the Blob
    const objectURL = URL.createObjectURL(csvBlob);

    // Now you can use the 'objectURL' to create a downloadable link or perform other operations
    // For example, creating a download link:
    const downloadLink = document.createElement('a');
    downloadLink.href = objectURL;
    downloadLink.download = fileName;
    downloadLink.click(); // Simulate a click on the link to trigger the download

    // Don't forget to revoke the object URL to free up memory after the download is initiated.
    URL.revokeObjectURL(objectURL);


})