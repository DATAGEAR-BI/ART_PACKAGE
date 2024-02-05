let SchemaSelect = document.getElementById("Shcema");
let TableSelect = document.getElementById("TableName");
let ColumnsSelect = document.getElementById("ColumnNames");
let ChartColumnSelect = document.getElementById("ChartColumnSelect");
let ChartColumnTypeSelect = document.getElementById("chartType");
let addChartBtn = document.getElementById("addChart");
let chartTitle = document.getElementById("chartTitle");
let reportTitle = document.getElementById("title");
let reportDesc = document.getElementById("desc");
let cardContainer = document.getElementById("cardContainer");
let dltBtns = document.getElementsByClassName("chart-delete");
let addedCharts = [];
let form = document.getElementById("CustomReportForm");
let errosDiv = document.getElementById("errors");
let ShcemaSelect = document.getElementById("Shcema");

fetch("/report/GetDbSchemas").then(x => x.json()).then(data => {
    var options = [...data].map(o => {
        var opt = document.createElement("option");
        opt.value = o.value;
        opt.innerText = o.text;
        return opt;
    });
    SchemaSelect.update([document.createElement("option"),... options]);
});
fetch("/report/GetChartsTypes").then(x => x.json()).then(data => {
    var options = [...data].map(o => {
        var opt = document.createElement("option");
        opt.value = o.value;
        opt.innerText = o.text;
        return opt;
    });
    ChartColumnTypeSelect.update([document.createElement("option"),... options]);

});
ShcemaSelect.onchange = (e) => {
    var value = parseInt(e.target.value);
    if (value != -1) {
        Fetch(`/Report/GetViews/${value}`, null, "GET").then(d => {
            var options = d.map(elm => {
                var opt = document.createElement("option");
                opt.innerText = elm.vieW_NAME.toString().split(".")[1];
                opt.dataset.type = elm.type;
                opt.value = elm.vieW_NAME;
                return opt;
            });
            TableSelect.update([document.createElement("option"),... options]);

        });
    }
}
TableSelect.onSelectChange = async (e) => {
    var selected = TableSelect.value;
    var type = selected.dataset.type;
    var view = selected.value;
    var schemaVal = parseInt(ShcemaSelect.value.value);
    var columns = await Fetch(`/Report/GetViewColumn/${schemaVal}/${view}/${type}`, null, "GET");

    var options = columns.map(elm => {
        var opt = document.createElement("option");
        opt.innerText = elm.name;
        opt.value = elm.name;
        opt.dataset.isnullable = elm.isNullable;
        opt.dataset.type = elm.sqlDataType;
        return opt;
    });

    var clonedOptions = [...options].map(x => x.cloneNode(true));

    ColumnsSelect.update([document.createElement("option"),... options]);
    ChartColumnSelect.update([document.createElement("option"),...clonedOptions]);

}
function deleteCard(event) {
    var id = event.dataset.id;
    var cardToDlt = document.getElementById(id);
    addedCharts = addedCharts.filter(c => c.id != id);
    chartCardsDiv.removeChild(cardToDlt);

}

addChartBtn.onclick = (e) => {

    var title = chartTitle.value;
    var column = ChartColumnSelect.value;
    var type = ChartColumnTypeSelect.value;
    if (!title || title == "") {
        toastObj.icon = 'error';
        toastObj.text = "there is no chart title";
        toastObj.heading = "Custom Report Status";
        $.toast(toastObj);
        return;

    }
    if (!column.value || column.value == "") {
        toastObj.icon = 'error';
        toastObj.text = "you didn't select a column";
        toastObj.heading = "Custom Report Status";
        $.toast(toastObj);
        return;

    }
    if (!type.value || type.value == "") {
        toastObj.icon = 'error';
        toastObj.text = "you didn't select a type for the chart";
        toastObj.heading = "Custom Report Status";
        $.toast(toastObj);
        return;

    }


    var chart = { title, column: column.value, type: type.value }
    addedCharts.push(chart);
    var srcMap = {
        0: "Bar.png",
        1: "pie.png",
        2: "donut.png",
        3: "dragdrop.png",
        4: "clynder.png",
        5: "curved.png",
        6: "curvedline.png",
    }
    var card = new Card();
    card.title = title
    card.content = type.innerText + " Chart On " + column.innerText;
    card.imgsrc = "/imgs/ChartsImgs/" + srcMap[parseInt(type.value)];
    card.classList.add("col-3");

    cardContainer.appendChild(card);



}
function hideErrors() {
    errosDiv.hidden = true;
}

form.onsubmit = async (e) => {
    e.preventDefault();

    var table = TableSelect.value;
    console.log(table);
    if (!table.value || table.value == "") {
        toastObj.icon = 'error';
        toastObj.text = "you didn't select a Table";
        toastObj.heading = "Custom Report Status";
        $.toast(toastObj);
        return;

    }
    var columns = ColumnsSelect.value;
    console.log(columns);
    if (!columns || columns.length <= 0) {
        toastObj.icon = 'error';
        toastObj.text = "you must select at least one column";
        toastObj.heading = "Custom Report Status";
        $.toast(toastObj);
        return;

    }

    var Title = reportTitle.value;


    if (!Title || Title == "") {
        toastObj.icon = 'error';
        toastObj.text = "you must give the report a title";
        toastObj.heading = "Custom Report Status";
        $.toast(toastObj);
        return;

    }

    var Desc = reportDesc.value;


    var charts = addedCharts.map(x => ({

        Title: x.title,
        Type: parseInt(x.type),
        Column: x.column

    }));


    var model = {
        Table: table.value,
        ObjectType: table.dataset.type,
        Columns: columns.map(x => ({
            Name: x.value,
            SqlDataType: x.dataset.type,
            IsNullable: x.dataset.isnullable,
        })),
        Charts: charts,
        Description: Desc,
        Title: Title,
        Schema: parseInt(ShcemaSelect.value.value)
    }
    
    let req = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
        },
        body: JSON.stringify(model)
    }
    try {
       var res =  await fetch("/MyReports/SaveReport/",req);
       if(res.ok)
           window.location = "/myreports"; 
    }
    catch (e) {
        console.error(e);
        toastObj.icon = 'error';
        toastObj.text = "something wrong happend while creating the report please try again or call support";
        toastObj.heading = "Custom Report Status";
        $.toast(toastObj);
        return;
    }
}
function GUID() {
    return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    ).toString();
}
async function Fetch(url, body, mthod) {
    var req = {
        method: mthod,
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
        }

    }

    if (body) {
        var r = {
            ...req,
            body: JSON.stringify(body)
        };
        var res = await fetch(url, r);
    }
    else {
        var res = await fetch(url, req);
    }

    const data = await res.json();
    return data;
}