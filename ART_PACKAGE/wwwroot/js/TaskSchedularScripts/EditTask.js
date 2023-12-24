import { parametersConfig } from "./TaskParametersSettings.js"
import { mapParamtersToFilters, multiSelectOperation } from "../QueryBuilderConfiguration/QuerybuilderConfiguration.js"


const period = {

    0: "never",
    1: "minutely",
    2: "hourly",
    3: "daily",
    4: "weekly",
    5: "monthly",
    6: "yearly",

}



var tabs = document.querySelectorAll('.nav-tabs');
for (const [, value] of Object.entries(tabs)) {
    var tabInstance = materialstyle.MaterialTab.getOrCreateInstance(value)
    tabInstance.redraw();
}



var taskNameInput = document.getElementById("taskName");
var filePath = document.getElementById("filePath");
var taskDescInput = document.getElementById("taskDesc");
var mailContent = document.getElementById("mailContent");
var reportsDropDown = document.getElementById("reportsDropDown");
var periodDorpDown = document.getElementById("periodDropDown");
var monthDropDown = document.getElementById("monthDropDown");
var weekDayDropDown = document.getElementById("weekDayDropDown");
var calender = document.querySelector("#calendar");
var timePicker = document.querySelector("#timepicker");
var mailSwitch = document.getElementById("emailSwitch");
var serverSwitch = document.getElementById("serverSwitch");
const querybuilder = document.querySelector('#querybuilder');
var mailsInput = document.getElementById("mailsInput");
var modelCopy = model.accessWithKey("modelSecureSecretKey123@");
var endofmonthDiv = document.getElementById("endofmonthSec");
var endofmonthSwitch = document.getElementById("endofMonth");
console.log(modelCopy);
init();
function init() {


    timePicker.disabled = true;
    calender.disabled = true;

    var opt = document.createElement('option');
    opt.text = "Alert Details";
    opt.value = "AlertDetails";
    var Topt = document.createElement('option');
    Topt.text = "Alert Details Test";
    Topt.value = "AlertDetailsTest";
    opt.selected = true;



    var opts = [opt, Topt].map(x => {
        if (x.value == modelCopy.reportName)
            x.selected = true;
    });

    reportsDropDown.intialize([ opt, Topt]);
    var parametrs = parametersConfig.find(x => x.reportName == modelCopy.reportName).parameters;
    var customOps = [];
    var multifields = parametrs.filter(x => x.isMulti);
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

    querybuilder.customOperations = customOps;
    var filters = mapParamtersToFilters(parametrs);
    querybuilder.fields = filters;
    querybuilder.value = JSON.parse(modelCopy.parameters);


    fetch("/Tasks/GetTaskPeriods").then(x => x.json()).then(data => {
        var options = [...data].map(o => {
            var opt = document.createElement("option");
            opt.value = o.value;
            opt.innerText = o.text;
            if (modelCopy.period == opt.value)
                opt.selected = true;
            return opt;
        });
        periodDorpDown.intialize([...options]);

    });
    fetch("/Tasks/GetMonthes").then(x => x.json()).then(data => {
        var options = [...data].map(o => {
            var opt = document.createElement("option");
            opt.value = o.value;
            opt.innerText = o.text;
            if (modelCopy.month == opt.value) {
                opt.selected = true;

            }
            return opt;
        });
        monthDropDown.intialize([...options]);
        if (modelCopy.month)
            monthDropDown.enable();

    });
    fetch("/Tasks/GetDays").then(x => x.json()).then(data => {
        var options = [...data].map(o => {
            var opt = document.createElement("option");
            opt.value = o.value;
            opt.innerText = o.text;
            if (modelCopy.dayOfWeek == opt.value) {
                opt.selected = true;

            }
            return opt;
        });
        weekDayDropDown.intialize([...options]);
        if (modelCopy.dayOfWeek)
            weekDayDropDown.enable();

    });



    if (modelCopy.mails && modelCopy.mails.length > 0) {
        modelCopy.mails.forEach(mail => mailsInput.addMail(mail))

    }
    console.log(timePicker);


    if (modelCopy.hour || modelCopy.minute) {
        timePicker.disabled = false;
    }
    timePicker.value = `${modelCopy.hour ?? "00"}:${modelCopy.minute ?? "00"}`


    if (!modelCopy.endOfMonth && modelCopy.day && modelCopy.month) {
        var year = new Date().getFullYear();
        calender.selectedDates = [`${year}-${modelCopy.month}-${modelCopy.day}`]
        calender.disabled = false;
    }
    ////reportsDropDown.intialize([Model.reportName]);
    //taskDescInput.intialize([Model.description]);
    //querybuilder.value = 

};



function prePareDataToSelectField(options, selectedOption) {
    options.forEach((option) => {
        if (option.value === selectedOption) {
            option
        }
    })
}




var mailsDiv = document.getElementById("mailsDiv");





var form = document.getElementById("EditTaskForm");
form.onsubmit = async (e) => {
    e.preventDefault();
    var endofMonth = endofmonthSwitch.status;
    var report = reportsDropDown.value.value;
    if (!report || report == "") {
        toastObj.icon = 'error';
        toastObj.text = "You should select a report first, select and try again";
        toastObj.heading = "Add new Task Status";
        $.toast(toastObj);
        return;
    }
    var taskName = taskNameInput.value;
    var taskDesc = taskDescInput.value;


    if (!taskName || report == "") {
        toastObj.icon = 'error';
        toastObj.text = "Give the task a name";
        toastObj.heading = "Add new Task Status";
        $.toast(toastObj);
        return;
    }

    if (!querybuilder.value || querybuilder.value.length == 0) {
        toastObj.icon = 'error';
        toastObj.text = "you should select some filters";
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


    var taskTime = {
        DayOfWeek: null,
        Month: null,
        Day: null,
        Hour: null,
        Minute: null,
    };




    var period = parseInt(periodDorpDown.value.value);

    if (isNaN(period)) {
        toastObj.icon = 'error';
        toastObj.text = "select a period";
        toastObj.heading = "Add new Task Status";
        $.toast(toastObj);
        return;
    }

    // var weekDay = parseInt(weekDayDropDown.value);

    if (period >= 2) {
        var minute = timePicker.value.getMinutes();
        taskTime.Minute = minute;

    }

    if (period > 2) {
        var hour = timePicker.value.getHours();
        taskTime.Hour = hour;
    }

    if (period == 4) {
        var weekDay = parseInt(weekDayDropDown.value.value);
        if (isNaN(weekDay)) {
            toastObj.icon = 'error';
            toastObj.text = "select a week day";
            toastObj.heading = "Add new Task Status";
            $.toast(toastObj);
            return;
        }
        taskTime.DayOfWeek = weekDay;
    }

    if (period >= 5) {
        if (!endofmonthSwitch.status) {
            var day = calender.selectedDates[0].getDate();
            taskTime.Day = day;
        }
        
        
        taskTime.EndOfMonth = endofMonth;
    }


    if (period == 6 || period == 7) {
        var month = parseInt(monthDropDown.value.value);
        if (isNaN(month)) {
            toastObj.icon = 'error';
            toastObj.text = "select a month";
            toastObj.heading = "Add new Task Status";
            $.toast(toastObj);
            return;
        }
        taskTime.Month = month;
    }
    var mails = mailsInput.getMails();

    if (mailSwitch.status && (!mails || mails.length == 0)) {
        toastObj.icon = 'error';
        toastObj.text = "type at least one mail to send files to";
        toastObj.heading = "Add new Task Status";
        $.toast(toastObj);
        return;
    }
    var path = filePath.value;

    if (serverSwitch.status && (!path || path == "")) {
        toastObj.icon = 'error';
        toastObj.text = "type the path you like the files to be at";
        toastObj.heading = "Add new Task Status";
        $.toast(toastObj);
        return;
    }
    if (serverSwitch.status) {
        var validPathRes = await fetch("/Tasks/IsValidPath", {
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            },
            method: "POST",
            body: JSON.stringify(path),

        });


        if (!validPathRes.ok) {
            toastObj.icon = 'error';
            toastObj.text = "the path you provided is not correct make sure you provide a valid path on the server";
            toastObj.heading = "Add new Task Status";
            $.toast(toastObj);
            return;
        }
    }


    var reqBody = {
        Name: taskName,
        Description: taskDesc,
        ReportName: report,
        Period: period,
        Parameters: JSON.stringify(querybuilder.value),
        ...taskTime,
        MailContent: mailContent.value,
        IsMailed: mailSwitch.status,
        Mails: mailSwitch.status ? mails : [],
        IsSavedOnServer: serverSwitch.status,
        Path: serverSwitch.status ? path : null
    };


    var loader = document.getElementById("loader");
    loader.hidden = false;

    var addTaskRes = await fetch("/Tasks/EditTask/" + modelCopy.id, {
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
        },
        method: "PUT",
        body: JSON.stringify(reqBody),

    });

    if (!addTaskRes.ok) {
        loader.hidden = true;
        toastObj.icon = 'error';
        toastObj.text = "Something wrong happend while updating this task, make sure every thing is correct and try again";
        toastObj.heading = "Add new Task Status";
        $.toast(toastObj);
        return;
    }


    window.location.href = "/Tasks";




}

reportsDropDown.onSelectChange = (e) => {

    var report = reportsDropDown.value.value;
    var parametrs = parametersConfig.find(x => x.reportName == report).parameters;
    var customOps = [];
    var multifields = parametrs.filter(x => x.isMulti);
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

    querybuilder.customOperations = customOps;
    var filters = mapParamtersToFilters(parametrs);
    querybuilder.fields = filters;


}

monthDropDown.onSelectChange = (e) => {
    var date = new Date();
    date.setMonth(parseInt(monthDropDown.value.value) - 1);
    calender.selectedDates = [date];
}

periodDorpDown.onchange = (e) => {

    var period = periodDorpDown.value.value;

    var val = parseInt(period);

    timePicker.disabled = true;
    calender.disabled = true;
    if (!endofmonthDiv.classList.contains("disabledDiv")) {
        endofmonthDiv.classList.add("disabledDiv")
        endofmonthSwitch.unCheck();
    }
    weekDayDropDown.disable();
    weekDayDropDown.deSelect();
    monthDropDown.deSelect();
    monthDropDown.disable();
    timePicker.value = "00:00";
    calender.selectedDates = [];

    if (val == 2 || val == 3) {
        timePicker.disabled = false;
        timepicker.selection = val == 2 ? 'minute' : 'hour';
    }

    if (val == 4) {
        timePicker.disabled = false;
        weekDayDropDown.enable();
    }

    if (val >= 5) {
        timePicker.disabled = false;
        calender.disabled = false;
        calender.selectedDates = [new Date()]
        endofmonthDiv.classList.remove("disabledDiv")
    }

   

    if (val == 6 || val == 7) {
        endofmonthDiv.classList.remove("disabledDiv")
        monthDropDown.enable();
    }

    

  
    //if (val !== -1)
    //    disablIinputsDict[period[val]].forEach(x => x.classList.remove("disabledDiv"));
}

mailSwitch.onswitchchanged = (e) => {
    if (mailSwitch.status) {
        if (mailsDiv.classList.contains("disabledDiv"))
            mailsDiv.classList.remove("disabledDiv")
    } else {
        if (!mailsDiv.classList.contains("disabledDiv"))
            mailsDiv.classList.add("disabledDiv")
    }
}

serverSwitch.onswitchchanged = (e) => {
    if (serverSwitch.status) {
        filePath.enable();
    } else {
        filePath.disable();
    }
}

endofmonthSwitch.onswitchchanged = (e) => {
    calender.disabled = !calender.disabled;
}
