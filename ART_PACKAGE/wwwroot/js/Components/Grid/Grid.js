import { URLS } from "../../URLConsts.js"
import { Templates } from "../../GridConfigration/ColumnsTemplate.js"
import { columnFilters } from "../../GridConfigration/ColumnsFilters.js"
import { Handlers, dbClickHandlers, changeRowColorHandlers } from "../../GridConfigration/GridEvents.js"
import { makedynamicChart } from "../../Modules/MakeDynamicChart.js";

import { parametersConfig } from "../../QueryBuilderConfiguration/QuerybuilderParametersSettings.js"
import { mapParamtersToFilters, multiSelectOperation } from "../../QueryBuilderConfiguration/QuerybuilderConfiguration.js"
import { exportConnection } from "../../ExportListener.js";



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
    isAllSelected = false;
    selectedRows = {};
    defaultfilters = undefined;
    defaultAggs = undefined;
    defaultGroup = undefined;
    handlerkey = "";
    isCustom = false;
    storedConfig = {
        isStoredProc: false,
        builder: undefined,
        applyBtn: undefined
    }
    customtToolBarBtns = [];
    filtersModal = document.createElement("div");
    csvExportId = "";
    isExporting = false;
    isDownloaded = true;

    constructor() {
        super();



    }
    connectedCallback() {
        this.filtersModal.classList.add("modal", "fade");
        this.filtersModal.id = this.id + "-modal";
        this.filtersModal.tabIndex = -1;
        this.filtersModal.ariaHidden = true;
        this.filtersModal.ariaLabel = this.id + "-modal" + "Label";
        this.filtersModal.innerHTML = `<div class="modal-dialog modal-lg">
           <div class="modal-content">
               <div class="modal-header">
                   <h4 class="modal-title" id="${this.id}-modalLabel">Filters</h4>
                   <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
               </div>

               <div class="modal-body">
                   <div class="row" id="${this.id}-filtersDiv">






                   </div>
               </div>

               <div class="modal-footer">
                   <button type="button" class="btn btn-primary" data-bs-dismiss="modal">Close</button>
               </div>
           </div>
       </div>`

        this.appendChild(this.filtersModal);




        if (Object.keys(this.dataset).includes("stored"))
            this.isStoredProc = true;
        this.isCustom = Object.keys(this.dataset).includes("custom");
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
        if (this.isCustom) {
            this.url = URLS.CustomReport + parseInt(this.dataset.reportid)
            var title = document.createElement("h2");
            title.id = this.id + "-title";
            var desc = document.createElement("p");
            desc.id = this.id + "-desc";
            this.appendChild(title)
            this.appendChild(desc)
        } else {

            this.url = URLS[this.dataset.urlkey];
        }


        if (this.dataset.stored) {


            this.storedConfig.isStoredProc = true;
            this.storedConfig.builder = document.getElementById(this.dataset.stored);
            this.storedConfig.builder.dateFormat = 'yyyy-MM-dd'
            this.storedConfig.applyBtn = document.getElementById(this.storedConfig.builder.dataset.applybtn);
            var rep = parametersConfig.find(x => x.reportName == this.storedConfig.builder.dataset.params);
            var customOps = [];
            var multifields = rep.parameters.filter(x => x.isMulti);
            multifields.forEach(p => {
                var vals = [];
                if (p.values.url) {
                    $.ajax({
                        url: p.values.url,
                        type: "GET",
                        async: false,
                        dataType: "json",
                        success: function (data) {
                            vals = data;
                        }
                    });
                }
                else
                    vals = p.values.static;

                customOps.push(multiSelectOperation(p.paraName, vals));
            })


            this.storedConfig.builder.customOperations = customOps;
            var filters = mapParamtersToFilters(rep.parameters);
            this.storedConfig.builder.fields = filters;
            if (rep.defaultFilter) {
                this.storedConfig.builder.value = rep.defaultFilter;
            }

            this.storedConfig.applyBtn.addEventListener('click', () => {
                var grid = $(this.gridDiv).data("kendoGrid");
                grid.dataSource.read();
            });

        }
        this.gridDiv.id = this.id + "-Grid";
        this.appendChild(this.gridDiv);
        this.intializeColumns();

        exportConnection.on("updateExportProgress", async (progress, folder, gridId) => {
            console.log(gridId);

            if (this.id !== gridId)
                return;

            if (!this.isExporting) {
                this.csvExportId = folder;
                this.isExporting = true;
            }

            var progressBar = document.getElementById(this.id + "Progress");
            if (progressBar.hidden)
                progressBar.hidden = false;


            progressBar.value = progress;
            if (progress >= 100) {
                progressBar.hidden = true;
                var downloadButton = document.getElementById("ExportDownloadBtn");
                downloadButton.hidden = false;
                this.isExporting = false;
                this.isDownloaded = false;
            }
        });


    }

    intializeColumns() {

        var para = { IsIntialize: true };
        if (this.isStoredProc) {
            var flatted = this.storedConfig.builder.value.flat();
            var val = flatted.filter(x => x !== "or" && x !== "and").map(x => {
                var val = x[2];
                return {
                    Field: x[0],
                    Operator: x[1],
                    Value: val
                }

            });
            para.QueryBuilderFilters = val;
        }

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
                this.toolbar = this.genrateToolBar(d.toolbar, d.doesNotContainAllFun, d.showCsvBtn, d.showPdfBtn);



                if (this.isCustom) {
                    document.getElementById(this.id + "-title").innerText = d.title;
                    document.getElementById(this.id + "-desc").innerText = d.desc;


                    if (d.chartsids) {
                        var chartsContainer = document.createElement("div");
                        chartsContainer.classList.add("row");
                        [...d.chartsids].forEach(x => {
                            var chart = document.createElement("div");
                            chart.id = x
                            chart.classList.add("col-12");
                            chartsContainer.appendChild(chart);
                        })




                        this.appendChild(chartsContainer);

                    }

                }
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
                    : hasTemplate ? (di) => Templates[template](di, column.name) : null,
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

    genrateToolBar(data, doesnotcontainsll, showCsvBtn, showPdfBtn) {
        var toolbar = [];
        if (!doesnotcontainsll) {
            //{ name: "customButton1",  },
            //{ name: "customButton2", text: "Custom Button 2" }

            toolbar = ["excel"];
            if (showCsvBtn) {
                toolbar.push({
                    name: this.gridDiv.id + "csvExport",
                    text: "Export To CSV"
                });
            }
            if (showPdfBtn) {
                toolbar.push({
                    name: this.gridDiv.id + "pdfExport",
                    text: "Export To PDF"
                });
            }
            toolbar.push(
                {
                    name: this.gridDiv.id + "sh_filters",
                    text: "Show Filters"
                },
                {
                    name: this.gridDiv.id + "clrfil",
                    text: "Clear All Filters"
                }
            );


        }

        if (data) {
            data.forEach((x) => {
                var btn = {
                    name: `${x.action}`,
                    text: `${x.text}`
                    //template: `<a class="k-button k-button-icontext k-grid-custom" id="${x.action}" href="\\#"">${x.text}</a>`,
                }
                this.customtToolBarBtns.push(btn);
                toolbar.push(btn);
            });
        }
        toolbar.push({
            name: "bar",
            //text: "Clear All Filters"
            template: `
            <span style="display: inline-block">
                <span style="display:flex;align-items:center">
                    <smart-progress-bar id="${this.id + "Progress"}" value="0" style="display: inline-block" hidden></smart-progress-bar>
                    <a class="k-button k-button-icontext k-grid-download" id="ExportDownloadBtn" hidden>Download Files</a>
                </span>
            </span>

            `,
        });
        return toolbar;
    }

    generateGrid() {
        var para = {};
        var grid = $(this.gridDiv).kendoGrid({
            excel: {
                allPages: true, // Export all pages
                fileName: "KendoGridExport.xlsx",
                filterable: true,
                // You can set other Excel export options here
            },


            toolbar: this.toolbar,
            dataSource: {
                transport: {
                    read: async (options) => {
                        para = {
                            IsIntialize: false,
                            Take: options.data.take,
                            Skip: options.data.skip,
                            Sort: options.data.sort,
                            Group: options.data.group,
                            Filter: options.data.filter,
                            All: true
                        };

                        if (this.isStoredProc) {
                            var flatted = this.storedConfig.builder.value.flat();
                            if (flatted.includes("or")) {
                                toastObj.icon = 'error';
                                toastObj.text = "only and logic operators are allowed";
                                toastObj.heading = "Filters Status";
                                $.toast(toastObj);
                                kendo.ui.progress($(this.gridDiv), false);
                                return;
                            }
                            var val = flatted.filter(x => x !== "or" && x !== "and").map(x => {
                                var val = x[2];
                                return {
                                    Field: x[0],
                                    Operator: x[1],
                                    Value: val
                                }

                            });
                            para.QueryBuilderFilters = val;
                            para.IsStored = true;
                        }



                        var d = await this.readdata(para);
                        if (d) {
                            this.total = d.total;
                            //if (isHierarchy == "true") {
                            //    var temp = groupAndSum([...d.data], groupList[0], valList[0]);

                            //    globaldata = [...d.data];

                            //    options.success(temp);
                            //}
                            /*   else {*/
                            options.success([...d.data]);
                            /*   }*/


                            //To perserve the select status
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

                            if (this.isCustom) {
                                var chartdata = [];
                                if (d.chartdata)
                                    chartdata = [...d.chartdata];
                                chartdata.forEach((x) => {
                                    var div = document.getElementById(x.ChartId);



                                    makedynamicChart(
                                        x.Type,
                                        x.Data,
                                        x.Title,
                                        x.ChartId,
                                        x.Val,
                                        x.Cat
                                    );
                                });
                            }
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

            change: (e) => {
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
            height: 700,
            groupable: true,
            //excelExport: function (e) {
            //    e.preventDefault();

            //    var options = grid.getOptions();
            //    console.log(options);
            //    //options.excel.allPages = true;
            //    //grid.setOptions(options);
            //    //grid.saveAsExcel();
            //    // Handler for the excel export event
            //},
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


                grid.tbody.find("tr").dblclick((e) => {

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
                console.log(e.field);
                e.container.find("[type='submit']").click((ev) => {
                    ev.preventDefault();
                    var multiselects = e.container.find(`input[data-role=multiselect][data-field=${e.field}]`);
                    var op = e.container.find("select[title='Operator']")[0].value;
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
                    console.log(filter);
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
                        console.log(parentFilter);
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

        // Assuming you have a Kendo Grid initialized with the ID 'myGrid'
        grid.tbody.on("dblclick", "td", function (e) {


            // Get the current item (row data)
            var item = grid.dataItem($(e.currentTarget).closest("tr"));
            console.log(e);
            // Get the field name associated with the clicked cell
            var cellIndex = $(e.target).index(); // Get the index of the clicked cell
            var column = grid.columns[cellIndex];
            console.log(item);
            console.log(column.field);
            // Check if the clicked cell is from a specific column
            //if (fieldName === "yourColumnName") {
            //    // Perform action specific to the column
            //    console.log("Double-clicked on column", fieldName, "of", item);

            //    // Example action: display a message, open a modal, etc.
            //}
        });




        $(`.k-grid-${this.gridDiv.id}clrfil`).click((e) => {
            this.clrfil(e, this.gridDiv);
        });
        $(`.k-grid-${this.gridDiv.id}sh_filters`).click((e) => {
            this.sh_filters(e, this.gridDiv, this.filtersModal, `${this.id}-filtersDiv`, this.columns);
        });

        $(`.k-grid-${this.gridDiv.id}pdfExport`).click((e) => {
            var pdfExportHandler = undefined;
            if (!this.isStoredProc)
                pdfExportHandler = Handlers["PdExport"];
            else
                pdfExportHandler = Handlers["StoredPdExport"];

            var orgin = window.location.pathname.split("/");
            var controller = orgin[1];
            pdfExportHandler(e, controller, this.url, this.gridDiv);
        });


        $(`.k-grid-${this.gridDiv.id}csvExport`).click(async (e) => {
            await this.ExportCsv(e)
        });


        $(`.k-grid-download`).click(async (e) => {



            var downloadRes = await fetch("/Files/DownloadCsvFiles/" + this.csvExportId);
            if (downloadRes.ok) {
                var blob = await downloadRes.blob();
                var a = document.createElement("a");
                a.setAttribute("download", this.csvExportId + ".Zip");
                a.href = window.URL.createObjectURL(blob);
                a.click();
                e.target.hidden = true;
                this.csvExportId = "";
                this.isDownloaded = true;
            }
        });


        this.customtToolBarBtns.forEach(x => {
            $(`.k-grid-${x.name}`).click((e) => {
                if (this.handlerkey) {
                    var reportHandlers = Handlers[this.handlerkey];
                    if (reportHandlers)
                        reportHandlers[x.name](e, this.gridDiv);
                    else
                        console.error("there is no Handlers for this report");
                } else {
                    console.error("there is no handler key");
                }
            });
        })


        //$(".k-grid-custom").click(function (e) {
        //    var orgin = window.location.pathname.split("/");
        //    var controller = orgin[1];
        //    if (e.target.id == "csvExport") {
        //        if (isStoredProc) {
        //            var csvhandler = Handlers["csvExportForStored"];
        //            csvhandler(e, controller);
        //        } else {
        //            var csvhandler = Handlers["csvExport"];
        //            csvhandler(e, controller, url, prop);
        //        }

        //    }

        //    else if (e.target.id == "clientPdExport") {

        //        if (isStoredProc) {
        //            var csvhandler = Handlers["clientStoredPdExport"];
        //            csvhandler(e, controller, reportName);
        //        } else {
        //            var csvhandler = Handlers["clientPdExport"];
        //            csvhandler(e, controller, url);
        //        }
        //    }

        //    else if (e.target.id == "clrfil") {
        //        var clrfilhandler = Handlers["clrfil"];
        //        clrfilhandler(e);
        //    }
        //    else if (e.target.id == "sh_filters") {
        //        var sh_filtershandler = Handlers["sh_filters"];
        //        sh_filtershandler(e);
        //    }
        //    else {
        //        var handler = Handlers[handlerkey][e.target.id];
        //        handler(e);
        //    }
        //});

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

    sh_filters(e, gridDiv, Modal, filtersDivId, columns) {
        var grid = $(gridDiv).data("kendoGrid");
        var filters = grid.dataSource.filter();
        var filterDiv = document.getElementById(filtersDivId);
        filterDiv.innerHTML = "";
        function buildInputs(filter) {

            if (!filter) return;

            var ops = {
                eq: "Is Equal To",
                neq: "Not Equal To",
                isnull: "Is Null",
                isnotnull: "Is Not Null",
                isempty: "Is Empty",
                isnotempty: "Is Not Empty",
                startswith: "Starts With",
                doesnotstartwith: "Does Not Start With",
                contains: "Contains",
                doesnotcontain: "Does Not Contain",
                endswith: "Ends With",
                doesnotendwith: "Does Not End With",
                gte: "Greater Than Or Equal",
                gt: "Greater Than",
                lte: "Less Than Or Equal",
                lt: "Less Than",
            };

            if (filter.logic) {
                var logicDiv = document.createElement("div");
                logicDiv.classList.add("row");
                var childFilter = [];
                var res = [];
                filter.filters.forEach(function (f) {
                    childFilter.push(buildInputs(f)); // Recursively build inputs for nested filters
                });
                for (let i = 0; i < childFilter.length; i++) {
                    res.push(childFilter[i]); // Add the original element
                    // Add 'x' after each original element, except after the last one
                    if (i < childFilter.length - 1) {
                        var logic = document.createElement("p");
                        logic.classList.add("m-2");
                        logic.innerText = filter.logic;
                        res.push(logic);
                    }
                }
                res.forEach(x => logicDiv.appendChild(x));
                return logicDiv;
            } else {
                var div = document.createElement("div");
                div.classList.add("col-12");
                var filterInput = document.createElement("m-input");
                filterInput.dataset.value = `${ops[filter.operator]} ${filter.value}`;
                var column = columns.find(x => x.field == filter.field);
                console.log(column);
                filterInput.dataset.title = column.title;
                filterInput.dataset.disabled = true;
                div.appendChild(filterInput);
                return div;
            }
        }

        if (filters) {
            filterDiv.appendChild(buildInputs(filters));
        }
        //console.log(filters.filters.flat(Infinity));
        $(Modal).modal("show");
    }
    clrfil(e, gridDiv) {

        var grid = $(gridDiv).data("kendoGrid");
        var multiSelects = document.querySelectorAll("input[data-role=multiselect]");
        console.log(multiSelects);
        [...multiSelects].forEach(x => {
            $(x).data("kendoMultiSelect").value(null);
        });
        grid.dataSource.filter(null);
    }

    async readdata(para) {

        var res = await fetch(this.url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Accept: "application/json",
            },
            body: JSON.stringify(para),
        });
        if (res.ok)
            return await res.json();
        else {

            console.error(res.body);
            toastObj.icon = 'error';
            toastObj.text = "something wrong happend while getting data please try again";
            toastObj.heading = "Grid Intialization Status";
            $.toast(toastObj);
            kendo.ui.progress($(this.gridDiv), false);
            return;

        }

    }
    async ExportCsv(e) {
        if (!this.isDownloaded) {
            toastObj.icon = 'error';
            toastObj.text = "you exported a file and haven't downloaded it yet.";
            toastObj.heading = "Export Status";
            $.toast(toastObj);
            return;
        }

        if (this.isExporting) {
            toastObj.icon = 'error';
            toastObj.text = "there is another Export Process running wait untill it ends and try again";
            toastObj.heading = "Export Status";
            $.toast(toastObj);
            return;
        }

        this.isExporting = true;
        this.isDownloaded = false;
        var grid = $(this.gridDiv).data("kendoGrid");
        var filters = grid.dataSource.filter();
        var total = grid.dataSource.total();
        var sort = grid.dataSource.sort();
        var para = {}
        console.log("bbb");
        para.Take = total;
        para.Skip = 0;
        para.Filter = filters;
        para.Sort = sort;
        if (!this.isAllSelected) {
            var pagesWithSelectedRows = Object.keys(this.selectedRows);
            if (pagesWithSelectedRows && pagesWithSelectedRows.length > 0)
                para.All = false;
            else
                para.All = true;
        }
        para.IdColumn = "CustomerNumber";
        para.SelectedValues = this.isAllSelected ? [] : Object.values(this.selectedRows).flat().map(x => x["CustomerNumber"].toString());
        console.log(para.SelectedValues);
        var exportRes = await fetch("/Grid/ExportToCsv/" + this.id, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Accept: "application/json",
            },
            body: JSON.stringify(para),
        });

        if (exportRes.ok) {
            var exportId = (await exportRes.json()).folder;
            this.csvExportId = exportId;
        }
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
