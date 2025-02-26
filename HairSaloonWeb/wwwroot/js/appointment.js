$(document).ready(() => {
    loadDataTable();
})

const loadDataTable = () => {
    dataTable = $('#tblData').DataTable({
        "responsive": true,
        "ajax": { url: "/admin/adminappointment/getall" },
        "columns": [
            { data: 'service.name', "width": "10%" },
            {
                data: 'date',
                "width": "8%",
                "render": (data) => {
                    let [date, time] = data.split("T");
                    return `${date}`;
                }
            },
            {
                data: 'date',
                "width": "7%",
                "render": (data) => {
                    let [date, time] = data.split("T");
                    return `${time.substring(0, 5)}`;
                }
            },
            //{
            //    data: 'service.price',
            //    "width": "10%",
            //    "render": (data) => {
            //        return `${data} zł`
            //    }
            //},
            { data: 'customerFirstName', "width": "10%" },
            { data: 'customerEmail', "width": "10%" },
            { data: 'customerPhoneNumber', "width": "10%" },
            {
                data: null,
                "width": "10%",
                "render": (row) => {
                    return `${row.employee.firstName} ${row.employee.lastName}`
                }
            },
            {
                data: 'id',
                width: "30%",
                "render": (data) => {
                    return `<div class="btn-group w-100 gap-2">
                        <button onClick=Details('/Admin/AdminAppointment/Details?id=${data}') class="d-flex gap-1 w-50 justify-content-center align-items-center btn btn-dark"><i class="bi bi-pen"> Szczegóły/edycja</i></button>
                        <button onClick=Delete('/Admin/AdminAppointment/Delete?id=${data}') class="d-flex gap-1 w-50 justify-content-center align-items-center btn btn-danger"><i class="bi bi-trash"> Usuń</i></button>
                    </div>`
                }
            }
        ]
    })
    dataTable.ajax.reload();
}

const Delete = (url) => {
    $.ajax({
        url: url,
        type: 'DELETE',
        success: (data) => {
            dataTable.ajax.reload();
        }
    }) 
}

const Details = (url) => {
    window.location.href = url;
}

