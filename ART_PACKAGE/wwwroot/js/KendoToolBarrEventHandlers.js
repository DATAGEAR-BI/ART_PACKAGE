var toastObj = {
    text: "", // Text that is to be shown in the toast
    heading: '', // Optional heading to be shown on the toast
    icon: '', // Type of toast icon
    showHideTransition: 'slide', // fade, slide or plain
    allowToastClose: true, // Boolean value true or false
    hideAfter: 3000, // false to make it sticky or number representing the miliseconds as time after which toast needs to be hidden
    stack: 5, // false if there should be only one toast at a time or a number representing the maximum number of toasts to be shown at a time
    position: 'bottom-center', // bottom-left or bottom-right or bottom-center or top-left or top-right or top-center or mid-center or an object representing the left, right, top, bottom values
    textAlign: 'left',  // Text alignment i.e. left, right or center
    loader: true,  // Whether to show loader or not. True by default
    loaderBg: '#9EC600',  // Background color of the toast loader
};
var chngeRowColor = (dataItem, row, colormapinng) => {

    Object.keys(colormapinng).forEach(key => {
        if (colormapinng[key](dataItem)) {

            row.addClass(key);
        }
    })




}
export const Handlers = {
    csvExport: async (e, controller, url) => {
        kendo.ui.progress($('#grid'), true);
        var id = document.getElementById("script").dataset.id;
        var ds = $("#grid").data("kendoGrid");
        var selectedrecords = [];

        var all = true;
        if (selectedrecords && [...selectedrecords].length != 0)
            all = false
        var filters = ds.dataSource.filter();
        var total = ds.dataSource.total();
        var para = {}
        if (id) {
            para.Id = id;
        }
        para.Take = total;
        para.Skip = 0;
        para.Filter = filters;
        var isMyreports = window.location.href.toLowerCase().includes('myreports');
        var res;
        if (isMyreports) {
            res = await fetch(`/${controller}/ExportMyReports`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json"
                },
                body: JSON.stringify({ Req: para, All: all, SelectedIdz: selectedrecords })
            });
        } else {
            res = await fetch(`/${controller}/Export`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json"
                },
                body: JSON.stringify({ Req: para, All: all, SelectedIdz: selectedrecords })
            });
        }
        var blob = await res.blob();
        var a = document.createElement("a");
        var dateNow = new Date().toLocaleString();
        var userId;
        //userId = (await (await fetch('https://clonesasweb.hqdomain.com/SASComplianceSolutionsMid/rest/users/current?applicationNames=aml&relationships=applicationCapabilities,queues')).json()).userId;
        var fileName = "";
        if (userId)
            fileName = `${controller}_${userId}_${dateNow}.csv`;
        else
            fileName = `${controller}_${dateNow}.csv`;

        a.setAttribute("download", fileName);
        a.href = window.URL.createObjectURL(blob);
        a.click();
        kendo.ui.progress($('#grid'), false);
    },
    csvExportForStored: async (e, controller) => {
        kendo.ui.progress($('#grid'), true);
        var id = document.getElementById("script").dataset.id;
        var ds = $("#grid").data("kendoGrid");
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
        var filters = ds.dataSource.filter();
        var total = ds.dataSource.total();
        var para = {}
        if (id) {
            para.Id = id;
        }
        para.Take = total;
        para.Skip = 0;
        para.Filter = filters;
        var res = await fetch(`/${controller}/Export`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            },
            body: JSON.stringify({ req: para, procFilters: exRules })
        });
        var blob = await res.blob();
        var a = document.createElement("a");
        var dateNow = new Date().toLocaleString();
        var userId;
        //userId = (await (await fetch('https://clonesasweb.hqdomain.com/SASComplianceSolutionsMid/rest/users/current?applicationNames=aml&relationships=applicationCapabilities,queues')).json()).userId;
        var fileName = "";
        if (userId)
            fileName = `${controller}_${userId}_${dateNow}.csv`;
        else
            fileName = `${controller}_${dateNow}.csv`;

        a.setAttribute("download", fileName);
        a.href = window.URL.createObjectURL(blob);
        a.click();
        kendo.ui.progress($('#grid'), false);
    }, clrfil: (e) => {
        var ds = $("#grid").data("kendoGrid");
        var multiSelects = document.querySelectorAll("[data-role=multiselect]");
        [...multiSelects].forEach(x => {
            $(x).data("kendoMultiSelect").value(null);
        });
        ds.dataSource.filter(null);
    },


    clientPdExport: async (e, controller) => {
        kendo.ui.progress($('#grid'), true);
        var ds = $("#grid").data("kendoGrid");
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
                    res = await fetch(`/${controller}/ExportPdf`, {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json",
                            "Accept": "application/json"
                        },
                        body: JSON.stringify(para)
                    });
                }
            
                //const contentDispositionHeader = res.headers.get('Content-Disposition');

                //const filename = contentDispositionHeader.split(";")[1].trim().split("=")[1].split(".")[0];

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
        kendo.ui.progress($('#grid'), false);




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



    sh_filters: (e) => {
        $('#filtersCollapse').collapse("toggle")
    },
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


            kendo.ui.progress($('#grid'), true);
            var selectedidz = await Select("/AML_ANALYSIS/GetData", "PartyNumber");

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
                var res = await fetch("/AML_ANALYSIS/Close", {
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
                var resText = await res.json();
                toastObj.text = resText;
                toastObj.heading = "Close Status";
                $.toast(toastObj);
                comment.value = "";

                $("#closeModal").modal("hide");
                $("#grid").data("kendoGrid").refresh();
            }

            kendo.ui.progress($('#grid'), false);

        },
        routeAlerts: async (e) => {


            kendo.ui.progress($('#grid'), true);
            var selectedidz = await Select("/AML_ANALYSIS/GetData", "PartyNumber");

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




            queues.forEach(x => {
                var opt = document.createElement("option");
                opt.value = x;
                opt.innerText = x;
                queueSelect.append(opt);
            });
            $('#queueSelect').selectpicker('refresh');
            var queueUsers = await (await fetch("/AML_ANALYSIS/GetQueuesUsers", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json"
                },
                body: JSON.stringify("")
            })).json();

            [...queueUsers].forEach(x => {
                var opt = document.createElement("option");
                opt.value = x;
                opt.innerText = x;
                users.append(opt);
            });
            $('#userSelect').selectpicker('refresh');


            document.getElementById("selcted-Route-div").innerText = `You Selected ${selectedidz.length} Entities`;

            $("#RouteModal").modal("show");


            queueSelect.onchange = async (e) => {

                var queueUsers = await (await fetch("/AML_ANALYSIS/GetQueuesUsers", {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                        "Accept": "application/json"
                    },
                    body: JSON.stringify(e.target.value)
                })).json();
                users.innerHTML = "";
                var opt = document.createElement("option");
                opt.value = "";
                opt.innerText = "Select An User";
                users.append(opt);
                queueUsers.forEach(x => {
                    var opt = document.createElement("option");
                    opt.value = x;
                    opt.innerText = x;
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

                var res = await fetch("/AML_ANALYSIS/Route", {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                        "Accept": "application/json"
                    },
                    body: JSON.stringify(para)
                })
                if (res.ok) {

                    toastObj.icon = 'info';

                }
                else {

                    toastObj.icon = 'error';

                }
                var resText = await res.json();
                toastObj.text = resText;
                toastObj.heading = "Route Status";
                $.toast(toastObj);


                comment.value = "";

                $("#closeModal").modal("hide");
            }
            kendo.ui.progress($('#grid'), false);

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
                            comment.value = "";

                            $("#closeAllModal").modal("hide");
                            $("#grid").data("kendoGrid").refresh();
                        },
                        cancel: function () {

                        }
                    }
                });


            }
        }
    },
    Aml_AnalysisRules: {
        testRules: async (e) => {
            kendo.ui.progress($('#grid'), true);
            var selectedidz = await Select("/AML_ANALYSIS/GetRulesData", "Id")
            if (!selectedidz || [...selectedidz].length == 0) {
                toastObj.icon = 'error';
                toastObj.text = "there is no rules selected";
                toastObj.heading = "Test Rules Status";
                $.toast(toastObj);
                kendo.ui.progress($('#grid'), false);
                return;
            }
            var res = await fetch("/AML_ANALYSIS/TestRules", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json"
                },
                body: JSON.stringify([...selectedidz])
            });
            if (res.ok) {
                $('#testRulesGrid').empty();
                $("#testRulesGrid").kendoGrid({
                    dataSource: {
                        type: "api",
                        transport: {
                            read: async (options) => {
                                var data = await (res).json();

                                options.success(data);
                            }
                        },
                        schema: {
                            model: {
                                fields: {
                                    Id: { type: "number" },
                                    AlertedEntities: { type: "number" },
                                    Alerts: { type: "number" }
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
                        { field: "Id", title: "Rule ID", width: 80 },
                        { field: "AlertedEntities", width: 80, title: "Number Of Matched Enities" },
                        { field: "Alerts", title: "Number Of Matched Alerts", width: 80 },
                    ]

                });

                $("#TestModel").modal("show");

            } else {
                toastObj.icon = 'error';
                toastObj.text = await (res).json();
                toastObj.heading = "Test Rules Status";
                $.toast(toastObj);
            }
            kendo.ui.progress($('#grid'), false);


            document.getElementById("ApplyBtn").onclick = async () => {
                $.confirm({
                    theme: 'supervan',
                    title: 'Confirm Please!',
                    content: 'You are about to Apply This Rules, Are You Sure ?',
                    buttons: {
                        confirm: async function () {

                            var para = [...selectedidz]
                            var res = await fetch("/AML_ANALYSIS/Apply", {
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
                            var resText = await res.json();
                            toastObj.text = resText;
                            toastObj.heading = "Apply Rules Status";
                            $.toast(toastObj);


                            $("#TestModel").modal("hide");
                            kendo.ui.progress($('#grid'), false);
                        },
                        cancel: function () {
                            $("#TestModel").modal("hide");
                            kendo.ui.progress($('#grid'), false);
                        }
                    }
                });
            }


        },
        crtrule: (e) => {
            $('#collapseDiv').collapse("toggle")
        }

    }
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
async function Select(url, idcolumn) {
    var idz = [];
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
        var temp = await (await fetch(url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            },
            body: JSON.stringify(para)
        })).json()


        idz = temp.data.map(x => x[idcolumn]);

        return idz;

    } else {
        var idz = Object.values(JSON.parse(localStorage.getItem("selectedidz"))).flat().map(x => x[idcolumn]);




        return idz;


    }




}



