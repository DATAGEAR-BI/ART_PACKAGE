export const parametersConfig = [
    {
        "reportName": "AlertDetails",
        "parameters": [
            {
                "paraName": "AlertedEntityNumber",
                "paraDisplayName": "Alerted Entity Number",
                "isMulti": false,
                "type": "string"
            },
            {
                "paraName": "AlertStatus",
                "paraDisplayName": "Alert Status",
                "isMulti": true,
                "type": "string",
                "values": {
                    "static": ["Closed"],
                    "url": null
                }
            },
            {
                "paraName": "Test",
                "paraDisplayName": "Test Drop Url",
                "isMulti": true,
                "type": "string",
                "values": {
                    "static": ["zobry", "manga"],
                    "url": null
                }
            },
            {
                "paraName": "CreateDate",
                "paraDisplayName": "Create Date",
                "type": "date",
            } ,{
                "paraName": "number",
                "paraDisplayName": "number",
                "type": "number",
            }
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