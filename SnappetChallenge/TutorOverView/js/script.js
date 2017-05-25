$(document).ready(function () {

    showTotalResults();


    /**** functions ****/

    //get json data with totalprogress results per domain
    function showTotalResults() {
        $.get("http://localhost:7115/SnappetChallenge.svc/GetProgressOverViewDate/20150324/113000", function (data) {
            showTableTotals(data);
        });
    };

    //get json data with detail results
    function showDetailResults(userid, domain) {
        $.get("http://localhost:7115/SnappetChallenge.svc/GetDomainAnswersForDateTime/" + userid + "/" + domain + "/20150324/113000", function (data) {
            showTableDetail(data);
        });
    }

    function showTableTotals(resultTotals) {
        var tableHTML = "<table id='totals'><tr><th>UserId</th><th>Domain</th><th>Progress</th></tr>";

        $.each(resultTotals, function (key, value) {
            tableHTML += "<tr>" +
                            "<td class='UserId'>" + value["UserId"] + "</td>" +
                            "<td class='Domain'>" + value["Domain"] + "</td>" +
                            "<td>" + value["TotalProgress"] + "</td>" +
                         "</tr>";
        });

        tableHTML += "</table>";
        $("#results").html(tableHTML);

        //hide back button
        $("#backbutton").hide();
    };

    function showTableDetail(resultDetail) {
        var tableHTML = "<table id='detail'><tr>" +
                        "<th>UserId</th>" +
                        "<th>ExerciseId</th>" +
                        "<th>Domain</th>" +
                        "<th>Subject</th>" +
                        "<th>LearningObjective</th>" +
                        "<th>Difficulty</th>" +
                        "<th>Correct</th>" +
                        "<th>Progress</th>" +
                        "</tr>";

        $.each(resultDetail, function (key, value) {
            tableHTML += "<tr>" +
                            "<td>" + value["UserId"] + "</td>" +
                            "<td>" + value["ExerciseId"] + "</td>" +
                            "<td>" + value["Domain"] + "</td>" +
                            "<td>" + value["Subject"] + "</td>" +
                            "<td>" + value["LearningObjective"] + "</td>" +
                            "<td>" + value["Difficulty"] + "</td>" +
                            "<td>" + value["Correct"] + "</td>" +
                            "<td>" + value["Progress"] + "</td>" +
                         "</tr>";
        });

        tableHTML += "</table>";
        $("#results").html(tableHTML);

        //show back button
        $("#backbutton").show();
    };

    /**** eventhandlers ****/

    //click on table row
    $("body").on("click", "#totals tr", function () {
        var userId = $(this).find(".UserId").html();
        var domain = $(this).find(".Domain").html();

        showDetailResults(userId, domain);
    });

    $('#backbutton').click(function () {
        showTotalResults();
    });
});