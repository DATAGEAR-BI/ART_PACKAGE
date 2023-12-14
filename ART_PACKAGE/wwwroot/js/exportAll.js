import xlsx, * as shjs from "../lib/SheetJs/xlsx.mjs";
const tabs = document.querySelector('smart-tabs');
console.log(tabs);
var exportAllBtn = document.createElement("button");
exportAllBtn.classList.add("btn", "btn-primary");
exportAllBtn.innerText = "Export"
//document.querySelector("smart-tabs").querySelector("div.smart-tabs-header-items").appendChild(exportAllBtn);

window.onload = function () {
    console.log(tabs.getTabs());
    var header = document.querySelector('.smart-tabs-header-items');
    header.appendChild(exportAllBtn);

};
exportAllBtn.onclick = async () => {
    const gridIds = tabs.getTabs().map(x => x.querySelector("m-grid").id);
    var grids = gridIds.map(x => document.getElementById(x));

    var params = grids.map(x => {

        var para = {
            IsIntialize: false,
            Take: x.total,
            Skip: 0,
            Sort: $(x.gridDiv).data("kendoGrid").dataSource.sort(),
            Group: $(x.gridDiv).data("kendoGrid").dataSource.group(),
            Filter: $(x.gridDiv).data("kendoGrid").dataSource.filter(),
            All: true
        };

        if (x.isStoredProc) {
            var flatted = x.storedConfig.builder.value.flat();
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

        return para;
    });
    console.log(params);

    var gridsData = grids.map((g, i) => g.readdata(params[i]));
    var data = await Promise.all(gridsData);
    var wb = xlsx.utils.book_new();
    data.map(x => xlsx.utils.json_to_sheet(x.data)).forEach((w, i) => xlsx.utils.book_append_sheet(wb, w, tabs.getTabLabel(i)));

    // Export the workbook
    xlsx.writeFile(wb, "GridsData.xlsx");


    //var grid1 = document.getElementById("Test1");
    //var grid2 = document.getElementById("Test2");
    //var grid3 = document.getElementById("Test3");

    //var grd1filter = $(grid1.gridDiv).data("kendoGrid").dataSource.filter();
    //var grd2filter = $(grid2.gridDiv).data("kendoGrid").dataSource.filter();
    //var grd3filter = $(grid3.gridDiv).data("kendoGrid").dataSource.filter();

    //var para1 = {
    //    Take: 1000,//grid1.total,
    //    Skip: 0,
    //    Filter: grd1filter,
    //    All: true
    //};
    //var para2 = {
    //    Take: 1000,//grid2.total,
    //    Skip: 0,
    //    Filter: grd2filter,
    //    All: true
    //};
    //var para3 = {
    //    Take: 1000,// grid3.total,
    //    Skip: 0,
    //    Filter: grd3filter,
    //    All: true
    //};
    //var data1 = grid1.readdata(para1);
    //var data2 = grid1.readdata(para2);
    //var data3 = grid1.readdata(para3);

    //var values = await Promise.all([data1, data2, data3]);

    //var wb = xlsx.utils.book_new();
    //values.map(x => xlsx.utils.json_to_sheet(x.data)).forEach((w, i) => xlsx.utils.book_append_sheet(wb, w, "Grid " + i));

    //// Export the workbook
    //xlsx.writeFile(wb, "GridsData.xlsx");
}


