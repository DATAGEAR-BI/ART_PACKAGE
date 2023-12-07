import xlsx, * as shjs from "../lib/SheetJs/xlsx.mjs";


var btn = document.getElementById("ExportAll");

btn.onclick = async () => {
    var grid1 = document.getElementById("Test1");
    var grid2 = document.getElementById("Test2");
    var grid3 = document.getElementById("Test3");

    var grd1filter = $(grid1.gridDiv).data("kendoGrid").dataSource.filter();
    var grd2filter = $(grid2.gridDiv).data("kendoGrid").dataSource.filter();
    var grd3filter = $(grid3.gridDiv).data("kendoGrid").dataSource.filter();

    var para1 = {
        Take: 1000,//grid1.total,
        Skip: 0,
        Filter: grd1filter,
        All: true
    };
    var para2 = {
        Take: 1000,//grid2.total,
        Skip: 0,
        Filter: grd2filter,
        All: true
    };
    var para3 = {
        Take: 1000,// grid3.total,
        Skip: 0,
        Filter: grd3filter,
        All: true
    };
    var data1 =  grid1.readdata(para1);
    var data2 =  grid1.readdata(para2);
    var data3 =  grid1.readdata(para3);

    var values = await Promise.all([data1, data2, data3]);

    var wb = xlsx.utils.book_new();
    values.map(x => xlsx.utils.json_to_sheet(x.data)).forEach((w, i) => xlsx.utils.book_append_sheet(wb, w, "Grid " + i));

    // Export the workbook
    xlsx.writeFile(wb, "GridsData.xlsx");
}