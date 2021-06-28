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
                                          <a  class="btn btn-danger">Delete</a>
                               </div>
                           `
                }, "width": "30%"
            }
            
        ]
    });
}
