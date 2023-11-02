﻿import { makedynamicChart } from "./Modules/MakeDynamicChart.js"
import { URLS } from "./URLConsts.js"
import { Handlers, dbClickHandlers, changeRowColorHandlers } from "./GridConfigration/GridEvents.js"
import { Spinner } from "../lib/spin.js/spin.js"
import { Actions } from "./GridActions.js"
import { Templates } from "./GridConfigration/ColumnsTemplate.js"
import { columnFilters } from "./GridConfigration/ColumnsFilters.js"
var spinnerOpts = {
    lines: 13, // The number of lines to draw
    length: 14, // The length of each line
    width: 2, // The line thickness
    radius: 50, // The radius of the inner circle
    scale: 1, // Scales overall size of the spinner
    corners: 1, // Corner roundness (0..1)
    speed: 1, // Rounds per second
    rotate: 0, // The rotation offset
    animation: 'spinner-line-shrink', // The CSS animation name for the lines
    direction: 1, // 1: clockwise, -1: counterclockwise
    color: '#000000', // CSS color or array of colors
    fadeColor: 'transparent', // CSS color or array of colors
    top: '50%', // Top position relative to parent
    left: '50%', // Left position relative to parent
    shadow: '0 0 1px transparent', // Box-shadow for the lines
    zIndex: 2000000000, // The z-index (defaults to 2e9)
    className: 'spinner', // The CSS class to assign to the spinner
    position: 'absolute', // Element positioning
};
var spinnerStyle = document.createElement("link");
spinnerStyle.rel = "stylesheet";
spinnerStyle.href = "/lib/spin.js/spin.css";
const handleError = (error) => {
    if (error instanceof Error) {
        // This is a client-side error (e.g., network issues)
        console.error('Client-side error:', error.message);
    } else {
        // This is a server error (e.g., 500 Internal Server Error)
        console.error('Server error:', error);
        if (error.response && error.response.status === 500) {
            // Handle 500 Internal Server Error here
            toastObj.hideAfter = false;
            toastObj.icon = 'error';
            toastObj.text = "Some thing wrong hannped while intializing the report please reload page or call support";
            toastObj.heading = "Report Status";
            $.toast(toastObj);
        }
    }
}
var grid = document.getElementById("grid");
localStorage.removeItem("selectedidz");
localStorage.setItem("isAllSelected", false);
var filtersDiv = document.createElement("div");
var exRules = [];
filtersDiv.style = "margin-top:2%";
filtersDiv.id = "filters";
filtersDiv.innerHTML = ` <div class="collapse" style="margin-top:4%" id="filtersCollapse">
                 
                </div>`;
grid.parentNode.insertBefore(spinnerStyle, grid);
grid.parentNode.insertBefore(filtersDiv, grid);
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
var isHierarchy = document.getElementById("script").dataset.hierarchy;
var reportName = "";
var isColoredRows = document.getElementById("script").dataset.coloredrows;
var pdfUrl = document.getElementById("script").dataset.pdfurl;
var isextractRulesFinished = false;
var isAllSelected = false;
var selected = {};
var isStoredProc = document.getElementById("script").dataset.stored;
var isDateField = [];
var isNumberField = [];
var id = document.getElementById("script").dataset.id;
var defaultfilters = document.getElementById("script").dataset.defaultfilters;
var defaultGroup = document.getElementById("script").dataset.defaultgroup;
var defaultAggs = document.getElementById("script").dataset.aggregates;
var urlKey = document.getElementById("script").dataset.urlkey;
var prop = document.getElementById("script").dataset.prop;
var handlerkey = document.getElementById("script").dataset.handlerkey;
var chartsDiv = document.getElementById("charts");
var url = URLS[urlKey].toString();
var types = {};
var typesString = document.getElementById("script").dataset.charttypes;
if (typesString) types = JSON.parse(typesString);
var para = {};
if (id) {
    para.Id = id;
}
var procFilters
para.Take = 1;
para.IsIntialize = true;
var model = {};
var columns = {};
var toolbar = [];
var pages = 0;
var total = 0;
var globaldata = [];
var groupList = [];
var valList = [];
var spinner = new Spinner(spinnerOpts).spin(grid);
if (isStoredProc == "true") {

    getExRules();
    var intializeParaInterval = setInterval(() => {
        if (isextractRulesFinished) {
            para = { req: para, procFilters: exRules }
            intializeGrid();
            isextractRulesFinished = false;

            clearInterval(intializeParaInterval);
        }
    }, 1000);
} else {
    intializeGrid();
}

function intializeGrid() {
    fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
        },
        body: JSON.stringify(para),
    })
        .then((d) => d.json())
        .then((d) => {
            total = d.total;
            reportName = d.reportname;
            if (isHierarchy == "true") {
                groupList = d.grouplist;
                valList = d.vallist;
            }
            model = generateModel(d);
            columns = generateColumns(d);
            toolbar = genrateToolBar(d.toolbar, d.doesNotContainAllFun);
            var title = document.getElementById("title");
            var desc = document.getElementById("desc");

            if (title && desc) {
                title.innerText = d.title;
                desc.innerText = d.desc;
            }
            $(".spinner").remove();
            generateGrid();

        }).catch(handleError);
}
function genrateToolBar(data, doesnotcontainsll) {
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

function getExRules() {


    var checkinterval = setInterval(check, 1000);


    function check() {

        var isFiltersExist = document.getElementById("filters");
        if (isFiltersExist) {
            console.log("check");
            internal();
            clearInterval(checkinterval);
        }
    }
    function internal() {

        var rules = $('#filters').queryBuilder('getRules');

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
            isextractRulesFinished = true;
            console.log(exRules);

        }
    }
}
function generateGrid() {
    var grid = $("#grid").kendoGrid({
        toolbar: toolbar,

        dataSource: {

            transport: {
                read: function (options) {
                    if (isStoredProc) {
                        getExRules();

                        para.req.Id = id;
                        para.req.IsIntialize = false;
                        para.req.Take = options.data.take;
                        para.req.Skip = options.data.skip;
                        para.req.Sort = options.data.sort;
                        para.req.Filter = options.data.filter;

                        var intializeParaInterval = setInterval(() => {
                            if (isextractRulesFinished) {
                                para.procFilters = exRules;
                                readdata();
                                isextractRulesFinished = false;
                                clearInterval(intializeParaInterval);
                            }
                        }, 1000);


                    } else {
                        para.Id = id;
                        para.Take = options.data.take;
                        para.Skip = options.data.skip;
                        para.Sort = options.data.sort;
                        para.IsIntialize = false;
                        para.Filter = options.data.filter;
                        readdata();
                    }






                    function readdata() {
                        url = URLS[urlKey].toString();
                        fetch(url, {
                            method: "POST",
                            headers: {
                                "Content-Type": "application/json",
                                Accept: "application/json",
                            },
                            body: JSON.stringify(para),
                        })
                            .then((d) => d.json())
                            .then((d) => {
                                total = d.total;
                                if (isHierarchy == "true") {
                                    var temp = groupAndSum([...d.data], groupList[0], valList[0]);

                                    globaldata = [...d.data];

                                    options.success(temp);
                                }
                                else {
                                    if (!d.doesNotContainAllFun) {
                                        var tpcountSpan = document.getElementById("tbdataCount");
                                        tpcountSpan.innerText = `${options.data.skip + 1} - ${options.data.skip + 100} of ${d.total} items`

                                    }
                                    options.success([...d.data]);
                                }

                                if (isAllSelected) {
                                    var select = [];
                                    [...Array(100).keys()].forEach((x) => {
                                        select.push(`tr:eq(${x})`);
                                    });
                                    var selectstr = select.join(", ");
                                    grid.select(selectstr);
                                } else {
                                    var selectedInCurrentPage = selected[grid.dataSource.page()];

                                    if (selectedInCurrentPage) {
                                        selectedInCurrentPage.forEach((x) => {
                                            var res = $.grep(grid.dataSource.data(), function (d) {
                                                return d[prop] == x[prop];
                                            });

                                            grid.select(`tr[data-uid="${res[0].uid}"]`);
                                        });

                                        setTimeout(() => {
                                            var selectall = document.querySelector("th > input.k-checkbox");
                                            selectall.classList.remove("k-checkbox:checked");
                                            selectall.setAttribute("aria-checked", 'false');
                                            selectall.checked = false;
                                            selectall.ariaChecked = false;
                                        }, 5);
                                    }
                                }
                                var filter = options.data.filter;

                                createFiltersDiv(filter);

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
                                if (chartsDiv) {
                                    var chartdata = [];
                                    if (d.chartdata)
                                        chartdata = [...d.chartdata];
                                    chartdata.forEach((x) => {
                                        var div = document.getElementById(x.ChartId);

                                        var type = div.dataset.type;

                                        makedynamicChart(
                                            parseInt(type),
                                            x.Data,
                                            x.Title,
                                            x.ChartId,
                                            x.Val,
                                            x.Cat
                                        );
                                    });
                                }
                            }).catch(handleError);;
                    }
                },
            },

            schema: {
                model: model,
                total: () => {
                    return total;
                },
            },
            serverPaging: true,
            serverFiltering: true,
            ...(defaultfilters && { filter: JSON.parse(defaultfilters) }),
            ...(defaultGroup && { group: JSON.parse(defaultGroup) }),
            ...(defaultAggs && { aggregate: JSON.parse(defaultAggs) }),
            serverSorting: true,
            pageSize: isHierarchy ? 1000 : 100,

        },
        resizable: true,
        filterable: true,
        filter: (e) => {

            var multiselects = document.querySelector(`[data-role=multiselect][data-field=${e.field}]`);
            if (multiselects) {
                e.preventDefault();
                var filter = { logic: "or", filters: [] };
                var values = $(multiselects).data("kendoMultiSelect").value();
                var op = multiselects.parentElement.parentElement.querySelector("select[title='Operator']").value
                if (values && values.length > 0) {
                    $.each(values, function (i, v) {
                        filter.filters.push({
                            field: e.field,
                            operator: op,
                            value: v,
                        });
                    });
                } else {
                    filter.filters.push({
                        field: e.field,
                        operator: op,
                        value: "",
                    });
                }

                var filters = $("#grid").data("kendoGrid").dataSource.filter();
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
                    $("#grid").data("kendoGrid").dataSource.filter(parentFilter);
                } else {
                    var parentFilter = {
                        logic: "and",
                        filters: [filter],
                    };
                    $("#grid").data("kendoGrid").dataSource.filter(parentFilter);
                }
            }


        },
        columns: columns,
        noRecords: true,
        persistSelection: true,
        pageable: true,
        sortable: true,
        change: function (e) {
            if ([...this.select()].length > 0) {
                selected[this.dataSource.page()] = [...this.select()].map((x) => {
                    var dataItem = grid.dataItem(x);

                    return dataItem;
                });
            } else {

                selected[this.dataSource.page()] = [];

            }

            localStorage.setItem("selectedidz", JSON.stringify(selected));
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
        dataBound: function (e) {
            for (var i = 0; i < this.columns.length; i++) {
                this.autoFitColumn(i);
            }

            if (isColoredRows) {
                var rows = e.sender.tbody.children();
                for (var j = 0; j < rows.length; j++) {
                    var row = $(rows[j]);
                    var dataItem = e.sender.dataItem(row);
                    var colorHandler = changeRowColorHandlers[handlerkey];
                    colorHandler(dataItem, row);
                }
            }

            $("[type='reset']").click(function (e) {

                // Your custom logic to handle the clear button event
                var multi = e.target.parentElement.parentElement.querySelector(`[data-role=multiselect][data-field]`);

                if (multi) {
                    var field = multi.dataset.field;
                    e.preventDefault();

                    $(multi).data("kendoMultiSelect").value(null);
                    var filters = $("#grid").data("kendoGrid").dataSource.filter();

                    var filtersExceptThis = filters.filters.filter((x) => {
                        if (x.field && x.field != field) return true;
                        if (x.filters && x.filters.some((x) => x.field != field)) return true;
                    });
                    $("#grid").data("kendoGrid").dataSource.filter({
                        logic: "and",
                        filters: [...filtersExceptThis],
                    });

                    return;

                }
            });
            this.tbody.find("tr").dblclick(function (e) {
                var dataItem = grid.dataItem(this);
                var dbclickhandler = dbClickHandlers[handlerkey];
                dbclickhandler(dataItem).then(console.log("done"));
            });
        },
        ...(isHierarchy == "true" && {
            detailInit: (e) => {

                var data = globaldata;

                data = data.filter(x => x[groupList[0]] == e.data[groupList[0]]);
                console.log(data);
                detailInit(e, data, groupList, groupList[1], valList, valList[1]);

            }
        })

    });

    var grid = $("#grid").data("kendoGrid");

    grid.thead.on("click", ".k-checkbox", onClick);

    grid.tbody.on("click", ".k-checkbox", (e) => {
        selected = Object.entries(selected).reduce((acc, [key, value]) => {
            if (grid.dataSource.page() == key) {

                acc[key] = value;
            }
            return acc;
        }, {});

        localStorage.setItem("selectedidz", JSON.stringify(selected));
        if (isAllSelected) {
            isAllSelected = false;
            localStorage.setItem("isAllSelected", false);
        }
        else {

            //console.log();

            setTimeout(() => {
                var selectall = document.querySelector("th > input.k-checkbox");
                selectall.classList.remove("k-checkbox:checked");
                selectall.setAttribute("aria-checked", 'false');
                selectall.checked = false;
                selectall.ariaChecked = false;
            }, 5);



            //if () {
            //    console.log("all");
            //}
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
        } else if (e.target.id == "sh_filters") {
            var sh_filtershandler = Handlers["sh_filters"];
            sh_filtershandler(e);
        } else {
            var handler = Handlers[handlerkey][e.target.id];
            handler(e);
        }
    });

    //$(".k-grid-excel").on("click", (e) => {

    //    e.preventDefault();

    //})
}

function groupAndSum(list, groupbyKey, valueKey) {
    const result = {};
    for (const item of list) {
        if (!result[item[groupbyKey]]) {
            result[item[groupbyKey]] = { [groupbyKey]: item[groupbyKey], [valueKey]: 0 };
        }
        result[item[groupbyKey]][valueKey] += item[valueKey];
    }
    return Object.values(result);
}

function detailInit(e, data, groupList, grouper, valList, val) {
    var result = groupAndSum(data, grouper, val);


    console.log(result);
    $("<div/>").appendTo(e.detailCell).kendoGrid({
        dataSource: {
            data: [...result],
            serverPaging: false,
            serverSorting: false,
            serverFiltering: false,
            pageSize: 31,

        },
        scrollable: false,
        sortable: true,
        pageable: true,
        columns: () => {
            var cols = [];
            for (var prop in result[0]) {
                cols.push({

                    field: prop,
                    title: prop,
                    width: "110px"

                })
            }

            return cols;

        },
        detailInit: (e) => {
            if (groupList && groupList.indexOf(grouper) != groupList.length - 1 && valList.indexOf(val) != valList.length - 1) {
                var tempdata = data.filter(x => x[groupList[groupList.indexOf(grouper)]] == e.data[groupList[groupList.indexOf(grouper)]]);
                console.log(data);
                detailInit(e, tempdata, groupList, groupList[groupList.indexOf(grouper) + 1], valList, valList[valList.indexOf(val) + 1])
            }
        }
    });
}

function createFiltersDiv(obj) {
    var fDiv = document.getElementById("filtersCollapse");
    fDiv.innerHTML = "";

    if (obj == null || !obj) return null;

    var logic = obj.logic;
    var filters = obj.filters;

    [...filters].forEach((x) => {
        if (x.field) {
            var existinp = document.getElementById(`${x.field}-0`);

            if (existinp) {
                var oldVal = existinp.value.split("=> ")[1];
                existinp.value = `${x.field}=> ${oldVal},${ops[x.operator]} ${x.value}`;
            } else {
                var inp = document.createElement("input");
                inp.id = x.field + "-0";
                inp.type = "text";
                inp.value = `${x.field}=> ${ops[x.operator]} ${x.value}`;
                inp.classList = ["form-control"];
                inp.readOnly = true;
                fDiv.appendChild(inp);
            }
            //var lgc = document.createElement("div");
            //lgc.innerText = logic;
            //frag.appendChild(lgc);
        } else {
            [...x.filters].forEach((y) => {
                var existinp = document.getElementById(`${y.field}-0`);

                if (existinp) {
                    var oldVal = existinp.value.split("=> ")[1];
                    existinp.value = `${y.field}=> ${oldVal},${ops[y.operator]} ${y.value
                        }`;
                } else {
                    var inp = document.createElement("input");
                    inp.id = y.field + "-0";
                    inp.type = "text";
                    inp.value = `${y.field}=> ${ops[y.operator]} ${y.value}`;
                    inp.classList = ["form-control"];
                    inp.readOnly = true;
                    fDiv.appendChild(inp);
                }
                //var lgc = document.createElement("div");
                //lgc.innerText = x.logic;
                //frag.appendChild(lgc);
            });
        }
    });
}

function onClick(e) {
    if (!isAllSelected) {
        isAllSelected = true;
        localStorage.setItem("isAllSelected", true);
    } else {
        isAllSelected = false;
        localStorage.setItem("isAllSelected", false);
        selected = {};
    }
}

function createCollection(di, prop) {
    var columns = di;
    var html = "<table>";
    console.log("hi", columns);
    if (columns) {
        for (var x = 0; x < columns.length; x++) {
            html += "<tr><td>";
            html += columns[x][prop];
            html += "</td></tr>";
        }
    }


    html += "</table>";
    return html;
}

function generateColumns(response) {
    var columnNames = response["columns"];
    var contiansActions = response["containsActions"];
    var selectCol = {
        selectable: true,
        width: "50px",
    };
    var cols = columnNames.map(function (column) {
        var filter = {};
        if (column.isDropDown)
            filter = columnFilters.multiSelectFilter(column);

        if (isDateField[column.name])
            filter = columnFilters.dateFilter();



        var template = column.template;
        var isCollection = column.isCollection;
        var hasTemplate = template && template != ""

        if (!column.isNullable) {
            if (isNumberField[column.name]) {
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

            if (isDateField[column.name]) {
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
                isDateField[column.name]
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

    if (contiansActions) {
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
    if (response.selectable) cols = [selectCol, ...cols];
    return cols;
}

function generateModel(response) {
    var sampleDataItem = response["columns"];

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
            isNumberField[property.name] = true;
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
            isDateField[property.name] = true;
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




