$(document).ready(() => {
    loadDataTable();
})

const loadDataTable = () => {
    dataTable = $('#tblData').DataTable({
        "responsive": true,
        "ajax": { url: "/admin/user/getall" },
        "columns": [
            { data: 'email', "width": "15%" },
            { data: 'firstName', "width": "20%" },
            { data: 'lastName', "width": "20%" },
            { data: 'role', "width": "15%" },
            {
                data: { id: "id", lockoutEnd:"lockoutEnd" },
                width: "30%",
                "render": (data) => {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();

                    if (lockout > today) {
                        return `<div class="btn-group w-100 gap-2">
                                    <button onClick=LockUnlock('${data.id}') class="d-flex gap-1 w-10 justify-content-center align-items-center btn btn-danger">
                                        <i class="bi bi-lock-fill"></i>
                                    </button>
                                    <button onClick=Update('/Admin/User/Update?id=${data.id}') class="d-flex gap-1 w-50 justify-content-center align-items-center btn btn-dark">
                                        <i class="bi bi-pen"> Edytuj</i>
                                    </button>
                                    <button onClick=Delete('${data.id}') class="d-flex gap-1 w-50 justify-content-center align-items-center btn btn-danger">
                                        <i class="bi bi-trash"> Usuń</i>
                                    </button>
                                </div>`
                    } else {
                        return `<div class="btn-group w-100 gap-2">
                                    <button onClick=LockUnlock('${data.id}') class="d-flex gap-1 w-10 justify-content-center align-items-center btn btn-success">
                                        <i class="bi bi-unlock-fill"></i>
                                    </button>
                                    <button onClick=Update('/Admin/User/Update?id=${data.id}') class="d-flex gap-1 w-50 justify-content-center align-items-center btn btn-dark">
                                        <i class="bi bi-pen"> Edytuj</i>
                                    </button>
                                    <button onClick=Delete('${data.id}') class="d-flex gap-1 w-50 justify-content-center align-items-center btn btn-danger">
                                        <i class="bi bi-trash"> Usuń</i>
                                    </button>
                                </div>`
                    }
                }
            }
        ]
    })
    dataTable.ajax.reload();
}

const LockUnlock = (id) => {
    $.ajax({
        type: 'POST',
        url: '/Admin/User/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: (data) => {
            if (data.success) {
                console.log("locking/unlocking success");
                dataTable.ajax.reload();
            }     
        }
    })
}

const Delete = (id) => {
    $.ajax({
        type: 'DELETE',
        url: '/Admin/User/Delete',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: (data) => {
            if (data.success) {
                console.log("Deleting success");
                dataTable.ajax.reload();
            }
        }
    }) 
}

const Update = (url) => {
    window.location.href = url;
}

