var SchemaSelect = document.getElementById("Shcema");
var TableSelect = document.getElementById("TableName");
var ColumnsSelect = document.getElementById("ColumnNames");
var ChartColumnSelect = document.getElementById("ChartColumnSelect");
var ChartColumnTypeSelect = document.getElementById("chartType");
var addChartBtn = document.getElementById("addChart");
var chartTitle = document.getElementById("chartTitle");
var reportTitle = document.getElementById("title");
var reportDesc = document.getElementById("desc");
var cardContainer = document.getElementById("cardContainer");
var dltBtns = document.getElementsByClassName("chart-delete");
var addedCharts = [];
var form = document.getElementById("CustomReportForm");
var errosDiv = document.getElementById("errors");
var ShcemaSelect = document.getElementById("Shcema");


TableSelect.intialize([document.createElement("option")]);
ColumnsSelect.intialize([document.createElement("option")]);
ChartColumnSelect.intialize([document.createElement("option")]);
reportTitle.intialize();
chartTitle.intialize();
reportDesc.intialize();
fetch("/report/GetDbSchemas").then(x => x.json()).then(data => {
    var options = [...data].map(o => {
        var opt = document.createElement("option");
        opt.value = o.value;
        opt.innerText = o.text;
        return opt;
    });
    SchemaSelect.intialize(options);

});
fetch("/report/GetChartsTypes").then(x => x.json()).then(data => {
    var options = [...data].map(o => {
        var opt = document.createElement("option");
        opt.value = o.value;
        opt.innerText = o.text;
        return opt;
    });
    ChartColumnTypeSelect.intialize(options);

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
            TableSelect.update(options);

        });
    }

}




TableSelect.onSelectChange = async (e) => {
    var selected = TableSelect.value;
    var type = selected.dataset.type;
    var view = selected.value;
    var schemaVal = parseInt(ShcemaSelect.value);
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

    ColumnsSelect.update(options);
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
        Type: x.type,
        Column: x.column

    }));


    var model = {
        Table: table.value,
        ObjectType: table.dataset.type,
        Columns: columns.map(x=>x.value),
        Charts: charts,
        Description: Desc,
        Title: Title,
        Schema: parseInt(ShcemaSelect.value.value)
    }

    var d = await Fetch("/report/SaveReport", model, "POST").then(x => {

        window.location = "/report/myreports";


    })
    .catch(err => {
        toastObj.icon = 'error';
        toastObj.text = "something wrong happend while creating the report please try again or call support";
        toastObj.heading = "Custom Report Status";
        $.toast(toastObj);
        return;
    });





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