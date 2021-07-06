var dataTable;

$(document).ready(function () {
    LoadUserTable();
});

function LoadUserTable() {
    dataTable = $('#UserTbl').DataTable({
        "ajax": {
            "url": "/Admin/User/GetAll"
        },
        "columns": [
            { "data": "name", "width": "12%" },
            { "data": "streetAddress", "width": "12%" },
            { "data": "city", "width": "12%" },
            { "data": "state", "width": "12%" },
            { "data": "phoneNumber", "width": "12%" },
            { "data": "company.name", "width": "12%" },
            { "data": "role", "width": "12%" },
        ]
    });
}