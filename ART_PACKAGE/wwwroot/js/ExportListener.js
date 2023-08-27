var exportConnection = new signalR.HubConnectionBuilder().withUrl("/ExportHub").build();
exportConnection.start().then(x => {
    console.log("connection started");
});
var toastObj = {
    text: "", // Text that is to be shown in the toast
    heading: '', // Optional heading to be shown on the toast
    icon: '', // Type of toast icon
    showHideTransition: 'slide', // fade, slide or plain
    allowToastClose: true, // Boolean value true or false
    hideAfter: false, // false to make it sticky or number representing the miliseconds as time after which toast needs to be hidden
    stack: 5, // false if there should be only one toast at a time or a number representing the maximum number of toasts to be shown at a time
    position: 'bottom-center', // bottom-left or bottom-right or bottom-center or top-left or top-right or top-center or mid-center or an object representing the left, right, top, bottom values
    textAlign: 'left',  // Text alignment i.e. left, right or center
    loader: true,  // Whether to show loader or not. True by default
    loaderBg: '#9EC600',  // Background color of the toast loader
};
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

    toastObj.icon = 'success';
    toastObj.text = `export done for this file : ${fileName}, check your downloads`;
    toastObj.heading = "Export Status";
    $.toast(toastObj);
})