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
                    id: "id",
                    parentId: "parentId",
                    expanded: true,
                    fields: {
                        id: { field: "id", type: "string", nullable: false },
                        parentId: { field: "parentId", nullable: true },
                        title: { field: "title", nullable: true },
                        name: { field: "id" }
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

