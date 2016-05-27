var graph_1_1;
var graph_1_2;
var graph_1_3;
var graph_2_1;
var graph_2_2;
var data_1_1;
var data_1_2;
var data_1_3;
var data_2_1;
var data_2_2;

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

    var options = {
        plugins: [
            Chartist.plugins.tooltip()
        ]
    };

    graph_1_1 = new Chartist.Bar('#grid-1-1', data_1_1, options);
    graph_1_2 = new Chartist.Bar('#grid-1-2', data_1_2, options);
    graph_1_3 = new Chartist.Bar('#grid-1-3', data_1_3, options);
    graph_2_1 = new Chartist.Pie('#grid-2-1', data_2_1, options);
    graph_2_2 = new Chartist.Bar('#grid-2-2', data_2_2, options);

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
            url: '/Data/Domains',
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
            url: '/Data/LearningObjectives',
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

    AnswerStatistics: function () {
        $.ajax({
            type: 'POST',
            url: '/Data/GraphData',
            dataType: 'json',
            data: { id: id, subject: $('#Subject').val(), domain: $('#Domain').val(), learningObjective: $('#LearningObjective').val() },
            success: function (graphData) {
                Data.UpdateStatisticsData(graphData);
            },
            error: function (ex) {
                alert('Statistieken kon niet geladen worden.' + ex);
            }
        });

    },

    UpdateStatisticsData: function (graphData) {
        data_1_1 = graphData.graph_1_1;
        data_1_2 = graphData.graph_1_2;
        data_1_3 = graphData.graph_1_3;
        data_2_1 = graphData.graph_2_1;
        data_2_2 = graphData.graph_2_2;

        self.graph_1_1.update(data_1_1);
        self.graph_1_2.update(data_1_2);
        self.graph_1_3.update(data_1_3);
        self.graph_2_1.update(data_2_1);
        self.graph_2_2.update(data_2_2);
    }
}
