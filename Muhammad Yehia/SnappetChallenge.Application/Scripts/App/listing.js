 (function () {
    var getStructure = function () {
        var object = [];

        var submittedAnswerId = {};
        submittedAnswerId.title = 'Submitted Answer Id';
        submittedAnswerId.name = "SubmittedAnswerId";
        submittedAnswerId.template = "";
        submittedAnswerId.filter = { type: "text" };
        object.push(submittedAnswerId);

        var submitDateTime = {};
        submitDateTime.title = 'Submit Date Time';
        submitDateTime.name = "SubmitDateTime";
        submitDateTime.template = "";
        submitDateTime.filter = { type: "text" };
        object.push(submitDateTime);


        var correct = {};
        correct.title = 'Correct';
        correct.name = "Correct";
        correct.template = "";
        correct.filter = { type: "text" };
        object.push(correct);

        var progress = {};
        progress.title = 'Progress';
        progress.name = "Progress";
        progress.template = "";
        progress.filter = { type: "text" };
        object.push(progress);

        var userId = {};
        userId.title = 'User Id';
        userId.name = "UserId";
        userId.template = "";
        userId.filter = { type: "text" };
        object.push(userId);

        var exerciseId = {};
        exerciseId.title = 'Exercise Id';
        exerciseId.name = "ExerciseId";
        exerciseId.template = "";
        exerciseId.filter = { type: "text" };
        object.push(exerciseId);

        var difficulty = {};
        difficulty.title = 'Difficulty';
        difficulty.name = "Difficulty";
        difficulty.template = "";
        difficulty.filter = { type: "text" };
        object.push(difficulty);

        var subject = {};
        subject.title = 'Subject';
        subject.name = "Subject";
        subject.template = "";
        subject.filter = { type: "text" };
        object.push(subject);

        var domain = {};
        domain.title = 'Domain';
        domain.name = "Domain";
        domain.template = "";
        domain.filter = { type: "text" };
        object.push(domain);

        var learningObjective = {};
        learningObjective.title = 'Learning Objective';
        learningObjective.name = "LearningObjective";
        learningObjective.template = "";
        learningObjective.filter = { type: "text" };
        object.push(learningObjective);


        return object;
    }

    var getData = function () {    
        var url = "/Home/Search";
        $("#TableContainer").XenoTable({
            source: url,
            filterObject: { PageSize: 20 },
            labels: { refresh: "Refresh", filter: "Filter", first: "First", last: "Last", records: "Records", recordsNoPerPage: "RecordsNoPerPage" },
            structures: getStructure(), onError: function (data) {
                if (data.Message) {

                } else {

                }
            }
        });
    }
    getData();
})();