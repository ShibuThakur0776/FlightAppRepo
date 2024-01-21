var dataTable;
$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "Flight/GetAll"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "model", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return`
                    <div class="text-center">
                        <a href="Flight/Upsert/${data}" class="btn btn-info">
                            <i class="fas fa-edit"></i>&nbsp;
                        </a>
                        <a class="btn btn-danger" onclick=Delete("Flight/Delete/${data}")>
                            <i class="fas fa-trash"></i>&nbsp;
                        </a>
                    </div>
                    `;
                }
            }
        ]
    })
}

/*{
  "id": 16,
  "name": "Boeing 707",
  "picture": "",
  "model": 707,
  "airline_Name": 0,
  "departure_Time": "2023-12-22T06:45:58.749",
  "arrival_Time": "2023-12-22T06:45:58.749",
  "departure_State": "Chandigarh",
  "arrival_State": "Delhi"
} */