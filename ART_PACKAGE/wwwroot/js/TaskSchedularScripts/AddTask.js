import { parametersConfig } from "./TaskParametersSettings.js"
import { dateSetting, multiSetting } from "../Components/QueryBuilder/QueryBuilderPlugins.js"
const period = {

    0: "never",
    1: "minutely",
    2: "hourly",
    3: "daily",
    4: "weekly",
    5: "monthly",
    6: "yearly",

}

function multiSelectSetting(url) {
    var vals = [];


    $.ajax({
        url: url,
        type: "GET",
        async: false,
        dataType: "json",
        success: function (data) {
            vals = data;
        }
    });

    return vals;
}

var taskNameInput = document.getElementById("taskName");
var taskDescInput = document.getElementById("taskDesc");
var reportsDropDown = document.getElementById("reportsDropDown");
var paramtersBuilder = document.getElementById('paraBuilder');
var periodDorpDown = document.getElementById("periodDropDown");
var monthDropDown = document.getElementById("monthDropDown");
var weekDayDropDown = document.getElementById("weekDayDropDown");
var dayInput = document.getElementById("dayInput");
var hourInput = document.getElementById("hourInput");
var minutInput = document.getElementById("minutInput");
var mailsInput = document.getElementById("mailsInput");
var mailSwitch = document.getElementById("emailSwitch");
var serverSwitch = document.getElementById("serverSwitch");

//period Genration divs
var monthDiv = document.getElementById("monthDiv");
var weekDayDiv = document.getElementById("weekDayDiv");
var dayDiv = document.getElementById("dayDiv");
var hourDiv = document.getElementById("hourDiv");
var minuteDiv = document.getElementById("minuteDiv");
var mailsDiv = document.getElementById("mailsDiv");





var form = document.getElementById("AddTaskForm");



var disablIinputsDict = {
    hourly: [minuteDiv],
    daily: [minuteDiv, hourDiv],
    weekly: [minuteDiv, hourDiv, weekDayDiv],
    monthly: [minuteDiv, hourDiv, dayDiv],
    yearly: [minuteDiv, hourDiv, dayDiv, monthDiv]
}



//add options
reportsDropDown.innerHTML = '';
var selectOpt = document.createElement('option');
selectOpt.text = "Select A Report";
selectOpt.value = "-1";

var opt = document.createElement('option');
opt.text = "Alert Details";
opt.value = "AlertDetails";
var Topt = document.createElement('option');
Topt.text = "Alert Details Test";
Topt.value = "AlertDetailsTest";
reportsDropDown.appendChild(selectOpt);
reportsDropDown.appendChild(opt);
reportsDropDown.appendChild(Topt);
$(reportsDropDown).selectpicker('refresh');


form.onsubmit = async (e) => {
    e.preventDefault();
    var report = reportsDropDown.value;
    if (report == "-1") {
        toastObj.icon = 'error';
        toastObj.text = "You should select a report first, select and try again";
        toastObj.heading = "Add new Task Status";
        $.toast(toastObj);
        return;
    }
    var taskName = taskNameInput.value;
    var taskDesc = taskDescInput.value;
    var paramters = paramtersBuilder.getRules().map(x => ({ Value: Array.isArray(x.value) ? x.value : [x.value], Name: x.id, Operator: x.operator }));

    var taskExistsRes = await fetch(`/Tasks/IsTaskExists/${taskName}`);
    if (!taskExistsRes.ok) {
        toastObj.icon = 'error';
        toastObj.text = "Task Name must be unique";
        toastObj.heading = "Add new Task Status";
        $.toast(toastObj);
        return;
    }

    var period = parseInt(periodDorpDown.value);
    if (period === -1) {
        toastObj.icon = 'error';
        toastObj.text = "You should select a period for the task to be fired after";
        toastObj.heading = "Add new Task Status";
        $.toast(toastObj);
        return;
    }
    var weekDay = parseInt(weekDayDropDown.value);

    if (period === 4 && weekDay === -1) {
        toastObj.icon = 'error';
        toastObj.text = "You should select a valid week day";
        toastObj.heading = "Add new Task Status";
        $.toast(toastObj);
        return;
    }
    var month = parseInt(monthDropDown.value);

    if (period === 6 && month === -1) {
        toastObj.icon = 'error';
        toastObj.text = "You should select a valid month";
        toastObj.heading = "Add new Task Status";
        $.toast(toastObj);
        return;
    }

    var day = parseInt(dayInput.value);
    var hour = parseInt(hourInput.value);
    var minute = parseInt(minutInput.value);


    var reqBody = {
        Name: taskName,
        Description: taskDesc,
        ReportName: report,
        Period: period,
        Month: month == -1 ? null : month,
        Parameters: paramters,
        DayOfWeek: weekDay == -1 ? null : weekDay,
        Day: isNaN(day) ? null : day,
        Hour: isNaN(hour) ? null : hour,
        Minute: isNaN(minute) ? null : minute,
        IsMailed: mailSwitch.status,
        Mails: mailSwitch.status ? mailsInput.getMails() : [],
        IsSavedOnServer: serverSwitch.status
    };
    //console.log(paramtersBuilder.getSql());
    //console.log(reqBody);

    var addTaskRes = await fetch("/Tasks/AddTask", {
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
        },
        method: "POST",
        body: JSON.stringify(reqBody),

    });

    if (!addTaskRes.ok) {
        toastObj.icon = 'error';
        toastObj.text = "Something wrong happend while adding this task, make sure every thing is correct and try again";
        toastObj.heading = "Add new Task Status";
        $.toast(toastObj);
        return;
    }


    window.location.href = "/Tasks";




}

reportsDropDown.onchange = (e) => {
    if (e.target.value === "-1") {
        paramtersBuilder.style.display = "none";
        paramtersBuilder.reset();
        return;
    }

    paramtersBuilder.style.display = "block";
    var parametrs = parametersConfig.find(x => x.reportName == e.target.value).parameters;
    var filters = mapParamtersToFilters(parametrs);
    if (!paramtersBuilder.isIntialzed) {
        paramtersBuilder.filtersInit(filters);
        console.log(paramtersBuilder.isIntialzed);
    }
    else
        paramtersBuilder.updateFilters(filters);


}

periodDorpDown.onchange = (e) => {

    var val = parseInt(e.target.value);

    if (!monthDiv.classList.contains("disabledDiv"))
        monthDiv.classList.add("disabledDiv");
    if (!weekDayDiv.classList.contains("disabledDiv"))
        weekDayDiv.classList.add("disabledDiv");
    if (!dayDiv.classList.contains("disabledDiv"))
        dayDiv.classList.add("disabledDiv");
    if (!hourDiv.classList.contains("disabledDiv"))
        hourDiv.classList.add("disabledDiv");
    if (!minuteDiv.classList.contains("disabledDiv"))
        minuteDiv.classList.add("disabledDiv");

    if (val !== -1)
        disablIinputsDict[period[val]].forEach(x => x.classList.remove("disabledDiv"));
}

mailSwitch.onswitchchanged = (e) => {
    if (mailSwitch.status) {
        if (mailsDiv.classList.contains("disabledDiv"))
            mailsDiv.classList.remove("disabledDiv")
    } else {
        if (!mailsDiv.classList.contains("disabledDiv"))
            mailsDiv.classList.add("disabledDiv")
    }
};

function mapParamtersToFilters(paramters) {

    var filters = [...paramters].map(p => {
        var filter = { id: p.paraName, field: p.paraName, label: p.paraDisplayName, type: p.type };
        if (p.type === "date")
            filter = { ...filter, ...dateSetting };


        if (p.isMulti) {
            filter = { ...filter, ...multiSetting };
            if (p.values.static)
                filter.values = p.values.static;
            else
                filter.values = multiSelectSetting(p.values.url);
        }

        return filter
    });
    return filters;
}

