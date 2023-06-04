var dateSetting = {
    plugin: 'datepicker',
    plugin_config: {
        format: 'yyyy-mm-dd',
        todayBtn: 'linked',
        todayHighlight: true,
        autoclose: true
    }
};

function multiSelectSetting(url) {
    var vals = [];


    $.ajax({
        url: url,
        type: "GET",
        async: false,
        dataType: "json",
        success: function (data) {
            vals = data;
        }
    });


    console.log(vals);


    return {
        multiple: true,
        input: 'select',
        validation: false,
        operators: ['in'],
        values: vals,
        value_separator: ",",
        plugin: 'selectpicker',
        plugin_config: {
            actionsBox: true,
            liveSearch: true,
            width: 'auto',
            selectedTextFormat: 'count',
            liveSearchStyle: 'contains',
        },
    }
}
function currentDate() {
    var d = new Date();
    return d.toISOString().slice(0, 10);
}


function yesterday() {
    var d = new Date(new Date().getTime() - 24 * 60 * 60 * 1000);
    return d.toISOString().slice(0, 10);
}
export const Filters = {

    SanctionAllCasesSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "case_id", field: "case_id", label: "Case ID", operators: ['equal'], type: "string" },
                { id: "case_status", field: "case_status", label: "Case Status", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionAllCasesStatusDropDown") },
                { id: "case_type", field: "case_type", label: "Case Type", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionAllCasesTypesDropDown") },
                { id: "create_user_category", field: "create_user_category", label: "Create User Category", type: "string", ...multiSelectSetting("/DropDownHelper/GetUserMkerCheckerDropDown") },
                { id: "lock_user_category", field: "lock_user_category", label: "Lock User Category", type: "string", ...multiSelectSetting("/DropDownHelper/GetUserMkerCheckerDropDown") },
                { id: "prev_status_user_category", field: "prev_status_user_category", label: "Previous Status User Category", type: "string", ...multiSelectSetting("/DropDownHelper/GetUserMkerCheckerDropDown") },

            ]
        }
        ,
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },
    SanctionAllCasesDetailNew: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
                //    { id: "case_id", field: "case_id", label: "Case ID", operators: ['equal'], type: "string" },
                //    { id: "case_status", field: "case_status", label: "Case Status", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionAllCasesStatusDropDown") },
                //    { id: "case_type", field: "case_type", label: "Case Type", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionAllCasesTypesDropDown") },
            ]
        }
        ,
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },

    SanctionManualSearchSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "searchUser", field: "searchUser", label: "Search User", type: "string" },
                {
                    id: "searchMatch", field: "searchMatch", label: "Search Match", type: "string", multiple: true,
                    input: 'select',
                    validation: false,
                    operators: ['in'],
                    values: {
                        "Found": "Found",
                        "Not Found": "Not Found"
                    },
                    value_separator: ",",
                    plugin: 'selectpicker',
                    plugin_config: {
                        actionsBox: true,
                        liveSearch: true,
                        width: 'auto',
                        selectedTextFormat: 'count',
                        liveSearchStyle: 'contains',
                    },
                },
                { id: "sourceType", field: "sourceType", label: "Source Type", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionManualSearchSourceTypesDropDown") },
            ]
        },
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },


    SanctionListUpdateSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "entity_name", field: "entity_name", operators: ['equal'], label: "Entity Name", type: "string" },
                { id: "entity_watch_list_number", operators: ['equal'], field: "entity_watch_list_number", label: "Entity Watch List Number", type: "string" },
                {
                    id: "status", field: "status", label: "Status", type: "string", multiple: true,
                    input: 'select',
                    validation: false,
                    operators: ['in'],
                    values: {
                        "ADDED": "ADDED",
                        "UPDATED": "UPDATED"
                    },
                    value_separator: ",",
                    plugin: 'selectpicker',
                    plugin_config: {
                        actionsBox: true,
                        liveSearch: true,
                        width: 'auto',
                        selectedTextFormat: 'count',
                        liveSearchStyle: 'contains',
                    },
                },
                {
                    id: "type", field: "type", label: "Type", type: "string", multiple: true,
                    input: 'select',
                    validation: false,
                    operators: ['in'],
                    values: {
                        "UNKNOWN": "UNKNOWN",
                        "INDIVIDUAL": "INDIVIDUAL",
                        "ORGANIZATION": "ORGANIZATION"
                    },
                    value_separator: ",",
                    plugin: 'selectpicker',
                    plugin_config: {
                        actionsBox: true,
                        liveSearch: true,
                        width: 'auto',
                        selectedTextFormat: 'count',
                        liveSearchStyle: 'contains',
                    },
                },
                {
                    id: "watch_list_name", field: "Watch_list_name", label: "Watch List Name", type: "string", ...multiSelectSetting("/DropDownHelper/GetWatchListNameDropDown")
                },
                //{ id: "ColumnsNames", field: "ColumnsNames", label: "ColumnsNames", type: "string" }
            ]
        },
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },


    PartyListUpdateSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "party_name", field: "party_name", label: "Party Name", operators: ['equal'], type: "string" },
                { id: "party_number", field: "party_number", label: "Party Number", operators: ['equal'], type: "string" },
                {
                    id: "party_type", field: "party_type", label: "Party Type", type: "string", multiple: true,
                    input: 'select',
                    validation: false,
                    operators: ['in'],
                    values: {
                        "UNKNOWN": "UNKNOWN",
                        "INDIVIDUAL": "INDIVIDUAL",
                        "ORGANIZATION": "ORGANIZATION"
                    },
                    value_separator: ",",
                    plugin: 'selectpicker',
                    plugin_config: {
                        actionsBox: true,
                        liveSearch: true,
                        width: 'auto',
                        selectedTextFormat: 'count',
                        liveSearchStyle: 'contains',
                    },
                },
                { id: "party_status", field: "party_status", label: "Party Status", type: "string", ...multiSelectSetting("/DropDownHelper/GetPartyStatusDropDown") },
                {
                    id: "action_status", field: "action_status", label: "Action Status", type: "string", multiple: true,
                    input: 'select',
                    validation: false,
                    operators: ['in'],
                    values: {
                        "ADDED": "ADDED",
                        "UPDATED": "UPDATED",
                        'REMOVED': 'REMOVED'
                    },
                    value_separator: ",",
                    plugin: 'selectpicker',
                    plugin_config: {
                        actionsBox: true,
                        liveSearch: true,
                        width: 'auto',
                        selectedTextFormat: 'count',
                        liveSearchStyle: 'contains',
                    },
                },

            ]
        },
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },

    UserPerfAvgPrevStatusUser: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "case_id", field: "case_id", label: "Case ID", operators: ['equal'], type: "string" },
                { id: "case_status", field: "case_status", label: "Case Status", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionCasesStatusDropDown") },
                { id: "case_type", field: "case_type", label: "Case Type", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionAllCasesTypesDropDown") },
                { id: "create_user", field: "create_user", label: "Create User", type: "string", ...multiSelectSetting("/DropDownHelper/GetCreateUserDropDown") },
                { id: "prev_status_user", field: "prev_status_user", label: "Prev Status User", type: "string", ...multiSelectSetting("/DropDownHelper/GetPrevStatusUserDropDown") },
                { id: "prev_status", field: "prev_status", label: "Prev Status", type: "string", ...multiSelectSetting("/DropDownHelper/GetPrevStatusDropDown") },
                { id: "create_user_category", field: "create_user_category", label: "Create User Category", type: "string", ...multiSelectSetting("/DropDownHelper/GetUserMkerCheckerDropDown") },
                { id: "lock_user_category", field: "lock_user_category", label: "Lock User Category", type: "string", ...multiSelectSetting("/DropDownHelper/GetUserMkerCheckerDropDown") },
                { id: "prev_status_user_category", field: "prev_status_user_category", label: "Previous Status User Category", type: "string", ...multiSelectSetting("/DropDownHelper/GetUserMkerCheckerDropDown") },
            ]
        },
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },

    UserPerfAvgPrevUser: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "case_id", field: "case_id", label: "Case ID", operators: ['equal'], type: "string" },
                { id: "case_status", field: "case_status", label: "Case Status", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionCasesStatusDropDown") },
                { id: "case_type", field: "case_type", label: "Case Type", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionAllCasesTypesDropDown") },
                { id: "create_user", field: "create_user", label: "Create User", type: "string", ...multiSelectSetting("/DropDownHelper/GetCreateUserDropDown") },
                { id: "prev_status_user", field: "prev_status_user", label: "Prev Status User", type: "string", ...multiSelectSetting("/DropDownHelper/GetPrevStatusUserDropDown") },
                { id: "prev_status", field: "prev_status", label: "Prev Status", type: "string", ...multiSelectSetting("/DropDownHelper/GetPrevStatusDropDown") },
                { id: "create_user_category", field: "create_user_category", label: "Create User Category", type: "string", ...multiSelectSetting("/DropDownHelper/GetUserMkerCheckerDropDown") },
                { id: "lock_user_category", field: "lock_user_category", label: "Lock User Category", type: "string", ...multiSelectSetting("/DropDownHelper/GetUserMkerCheckerDropDown") },
                { id: "prev_status_user_category", field: "prev_status_user_category", label: "Previous Status User Category", type: "string", ...multiSelectSetting("/DropDownHelper/GetUserMkerCheckerDropDown") },
            ]
        },
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },

    UserPerformanceSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "case_id", field: "case_id", label: "Case ID", operators: ['equal'], type: "string" },
                { id: "case_status", field: "case_status", label: "Case Status", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionCasesStatusDropDown") },
                { id: "case_type", field: "case_type", label: "Case Type", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionAllCasesTypesDropDown") },
                { id: "create_user", field: "create_user", label: "Create User", type: "string", ...multiSelectSetting("/DropDownHelper/GetCreateUserDropDown") },
                { id: "prev_status_user", field: "prev_status_user", label: "Prev Status User", type: "string", ...multiSelectSetting("/DropDownHelper/GetPrevStatusUserDropDown") },
                { id: "prev_status", field: "prev_status", label: "Prev Status", type: "string", ...multiSelectSetting("/DropDownHelper/GetPrevStatusDropDown") },
                { id: "create_user_category", field: "create_user_category", label: "Create User Category", type: "string", ...multiSelectSetting("/DropDownHelper/GetUserMkerCheckerDropDown") },
                { id: "lock_user_category", field: "lock_user_category", label: "Lock User Category", type: "string", ...multiSelectSetting("/DropDownHelper/GetUserMkerCheckerDropDown") },
                { id: "prev_status_user_category", field: "prev_status_user_category", label: "Previous Status User Category", type: "string", ...multiSelectSetting("/DropDownHelper/GetUserMkerCheckerDropDown") },

            ]
        },
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },

    SystemPerformanceSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "case_id", field: "case_id", label: "Case ID", operators: ['equal'], type: "string" },
                { id: "case_status", field: "case_status", label: "Case Status", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionCasesStatusDropDown") },
                { id: "case_type", field: "case_type", label: "Case Type", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionAllCasesTypesDropDown") },
                { id: "create_user_category", field: "create_user_category", label: "Create User Category", type: "string", ...multiSelectSetting("/DropDownHelper/GetUserMkerCheckerDropDown") },
                { id: "lock_user_category", field: "lock_user_category", label: "Lock User Category", type: "string", ...multiSelectSetting("/DropDownHelper/GetUserMkerCheckerDropDown") },
                { id: "prev_status_user_category", field: "prev_status_user_category", label: "Previous Status User Category", type: "string", ...multiSelectSetting("/DropDownHelper/GetUserMkerCheckerDropDown") },


            ]
        },
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },
    UserPerformancePerActionUser: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "case_id", field: "case_id", label: "Case ID", operators: ['equal'], type: "string" },
                //{ id: "case_status", field: "case_status", label: "Case Status", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionCasesStatusDropDown") },
                //{ id: "case_type", field: "case_type", label: "Case Type", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionAllCasesTypesDropDown") },
                //{ id: "create_user", field: "create_user", label: "Create User", type: "string", ...multiSelectSetting("/DropDownHelper/GetCreateUserDropDown") },
                //{ id: "prev_status_user", field: "prev_status_user", label: "Prev Status User", type: "string", ...multiSelectSetting("/DropDownHelper/GetPrevStatusUserDropDown") },
                //{ id: "prev_status", field: "prev_status", label: "Prev Status", type: "string", ...multiSelectSetting("/DropDownHelper/GetPrevStatusDropDown") },
                ////{ id: "ColumnsNames", field: "ColumnsNames", label: "ColumnsNames", type: "string" }
            ]
        },
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },
    UserPerformPerAction: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
                //{ id: "case_id", field: "case_id", label: "Case ID", operators: ['equal'], type: "string" },
                //{ id: "case_status", field: "case_status", label: "Case Status", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionCasesStatusDropDown") },
                //{ id: "case_type", field: "case_type", label: "Case Type", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionAllCasesTypesDropDown") },

            ]
        },
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },
    UserPerformancePerUserAndAction: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
                //{ id: "case_id", field: "case_id", label: "Case ID", operators: ['equal'], type: "string" },
                //{ id: "case_status", field: "case_status", label: "Case Status", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionCasesStatusDropDown") },
                //{ id: "case_type", field: "case_type", label: "Case Type", type: "string", ...multiSelectSetting("/DropDownHelper/GetSanctionAllCasesTypesDropDown") },
                //{ id: "create_user", field: "create_user", label: "Create User", type: "string", ...multiSelectSetting("/DropDownHelper/GetCreateUserDropDown") },
                //{ id: "prev_status_user", field: "prev_status_user", label: "Prev Status User", type: "string", ...multiSelectSetting("/DropDownHelper/GetPrevStatusUserDropDown") },
                //{ id: "prev_status", field: "prev_status", label: "Prev Status", type: "string", ...multiSelectSetting("/DropDownHelper/GetPrevStatusDropDown") },
                ////{ id: "ColumnsNames", field: "ColumnsNames", label: "ColumnsNames", type: "string" }
            ]
        },
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },
}


export const GoToDeatailsUrls = {

    SystemPerformanceSummary: {
        filtersOrder: ["startdate",
            "enddate",
            "case_id",
            "case_type",
            "case_status",
        ],
        url: "/SystemPerformance/Index/?"
    },
    SanctionAllCasesSummary: {
        filtersOrder: ["startdate",
            "enddate",
            "case_id",
            "case_type",
            "case_status",
        ],
        url: "/SanctionAllCasesDetails/Index/?"
    },
    UserPerformanceSummary: {
        filtersOrder: ["startdate",
            "enddate",
            "case_id",
            "case_type",
            "case_status",
            "prev_status_user",
            "create_user",
            "prev_status",
            "create_user_category",
            "lock_user_category",
            "prev_status_user_category"
        ],
        url: "/UserPerformance/Index/?"
    },
    UserPerfAvgPrevUser: {
        filtersOrder: ["startdate",
            "enddate",
            "case_id",
            "case_type",
            "case_status",
            "prev_status_user",
            "create_user",
            "prev_status",
            "create_user_category",
            "lock_user_category",
            "prev_status_user_category"
        ],
        url: "/UserPerformance/Index/?"
    },
    UserPerfAvgPrevStatusUser: {
        filtersOrder: ["startdate",
            "enddate",
            "case_id",
            "case_type",
            "case_status",
            "prev_status_user",
            "create_user",
            "prev_status",
            "create_user_category",
            "lock_user_category",
            "prev_status_user_category"
        ],
        url: "/UserPerformance/Index/?"
    },
    SanctionManualSearchSummary: {
        filtersOrder: [
            "startdate",
            "enddate",
            "searchUser",
            "searchMatch",
            "sourceType"
        ],
        url: "/SanctionManualSearchDetails/Index/?"
    },
    PartyListUpdateSummary: {
        filtersOrder: [
            "startdate",
            "enddate",
            "party_name",
            "party_number",
            "party_type",
            "party_status",
            "action_status"
        ],
        url: "/VaPartyListUpdateDetails/Index/?"
    },
    SanctionListUpdateSummary: {
        filtersOrder: [
            "startdate",
            "enddate",
            "entity_name",
            "entity_watch_list_number",
            "type",
            "watch_list_name"
        ],
        url: "/VaSanctionListUpdateDetails/Index/?"
    }
}


