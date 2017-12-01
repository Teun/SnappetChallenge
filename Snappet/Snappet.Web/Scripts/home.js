var home = {
    _dateFormat: "dd/mm/yy",
    init: function () {

        //march, 24th, 2015
        var maxDate = new Date(2015, 2, 24);
        //march, 2nd, 2015
        var minDate = new Date(2015, 2, 2);
        //main date picker
        $('#date').datepicker({
            dateFormat: home._dateFormat,
            maxDate: maxDate,
            minDate: minDate,
            onSelect: home.getDayResult,
        });
        //date pickers inside the pop up
        var from = $("#fromDate").datepicker({
            dateFormat: home._dateFormat,
            minDate: minDate,
            maxDate: maxDate,
        }).on("change", function () {
            to.datepicker("option", "minDate", home.getDate($(this)));
        }),
            to = $("#toDate").datepicker({
                dateFormat: home._dateFormat,
                minDate: minDate,
                maxDate: maxDate,
            }).on("change", function () {
                from.datepicker("option", "maxDate", home.getDate($(this)));
            });
        //set up the pop up
        $("#details").dialog({
            title: "Student progress",
            autoOpen: false,
            resizable: false,
            height: "650",
            width: 850,
            modal: true,
        });
    },

    getDate: function (element) {
        var date;
        try {
            date = $.datepicker.parseDate(home._dateFormat, element.val());
        } catch (error) {
            date = null;
        }

        return date;
    },

    getDayResult: function (dateText) {
        $.get("/home/GetDayResult", {
            dateText: dateText
        }, function (resultHtml) {
            $("#result").html(resultHtml);

            $("#result .chart").each(function () {
                var div = $(this);
                var progress = div.data("progress").split(",").map(Number);
                var labels = div.data("labels").split(",");

                div.addClass('chart-container');

                var canvas = document.createElement('canvas');
                div.append(canvas);

                var ctx = canvas.getContext('2d');
                var config = {
                    type: 'line',
                    data: {
                        labels: labels,
                        datasets: [{
                            label: 'Progress',
                            steppedLine: true,
                            data: progress,
                            borderColor: "#6085b0",
                            fill: false,
                        }]
                    },
                    options: {
                        responsive: true,
                    }
                };
                new Chart(ctx, config);
            });

            $("#result table").floatThead({
                position: 'fixed'
            });
        });
    },

    showDetailsDialog: function (studentID) {
        $("#studentID").val(studentID);
        $("#progress,#success").html("");
        $("#details").dialog("open");
        $("#details").dialog('option', 'title', 'Student ' + studentID + ' progress');
    },

    getDetails: function () {
        if ($("#fromDate").val() && $("#toDate").val()) {
            $.post("/home/GetStudentProgressDetails", {
                fromText: $("#fromDate").val(),
                toText: $("#toDate").val(),
                studentID: $("#studentID").val()
            }, function (result) {
                //generate labels with dates from to, skip weekends
                var labels = [];
                var current = home.getDate($("#fromDate"));
                var toDate = home.getDate($("#toDate"));
                while (current <= toDate) {
                    //skip sunday
                    //skip saturday
                    if (current.getDay() != 0 && current.getDay() != 6) {
                        labels.push($.datepicker.formatDate(home._dateFormat, current));
                    }
                    current.setDate(current.getDate() + 1);
                }

                var div = $("#progress");
                div.html("");
                div.addClass('chart-container');

                var canvas = document.createElement('canvas');
                div.append(canvas);

                var ctx = canvas.getContext('2d');
                var config = {
                    type: 'line',
                    data: {
                        labels: labels,
                        datasets: [{
                            label: 'Progress',
                            steppedLine: true,
                            data: result.daysProgress,
                            borderColor: "#6085b0",
                            fill: false,
                        }]
                    },
                    options: {
                        responsive: true,
                    }
                };
                new Chart(ctx, config);

                div = $("#success");
                div.html("");
                div.addClass('chart-container');

                var canvas = document.createElement('canvas');
                div.append(canvas);

                var ctx = canvas.getContext('2d');
                var config = {
                    type: 'line',
                    data: {
                        labels: labels,
                        datasets: [{
                            label: 'Success rate %',
                            steppedLine: true,
                            data: result.daysSuccessRate,
                            borderColor: "#6085b0",
                            fill: false,
                        }]
                    },
                    options: {
                        responsive: true,
                    }
                };
                new Chart(ctx, config);
            });
        }
    }
};

$(document).ready(function () {
    home.init();
});