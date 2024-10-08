﻿
import { invokeExport, start, exportConnection } from '../ExportListener.js'
var chngeRowColor = (dataItem, row, colormapinng) => {

    Object.keys(colormapinng).forEach(key => {
        if (colormapinng[key](dataItem)) {

            row.addClass(key);
        }
    })




}

function getQueryParameters(urlString) {
    const searchParams = new URL("http://test.com" + urlString).searchParams;
    return [...searchParams.values()];
}
export function generateGUID() {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000)
            .toString(16)
            .substring(1);
    }
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
        s4() + '-' + s4() + s4() + s4();
}
export var currentPDFReportId = '';

export const Handlers = {
    AlertSearch: {
        test1: (e) => {

            var isAllSelected = localStorage.getItem("isAllSelected");
            var ds = $("#grid").data("kendoGrid");
            if (isAllSelected !== 'false') {


                var id = document.getElementById("script").dataset.id;

                var filters = ds.dataSource.filter();
                var total = ds.dataSource.total();
                var para = {}
                if (id) {
                    para.Id = id;
                }
                para.Take = total;
                para.Skip = 0;
                para.Filter = filters;
                fetch("/report/GetGridData/", {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                        "Accept": "application/json"
                    },
                    body: JSON.stringify(para)
                }).then(d => d.json()).then(x => console.log(x.data.map(x => x.alert_id)));

            } else {
                var selected = ds.select();
                console.log([...selected]);

                var idz = [...selected].map(x => {
                    var dataItem = ds.dataItem(x);
                    return dataItem.alert_id;
                })

                console.log(idz);


            }




        },
        clrfil: (e) => {
            var ds = $("#grid").data("kendoGrid");
            ds.dataSource.filter(null);
        }
    },
    Aml_Analysis: {
        closeAlerts: async (e) => {

            var selectedidz = await Select("PartyNumber");

            if ([...selectedidz].length == 0) {
                toastObj.text = "please select at least one record";
                toastObj.icon = "warning";
                toastObj.heading = "Close Status";
                $.toast(toastObj);
                kendo.ui.progress($('#grid'), false);
                return;
            }


            document.getElementById("selcted-div").innerText = `You Selected ${selectedidz.length} Entities`
            $("#closeModal").modal("show");
            var closeBtn = document.getElementById("closeBtn");

            closeBtn.onclick = async (e) => {
                var comment = document.getElementById("comment-box-close")
                var errorspan = document.getElementById("comment-span")
                if (!comment.value || comment.value == "") {

                    errorspan.innerText = "You must type a comment";
                    errorspan.hidden = false;
                    return;
                }
                errorspan.hidden = true;
                var para = {
                    Entities: selectedidz.map(x => x.toString()),
                    Comment: comment.value,
                    Desc: document.getElementById("close-desc").value,
                }
                var res = fetch("/AML_ANALYSIS/CloseAlerts", {
                    method: "PUT",
                    headers: {
                        "Content-Type": "application/json",
                        "Accept": "application/json"
                    },
                    body: JSON.stringify(para)
                }).then(x => {
                    comment.value = "";
                    localStorage.removeItem("selectedidz");
                    /* $("#grid").data("kendoGrid").dataSource.read();
                     $("#grid").data("kendoGrid").refresh();
                     toastObj.text = "Alert Closed Succesfully";
                     toastObj.icon = "message";
                     toastObj.heading = "Close Status";
                     $.toast(toastObj);*/
                });
                $("#closeModal").modal("hide");

            }
        },
        routeAlerts: async (e) => {
            var selectedidz = await Select("PartyNumber");

            if ([...selectedidz].length == 0) {
                toastObj.text = "please select at least one record";
                toastObj.icon = "warning";
                toastObj.heading = "Route Status";
                $.toast(toastObj);
                kendo.ui.progress($('#grid'), false);
                return;
            }

            var queues = await (await fetch("/AML_ANALYSIS/GetQueues", {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json"
                }
            })).json();
            var queueSelect = document.getElementById("queueSelect");
            var users = document.getElementById("userSelect");



            queueSelect.innerHTML = "";
            users.innerHTML = "";
            var usersOpt = document.createElement("option");
            usersOpt.value = "";
            usersOpt.innerText = "Select User";
            users.append(usersOpt);
            var queueSelectOpt = document.createElement("option");
            queueSelectOpt.value = "";
            queueSelectOpt.innerText = "Select Queue";
            queueSelect.append(queueSelectOpt);
            queues.forEach(x => {
                var opt = document.createElement("option");
                opt.value = x.value;
                opt.innerText = x.text;
                queueSelect.append(opt);
            });
            $('#queueSelect').selectpicker('refresh');
            var queueUsers = await (await fetch("/AML_ANALYSIS/GetQeueUsers/", {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json"
                },
                //body: JSON.stringify("")
            })).json();

            [...queueUsers].forEach(x => {
                var opt = document.createElement("option");
                opt.value = x.value;
                opt.innerText = x.text;
                users.append(opt);
            });
            $('#userSelect').selectpicker('refresh');


            document.getElementById("selcted-Route-div").innerText = `You Selected ${selectedidz.length} Entities`;

            $("#RouteModal").modal("show");


            queueSelect.onchange = async (e) => {

                var queueUsers = await (await fetch("/AML_ANALYSIS/GetQeueUsers/" + e.target.value, {
                    method: "GET",
                    headers: {
                        "Content-Type": "application/json",
                        "Accept": "application/json"
                    },
                    //body: JSON.stringify(e.target.value)
                })).json();
                users.innerHTML = "";
                var opt = document.createElement("option");
                opt.value = "";
                opt.innerText = "Select User";
                users.append(opt);
                queueUsers.forEach(x => {
                    var opt = document.createElement("option");
                    opt.value = x.value;
                    opt.innerText = x.text;
                    users.append(opt);
                });

                $('#userSelect').selectpicker('refresh');
            }

            var routeBtn = document.getElementById("modalRoutBtn");
            var comment = document.getElementById("comment-box-route");
            var errorspan = document.getElementById("comment-span-route");
            routeBtn.onclick = async (e) => {

                if (!comment.value || comment.value == "") {

                    errorspan.innerText = "You must type a comment";
                    errorspan.hidden = false;
                    return;
                }

                if ((!queueSelect.value || queueSelect.value == "") && (!users.value || users.value == "")) {
                    errorspan.innerText = "You must select user, queue or both";
                    errorspan.hidden = false;
                    return;
                }

                errorspan.hidden = true;
                var para = {
                    Entities: selectedidz.map(x => x.toString()),
                    Comment: comment.value,
                    OwnerId: users.value,
                    QueueCode: queueSelect.value

                }
                kendo.ui.progress($('#grid'), true);
                var res = fetch("/AML_ANALYSIS/RouteAlerts", {
                    method: "PUT",
                    headers: {
                        "Content-Type": "application/json",
                        "Accept": "application/json"
                    },
                    body: JSON.stringify(para)
                }).then(x => {
                    comment.value = "";
                    localStorage.removeItem("selectedidz");
                    /*  $("#grid").data("kendoGrid").refresh();
                      
                      toastObj.text = "Alert Routed Succesfully";
                      toastObj.icon = "message";
                      toastObj.heading = "Route Status";
                      $.toast(toastObj);*/
                    kendo.ui.progress($('#grid'), false);
                });

                $("#RouteModal").modal("hide");
            }

        },
        CloseAll: async (e) => {
            var Entities = await (await fetch("/AML_ANALYSIS/GetAllEntities", {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json"
                }
            })).json();
            document.getElementById("closeAll-div").innerText = `There is ${Entities.alertedEntities} Alerted Entities with ${Entities.alerts} Alert of ${Entities.totalEntities} Entities`;
            $("#closeAllModal").modal("show");
            var closeBtn = document.getElementById("Close-All");

            closeBtn.onclick = async (e) => {

                var comment = document.getElementById("comment-box-closeAll")
                var errorspan = document.getElementById("comment-span-close-all")
                if (!comment.value || comment.value == "") {

                    errorspan.innerText = "You must type a comment";
                    errorspan.hidden = false;
                    return;
                }
                errorspan.hidden = true;
                $.confirm({
                    theme: 'supervan',
                    title: 'Confirm Please!',
                    content: 'You are about to close all alerted Entities Are You Sure ?',
                    buttons: {
                        confirm: async function () {

                            var para = {
                                Entities: [...Entities.alertedentitiesNumbers].map(x => x.toString()),
                                Comment: comment.value,
                                Desc: document.getElementById("close-desc").value,
                            }
                            var res = await fetch("/AML_ANALYSIS/Close", {
                                method: "POST",
                                headers: {
                                    "Content-Type": "application/json",
                                    "Accept": "application/json"
                                },
                                body: JSON.stringify(para)
                            });
                            console, log(res);
                            if (res.ok) {

                                toastObj.icon = 'success';

                            }
                            else {

                                toastObj.icon = 'error';

                            }
                            var resText = await res.json();
                            toastObj.text = resText;
                            toastObj.heading = "Close Status";
                            $.toast(toastObj);
                            $("#grid").data("kendoGrid").dataSource.read();
                            comment.value = "";

                            $("#closeAllModal").modal("hide");
                            // $("#grid").data("kendoGrid").refresh();
                        },
                        cancel: function () {

                        }
                    }
                });


            }
        }
    },
    autorules: {
        testRules: async (e, grid) => {

            let selectedidz = Object.values(grid.selectedRows).flat().map(x => x.Id);
            if (!selectedidz || [...selectedidz].length == 0) {
                toastObj.icon = 'error';
                toastObj.text = "there is no rules selected";
                toastObj.heading = "Test Rules Status";
                $.toast(toastObj);
                return;
            }
            let queryParams = selectedidz.map(value => `${encodeURIComponent("rules")}=${encodeURIComponent(value)}`).join('&')

            try {
                let gridInitializationPromise = new Promise((resolve, reject) => {
                    $('#testRulesGrid').empty();
                    $("#testRulesGrid").kendoGrid({
                        dataSource: {
                            type: "api",
                            transport: {
                                read: async (options) => {
                                    try {
                                        let res = await fetch("/AutoRules/TestRules?" + queryParams, {
                                            method: "GET",
                                            headers: {
                                                "Content-Type": "application/json",
                                                "Accept": "application/json"
                                            }
                                        });
                                        let data = await (res).json();
                                        options.success(data);
                                    } catch (e) {
                                        reject(e);
                                    }
                                }
                            },
                            schema: {
                                model: {
                                    fields: {
                                        id: { type: "number" },
                                        alertedEntities: { type: "number" },
                                        alerts: { type: "number" }
                                    }
                                }
                            },
                            pageSize: 100,
                            serverPaging: false,
                            serverFiltering: false,
                            serverSorting: false
                        },
                        height: 400,
                        filterable: true,
                        sortable: true,
                        reorderable: true,
                        pageable: {
                            numeric: true,
                            previousNext: true
                        },
                        resizable: true,
                        scrollable: { virtual: true },


                        columns: [
                            { field: "id", title: "Rule ID", width: 80 },
                            { field: "alertedEntities", width: 80, title: "Number Of Matched Enities" },
                            { field: "alerts", title: "Number Of Matched Alerts", width: 80 },
                        ]

                    });
                    resolve();
                });
                await gridInitializationPromise;
                document.getElementById("ApplyBtn").onclick = async () => {
                    Swal.fire({
                        title: 'Confirm Please!',
                        text: 'You are about to Apply This Rules, Are You Sure ?',
                        icon: 'question',
                        showCancelButton: true,
                        confirmButtonText: 'Cool',
                        cancelButtonText: "Not Cool",
                        confirmButtonColor: "#4f0769",
                        showLoaderOnConfirm: true,
                        preConfirm: async () => {

                            let para = [...selectedidz]
                            var res = await fetch("/AutoRules/Apply", {
                                method: "POST",
                                headers: {
                                    "Content-Type": "application/json",
                                    "Accept": "application/json"
                                },
                                body: JSON.stringify(para)
                            });

                            if (res.ok) {

                                toastObj.icon = 'success';

                            }
                            else {

                                toastObj.icon = 'error';

                            }
                            let resText = await res.json();
                            toastObj.text = resText;
                            toastObj.heading = "Apply Rules Status";
                            $.toast(toastObj);


                        }
                    })
                }
                $("#testRules").modal("show");
            }
            catch (e) {
                toastObj.icon = 'error';
                toastObj.text = "something wrong happend"
                toastObj.heading = "Test Rules Status";
                $.toast(toastObj);
            }




        },
        crtrule: (e) => {
            $('#collapseExample').collapse("toggle");
        },

    },
    License: {
        addreplic: async (e , gridDiv) => {
            $("#addreplicModal").modal("show");
            var form = document.getElementById("licForm");
            form.onsubmit = async (e) => {
                e.preventDefault();
                let licFile = document.getElementById("fileupload").value[0];
                var licModule = document.getElementById("licModule").value.value;
                console.log(licFile,licModule);
                var data = new FormData()
                data.append('License', licFile)
                data.append('Module', licModule)
                var reqBody = {
                    Module: licModule,
                    License: licFile
                };
                var res = await fetch("/License/UploadLic", {
                    method: "POST",
                    body: data
                }).catch(err => console.log(err));

                if (res.ok) {
                    $("#addreplicModal").modal("hide");
                    $(gridDiv).data("kendoGrid").dataSource.read();
                    toastObj.text = "license has been uploaded";
                    toastObj.heading = "License Status";
                    toastObj.icon = 'success';

                    $.toast(toastObj);
                    //this line is important to clear all notifications on all clients
                    //connection is intialized in _loginPartial.cshtml
                    connection.invoke("ClearLiceMsg");

                }

                else {
                    
                    toastObj.text = "Something wrong happened";
                    toastObj.heading = "License Status";
                    toastObj.icon = 'error';
                    $.toast(toastObj);

                }

            }
        }
    },
    TaskSchedular: {
        addTask: () => {
            window.location = `/Tasks/AddTask`;
        }
    },
    Grid: {
        test: async (e, gridDiv) => {
            console.log("test");
        }
    },


    clientPdExport: async (e, controller, url, gridDiv, Request) => {
        var paramsArr = url.split("?");
        var params = "";
        if (paramsArr[1]) {
            params = paramsArr[1];
        }

       // kendo.ui.progress($("#"+gridDiv.id), true);
        var ds = $("#"+gridDiv.id).data("kendoGrid");
        var total = ds.dataSource.total();
        var take = 20000;
        var skip = 0;
        var id = gridDiv.id; //document.getElementById("script").dataset.id;

        var filters = ds.dataSource.filter();
        var groups = ds.dataSource.group();
        var promses = [];
        while (total > 0) {
            var promise = new Promise(async (resolve, reject) => {
                var para = {}
                if (id) {
                    para.Id = id;
                }
                para.Take = take;
                para.Skip = skip;
                para.Filter = filters;
                para.Group = groups;
                para.sort = ds.dataSource.sort();

                var isMyreports = window.location.href.toLowerCase().includes('myreports');
                var res;
                if (isMyreports) {
                    res = await fetch(`/${controller}/ExportPdfMyReports`, {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json",
                            "Accept": "application/json"
                        },
                        body: JSON.stringify(para)
                    });
                } else {
                    currentPDFReportId = generateGUID();
                    var exportUrl = params ? `/${controller}/ExportPdf/${gridDiv.id}?reportGUID=${currentPDFReportId}` : `/${controller}/ExportPdf/${gridDiv.id}?reportGUID=${currentPDFReportId}`;//`/${controller}/ExportPdf/${gridDiv.id}` : `/${controller}/ExportPdf/${gridDiv.id}`;
                    res = await fetch(exportUrl, {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json",
                            "Accept": "application/json"
                        },
                        body: JSON.stringify(Request)
                    });
                    console.log("res",res)
                }
                var r = await res.blob();
                resolve({
                    blob: r

                });
            });
            promses.push(promise);
            skip += take;
            total -= take;
        }

        var results = await Promise.all(promses);
        results.forEach((x, i) => {
            var a = document.createElement("a");
            var dateNow = new Date();

            a.setAttribute("download", controller + "_" + (i + 1) + "_" + dateNow + ".pdf");
            a.href = window.URL.createObjectURL(x.blob);
            a.click();
        });
        //kendo.ui.progress($("#"+gridDiv.id), false);




    },

    clientStoredPdExport: async (e, controller) => {
        kendo.ui.progress($('#grid'), true);
        var ds = $("#grid").data("kendoGrid");
        var id = document.getElementById("script").dataset.id;
        var exRules = [];
        var rules = $("#filters").queryBuilder('getRules');
        var g = [...rules.rules].reduce((group, product) => {
            const { id } = product;
            group[id] = !group[id] ? [] : group[id];
            group[id].push(product);
            return group;
        }, {});
        var arr = [];
        for (var prop in g) {
            arr.push(g[prop]);
        }
        if (arr.some(x => x.length > 1)) {
            console.log("error");
        } else {
            exRules = Array.prototype.concat.apply([], arr);
            exRules = [...exRules].map(x => {
                if (Array.isArray(x.value)) {
                    x.value = [...x.value].join(",");
                }
                return x;
            });
        }
        var total = ds.dataSource.total();
        var take = 20000;
        var skip = 0;
        var id = document.getElementById("script").dataset.id;

        var filters = ds.dataSource.filter();
        var promses = [];
        while (total > 0) {
            var promise = new Promise(async (resolve, reject) => {
                var para = {}
                if (id) {
                    para.Id = id;
                }
                para.Take = take;
                para.Skip = skip;
                para.Filter = filters;
                para.sort = ds.dataSource.sort();
                var res = await fetch(`/${controller}/ExportPdf`, {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                        "Accept": "application/json"
                    },
                    body: JSON.stringify({ req: para, procFilters: exRules })
                });

                console.log({ req: para, procFilters: exRules });
                var r = await res.blob();
                resolve(r);
            });
            promses.push(promise);
            skip += take;
            total -= take;
        }

        var results = await Promise.all(promses);
        results.forEach((x, i) => {
            console.log(i);
            var a = document.createElement("a");
            var dateNow = new Date().toLocaleDateString();

            a.setAttribute("download", controller + "_" + (i + 1) + "_" + dateNow + ".pdf");
            a.href = window.URL.createObjectURL(x);
            a.click();
        });
        kendo.ui.progress($('#grid'), false);




    },
}
export const dbClickHandlers = {
    EcmWorkflowProg: async (dataItem) => {
        kendo.ui.progress($('#grid'), true);
        console.log(dataItem.EcmReference);
        var commentData = await (await fetch(`/EcmWorkflowProg/GetEcmComments/${dataItem.EcmReference}`)).json();
        var title = document.getElementById("RiskTitle");
        var old_title = title.innerText;
        title.innerText = old_title.split(":")[0] + " : " + dataItem.EcmReference;
        var commentGrid = document.getElementById("partyRiskGrid");
        commentGrid.innerText = "";
        if (commentData && [...commentData].length > 0) {
            var table = document.createElement("table");
            table.className = "table";
            var thead = document.createElement("thead");
            var tr = document.createElement("tr");
            var headers = ["#", "Ecm Reference", "ECM Comment", "FTI Note", "Note Creation Time"]
            headers.forEach(x => {
                var th = document.createElement("th");
                th.setAttribute("scope", "col");
                th.innerText = x;
                tr.appendChild(th);
            });

            thead.appendChild(tr);
            var tbody = document.createElement("tbody");

            [...commentData].forEach((x, index) => {
                var tr = document.createElement("tr");

                var rowNumberTd = document.createElement("th");
                rowNumberTd.setAttribute("scope", "row");
                rowNumberTd.innerText = index + 1;

                var ecmReferenceTd = document.createElement("td");
                ecmReferenceTd.innerText = x.ecmReference;


                var commentTd = document.createElement("td");
                commentTd.innerText = x.comments;

                var noteTd = document.createElement("td");
                noteTd.innerText = x.note;

                var noteCreationTimeTd = document.createElement("td");
                noteCreationTimeTd.innerText = x.noteCreationTime;

                tr.appendChild(rowNumberTd);
                tr.appendChild(ecmReferenceTd);

                tr.appendChild(commentTd);
                tr.appendChild(noteTd);
                tr.appendChild(noteCreationTimeTd);

                tbody.appendChild(tr);
            });

            table.appendChild(thead);
            table.appendChild(tbody);

            commentGrid.appendChild(table);

        }
        else {
            var noCommentsDiv = document.createElement("div");
            noCommentsDiv.innerText = "There is no Comments Or Notes for the EcmReference:" + dataItem.EcmReference
            noCommentsDiv.className = "text-center";
            commentGrid.appendChild(noCommentsDiv);
        }


        $("#RiskModal").modal("show");


        kendo.ui.progress($('#grid'), false);

    },
    EcmAuditTrial: async (dataItem) => {
        kendo.ui.progress($('#grid'), true);
        console.log(dataItem.EcmReference);
        var commentData = await (await fetch(`/EcmAuditTrial/GetEcmComments/${dataItem.FtiReference}`)).json();
        var title = document.getElementById("RiskTitle");
        var old_title = title.innerText;
        title.innerText = old_title.split(":")[0] + " : " + dataItem.FtiReference;
        var commentGrid = document.getElementById("partyRiskGrid");
        commentGrid.innerText = "";
        if (commentData && [...commentData].length > 0) {
            var table = document.createElement("table");
            table.className = "table";
            var thead = document.createElement("thead");
            var tr = document.createElement("tr");
            var headers = ["#", "Fti Reference", "Note"]
            headers.forEach(x => {
                var th = document.createElement("th");
                th.setAttribute("scope", "col");
                th.innerText = x;
                tr.appendChild(th);
            });

            thead.appendChild(tr);
            var tbody = document.createElement("tbody");
            [...commentData].forEach((x, index) => {
                console.log(x);
                var tr = document.createElement("tr");

                var rowNumberTd = document.createElement("th");
                rowNumberTd.setAttribute("scope", "row");
                rowNumberTd.innerText = index + 1;

                var ecmReferenceTd = document.createElement("td");
                ecmReferenceTd.innerText = x.ftiref;


                var commentTd = document.createElement("td");
                commentTd.innerText = x.comment;



                tr.appendChild(rowNumberTd);
                tr.appendChild(ecmReferenceTd);

                tr.appendChild(commentTd);
                tbody.appendChild(tr);
            });
            table.appendChild(thead);
            table.appendChild(tbody);

            commentGrid.appendChild(table);
        }
        else {
            var noCommentsDiv = document.createElement("div");
            noCommentsDiv.innerText = "There is no Notes for the FtiReference:" + dataItem.FtiReference
            noCommentsDiv.className = "text-center";
            commentGrid.appendChild(noCommentsDiv);
        }

        $("#RiskModal").modal("show");


        kendo.ui.progress($('#grid'), false);

    },

    messagesDbHandler: async (item) => {
        kendo.ui.progress($('#grid'), true);
        var id = item.RequestUid;

        var messages = await (await fetch("/SanctionManualSearchDetails/GetMessageByReqUid/" + id)).json();

        var messagesDiv = document.getElementById("messages");
        $(messagesDiv).empty();
        $(messagesDiv).kendoGrid({
            dataSource: {
                data: [...messages],
                serverPaging: false,
                serverSorting: false,
                serverFiltering: false,
                pageSize: 31,

            },
            scrollable: false,
            sortable: true,
            pageable: true,
            columns: [{

                field: "message",
                title: "Message",
                width: "110px"

            }],
        });
        $("#messagesModal").modal("show");
        kendo.ui.progress($('#grid'), false);
    },
    Grid: async (item) => {
        console.log(item);
    }
}
export const changeRowColorHandlers = {
    SystemPerformance: (dataItem, row) => {
        //making each of class styles as a key for the object and the condion to add this class as the value to pass it for the function "chngeRowColor" to applay 
        //the class style based on the condition
        var colorMapping = {
            redRow: (x) => x.get("CaseStatus") == "Hit",
            greenRow: (x) => x.get("CaseStatus") == "NoHit",
            yellowRow: (x) => x.get("CaseStatus") == "Postponed",
        };

        chngeRowColor(dataItem, row, colorMapping);
    },
    UserPerformance: (dataItem, row) => {
        //making each of class styles as a key for the object and the condion to add this class as the value to pass it for the function "chngeRowColor" to applay 
        //the class style based on the condition
        var colorMapping = {
            redRow: (x) => x.get("CaseStatus") == "Hit",
            greenRow: (x) => x.get("CaseStatus") == "NoHit",
            yellowRow: (x) => x.get("CaseStatus") == "Postponed",
        };

        chngeRowColor(dataItem, row, colorMapping);
    },
    SanctionAllCasesDetails: (dataItem, row) => {
        //making each of class styles as a key for the object and the condion to add this class as the value to pass it for the function "chngeRowColor" to applay 
        //the class style based on the condition
        var colorMapping = {
            redRow: (x) => x.get("CaseStatus") == "Hit",
            greenRow: (x) => x.get("CaseStatus") == "NoHit",
            yellowRow: (x) => x.get("CaseStatus") == "Postponed",
            whiteRow: (x) => x.get("CaseStatus") == "New" || x.get("CaseStatus") == "Open"
        };

        chngeRowColor(dataItem, row, colorMapping);
    }
}
async function Select(idcolumn) {

    console.log(localStorage.getItem("selectedidz"))
    var idz = Object.values(JSON.parse(localStorage.getItem("selectedidz"))).flat().map(x => x[idcolumn]);


    console.log(idz);

    return idz;



}


