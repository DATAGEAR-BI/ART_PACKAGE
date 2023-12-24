var today = new Date();
var yesterday = new Date();
yesterday.setDate(today.getDate() - 1)
export const parametersConfig = [



    {
        "reportName": "UserPerformancePerActionUser",
        "parameters": [
            {
                "paraName": "startdate",
                "paraDisplayName": "Start Date",
                "isMulti": false,
                "type": "date"
            },
            {
                "paraName": "enddate",
                "paraDisplayName": "End Date",
                "isMulti": false,
                "type": "date"
            },
        ],
        "defaultFilter": null //[
        //    ["startdate", "=", today],
        //    "and",
        //    ["enddate", "=", yesterday]
        //]
    },
    {
        "reportName": "AlertSummary",
        "parameters": [
            {
                "paraName": "startdate",
                "paraDisplayName": "Start Date",
                "isMulti": false,
                "type": "date"
            },
            {
                "paraName": "enddate",
                "paraDisplayName": "End Date",
                "isMulti": false,
                "type": "date"
            },
        ],
        "defaultFilter": [
            ["startdate", "=", today],
            "and",
            ["enddate", "=", yesterday]
        ]
    }, {
        "reportName": "CasesSummary",
        "parameters": [
            {
                "paraName": "startdate",
                "paraDisplayName": "Start Date",
                "isMulti": false,
                "type": "date"
            },
            {
                "paraName": "enddate",
                "paraDisplayName": "End Date",
                "isMulti": false,
                "type": "date"
            },
        ],
        "defaultFilter": [
            ["startdate", "=", today],
            "and",
            ["enddate", "=", yesterday]
        ]
    },


]