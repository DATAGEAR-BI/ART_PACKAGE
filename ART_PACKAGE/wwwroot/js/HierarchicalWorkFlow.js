fetch("/HierarchicalWorkflow/GetData").then(x => x.json()).then(
    x => {
        var data = x;
        $("#orgchart").kendoOrgChart({
            dataSource: data,
            editable: false
        });
    }
);


