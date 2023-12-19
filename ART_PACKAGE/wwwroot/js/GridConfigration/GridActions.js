

export const Actions = {

    GoToReportDetails: (e, gridDiv) => {
        e.preventDefault();
        var tr = $(e.target).closest("tr");
        var grid = $(gridDiv).data("kendoGrid");
        var data = grid.dataItem(tr);
        window.location = `/report/showreport/${data.Id}`;
    },
    editTask: (e, gridDiv) => {
        e.preventDefault();
        var tr = $(e.target).closest("tr");
        var grid = $(gridDiv).data("kendoGrid");
        var data = grid.dataItem(tr);
        window.location = `/Tasks/EditTask/${data.Id}`;
    },
    runNow: async (e, gridDiv) => {
        e.preventDefault();
        var tr = $(e.target).closest("tr");
        var grid = $(gridDiv).data("kendoGrid");
        var data = grid.dataItem(tr);
        var runRes = await fetch(`/Tasks/RunNow/${data.Id}`, {
            method: "Post"
        });
        if (!runRes.ok) {
            toastObj.text = "something wrong happend while trying to run the task ,try again later.";
            toastObj.heading = "Run Task Status";
            toastObj.icon = 'error';
            $.toast(toastObj);
        }
        else {
            $(gridDiv).data("kendoGrid").dataSource.read();
            toastObj.text = "Task is currentlly running";
            toastObj.heading = "Run Task Status";
            toastObj.icon = 'success';
            $.toast(toastObj);
        }
        //window.location = `/report/showreport/${data.Id}`;
    },
    deleteTask: async (e , gridDiv) => {

        e.preventDefault();
        var tr = $(e.target).closest("tr");
        var grid = $(gridDiv).data("kendoGrid");
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
            $(gridDiv).data("kendoGrid").dataSource.read();
            toastObj.text = "Task Deleted Successfully";
            toastObj.heading = "Delete Task Status";
            toastObj.icon = 'success';
            $.toast(toastObj);
        }
    }

}