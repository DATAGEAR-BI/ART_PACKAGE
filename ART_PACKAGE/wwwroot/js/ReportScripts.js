var TableSelect = document.getElementById("TableName");
var ColumnsSelect = document.getElementById("ColumnNames");
var ChartColumnSelect = document.getElementById("chartColumn");
var ChartColumnTypeSelect = document.getElementById("chartType");
var addChartBtn = document.getElementById("addChart");
var chartTitle = document.getElementById("chartTitle");
var chartCardsDiv = document.getElementById("addedCharts");
var openAddChartBtn = document.getElementById("openAddChart");
var dltBtns = document.getElementsByClassName("chart-delete");
var addedCharts = [];
var form = document.getElementById("CustomReportForm");
var errosDiv = document.getElementById("errors");
var ShcemaSelect = document.getElementById("Shcema");
const categoryTree = document.querySelector('category-tree');
let previousSelectedValues = new Set();


ShcemaSelect.onchange = (e) => {
    var value = parseInt(e.target.value);
    if (value != -1) {
        Fetch(`/CustomReport/GetDbObjects/${value}`, null, "GET").then(d => {
            TableSelect.innerHTML = "";
            var opt = document.createElement("option");
            opt.innerText = "Select a Table";
            opt.value = "";
            opt.selected = true;
            TableSelect.appendChild(opt);
            d.forEach(elm => {
                var opt = document.createElement("option");
                opt.innerText = elm.vieW_NAME.toString().split(".")[1];
                opt.dataset.type = elm.type;
                opt.value = elm.vieW_NAME;
                TableSelect.appendChild(opt);
            })

            $('#TableName').selectpicker('refresh');
        });
    }

}

Fetch(`/ReportCategory/Getcategorieslist`, null, "GET").then(d => {
    // Define a function for when a category is selected
    function onCategoryChange(name, id) {

        console.log(`Selected Category:  ${id}`)
        //alert(`Selected Category: ${name}\nID: ${id}`);
    }
    console.log(JSON.stringify(d));
    // Set attributes on the custom element
    categoryTree.setAttribute('categories', JSON.stringify(d));
    categoryTree.setAttribute('oncategorychange', onCategoryChange.toString());
})




TableSelect.onchange = async (e) => {
    var selected = e.target.options[e.target.selectedIndex];
    var type = selected.dataset.type;
    var view = selected.value;
    var schemaVal = parseInt(ShcemaSelect.value);
    var columns = await Fetch(`/CustomReport/GetObjectColumnNames/${schemaVal}/${view}/${type}`, null, "GET");

    ColumnsSelect.innerHTML = "";
    ChartColumnSelect.innerHTML = "";
    var opt = document.createElement("option");
    opt.innerText = "Select some columns";
    opt.value = "";
    opt.selected = true;
    var opt2 = opt.cloneNode(true);
    opt2.innerText = "Select a column";
    ColumnsSelect.appendChild(opt);
    ChartColumnSelect.appendChild(opt2);
    columns.forEach(elm => {
        var opt = document.createElement("option");
        opt.innerText = elm.name;
        opt.value = elm.name;
        opt.dataset.isnullable = elm.isNullable;
        opt.dataset.type = elm.sqlDataType;
        var opt2 = opt.cloneNode(true);
        ColumnsSelect.appendChild(opt);
        ChartColumnSelect.appendChild(opt2);
    })

    $('#ColumnNames').selectpicker('refresh');
    $('#chartColumn').selectpicker('refresh');

}
//createTable('dynamic-table-container');

ColumnsSelect.onchange = async (e) => {


    const currentSelectedValues = new Set(
        [...e.target.selectedOptions].filter(option => option.value).map(option => option.value)
    );

    const containerId = 'dynamic-table-container'; // The ID of the container div
    const tableBody = document.getElementById("options-table").querySelector("tbody");



    // Determine newly selected options
    const newlySelected = [...currentSelectedValues].filter(
        value => !previousSelectedValues.has(value)
    );

    // Determine recently deselected options
    const recentlyDeselected = [...previousSelectedValues].filter(
        value => !currentSelectedValues.has(value)
    );

    // Remove rows for deselected options
    recentlyDeselected.forEach(value => {
        const row = document.getElementById(`row-${value}`);
        if (row) row.remove();
    });

    // Add rows for newly selected options
    newlySelected.forEach(value => {
        const option = [...e.target.options].find(opt => opt.value === value);
        const type = option.dataset.type;

        const row = document.createElement("tr");
        row.id = `row-${value}`;

        // Create the Name and Type inputs (disabled)
        const nameCell = document.createElement("td");
        const nameInput = document.createElement("input");
        nameInput.type = "text";
        nameInput.value = option.textContent;
        nameInput.disabled = true;
        nameCell.appendChild(nameInput);

        const typeCell = document.createElement("td");
        const typeInput = document.createElement("input");
        typeInput.type = "text";
        typeInput.value = type;
        typeInput.disabled = true;
        typeCell.appendChild(typeInput);

        // Create the Select columns using m-select elements
        const selectColumns = [];
        for (let i = 1; i <= 3; i++) {
            const selectCell = document.createElement("td");
            const mSelect = document.createElement("m-select");
            mSelect.id = `${value}-Select-${i}`;
            mSelect.dataset.title = `Select ${i}`;
            mSelect.dataset.searchable = true;

            // Add options to m-select
            ["Option 1", "Option 2", "Option 3"].forEach((optText, index) => {
                const optionElement = document.createElement("option");
                optionElement.value = `select${i}-${index}`;
                optionElement.textContent = optText;
                mSelect.appendChild(optionElement);
            });

            if (type !== "number" && type !== "decimal") {
                mSelect.disabled = true;
            }

            selectCell.appendChild(mSelect);
            selectColumns.push(selectCell);
        }

        // Append all cells to the row
        row.appendChild(nameCell);
        row.appendChild(typeCell);
        selectColumns.forEach(cell => row.appendChild(cell));

        // Append the row to the table body
        tableBody.appendChild(row);
    });

    // Update previousSelectedValues
    previousSelectedValues = currentSelectedValues;


// Example usage on a multi-select element
//document.getElementById("multi-select").addEventListener("change", handleSelectChange);

// Create the table when the page loads (or when the div is available)

    /*var selected = [...e.target.selectedOptions].filter(option => option.value).map(option => ({
        value: option.value,
        t: option.dataset.type
    }));  //var type = selected.dataset.type;
    //var name = selected.value;
    console.log(`selected item is ${JSON.stringify( selected)}`);
    console.log(e);*/
}

function createTable(containerId) {
    // Create the table
    const table = document.createElement('table');
    table.id = 'options-table';
    table.border = '1';

    // Create the table header
    const thead = document.createElement('thead');
    const headerRow = document.createElement('tr');
    const headers = ['Name', 'Type', 'Select 1', 'Select 2', 'Select 3'];

    headers.forEach(headerText => {
        const th = document.createElement('th');
        th.textContent = headerText;
        headerRow.appendChild(th);
    });

    thead.appendChild(headerRow);
    table.appendChild(thead);

    // Create the table body (empty initially)
    const tbody = document.createElement('tbody');
    table.appendChild(tbody);

    // Find the container div by id and append the table
    const container = document.getElementById(containerId);
    container.appendChild(table);
}
function deleteCard(event) {
    var id = event.dataset.id;
    var cardToDlt = document.getElementById(id);
    addedCharts = addedCharts.filter(c => c.id != id);
    chartCardsDiv.removeChild(cardToDlt);

}

addChartBtn.onclick = (e) => {

    var selectedChartType = ChartColumnTypeSelect.options[ChartColumnTypeSelect.selectedIndex].value;
    var selectedChartTypeString = ChartColumnTypeSelect.options[ChartColumnTypeSelect.selectedIndex].innerText;
    var selectedChartColumn = ChartColumnSelect.options[ChartColumnSelect.selectedIndex].value;
    var addedChartTitle = chartTitle.value;
    var errors = [];



    if (!addedChartTitle || addedChartTitle.length == 0) {
        errors.push("you must type a chart title");
    }

    if (!selectedChartColumn || selectedChartColumn.length == 0) {
        errors.push("you must select a column for the chart");
    }

    if (!selectedChartType) {
        errors.push("you must select a type for the chart");
    }

    if (errors && errors.length > 0) {
        var oldErrs = errosDiv.getElementsByClassName("err");
        [...oldErrs].forEach(errDiv => {
            errosDiv.removeChild(errDiv);
        })
        errors.forEach(err => {
            var errorDiv = document.createElement("div");
            errorDiv.className = "err";
            errorDiv.innerHTML = `<i class="glyphicon glyphicon-remove-sign"></i> ${err}`
            errosDiv.appendChild(errorDiv);
        });
        errosDiv.hidden = false;
        return;
    }


    if (!errors || errors.length == 0)
        if (!errosDiv.hidden)
            errosDiv.hidden = true;


    var cardId = GUID();
    var chartInfo = {
        id: cardId,
        title: addedChartTitle,
        type: parseInt(selectedChartType),
        column: selectedChartColumn
    };
    addedCharts.push(chartInfo);


    var card = document.createElement("div");
    card.id = cardId
    card.className = "card mb-3 row col-md-4";
    card.style = "max-width: 540px; max-hieght:540px;"
    card.innerHTML = `<div class="row no-gutters">
  
    <div class="col-md-12">
      <div class="card-body">
        <h5 class="card-title">${addedChartTitle}</h5>
        <p class="card-text">Chart Type  :  ${selectedChartTypeString}</p>
        <p class="card-text">Column : ${selectedChartColumn}</p>
        <p class="card-text"><small class="text-muted">Added at ${new Date().toLocaleString()}</small></p>
        <button onclick="deleteCard(this)" type="button" data-id="${cardId}" class="btn btn-danger chart-delete">Delete chart</button>
      </div>
       
        
        
    </div>
  </div>`;


    chartCardsDiv.appendChild(card);


    ChartColumnTypeSelect.options[ChartColumnTypeSelect.selectedIndex].selected = false;
    ChartColumnSelect.options[ChartColumnSelect.selectedIndex].selected = false;
    chartTitle.value = "";
    $('#chartType').selectpicker('refresh');
    $('#chartColumn').selectpicker('refresh');

}


function hideErrors() {
    errosDiv.hidden = true;
}

form.onsubmit = async (e) => {
    e.preventDefault();





    var errors = [];
    var table = TableSelect.options[TableSelect.selectedIndex].value;
    var tableType = TableSelect.options[TableSelect.selectedIndex].dataset.type;
    var columns = [...ColumnsSelect.options].filter(x => x.selected && x.value != "").map(x => ({
        Name: x.value,
        SqlDataType: x.dataset.type ,
        IsNullable: x.dataset.isnullable,
    }));
    var reportTitle = document.getElementById("title").value;
    var reportDesc = document.getElementById("desc").value;
    var category = categoryTree.selectedValue;

    if (!table || table == undefined || table == "" || table.length == 0) {
        errors.push("you must select a table");
    }

    if (!columns || columns.length == 0) {
        errors.push("you must select at least one column");
    }

    if (!reportTitle || reportTitle.length == 0) {
        errors.push("you type a title for this report");
    }

    if (errors && errors.length > 0) {
        var oldErrs = errosDiv.getElementsByClassName("err");
        [...oldErrs].forEach(errDiv => {
            errosDiv.removeChild(errDiv);
        })
        errors.forEach(err => {
            var errorDiv = document.createElement("div");
            errorDiv.className = "err";
            errorDiv.innerHTML = `<i class="glyphicon glyphicon-remove-sign"></i> ${err}`
            errosDiv.appendChild(errorDiv);
        });
        errosDiv.hidden = false;
        return;
    }


    if (!errors || errors.length == 0)
        if (!errosDiv.hidden)
            errosDiv.hidden = true;

    var charts = addedCharts.map(x => ({

        Title: x.title,
        Type: x.type,
        Column: x.column

    }));


    var model = {
        Table: table,
        ObjectType: tableType,
        Columns: columns,
        Charts: charts,
        Description: reportDesc,
        Title: reportTitle,
        CategoryId: parseInt(category)  ,
        Schema: parseInt(ShcemaSelect.value)
    }

    var d = await Fetch("/MyReports/SaveReport/", model, "POST").then(x => {
        window.location = "/MyReports";
    }).catch(e => console.error(e));





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
    try {
        const data = await res.json();
        return data;
    }catch (e ){
        return;
    }
   
}



// Example categories data
//const categoriesData = [
//    { id: 1, name: "Root Category", parentId: null },
//    { id: 2, name: "Parent Category 1", parentId: 1 },
//    { id: 3, name: "Subcategory 1.1", parentId: 2 },
//    { id: 4, name: "Subcategory 1.2", parentId: 2 },
//    { id: 5, name: "Parent Category 2", parentId: 1 },
//    { id: 6, name: "Subcategory 2.1", parentId: 5 },
//    { id: 7, name: "Subcategory 2.2", parentId: 5 }
//];



class MSelect extends HTMLElement {
    constructor() {
        super();
        this.select = document.createElement("select");
        this.label = document.createElement("label");
        this.isMulti = false;
    }

    connectedCallback() {
        const id = this.id;
        this.classList.add("form-floating", "form-floating-outline");
        const attrs = Object.keys(this.dataset);

        // Check for searchable and multiple attributes
        const isSearchable = attrs.includes("live-search");
        if (isSearchable) this.classList.add("searchable");

        this.isMulti = attrs.includes("multiple");
        if (this.isMulti) {
            this.select.multiple = true;
        }

        this.select.id = id;
        this.select.classList.add("form-select", "selectpicker");

        // Optional: Handle disabled attribute
        if (attrs.includes("disabled")) {
            this.select.disabled = true;
        }

        // Add label text
        this.label.innerText = this.dataset.title || "Select Option";

        this.appendChild(this.label);
        this.appendChild(this.select);

        // Initialize the selectpicker
        $(this.select).selectpicker({
            liveSearch: isSearchable,
            width: "100%"  // Ensure it's 100% width as in the example
        });

        // Initial options (empty or preset)
        this.initialize([]);
    }

    // Initialize the options in the select element
    initialize(options) {
        options.forEach(option => {
            const opt = document.createElement("option");
            opt.value = option.value;
            opt.textContent = option.text;
            this.select.appendChild(opt);
        });

        // Refresh the selectpicker after setting options
        $(this.select).selectpicker("refresh");
    }

    // Set options from an array of text, value
    setOptions(options) {
        this.reset();
        this.initialize(options);
    }

    // Fetch options from a URL and set them
    async fetchOptions(url) {
        try {
            const response = await fetch(url);
            if (!response.ok) throw new Error("Failed to fetch options");

            const data = await response.json();
            const options = data.map(item => ({
                text: item.text,  // Adjust this based on your API response
                value: item.value // Adjust this based on your API response
            }));

            this.setOptions(options);
        } catch (error) {
            console.error("Error fetching options:", error);
        }
    }

    // Reset the options in the select element
    reset() {
        this.select.innerHTML = '';
    }

    // Get the selected value(s)
    get value() {
        if (!this.isMulti) {
            return this.select.options[this.select.selectedIndex].value;
        }
        return [...this.select.options].filter(option => option.selected).map(option => option.value);
    }

    // Set default selected values
    setDefaultValues(defaultValues) {
        [...this.select.options].forEach(option => {
            option.selected = defaultValues.includes(option.value);
        });

        // Refresh the selectpicker after updating selections
        $(this.select).selectpicker("refresh");
    }

    // Enable the select element
    enable() {
        this.select.disabled = false;
        $(this.select).selectpicker("refresh");
    }

    // Disable the select element
    disable() {
        this.select.disabled = true;
        $(this.select).selectpicker("refresh");
    }

    // Toggle the disabled state
    toggleDisable() {
        this.select.disabled = !this.select.disabled;
        $(this.select).selectpicker("refresh");
    }

    // Deselect all options
    deSelect() {
        [...this.select.options].forEach(option => option.selected = false);
        $(this.select).selectpicker("refresh");
    }
}

// Define the custom element
customElements.define("m-select", MSelect);
