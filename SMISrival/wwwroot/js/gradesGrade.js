var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/gradess/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "personalId", "width": "30%" },
            { "data": "codeTeacher", "width": "30%" },
            { "data": "subjects", "width": "30%" },
            { "data": "grade", "width": "30%" },


            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                    
                        &nbsp;
                        </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
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
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}