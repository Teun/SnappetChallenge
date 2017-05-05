"use strict";

var sc = sc || {};
sc.pages = sc.pages || {};
sc.pages.students = function () {

    var koBindingApplied = false,
        viewModel;

    var viewModelStudents = function () {
        var self = this;
        self.students = ko.observableArray([]);
    }

    var viewModelStudent = function(data) {
        var self = this;

        var deviations = data.Deviations;
        self.studentName = ko.observable(data.StudentName);
        self.studentId = ko.observable(data.StudentId);
        self.chartData = ko.observableArray([
            deviations.Progress,
            deviations.CorrectAnswerRate * 10, // ugly chart hacks to get data in range with eachother
            deviations.NumberOfExercises * 1000, 
            deviations.DifficultyOfExercises * 10]);
    }

    var initialize = function () {
        viewModel = new viewModelStudents();
        retrieveItems();
    }

    var retrieveItems = function () {
        $.ajax({
            url: "/api/studentdeviations",
            cache: false,
            dataType: 'json',
            method: 'GET',
            success: retrieveItemsSuccess
        });
    };

    var retrieveItemsSuccess = function (data) {
        var students = [];
        $.each(data.students, function (index, student) {
            var studentModel = new viewModelStudent(student);
            students.push(studentModel);
        });
        viewModel.students(students);

        if (!koBindingApplied) {
            ko.applyBindings(viewModel);
            koBindingApplied = true;
        }
    };

    return {
        initialize: initialize
    }
}();