$(document).ready(function () {
    $('.nav-tabs > li:first').find('a').trigger('click');
    $('.exerciseTable').each(function() {
        $(this).DataTable({
            "processing": true,
            "serverSide": true,
            "ajax": {
                url: $(this).data("url"),
                type: "POST",
                data: function (data) {
                    return JSON.stringify(data);
                },
                contentType: "application/json",
            },
            aoColumns: [{ mData: 'LearningObjective' },
                                { mData: 'ExerciseId' },
                                { mData: 'SubmittedAnswerId' },
                                { mData: 'SubmitDateTime' },
                                 { mData: 'Difficulty' },
            { mData: 'Correct' },
             { mData: 'Progress' }
            ],
            "columnDefs": [
                    { "visible": false, "targets": 0 }
            ],
            "drawCallback": function (settings) {
                var api = this.api();
                var rows = api.rows({ page: 'current' }).nodes();
                var last = null;

                api.column(0, { page: 'current' }).data().each(function (group, i) {
                    if (last !== group) {
                        $(rows).eq(i).before(
                            '<tr class="group"><td colspan="6">Learning objective - ' + group + '</td></tr>'
                        );

                        last = group;
                    }
                });
            }
        });
    });

//$('.exerciseTable tbody').on('click', 'tr.group', function () {
//    var currentOrder = table.order()[0];
//    if (currentOrder[0] === 0 && currentOrder[1] === 'asc') {
//        table.order([0, 'desc']).draw();
//    }
//    else {
//        table.order([0, 'asc']).draw();
//    }
//});
});
