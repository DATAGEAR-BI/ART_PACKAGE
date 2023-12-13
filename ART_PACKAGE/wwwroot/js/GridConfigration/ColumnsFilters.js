export const columnFilters = {

    multiSelectFilter: (column) => {
        var ops = {};
        var equal = { eq: "is equal to" };
        if (column.type === "string") ops = { string: { ...equal, isnull: "is null" } };
        else if (column.type === "date") ops = { date: equal };
        else if (column.type === "number") ops = { number: equal };
        else ops = { boolean: equal };
        return {
            ui: (element) => {
                element.removeAttr("data-bind");
                element[0].dataset.field = column.name;
                var isEnum = column.menu[0].text;
                element.kendoMultiSelect({
                    dataSource: column.menu,



                    ...(column.menu[0].text &&
                    {
                        dataTextField: "text",
                        dataValueField: "value",
                    }
                    ),
                    filter: "contains"
                });
            },
            extra: false,
            operators: ops,
        }
    }
    ,
    dateFilter: () => {
        return {
            ui: function (element) {
                element.kendoDatePicker({
                    format: "dd/MM/yyyy",
                });
            },
        }
    }
}