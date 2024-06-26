$(document).ready(function () {
    /*$("#loader").kendoLoader({
        size: "large",
        type: 'infinite-spinner'
    });*/

    // Show loader before data loading
    //$("#loader").show();

    $("#orgchart").kendoOrgChart({
        dataSource: {
            transport: {
                read: {
                    url: "/HierarchicalWorkflow/GetData",
                    dataType: "json"
                }
            },
            schema: {
                model: {
                    id: "node_id",
                    parentId: "parent_id",
                    fields: {
                        id: { field: "node_id", type: "string", nullable: false },
                        parentId: { field: "parent_id", nullable: true },
                        title: { field: "role", nullable: true },
                        name: { field: "node_id" },
                        expanded: true
                    }
                }
            },
            requestEnd: function (e) {
                // Hide spinner after data loading
                //$("#loader").hide();
            }
        },
        editable: false
    });
});


//fetch("/HierarchicalWorkflow/GetData").then(x => x.json()).then(
//    x => {
//        var data = x;
//        $("#orgchart").kendoOrgChart({
//            dataSource: data,
//            editable: false
//        });
//    }
//);

