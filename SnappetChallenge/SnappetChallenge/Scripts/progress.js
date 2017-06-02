$(document).ready(
    function () {
        BuildAssignments();
        BuildSubjects();
        BuildDifficultyChart();
    }
);

BuildAssignments = function () {
    $.getJSON("/Progress/Assignments", function (data) {
        var sortedByAmountDone = data.sort(function (a, b) { return a.TotalAssignments - b.TotalAssignments; });
        var extractId = function (item) {
            return item.UserId;
        };
        var extractValue = function (item) {
            return item.TotalAssignments;
        };
        CreateResultTable(sortedByAmountDone, 5, "most_completed_assignments", extractId, extractValue, ["Student ID", "# Completed"], "#num_assignments", true);
        CreateResultTable(sortedByAmountDone, 5, "least_completed_assignments", extractId, extractValue, ["Student ID", "# Completed"], "#num_assignments");

        $.each(data, function (key) {
            data[key].PercentageCorrect = data[key].CorrectAssignments / data[key].TotalAssignments;
        });
        extractValue = function (item) {
            return Math.round(item.PercentageCorrect * 100) + "%";
        };
        var sortedByPercentageCorrect = data.sort(function (a, b) { return a.PercentageCorrect - b.PercentageCorrect; });
        CreateResultTable(sortedByPercentageCorrect, 5, "most_assignments_correct", extractId, extractValue, ["Student ID", "Correct"], "#perc_assignments", true);
        CreateResultTable(sortedByPercentageCorrect, 5, "least_assignments_correct", extractId, extractValue, ["Student ID", "Correct"], "#perc_assignments");
    });
};

BuildSubjects = function () {
    $.getJSON("/Progress/Subjects", function (data) {
        var sortedByAmountDone = data.sort(function (a, b) { return a.TotalAssignments - b.TotalAssignments; });
        var extractId = function (item) {
            return item.Subject;
        };
        var extractValue = function (item) {
            return item.TotalAssignments;
        };
        CreateResultTable(sortedByAmountDone, 5, "most_completed_subjects", extractId, extractValue, ["Subject", "# Completed"], "#num_subjects", true);
        CreateResultTable(sortedByAmountDone, 5, "least_completed_subjects", extractId, extractValue, ["Subject", "# Completed"], "#num_subjects");

        $.each(data, function (key) {
            data[key].PercentageCorrect = data[key].CorrectAssignments / data[key].TotalAssignments;
        });
        var sortedByPercentageCorrect = data.sort(function (a, b) { return a.PercentageCorrect - b.PercentageCorrect; });
        extractValue = function (item) {
            return Math.round(item.PercentageCorrect * 100) + "%";
        };
        CreateResultTable(sortedByPercentageCorrect, 5, "most_subjects_correct", extractId, extractValue, ["Subject", "Correct"], "#perc_subjects", true);
        CreateResultTable(sortedByPercentageCorrect, 5, "least_subjects_correct", extractId, extractValue, ["Subject", "Correct"], "#perc_subjects");
    });
};

CreateResultTable = function (sorted, amount, elemId, extractId, extractValue, columnHeaders, selector, desc = false) {
    $("#" + elemId).remove();
    amount = Math.min(amount, sorted.length);
    var items = ["<tr><th>Rank</th><th>" + columnHeaders[0] + "</th><th>" + columnHeaders[1] + "</th></tr>"];
    for (i = 0; i < amount; i++) {
        var index = desc ? sorted.length - (i + 1) : i;
        items.push("<tr><td>#" + (sorted.length - index) + "</td><td>" + extractId(sorted[index]) + "</td><td>" + extractValue(sorted[index]) + "</td></tr>");
    }
    $("<table/>", { "id": elemId, "class": "result_table " + (desc ? "most" : "least"), html: items.join("") }).appendTo(selector); //"#subjects div.number");
};

BuildDifficultyChart = function () {
    $.getJSON("/Chart/Difficulty", function (data) {
        var barChartData = {
            labels: data.Labels,
            datasets: [{
                type: 'line',
                label: 'Avg Difficulty',
                backgroundColor: "#666",
                borderColor: "#666",
                data: data.DataSets.avgDiff,
                fill: false
            },
            {
                label: 'Correct Assignments',
                backgroundColor: "#cfc",
                data: data.DataSets.correct
            },
            {
                label: 'Incorrect Assignments',
                backgroundColor: "#fcc",
                data: data.DataSets.incorrect
            }
            ]

        };


        var ctx = document.getElementById("canvas").getContext("2d");
        window.myBar = new Chart(ctx, {
            type: 'bar',
            data: barChartData,
            options: {
                title: {
                    display: false
                },
                tooltips: {
                    mode: 'index',
                    intersect: false
                },
                responsive: true,
                scales: {
                    xAxes: [{
                        stacked: true
                    }],
                    yAxes: [{
                        stacked: true
                    }]
                }
            }
        });
    });
};