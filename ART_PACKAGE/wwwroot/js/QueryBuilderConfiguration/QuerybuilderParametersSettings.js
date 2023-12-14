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
    },
    {
        "reportName": "AlertDetailsTest",
        "parameters": [
            {
                "paraName": "AlertedEntityNumberT",
                "paraDisplayName": "Alerted Entity NumberT",
                "isMulti": false,
                "type": "string"
            },
            {
                "paraName": "AlertStatusT",
                "paraDisplayName": "Alert StatusT",
                "isMulti": true,
                "type": "string",
                "values": {
                    "static": ["ACT", "CLS"],
                    "url": null
                }
            },
            {
                "paraName": "CreateDate",
                "paraDisplayName": "Create Date",
                "type": "date",
            }
        ]
    }

]