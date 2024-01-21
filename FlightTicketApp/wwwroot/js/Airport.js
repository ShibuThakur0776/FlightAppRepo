var dataTable;
$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "Airport/GetAll"
        },
        "columns": [
            { "data": "flight.name", "width": "20%" },
            { "data": "name", "width": "20%" },
            { "data": "state", "width": "20%" },
            { "data": "airport_Type", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="text-center">
                        <a href="Airport/Upsert/${data}" class="btn btn-info">
                            <i class="fas fa-edit"></i>
                        </a>
                        <a class="btn btn-danger" onclick=Delete("Airport/Delete/${data}")>
                            <i class="fas fa-trash-alt"></i>
                        </a>
                    </div>
                    `;
                }
            }
        ]
    })
}