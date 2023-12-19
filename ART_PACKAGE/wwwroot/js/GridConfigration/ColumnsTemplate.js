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
    },

    hyperlink: (dataItem , column) => {
        return `<a class="custom-link">${dataItem[column]}</a>`
    }
    ,
    TaskMails: (dataItem, column) => {

        var Mails = JSON.parse(dataItem.MailsSerialized);
        console.log(Mails);
        var template = Mails.map(x => `<span class="badge text-bg-primary mb-1 ">${x}</span>`).join("");
        console.log(template);
        return `<div class="d-flex justify-content-around flex-wrap align-content-between">
                                            ${template}        
                   </div>`;
    }
}