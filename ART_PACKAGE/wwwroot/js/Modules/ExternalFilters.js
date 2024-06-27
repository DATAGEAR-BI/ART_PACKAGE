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
function getLastTenYearsAsStrings() {
    const currentYear = new Date().getFullYear();
    return Array.from({ length: 10 }, (_, i) => (currentYear - i).toString());
}
function getLastTenYears() {
    const currentYear = new Date().getFullYear();
    const years = [];

    // Generate the last 10 years
    for (let i = 0; i < 10; i++) {
        years.push(currentYear - i);
    }

    // Sort the years in descending order (not necessary as we already generated them in descending order)
    years.sort((a, b) => b - a);

    return years;
}

function yearsMultiSelectSetting() {
    var vals = getLastTenYearsAsStrings();

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
    UserPerformanceSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
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
            ]
        },
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },
    CRPSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
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
            ]
        },
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },
    AlertAgeSummery: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
            ]
        },
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },
    //AML
    AlertSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
            ]
        }
        ,
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },
    CasesSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
            ]
        }
        ,
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },
    CustomersSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
            ]
        }
        ,
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },
    RiskClassSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
            ]
        }
        ,
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },

    //GoAml
    GOAMLReportsSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
            ]
        }
        ,
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },

    //DGAML
    DGAMLAlertSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
            ]
        }
        ,
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },
    DGAMLCustomersSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
            ]
        }
        ,
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },
    DGAMLExternalCustomerSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
            ]
        }
        ,
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },
    DGAMLCasesSummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
            ]
        }
        ,
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },

    //FATCA
    FATCASummary: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
            ]
        }
        ,
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },
/*    NonStaffGOAMLPerCrime: {
        filters: [],
        get filters() {
            return [
                { id: "startdate", field: "startdate", label: "Start Date", operators: ['equal'], type: "date", ...dateSetting },
                { id: "enddate", field: "enddate", label: "End Date", operators: ['equal'], type: "date", ...dateSetting },
            ]
        },
        rules: [

            { id: "startdate", field: "startdate", label: "Start Date", type: "date", operator: "equal", value: yesterday() },
            { id: "enddate", field: "enddate", label: "End Date", type: "date", operator: "equal", value: currentDate() },

        ]
    },*/
    NonStaffGOAMLPerCrime: {
        filters: [],
        get filters() {
            return [
                { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() },
            ]
        }
        ,
        rules: [

            { id: "year", field: "year", label: "Year", type: "string", operator: "in", value: new Date().getFullYear().toString() },

        ]
    },
    AMLCasesPerRegion: {
        filters: [],
        get filters() {
            return [
                { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() },
            ];
        },
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in", value: new Date().getFullYear().toString() },
        ]
    },
    AMLCasesPerTransactionType: {
        filters: [],
        get filters() {
            return [
                { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() },
            ];
        },
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in", value: new Date().getFullYear().toString() },
        ]
    },
    Bottom5AMLBranches: {
        filters: [],
        get filters() {
            return [
                { id: "year", field: "year", label: "Year", operators: ['in'], type: "string", optional: false, ...yearsMultiSelectSetting() },
            ];
        },
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in", value: new Date().getFullYear().toString() },
        ]
    },
    Bottom5GOAMLBranches: {
        filters: [],
        get filters() {
            return [
                { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() },
            ];
        },
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in", value: new Date().getFullYear().toString() },
        ]
    },
    Bottom5SanctionBranches: {
        filters: [],
        get filters() {
            return [
                { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() },
            ];
        },
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in", value: new Date().getFullYear().toString() },
        ]
    },
    CasesPerProduct: {
        filters: [],
        get filters() {
            return [
                { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() },
            ];
        },
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in", value: new Date().getFullYear().toString() },
        ]
    },
    CasesPerRegion: {
        filters: [],
        get filters() {
            return [
                { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() },
            ];
        },
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in", value: new Date().getFullYear().toString() },
        ]
    },
    CasesPerYear: {
        filters: [],
        get filters() {
            return [
                { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() },
            ];
        },
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in", value: new Date().getFullYear().toString() },
        ]
    },
    NonStaffGOAMLPerProduct: {
        filters: [],
        get filters() {
            return [
                { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() },
            ];
        },
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in", value: new Date().getFullYear().toString() },
        ]
    },
    Top5AMLBranches: {
        filters: [],
        get filters() {
            return [
                { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() },
            ];
        },
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in", value: new Date().getFullYear().toString() },
        ]
    },
    Top5GOAMLBranches: {
        filters: [],
        get filters() {
            return [
                { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() },
            ];
        },
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in", value: new Date().getFullYear().toString() },
        ]
    },
    Top5SanctionBranches: {
        filters: [],
        get filters() {
            return [
                { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() },
            ];
        },
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in", value: new Date().getFullYear().toString() },
        ]
    },






    ////////////////

    NonStaffGOAMLPerProduct: {
        filters: [
            { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() }
        ],
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in",value: new Date().getFullYear().toString() }
        ]
    },
    NonStaffGOAMLperRegion: {
        filters: [
            { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() }
        ],
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in",value: new Date().getFullYear().toString() }
        ]
    },
    NonStaffGOAMLSANCTIONPerProduct: {
        filters: [
            { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() }
        ],
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in",value: new Date().getFullYear().toString() }
        ]
    },
    NonStaffGOAMLSANCTIONPerRegion: {
        filters: [
            { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() }
        ],
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in",value: new Date().getFullYear().toString() }
        ]
    },
    NonStaffGOAMLSANCTIONSummary: {
        filters: [
            { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() }
        ],
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in",value: new Date().getFullYear().toString() }
        ]
    },
    StaffGOAMLperCrime: {
        filters: [
            { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() }
        ],
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in",value: new Date().getFullYear().toString() }
        ]
    },
    StaffGOAMLperProduct: {
        filters: [
            { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() }
        ],
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in",value: new Date().getFullYear().toString() }
        ]
    },
    StaffGOAMLperRegion: {
        filters: [
            { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() }
        ],
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in",value: new Date().getFullYear().toString() }
        ]
    },
    StaffGOAMLSANCTIONPerProduct: {
        filters: [
            { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() }
        ],
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in",value: new Date().getFullYear().toString() }
        ]
    },
    StaffGOAMLSANCTIONPerRegion: {
        filters: [
            { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() }
        ],
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in",value: new Date().getFullYear().toString() }
        ]
    },
    StaffGOAMLSANCTIONSummary: {
        filters: [
            { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() }
        ],
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in",value: new Date().getFullYear().toString() }
        ]
    },
    UnusualAndSuspectedAlerts: {
        filters: [
            { id: "year", field: "year", label: "Year",  type: "string", optional: false, ...yearsMultiSelectSetting() }
        ],
        rules: [
            { id: "year", field: "year", label: "Year", type: "string", operator: "in", value: new Date().getFullYear().toString() }
        ]
    }

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


