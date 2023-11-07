

export const Actions = {

    GoToReportDetails: (e) => {
        e.preventDefault();
        var tr = $(e.target).closest("tr");
        var grid = $("#grid").data("kendoGrid");
        var data = grid.dataItem(tr);
        window.location = `/report/showreport/${data.Id}`;
    },
    editTask: (e) => {
        e.preventDefault();
        var tr = $(e.target).closest("tr");
        var grid = $("#grid").data("kendoGrid");
        var data = grid.dataItem(tr);
        console.log(data);
        //window.location = `/report/showreport/${data.Id}`;
    },
    deleteTask: async (e) => {
        e.preventDefault();
        var tr = $(e.target).closest("tr");
        var grid = $("#grid").data("kendoGrid");
        var data = grid.dataItem(tr);
        var deleteRes = await fetch(`/Tasks/DeleteTask/${data.Id}`, {
            method: "DELETE"
        });

        if (!deleteRes.ok) {
            toastObj.text = "something wrong happend while trying to delete the task ,try again later.";
            toastObj.heading = "Delete Task Status";
            toastObj.icon = 'error';
            $.toast(toastObj);
        }
        else {
            $("#grid").data("kendoGrid").dataSource.read();
            toastObj.text = "Task Deleted Successfully";
            toastObj.heading = "Delete Task Status";
            toastObj.icon = 'success';
            $.toast(toastObj);
        }
    }

}