var dataTable;

$(document).ready(function () {
    loadTableData();
});


function loadTableData() {
    dataTable = $('#tbl').DataTable({
        "ajax": {
            "url": "/Admin/Company/getAll"
        },
        "columns": [
            { "data": "name", "width": "17%" },
            { "data": "streetAddress", "width": "15%" },
            { "data": "city", "width": "10%" },
            { "data": "state", "width": "15%" },
            { 'data': "postalCode", "width": "10%" },
            {"data":"phoneNumber","width":"8%"},
            {
                "data": "isAuthorized", "render": function (data) {
                    if (data) {
                        return `<input type="checkbox" disabled checked />`
                    } else {
                        return `<input type="checkbox" disabled />`
                    }
                }, "width": "5%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `


<div class="text-center">
    <a href="/Admin/Company/Upsert/${data}" class="btn btn-warning">Edit</a>
    <a onclick=Delete("/Admin/Company/Delete/${data}") class="btn btn-danger">Delete</a>
</div>
                        `
                }, "width": "20%"
            }
        ]
    });
}


function Delete(url) {
    swal({
        icon: "warning",
        title: "Are you sure you want to delete ?",
        text: "Deleted data cannot be retrived later",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}