function ExerciseStatsReportModel(data)
{
    this.title = ko.observable(data.Title);
    this.exerciseStats = ko.observableArray(
        $.map(data.ExerciseStats, function (item) { return new AggregateStats(item) })
    );
}

function AggregateStats(data)
{
    this.domain = ko.observable(data.Aggregate.LearningDomain.Name);
    this.subject = ko.observable(data.Aggregate.Name);
    this.learningObjective = ko.observable();
    this.averageExerciseCount = ko.observable(Math.round(data.AverageExerciseCount));
    this.averageExerciseInCorrect = ko.observable(Math.round(data.AverageExerciseInCorrect));
    this.topInCorrectExercises = ko.observableArray($.map(data.TopInCorrectExercises, function (item) { return new ExerciseStats(item) }));
    this.negativeProgressUserStats = ko.observableArray($.map(data.NegativeProgressUserStats, function (item) { return new UserStats(item) }));
    this.learningObjectiveStats = ko.observableArray($.map(data.LearningObjectiveStats, function (item) { return new LearningObjectiveStats(item) }));
}

function ExerciseStats(data)
{
    this.id = ko.observable(data.Exercise.Id);
    this.exerciseText = ko.observable(data.Exercise.ExerciseText);
    this.exerciseCount = ko.observable(data.ExerciseCount);
    this.exerciseInCorrectCount = ko.observable(data.ExerciseInCorrectCount);
}

function UserStats(data)
{
    this.id = ko.observable(data.User.Id);
    this.exerciseCount = ko.observable(data.ExerciseCount);
    this.exerciseInCorrectCount = ko.observable(data.ExerciseInCorrectCount);
}

function LearningObjectiveStats(data)
{
    this.learningObjective = ko.observable(data.LearningObjective.Name);
    this.exerciseCount = ko.observable(Math.round(data.ExerciseCount));
    this.exerciseInCorrectCount = ko.observable(Math.round(data.ExerciseInCorrectCount));
}