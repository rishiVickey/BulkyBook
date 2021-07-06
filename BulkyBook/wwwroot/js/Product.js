

var dataTable;

$(document).ready(function () {
    loadProductTable();
})

function loadProductTable() {
    dataTable = $('#prodTbl').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "isbn", "width": "10%" },
            { "data": "author", "width": "15%" },
            { "data": "description", "width": "15%" },
            { "data": "price", "width": "10%" },
            { "data": "catagory.name", "width": "10%" },
            {"data":"coverType.name","width":"10%"},
            {
                "data": "id",
                "render": function (data) {
                    return `

                                <div class="text-center">
                                          <a href="/Admin/Product/Upsert/${data}" class="btn btn-warning">Edit</a>
                                          <button onclick=Delete("/Admin/Product/Delete/${data}") class="btn btn-danger">Delete</button>
                               </div>
                           `
                }, "width": "30%"
            }
            
        ]
    });
}


function Delete(url){
    swal({
        icon: "warning",
        title: "Are you sure you want to delete ?",
        text: "deleted data cannot be retrived later.",
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