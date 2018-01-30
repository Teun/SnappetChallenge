 var classListing=   (function () {
    var getStructure = function () {
        var object = [];

        var userId = {};
        userId.title = 'User Id';
        userId.name = "UserId";
        userId.template = "";
        object.push(userId);

        var correctAnswers = {};
        correctAnswers.title = 'Correct Answers';
        correctAnswers.name = "CorrectAnswers";
        correctAnswers.template = "";
        object.push(correctAnswers);

        var incorrectAnswers = {};
        incorrectAnswers.title = 'Incorrect Answers';
        incorrectAnswers.name = "IncorrectAnswers";
        incorrectAnswers.template = "";
        object.push(incorrectAnswers);


        var correctPercentage = {};
        correctPercentage.title = 'Correct Percentage';
        correctPercentage.name = "CorrectPercentage";
        correctPercentage.template = "";
        object.push(correctPercentage);


        var incorrectPercentage = {};
        incorrectPercentage.title = 'Incorrect Percentage';
        incorrectPercentage.name = "IncorrectPercentage";
        incorrectPercentage.template = "";
        object.push(incorrectPercentage);

        var numberOfQuestions = {};
        numberOfQuestions.title = 'Number Of Questions';
        numberOfQuestions.name = "NumberOfQuestions";
        numberOfQuestions.template = "";
        object.push(numberOfQuestions);

        var numberOfExercises = {};
        numberOfExercises.title = 'Number Of Exercises';
        numberOfExercises.name = "NumberOfExercises";
        numberOfExercises.template = "";
        object.push(numberOfExercises);


        var totalProgress = {};
        totalProgress.title = 'Total Progress';
        totalProgress.name = "TotalProgress";
        totalProgress.template = "";
        object.push(totalProgress);
        

        return object;
    }

    var getData = function () {    
        var url = "/Home/ClassResults";
        var submitDateTime = $("#submitDateTime").val();
        if (submitDateTime) {
            url += "?submitDateTime=" + submitDateTime;
        }
        $("#ClassContainer").XenoTable({
            source: url,
            structures: getStructure(), onError: function (data) {
                if (data.Message) {

                } else {

                }
            }
        });
    }
    getData();

    return {
        LoadClassList: getData
    }
})();