const TaskPeriod = {
    0: "Never",
    1: "Minutely",
    2: "Hourly",
    3: "Daily",
    4: "Weekly",
    5: "Monthly",
    6: "Quarterly",
    7: "Yearly",
}

const DayOfWeek = {

}
export const Templates = {

    TaskPeriodTemplate: (dataItem) => {
        return TaskPeriod[dataItem.Period]
    }


}