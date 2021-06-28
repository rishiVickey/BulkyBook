var dataTable;

$(document).ready(function () {
    loadData();
})

function loadData() {
    dataTable = $('#myTbl').DataTable({
        "ajax": {
            "url": "/Admin/Catagory/GetAll"
        },
        "columns": [
            {
                "data": "name", "width": "60%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `

                                <div class="text-center">
                                          <a href="/Admin/Catagory/Upsert/${data}" class="btn btn-warning">Edit</a>
                                          <a onclick=Delete("/Admin/Catagory/Delete/${data}") class="btn btn-danger">Delete</a>
                               </div>

                           `
                }, "width": "40%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Are You Sure,you want to delete?",
        text: "Cannot be retrived later",
        dangerMode: true,
        buttons: true,
        icon: "warning"

    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "Delete",
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

