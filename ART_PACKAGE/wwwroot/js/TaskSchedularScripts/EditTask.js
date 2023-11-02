import { parametersConfig } from "./TaskParametersSettings.js"
import { dateSetting, multiSetting } from "../Components/QueryBuilder/QueryBuilderPlugins.js"
var reportsDropDown = document.getElementById("reportsDropDown");
//add options
var model = {};

eventEmitter.on("editTaskModel", (e) => { console.log("hi"); model = e; console.log(model); });


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
