
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

export const Handlers = {
    AmlAnalysis: {
        closeAlerts: async (e,grid) => {
            
            let selectedidz = Object.values( grid.selectedRows).flat().map(x => x.PartyNumber);

            if ([...selectedidz].length == 0) {
                toastObj.text = "please select at least one record";
                toastObj.icon = "warning";
                toastObj.heading = "Close Status";
                $.toast(toastObj);
                kendo.ui.progress($(grid.gridDiv), false);
                return;
            }


            document.getElementById("number_of_entities_to_close").innerText = `You are about to close alerts for ${selectedidz.length} ${selectedidz.length == 1 ? "entity" : "entities"}`
            $("#closeModal").modal("show");
            var closeBtn = document.getElementById("closeBtn");
            var comment = document.getElementById("comment");
            var errorspan = document.getElementById("comment-validation")
            comment.onkeyup = () => {
                if(!comment.value || comment.value == "")
                    errorspan.hidden = false;
                else
                    errorspan.hidden = true;
            }
            errorspan.hidden = true;
            closeBtn.onclick = async (e) => {
                
                if (!comment.value || comment.value == "") {
                    errorspan.hidden = false;
                    return;
                }
                
                var para = {
                    Entities: selectedidz.map(x => x.toString()),
                    Comment: comment.value,
                    Desc: document.getElementById("closeDesc").value.value,
                }
                
                try {
                    let res = await fetch("/AmlAnalysis/CloseAlerts", {
                        method: "PUT",
                        headers: {
                            "Content-Type": "application/json",
                            "Accept": "application/json"
                        },
                        body: JSON.stringify(para)
                    });
                    if(res.ok){
                        $(grid.gridDiv).data('kendoGrid').dataSource.read();
                        $(grid.gridDiv).data('kendoGrid').refresh();
                        $("#closeModal").modal("hide");
                    }
                        
                    else {
                        toastObj.text = "something went wrong";
                        toastObj.icon = "error";
                        toastObj.heading = "Close Status";
                        $.toast(toastObj);
                    }
                   
                }
                catch (e) {
                    toastObj.text = "something went wrong";
                    toastObj.icon = "error";
                    toastObj.heading = "Close Status";
                    $.toast(toastObj);
                }
                
               

            }
        },
        routeAlerts: async (e,grid) => {
            let selectedidz = Object.values( grid.selectedRows).flat().map(x => x.PartyNumber);
            document.getElementById("number_of_entities_to_route").innerText = `You are about to route ${selectedidz.length} ${selectedidz.length == 1 ? "entity" : "entities"}`

            if ([...selectedidz].length == 0) {
                toastObj.text = "please select at least one record";
                toastObj.icon = "warning";
                toastObj.heading = "Route Status";
                $.toast(toastObj);
                kendo.ui.progress($(grid.gridDiv), false);
                return;
            }
        
            $("#routeModal").modal("show");

            let queueS = document.getElementById("queue");
            let userS = document.getElementById("user");
            try {
                let res = await fetch("/AmlAnalysis/GetQueues", {
                    method: "GET",
                    headers: {
                        "Content-Type": "application/json",
                        "Accept": "application/json"
                    }
                });
                
                let queues = await res.json();
                let qOpts = queues.map(q =>  {
                    let opt = document.createElement("option");
                    opt.value = q.value;
                    opt.innerText = q.text;
                    return opt
                });
                let allOpt = document.createElement("option");
                allOpt.value = "all";
                queueS.update([allOpt,...qOpts]);
                await update_users("all");
                async function update_users(queue) {
                    res = await fetch("/AmlAnalysis/GetQeueUsers/"+queue, {
                        method: "GET",
                        headers: {
                            "Content-Type": "application/json",
                            "Accept": "application/json"
                        },
                    });
                    let users = await res.json();

                    let quOpts = users.map(q =>  {
                        let opt = document.createElement("option");
                        opt.value = q.value;
                        opt.innerText = q.text;
                        return opt
                    });
                    userS.update([document.createElement("option"),...quOpts]);

                }
                

                queueS.onchange = async (e) => {
                    let queue = queueS.value.value;
                    await update_users(queue);
                }

                let routeBtn = document.getElementById("routeBtn");
                let comment = document.getElementById("routecomment");
                let errorspan = document.getElementById("comment-validation-route");
                comment.onkeyup = () => {
                    if(!comment.value || comment.value == "")
                    {
                        errorspan.innerText = "you must enter a comment";
                        errorspan.hidden = false;
                    }
                    else
                        errorspan.hidden = true;
                }



                routeBtn.onclick = async (e) => {

             
                    if ((queueS.value.value == "all") && (!userS.value.value)) {
                        errorspan.innerText = "You must select user, queue or both";
                        errorspan.hidden = false;
                        return;
                    }

                    if (!comment.value || comment.value == "") {

                        errorspan.innerText = "you must enter a comment";
                        errorspan.hidden = false;
                        return;
                    }
                    errorspan.hidden = true;
                    let para = {
                        Entities: selectedidz.map(x => x.toString()),
                        Comment: comment.value,
                        OwnerId: userS.value.value,
                        QueueCode: queueS.value.value
                    }

                    let res = await fetch("/AmlAnalysis/RouteAlerts/", {
                        method: "PUT",
                        headers: {
                            "Content-Type": "application/json",
                            "Accept": "application/json"
                        },
                        body: JSON.stringify(para)
                    });

                    if(res.ok){
                        $("#routeModal").modal("hide");
                    }
                    else {
                        toastObj.text = "somthing wrong happend please try again later";
                        toastObj.icon = "error";
                        toastObj.heading = "Route Status";
                        $.toast(toastObj);
                    }
                }
                
                
                
                
                
            }catch (err){
                console.error(err)
                toastObj.text = "somthing wrong happend please try again later";
                toastObj.icon = "error";
                toastObj.heading = "Route Status";
                $.toast(toastObj);
                kendo.ui.progress($(grid.gridDiv), false);
                return;
            }
            
           
          
         

        },
        CloseAll: async (e,grid) => {
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
    autorules: {
        testRules: async (e,grid) => {
            
            let selectedidz = Object.values( grid.selectedRows).flat().map(x => x.Id);
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
                                            id: {type: "number"},
                                            alertedEntities: {type: "number"},
                                            alerts: {type: "number"}
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
                            scrollable: {virtual: true},


                            columns: [
                                {field: "id", title: "Rule ID", width: 80},
                                {field: "alertedEntities", width: 80, title: "Number Of Matched Enities"},
                                {field: "alerts", title: "Number Of Matched Alerts", width: 80},
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
                            showCancelButton : true,
                            confirmButtonText: 'Cool',
                            cancelButtonText : "Not Cool",
                            confirmButtonColor: "#4f0769",
                            showLoaderOnConfirm : true,
                            preConfirm : async () => {

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



