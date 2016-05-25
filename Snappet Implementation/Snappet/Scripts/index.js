$(document).ready(function () {

    $("#Subject").change(function () {
        Data.Domains();
        return false;
    });

    $("#Domain").change(function () {
        Data.LearningObjectives();
        return false;
    });

    $("#LearningObjective").change(function () {
        Data.AnswerStatistics();
        return false;
    });
    Data.Subjects();
});

var Data = {
    Subjects: function () {
        $("#Subject").empty();
        $.ajax({
            type: 'POST',
            url: '/Data/Subjects',
            dataType: 'json',
            data: { id: id },
            success: function (subjects) {
                $.each(subjects, function (i, subject) {
                    $("#Subject").append('<option value="' + subject.Value + '">' + subject.Text + '</option>');
                });
                Data.Domains();
            },
            error: function (ex) {
                $("#Subject").append('<option value="ERROR">ERROR</option>');
            }
        });
    },

    Domains: function () {
        $("#Domain").empty();
        $.ajax({
            type: 'POST',
            url: '/Data/GetDomains',
            dataType: 'json',
            data: { id: id, subject: $('#Subject').val() },
            success: function (domains) {
                $.each(domains, function (i, domain) {
                    $("#Domain").append('<option value="' + domain.Value + '">' + domain.Text + '</option>');
                });
                Data.LearningObjectives();
            },
            error: function (ex) {
                $("#Domain").append('<option value="ERROR">ERROR</option>');
            }
        });
    },

    LearningObjectives: function () {
        $("#LearningObjective").empty();
        $.ajax({
            type: 'POST',
            url: '/Data/GetLearningObjectives',
            dataType: 'json',
            data: { id: id, subject: $('#Subject').val(), domain: $('#Domain').val() },
            success: function (learningObjectives) {
                $.each(learningObjectives, function (i, learningObjective) {
                    $("#LearningObjective").append('<option value="' + learningObjective.Value + '">' + learningObjective.Text + '</option>');
                });
                Data.AnswerStatistics();
            },
            error: function (ex) {
                $("#LearningObjective").append('<option value="ERROR">ERROR</option>');
            }
        });
    },

    LoadAnswerStatistics: function () {
        $.ajax({
            type: 'POST',
            url: '/Data/GetAnswerStatistics',
            dataType: 'json',
            data: { timePeriod: $("#TimePeriod").val(), subject: $('#Subject').val(), domain: $('#Domain').val(), learningObjective: $('#LearningObjective').val() },
            success: function (statistics) {
                Data.UpdateStatisticsData(statistics);
            },
            error: function (ex) {
                alert('Statistieken kon niet geladen worden.' + ex);
            }
        });

    },

    UpdateStatisticsData: function (statistics) {
        $('#numberOfStudents').html(statistics.numberOfStudents);
        $('#numberOfAnswers').html(statistics.numberOfAnswers);
        $('#numberOfCorrectAnswers').html(statistics.numberOfCorrectAnswers);
        $('#percentCorrectAnswers').html(statistics.percentCorrectAnswers.toFixed(2));
        $('#averageAnswersPerStudent').html(statistics.averageAnswersPerStudent.toFixed(2));
        $('#averageCorrectAnswersPerStudent').html(statistics.averageCorrectAnswersPerStudent.toFixed(2));
        $('#highestDifficulty').html(statistics.highestDifficulty.toFixed(2));
        $('#lowestDifficulty').html(statistics.lowestDifficulty.toFixed(2));
        $('#averageDifficulty').html(statistics.averageDifficulty.toFixed(2));

        var answersPerStudentPerDayContext = $("#answersPerStudentPerDayChart");
        if (Data.AnswersPerStudentPerDayChart != null)
            Data.AnswersPerStudentPerDayChart.destroy();

        Data.AnswersPerStudentPerDayChart = new Chart(answersPerStudentPerDayContext, {
            type: 'bar',
            data: {
                labels: statistics.answersPerStudentPerDayData.Labels,
                datasets: [{
                    label: statistics.answersPerStudentPerDayData.ValueLabel,
                    data: statistics.answersPerStudentPerDayData.Values
                }]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });

        var percentCorrectPerDayContext = $("#percentCorrectPerDayChart");
        if (Data.PercentCorrectPerDayChart != null)
            Data.PercentCorrectPerDayChart.destroy();

        Data.PercentCorrectPerDayChart = new Chart(percentCorrectPerDayContext, {
            type: 'bar',
            data: {
                labels: statistics.percentCorrectPerDayData.Labels,
                datasets: [{
                    label: statistics.percentCorrectPerDayData.ValueLabel,
                    data: statistics.percentCorrectPerDayData.Values
                }]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });

        var percentCorrectPerStudentContext = $("#percentCorrectPerStudentChart");
        if (Data.PercentCorrectPerStudentChart != null)
            Data.PercentCorrectPerStudentChart.destroy();

        Data.PercentCorrectPerStudentChart = new Chart(percentCorrectPerStudentContext, {
            type: 'bar',
            data: {
                labels: statistics.percentCorrectPerStudentData.Labels,
                datasets: [{
                    label: statistics.percentCorrectPerStudentData.ValueLabel,
                    data: statistics.percentCorrectPerStudentData.Values
                }]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });

        var progressPerStudentContext = $("#progressPerStudentChart");
        if (Data.ProgressPerStudentChart != null)
            Data.ProgressPerStudentChart.destroy();

        Data.ProgressPerStudentChart = new Chart(progressPerStudentContext, {
            type: 'bar',
            data: {
                labels: statistics.progressPerStudentData.Labels,
                datasets: [{
                    label: statistics.progressPerStudentData.ValueLabel,
                    data: statistics.progressPerStudentData.Values
                }]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });

        var averageDifficultyPerStudentContext = $("#averageDifficultyPerStudentChart");
        if (Data.AverageDifficultyPerStudentChart != null)
            Data.AverageDifficultyPerStudentChart.destroy();

        Data.AverageDifficultyPerStudentChart = new Chart(averageDifficultyPerStudentContext, {
            type: 'bar',
            data: {
                labels: statistics.averageDifficultyPerStudentData.Labels,
                datasets: [{
                    label: statistics.averageDifficultyPerStudentData.ValueLabel,
                    data: statistics.averageDifficultyPerStudentData.Values
                }]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });

        var studentsWithAnswersPerDayContext = $("#studentsWithAnswersPerDayChart");
        if (Data.StudentsWithAnswersPerDayChart != null)
            Data.StudentsWithAnswersPerDayChart.destroy();

        Data.StudentsWithAnswersPerDayChart = new Chart(studentsWithAnswersPerDayContext, {
            type: 'bar',
            data: {
                labels: statistics.studentsWithAnswersPerDayData.Labels,
                datasets: [{
                    label: statistics.studentsWithAnswersPerDayData.ValueLabel,
                    data: statistics.studentsWithAnswersPerDayData.Values
                }]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });

        var answerBreakdownContext = $("#answerBreakdownChart");
        if (Data.AnswerBreakdownChart != null)
            Data.AnswerBreakdownChart.destroy();
        $("#answerBreakdownHeading").html(statistics.answerBreakdownData.ValueLabel);
        Data.AnswerBreakdownChart = new Chart(answerBreakdownContext, {
            type: 'pie',
            data: {
                labels: statistics.answerBreakdownData.Labels,
                datasets: [{
                    data: statistics.answerBreakdownData.Values,
                    backgroundColor: statistics.answerBreakdownData.Colors,
                    hoverBackgroundColor: statistics.answerBreakdownData.HoverColors
                }]
            },
            options: {

            }
        });

    }
}