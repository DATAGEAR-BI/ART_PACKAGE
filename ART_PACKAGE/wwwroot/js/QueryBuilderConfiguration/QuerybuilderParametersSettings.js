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
            //{
            //    "paraName": "AlertStatus",
            //    "paraDisplayName": "Alert Status",
            //    "isMulti": true,
            //    "type": "string",
            //    "values": {
            //        "static": ["Closed"],
            //        "url": null
            //    }
            //},
            //{
            //    "paraName": "Test",
            //    "paraDisplayName": "Test Drop Url",
            //    "isMulti": true,
            //    "type": "string",
            //    "values": {
            //        "static": ["zobry", "manga"],
            //        "url": null
            //    }
            //},
            //{
            //    "paraName": "CreateDate",
            //    "paraDisplayName": "Create Date",
            //    "type": "date",
            //}, {
            //    "paraName": "number",
            //    "paraDisplayName": "number",
            //    "type": "number",
            //}
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