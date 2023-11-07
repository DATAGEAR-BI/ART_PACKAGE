const TaskPeriod = {
    0: "Minutely",
    1: "Hourly",
    2: "Daily",
    3: "Weekly",
    4: "Monthly",
    5: "Yearly",
    6: "Never"
}

const DayOfWeek = {

}
export const Templates = {
    TaskPeriodTemplate: (dataItem) => {
        return TaskPeriod[dataItem.Period]
    },

    amlanalysisPred: (dataItem) => {
        if (dataItem.Prediction < 0.39 && dataItem.Prediction >= 0) { return "<span class='glyphicon glyphicon-alert' style='color: dodgerblue'></span>" + "  " + kendo.format('{0:p}', dataItem.Prediction); }
        if (dataItem.Prediction < 0.699 && dataItem.Prediction >= 0.4) { return "<span class='glyphicon glyphicon-alert' style='color: darkorange'></span>" + " " + kendo.format('{0:p}', dataItem.Prediction); }
        if (dataItem.Prediction > 0.699) { return "<span class='glyphicon glyphicon-alert' style='color: red'></span>" + " " + kendo.format('{0:p}', dataItem.Prediction); }

    }
}