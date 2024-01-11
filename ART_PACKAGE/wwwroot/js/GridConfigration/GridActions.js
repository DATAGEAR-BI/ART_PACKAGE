

const UserName = document.getElementById("uid").value
localStorage.setItem("currentUser" , UserName)
export const Actions = {

    GoToReportDetails: (e, gridDiv) => {
        e.preventDefault();
        var tr = $(e.target).closest("tr");
        var grid = $(gridDiv).data("kendoGrid");
        var data = grid.dataItem(tr);
        window.location = `/report/showreport/${data.Id}`;
    },
    shareReport:async (e,gridDiv) => {
        console.log(UserName)
        try {
            let users = await (await fetch("/MyReports/GetAllUsers")).json();
            let options = users.map(u =>{
                let opt = document.createElement("option");
                opt.value = u;
                opt.innerText = u;
                return opt;
            } );
            let select = document.getElementById("recievers");
            let title = document.getElementById("sharetitle");
            let desc = document.getElementById("shareMessage");
            let tr = $(e.target).closest("tr");
            let grid = $(gridDiv).data("kendoGrid");
            let data = grid.dataItem(tr);
            title.innerHTML = `You are about to share <code style="background-color: #EEEEEE">${data.Name}</code> Report`
            select.update(options);
            $("#shareModal").modal("show");
            let shareBtn = document.getElementById("shareBtn");
            shareBtn.onclick = async () => {
                let users = [...select.value].map(x => x.value)
                if(users?.length == 0)
                {
                    toastObj.text = "something wrong happend while trying to run the task ,try again later.";
                    toastObj.heading = "Run Task Status";
                    toastObj.icon = 'error';
                    $.toast(toastObj);
                    return
                }
                
                
                var model = {
                    ShareMessage: desc.value,
                    Recievers : users,
                    ReportId : data.Id
                }
                
               var shareres =  await fetch("/report/ShareReport",
                    {
                        method : "POST",
                        headers : {
                            "content-type" : "application/json",
                        },
                        body : JSON.stringify(model)
                    })
                if(!shareres.ok){
                    toastObj.text = "something wrong happend while trying to run the task ,try again later.";
                    toastObj.heading = "Run Task Status";
                    toastObj.icon = 'error';
                    $.toast(toastObj);
                    return
                }
                toastObj.text = "something wrong happend while trying to run the task ,try again later.";
                toastObj.heading = "Run Task Status";
                toastObj.icon = 'success';
                $.toast(toastObj);
            }
            
        }
        catch (e) {
            console.error(e)
            toastObj.text = "something wrong happend while trying to run the task ,try again later.";
            toastObj.heading = "Run Task Status";
            toastObj.icon = 'error';
            $.toast(toastObj);
        }

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



export const ActionsConditions = {
    shareReport : function (dt)  {
        return dt.SharedFrom === localStorage.getItem("currentUser")
    }
}