var dataTable;

$(document).ready(function () {
    LoadAllData();
})

function LoadAllData() {
    dataTable = $('#MyTable').DataTable({
        "ajax": {
            "url": "/Admin/CoverType/GetAll"
        },
        "columns": [
            { "data": "name", "width": "60%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                              <a href="/Admin/CoverType/Upsert/${data}" class="btn btn-warning">Edit</a>
                                          <a  onclick=Delete("/Admin/CoverType/Delete/${data}")  class="btn btn-danger">Delete</a>

                            </div>
                          `
                },"width":"40%"

            }
        ]
    });
}

function Delete(url) {
    swal({
        icon: "warning",
        buttons: true,
        dangerMode: true,
        title: "Are you sure you want to delete",
        text: "Deleted data Cannot be retrived"
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