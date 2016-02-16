// Class to represent a students progress
function StudentProgress(studentObject){
    var context = this;
    context.answerCount = studentObject.AnswerCount;
    context.answerCount = studentObject.AnswerCount;
    context.correctCount = studentObject.CorrectCount;
    context.totalProgress = studentObject.TotalProgress;
    context.totalDifficulty = studentObject.TotalDifficulty;
    context.userId = studentObject.UserId;
    context.averageDifficulty = studentObject.AverageDifficulty;

    context.correctnessPercentage = studentObject.CorrectnessPercentage;

    context.relativeCorectnessPercentage = studentObject.RelativeCorectnessPercentage;
    context.relativeAnswerCountPercentage = studentObject.RelativeAnswerCountPercentage;
    context.relativeCorrectCountPercentage = studentObject.RelativeCorrectCountPercentage;

}

// Class to represent the progress of a class (collection of students)
function ClassProgressModel(){
    var context = this;

    // Non-editable catalog data - would come from the server
    context.studentProgress = totals;

    // Editable data
    context.classProgress = ko.observableArray(context.studentProgress.map(function(student){
            return new StudentProgress(student);
        })
    );
}

ko.applyBindings(new ClassProgressModel());
