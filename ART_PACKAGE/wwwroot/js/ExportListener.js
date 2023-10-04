import { keepAlive } from './HubUtils.js'
export var exportConnection = new signalR.HubConnectionBuilder().withUrl("/ExportHub").withAutomaticReconnect().build();
var keepAliveInterval;
export async function start() {
    try {
        await exportConnection.start();
        console.log("SignalR Connected.");
        keepAliveInterval = setInterval(() => keepAlive(exportConnection, "KeepAlive"), 60000);

    } catch (err) {
        console.log(err);
        clearInterval(keepAliveInterval);
        setTimeout(start, 5000);
    }
};

export const invokeExport = (para, controller, method, params) => exportConnection.invoke("Export", para, controller, method, params);
;

await start();

exportConnection.onreconnecting(err => {
    toastObj.icon = 'error';
    toastObj.text = `connection with server lost trying to reconnect this might cause losing some files`;
    toastObj.heading = "Export Status";
    $.toast(toastObj);
})

exportConnection.on("iAmAlive", () => {
    console.log("iam alive");
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
    toastObj.text = `something wrong happend in batch number ` + batch;
    toastObj.heading = "Export Status";
    $.toast(toastObj);

});

exportConnection.on("missedFilesRecived", async (files, reqId) => {
    console.log("tttttttttt", reqId, files);
    files.forEach(f => {
        console.log(f.fileName);
        downloadfile(f.file, f.fileName);

        toastObj.icon = 'success';
        toastObj.text = `export done for this file : ${ f.fileName }, check your downloads`;
        toastObj.heading = "Export Status";
        $.toast(toastObj);
    });
    exportConnection.invoke("ClearExportFolder", reqId);
    localStorage.removeItem(reqId);

});

exportConnection.on("FinishedExportFor", async (reqId, len) => {
    var recivedFiles = JSON.parse(localStorage.getItem(reqId));
    console.log(reqId, len, recivedFiles.length);
    if (len === recivedFiles.length) {
        console.log("clr");
        //exportConnection.invoke("ClearExportFolder", reqId);
    }

    else {
        var missedFiles = [];
        for (var j = 0; j <= len; j++) {

            if (!recivedFiles.includes(j)) {
                console.log(j + 1);
                missedFiles.push(j + 1);
            }

        }
        exportConnection.invoke("GetMissedFiles", reqId, missedFiles);
    }
});
exportConnection.on("csvRecevied", async (file, fileName, i, guid) => {
    console.log(file);
    var recivedFiles = JSON.parse(localStorage.getItem(guid));
    if (recivedFiles)
        localStorage.setItem(guid, JSON.stringify([...recivedFiles, i]));
    else
        localStorage.setItem(guid, JSON.stringify([i]));
    downloadfile(file, fileName);

    toastObj.icon = 'success';
    toastObj.text = `export done for this file : ${fileName}, check your downloads`;
    toastObj.heading = "Export Status";
    $.toast(toastObj);
})

function downloadfile(file, fileName) {
 
    const uint8Array = atob(file);

    var bytes = new Uint8Array(uint8Array.length);
    for (var i = 0; i < uint8Array.length; i++) {
        bytes[i] = uint8Array.charCodeAt(i);
    }
       
    const csvBlob = new Blob(["\ufeff", bytes], { type: 'text/csv; charset=utf-8' });
        const objectURL = URL.createObjectURL(csvBlob);

        const downloadLink = document.createElement('a');
        downloadLink.href = objectURL;
        downloadLink.download = fileName;
        downloadLink.click();
        URL.revokeObjectURL(objectURL);
}