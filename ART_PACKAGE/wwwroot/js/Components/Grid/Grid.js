import { URLS } from "../../URLConsts.js"
import { Templates } from "../../GridConfigration/ColumnsTemplate.js"
import { columnFilters } from "../../GridConfigration/ColumnsFilters.js"
import { Handlers, dbClickHandlers, changeRowColorHandlers } from "../../GridConfigration/GridEvents.js"
class Grid extends HTMLElement {
    url = "";
    total = 0;
    reportName = "";
    model = {};
    columns = {};
    toolbar = [];
    isDateField = [];
    isNumberField = [];
    isMultiSelect = [];
    gridDiv = document.createElement("div");
    isStoredProc = false;
    isAllSelected = false;
    selectedRows = {};
    defaultfilters = undefined;
    defaultAggs = undefined;
    defaultGroup = undefined;
    handlerkey = "";
    constructor() {
        super();
        if (Object.keys(this.dataset).includes("stored"))
            this.isStoredProc = true;

        if (this.dataset.handlerkey) {
            this.handlerkey = this.dataset.handlerkey;
        }
        if (this.dataset.defaultfilters) {
            this.defaultfilters = JSON.parse(this.dataset.defaultfilters);
        }
        if (this.dataset.aggregates) {
            this.defaultAggs = JSON.parse(this.dataset.aggregates);
        }
        if (this.dataset.defaultgroup) {
            this.defaultGroup = JSON.parse(this.dataset.defaultgroup);
        }
        this.ToggleSelectAll = this.ToggleSelectAll.bind(this);
        this.url = URLS[this.dataset.urlkey];
        this.gridDiv.id = this.id + "-Grid";
        this.appendChild(this.gridDiv);
        this.intializeColumns();


    }


    intializeColumns() {

        var para = { IsIntialize: true };

         fetch(this.url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Accept: "application/json",
            },
            body: JSON.stringify(para),
        })
        .then((d) => d.json())
        .then((d) => {
            this.total = d.total;
            this.reportName = d.reportname;
            //if (isHierarchy == "true") {
            //    groupList = d.grouplist;
            //    valList = d.vallist;
            //}
            this.model = this.generateModel(d.columns);
            this.columns = this.generateColumns(d.columns, d.containsActions, d.selectable);
            this.toolbar = this.genrateToolBar(d.toolbar, d.doesNotContainAllFun);


            //var title = document.getElementById("title");
            //var desc = document.getElementById("desc");

            //if (title && desc) {
            //    title.innerText = d.title;
            //    desc.innerText = d.desc;
            //}
            //$(".spinner").remove();
            this.generateGrid();

        })
        .catch(err => {
            console.error(err);
            toastObj.icon = 'error';
            toastObj.text = "something wrong happend while intializing the Grid please try again";
            toastObj.heading = "Grid Intialization Status";
            $.toast(toastObj);
            return;
        });
    }
    generateModel(columns) {
        var sampleDataItem = columns;

        var model = {};
        var fields = {};
        sampleDataItem.forEach((property) => {
            var propType = property.type;

            if (propType === "number") {
                fields[property.name] = {
                    type: "number",
                    validation: {
                        required: true,
                    },
                };
                if (model.id === property.name) {
                    fields[property.name].editable = false;
                    fields[property.name].validation.required = false;
                }
                this.isNumberField[property.name] = true;
            } else if (propType === "boolean") {
                fields[property.name] = {
                    type: "boolean",
                };
            } else if (propType === "date") {
                fields[property.name] = {
                    type: "date",
                    validation: {
                        required: true,
                    },
                };
                this.isDateField[property.name] = true;
            } else {
                fields[property.name] = {
                    validation: {
                        required: true,
                    },
                };
            }
        });
        model.fields = fields;

        return model;
    }

    generateColumns(columns, containsActions, selectable) {
        var columnNames = columns;
        var selectCol = {
            selectable: true,
            width: "50px",
        };
        var cols = columnNames.map((column) => {
            var filter = {};
            if (column.isDropDown) {
                filter = columnFilters.multiSelectFilter(column);
                this.isMultiSelect.push(column.name);
            }




            if (this.isDateField[column.name])
                filter = columnFilters.dateFilter();



            var template = column.template;
            var isCollection = column.isCollection;
            var hasTemplate = template && template != ""


            var columnF = column.filter;
            var hasFilters = columnF && columnF != ""

            if (hasFilters)
                filter = columnFilters[columnF]();

            if (!column.isNullable) {
                if (this.isNumberField[column.name]) {
                    filter["operators"] = {
                        number: {
                            eq: "is equal to",
                            neq: "is not equal to",
                            lt: "is less than",
                            lte: "is less than or equal",
                            gt: "is greater than",
                            gte: "is greater than or equal",
                        },
                    };
                }

                if (this.isDateField[column.name]) {
                    filter["operators"] = {
                        date: {
                            eq: "is equal to",
                            neq: "is not equal to",
                            lt: "is before",
                            lte: "is before or equal",
                            gt: "is after",
                            gte: "is after or equal",
                        },
                    };
                }
            }




            return {
                field: column.name,
                format: column.format ?
                    column.format :
                    this.isDateField[column.name]
                        ? "{0:dd/MM/yyyy HH:mm:ss tt}"
                        : "",

                filterable: isCollection ? false : filter,
                title: column.displayName ? column.displayName : column.name,
                sortable: !isCollection,
                ...(column.AggType && { aggregates: [column.AggType], groupFooterTemplate: `${column.AggTitle} : #=kendo.toString(${column.AggType},'n2')#` }),
                template: isCollection
                    ? (di) =>
                        createCollection(di[column.name], column.CollectionPropertyName)
                    : hasTemplate ? Templates[template] : null,
            };
        });

        if (containsActions) {
            var actions = response["actions"];
            var actionsBtns = [...actions].map(x => ({

                name: x.text,
                iconClass: `k-icon ${x.icon}`,
                click: (e) => Actions[x.action](e)
            }));
            cols = [
                ...cols,
                {
                    title: "Actions",
                    command: actionsBtns,
                },
            ];
        }
        if (selectable) cols = [selectCol, ...cols];
        return cols;
    }

    genrateToolBar(data, doesnotcontainsll) {
        var toolbar = [];
        if (!doesnotcontainsll) {
            toolbar = [
                {
                    name: "custom",
                    template: `<span id="tbdataCount"></span>`,
                },
                {
                    name: "custom",
                    template: `<a class="k-button k-button-icontext k-grid-custom" id="csvExport" href="\\#"">Export As CSV</a>`,
                },
                {
                    name: "custom",
                    template: `<a class="k-button k-button-icontext k-grid-custom" id="clientPdExport" href="\\#"">Export As Pdf</a>`,
                },
                {
                    name: "custom",
                    template: `<a class="k-button k-button-icontext k-grid-custom" id="sh_filters" href="\\#"">Show All Filters</a>`,
                },
                {
                    name: "custom",
                    template: `<a class="k-button k-button-icontext k-grid-custom" id="clrfil" href="\\#"">clear filters</a>`,
                },
            ];
        }

        if (data) {
            data.forEach((x) => {
                toolbar.push({
                    name: "custom",
                    template: `<a class="k-button k-button-icontext k-grid-custom" id="${x.id}" href="\\#"">${x.text}</a>`,
                });
            });
        }
        return toolbar;
    }

    generateGrid() {
        var para = {};
        var grid = $(this.gridDiv).kendoGrid({
            toolbar: this.toolbar,
            dataSource: {
                transport: {
                    read:  (options) => {

                        const readdata = () => {
                        
                            fetch(this.url, {
                                method: "POST",
                                headers: {
                                    "Content-Type": "application/json",
                                    Accept: "application/json",
                                },
                                body: JSON.stringify(para),
                            })
                                .then((d) => d.json())
                                .then((d) => {
                                    this.total = d.total;
                                    //if (isHierarchy == "true") {
                                    //    var temp = groupAndSum([...d.data], groupList[0], valList[0]);

                                    //    globaldata = [...d.data];

                                    //    options.success(temp);
                                    //}
                                    /*   else {*/
                                    if (!d.doesNotContainAllFun) {
                                        var tpcountSpan = document.getElementById("tbdataCount");
                                        tpcountSpan.innerText = `${options.data.skip + 1} - ${options.data.skip + 100} of ${d.total} items`

                                    }
                                    
                                    options.success([...d.data]);
                                    /*   }*/
                                    
                                    if (this.isAllSelected) {
                                        var select = [];
                                        [...Array(100).keys()].forEach((x) => {
                                            select.push(`tr:eq(${x})`);
                                        });
                                        var selectstr = select.join(", ");
                                        grid.select(selectstr);
                                    }
                                    else {
                                        var selectedInCurrentPage = this.selectedRows[grid.dataSource.page()];
                                        if (selectedInCurrentPage) {
                                            selectedInCurrentPage.forEach((x) => {
                                            
                                                var item = grid.dataSource.data().filter(i => areObjectEqual(x, this.cleanDataItem(i)));
                                                if (item && item.length > 0) {
                                                    var row = grid.tbody.find("tr[data-uid='" + item[0].uid + "']");
                                                    grid.select(row);
                                                 };
                                            });
                                            setTimeout(() => {
                                                var selectall = this.gridDiv.querySelector("th > input.k-checkbox");
                                                selectall.classList.remove("k-checkbox:checked");
                                                selectall.setAttribute("aria-checked", 'false');
                                                selectall.checked = false;
                                                selectall.ariaChecked = false;
                                            }, 0);
                                        }
                                    }
                                    //var filter = options.data.filter;

                                    //createFiltersDiv(filter);

                                    //if (filter) {
                                    //    var frag = new DocumentFragment();
                                    //    filter.filters.forEach(x => {
                                    //        if (x.field) {
                                    //            var p = document.createElement("p");
                                    //            p.innerHTML = `${x.field} ${x.operator} ${x.value}`
                                    //            frag.appendChild(p);
                                    //        } else {
                                    //            x.filters.forEach(x => {
                                    //                var p = document.createElement("p");
                                    //                p.innerHTML = `${x.field} ${x.operator} ${x.value}`
                                    //                frag.appendChild(p);
                                    //            })
                                    //        }

                                    //    })

                                    //    fDiv.appendChild(frag);

                                    //}
                                    //if (chartsDiv) {
                                    //    var chartdata = [];
                                    //    if (d.chartdata)
                                    //        chartdata = [...d.chartdata];
                                    //    chartdata.forEach((x) => {
                                    //        var div = document.getElementById(x.ChartId);

                                    //        var type = div.dataset.type;

                                    //        makedynamicChart(
                                    //            parseInt(type),
                                    //            x.Data,
                                    //            x.Title,
                                    //            x.ChartId,
                                    //            x.Val,
                                    //            x.Cat
                                    //        );
                                    //    });
                                    //}
                                }).catch(err => {
                                    console.error(err);
                                    toastObj.icon = 'error';
                                    toastObj.text = "something wrong happend while getting data please try again";
                                    toastObj.heading = "Grid Intialization Status";
                                    $.toast(toastObj);
                                    return;
                                });;
                        }

                        if (this.isStoredProc) {
                            //getExRules();

                            //para.req.Id = id;
                            //para.req.IsIntialize = false;
                            //para.req.Take = options.data.take;
                            //para.req.Skip = options.data.skip;
                            //para.req.Sort = options.data.sort;
                            //para.req.Filter = options.data.filter;

                            //var intializeParaInterval = setInterval(() => {
                            //    if (isextractRulesFinished) {
                            //        para.procFilters = exRules;
                            //        readdata();
                            //        isextractRulesFinished = false;
                            //        clearInterval(intializeParaInterval);
                            //    }
                            //}, 1000);


                        } else {

                           // para.Id = id;
                            para.Take = options.data.take;
                            para.Skip = options.data.skip;
                            para.Sort = options.data.sort;
                            para.IsIntialize = false;
                            para.Filter = options.data.filter;
                            readdata();
                        }






                        
                    },
                },

                schema: {
                    model: this.model,
                    total: () => {
                        return this.total;
                    },
                },
                serverPaging: true,
                serverFiltering: true,
                ...(this.defaultfilters && { filter: this.defaultfilters }),
                ...(this.defaultGroup && { group: this.defaultGroup }),
                ...(this.defaultAggs && { aggregate: this.defaultAggs }),
                serverSorting: true,
                pageSize: 100 /*isHierarchy ? 1000 : 100,*/

            },
            resizable: true,
            filterable: true,
            columns: this.columns,
            noRecords: true,
            persistSelection: true,
            pageable: true,
            sortable: true,
            change:  (e) => {
                if ([...grid.select()].length > 0) {
                    this.selectedRows[grid.dataSource.page()] = [...grid.select()].map((x) => {
                        var dataItem = grid.dataItem(x);
                        // Store relevant information dynamically
                        return this.cleanDataItem(dataItem);
                    });
                } else {
                    delete this.selectedRows[grid.dataSource.page()];
                }
            },
            allowCopy: {
                delimeter: ",",
            },
            loaderType: "skeleton",
            sortable: {
                mode: "multiple",
            },
            height: 550,
            groupable: true,
            dataBound: (e) => {
                
                for (var i = 0; i < this.columns.length; i++) {
                    grid.autoFitColumn(i);
                }

                //if (isColoredRows) {
                //    var rows = e.sender.tbody.children();
                //    for (var j = 0; j < rows.length; j++) {
                //        var row = $(rows[j]);
                //        var dataItem = e.sender.dataItem(row);
                //        var colorHandler = changeRowColorHandlers[handlerkey];
                //        colorHandler(dataItem, row);
                //    }
                //}

               
                grid.tbody.find("tr").dblclick( (e) => {
                 
                    var dataItem = grid.dataItem(e.target.parentElement);
                    if (this.handlerkey && this.handlerkey != "") {
                        var dbclickhandler = dbClickHandlers[this.handlerkey];
                        dbclickhandler(dataItem).then(console.log("done"));
                    }
                   
                });
            },
            //...(isHierarchy == "true" && {
            //    detailInit: (e) => {

            //        var data = globaldata;

            //        data = data.filter(x => x[groupList[0]] == e.data[groupList[0]]);
            //        console.log(data);
            //        detailInit(e, data, groupList, groupList[1], valList, valList[1]);

            //    }
            //})

        });

        var grid = $(this.gridDiv).data("kendoGrid");


        // event for constructing the filters for multi select columns
        grid.bind("filterMenuInit", (e) => {
            if (this.isMultiSelect.includes(e.field)) {
                e.container.find("[type='submit']").click((ev) => {
                            ev.preventDefault();
                           var multiselects = e.container.find(`input[data-role=multiselect][data-field=${e.field}]`);
                           var op = e.container.find("select[title='Operator']")[0].value
                            var values = $(multiselects).data("kendoMultiSelect").value();
                       
                           var filter = { logic: "or", filters: [] };
             
                           if (values && values.length > 0) {
                             
                               values.forEach(x => {
                                   var f = {
                                       field: e.field,
                                       operator: op,
                                       value: x,
                                   };
                                   filter.filters.push(f);
                               });
                        
                           } else {
                               filter.filters.push({
                                   field: e.field,
                                   operator: op,
                                   value: "",
                               });
                           }
                         
                           var filters = grid.dataSource.filter();
                           if (filters) {
                              
                               var remainingFilters = filters.filters.filter((x) => {
                                   if (x.field && x.field != e.field) return true;
                                   if (x.filters && x.filters.some((x) => x.field != e.field)) return true;
                               });

                               var newFilter = [];

                               if (filter.filters.length == 0) {
                                   newFilter = [...remainingFilters];
                               } else {
                                   newFilter = [...remainingFilters, filter];
                               }
                               var parentFilter = {
                                   logic: "and",
                                   filters: [...newFilter],
                               };
                               grid.dataSource.filter(parentFilter);
                           }
                           else {
                           

                               var parentFilter = {
                                   logic: "and",
                                   filters: [filter],
                               };
                               grid.dataSource.filter(parentFilter);
                    } 
                    $(e.container).data("kendoPopup").close();
                });
            }
        });



        grid.thead.on("click", ".k-checkbox", this.ToggleSelectAll);

        grid.tbody.on("click", ".k-checkbox", (e) => {
            var page = grid.dataSource.page();
            if (this.isAllSelected) {
                this.isAllSelected = false;
                var pages = Object.keys(this.selectedRows);

                pages.filter(p => p != page).forEach(p => delete this.selectedRows[p]);
            }
            else if (!this.isAllSelected && this.selectedRows[page] && this.selectedRows[page].length < 100) {
               setTimeout(() => {
                    var selectall = this.gridDiv.querySelector("th > input.k-checkbox");
                    selectall.classList.remove("k-checkbox:checked");
                    selectall.setAttribute("aria-checked", 'false');
                    selectall.checked = false;
                    selectall.ariaChecked = false;

                }, 0);
            
    
            }
        });

        $(".k-grid-custom").click(function (e) {
            var orgin = window.location.pathname.split("/");
            var controller = orgin[1];
            if (e.target.id == "csvExport") {
                if (isStoredProc) {
                    var csvhandler = Handlers["csvExportForStored"];
                    csvhandler(e, controller);
                } else {
                    var csvhandler = Handlers["csvExport"];
                    csvhandler(e, controller, url, prop);
                }

            }

            else if (e.target.id == "clientPdExport") {

                if (isStoredProc) {
                    var csvhandler = Handlers["clientStoredPdExport"];
                    csvhandler(e, controller, reportName);
                } else {
                    var csvhandler = Handlers["clientPdExport"];
                    csvhandler(e, controller, url);
                }
            }

            else if (e.target.id == "clrfil") {
                var clrfilhandler = Handlers["clrfil"];
                clrfilhandler(e);
            }
            else if (e.target.id == "sh_filters") {
                var sh_filtershandler = Handlers["sh_filters"];
                sh_filtershandler(e);
            }
            else {
                var handler = Handlers[handlerkey][e.target.id];
                handler(e);
            }
        });

        //$(".k-grid-excel").on("click", (e) => {

        //    e.preventDefault();

        //})
    }

    ToggleSelectAll(e) {
        
            if (!this.isAllSelected) {
                this.isAllSelected = true;
            } else {
                this.isAllSelected = false;
            }
       
    }

    cleanDataItem(dataItem) {
        var cleanDataItem = {};
        var unWantedFields = ["uid", "dirtyFields", "parent", "dirty"];
        // Iterate through all properties of the data item
        for (var prop in dataItem) {
            // Exclude internal keys like 'uid' and other keys specific to Kendo
            if (dataItem.hasOwnProperty(prop) && prop.indexOf('_') !== 0 && !unWantedFields.includes(prop)) {
                cleanDataItem[prop] = dataItem[prop];
            }
        }
        return cleanDataItem;
    }


    reload() {
        this.intializeColumns();
    }
}


customElements.define("m-grid", Grid);


function areObjectEqual(obj1, obj2, leftedKeys) {
    const obj1Keys = Object.keys(obj1);
    const obj2Keys = Object.keys(obj2);

    if (obj1Keys.length !== obj2Keys.length) {
        return false;
    }

    // Check if all properties have the same values
    for (let key of obj1Keys) {
        // Check if the property is in the leftedKeys array
        if (leftedKeys && leftedKeys.includes(key)) {
            continue;
        }

        const value1 = obj1[key];
        const value2 = obj2[key];

        // Compare dates by converting them to timestamps
        if (value1 instanceof Date && value2 instanceof Date) {
            if (value1.getTime() !== value2.getTime()) {
                return false;
            }
        } else if (value1 !== value2) {
            return false;
        }
    }

    // If all checks pass, the objects are equal
    return true;
}

//console.log(   areObjectEqual(
//{
//    "AlertedEntityNumber": "10112",
//        "AlertedEntityName": "Saleh Ali Mohammed Abdulrahman",
//            "PartyTypeDesc": "INDIVIDUAL",
//                "BranchName": "UNKNOWN",
//                    "BranchNumber": null,
//                        "AlertId": 191005,
//                            "AlertDescription": "Large Total Cash Transactions",
//                                "ActualValuesText": "Total Cash Transactions =   15.095; Transaction Day Count = 1",
//                                    "AlertStatus": null,
//                                        "AlertSubCat": "Large Total Cash Transactions",
//                                            "AlertTypeCd": "AMLALT",
//                                                "ScenarioName": "DG_10006",
//                                                    "ScenarioId": 12745,
//                                                        "MoneyLaunderingRiskScore": 870,
//                                                            "CreateDate": "2020-01-26T09:40:18.167Z",
//                                                                "RunDate": "2019-01-26T22:00:00.000Z",
//                                                                    "CloseDate": "2021-11-20T09:57:24.030Z",
//                                                                        "OwnerUserid": "ooooo@gggg.com",
//                                                                            "ReportCloseRsn": null,
//                                                                                "PoliticallyExposedPersonInd": "N",
//                                                                                    "EmployeeInd": "N",
//                                                                                        "InvestigationDays": 1028
//    },
//    {
//        "AlertedEntityNumber": "10112",
//        "AlertedEntityName": "Saleh Ali Mohammed Abdulrahman",
//        "PartyTypeDesc": "INDIVIDUAL",
//        "BranchName": "UNKNOWN",
//        "BranchNumber": null,
//        "AlertId": 191005,
//        "AlertDescription": "Large Total Cash Transactions",
//        "ActualValuesText": "Total Cash Transactions =   15.095; Transaction Day Count = 1",
//        "AlertStatus": null,
//        "AlertSubCat": "Large Total Cash Transactions",
//        "AlertTypeCd": "AMLALT",
//        "ScenarioName": "DG_10006",
//        "ScenarioId": 12745,
//        "MoneyLaunderingRiskScore": 870,
//        "CreateDate": "2020-01-26T09:40:18.167Z",
//        "RunDate": "2019-01-26T22:00:00.000Z",
//        "CloseDate": "2021-11-20T09:57:24.030Z",
//        "OwnerUserid": "ooooo@gggg.com",
//        "ReportCloseRsn": null,
//        "PoliticallyExposedPersonInd": "N",
//        "EmployeeInd": "N",
//        "InvestigationDays": 1028
//    },
//    ["uid"]
//    )

//); 