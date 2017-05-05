"use strict";

var sc = sc || {};
sc.pages = sc.pages || {};
sc.pages.progress = function () {

    var koBindingApplied = false,
        mainModel,
        vmExercises,
        vmStudents,
        vmAnswers;

    var viewModel = function () {
        var self = this;
        self.objectives = ko.observableArray([]);
        self.exercises = ko.observableArray([]);
        self.students = ko.observableArray([]);

        self.selectedObjective = ko.observable();
        self.selectedObjective.subscribe(function (newVal) {
            $.when(getExercises(newVal)).done(function (data) {
                getExercisesCallback(data);
            }).done(function () {
                getAnswers();
            });
        });

        self.studentIds = ko.pureComputed(function () {
            var ids = [];
            ko.utils.arrayForEach(self.students(), function (item) {
                ids.push(item.id());
            });
            return ids;
        });

        self.exerciseIds = ko.pureComputed(function () {
            var ids = [];
            ko.utils.arrayForEach(self.exercises(), function (item) {
                ids.push(item.id());
            });
            return ids;
        });

        self.findStudentById = function (id) {
            return ko.utils.arrayFirst(self.students(), function (item) {
                return id === item.id();
            });
        };
    };

    var objective = function (data) {
        var self = this;
        self.name = ko.observable(data.LearningObjective);
        self.id = ko.observable(data.Id);

    };

    var getExercisesCallback = function (data) {
        mainModel.exercises([]);
        $.each(data.exercises, function (i, obj) {
            mainModel.exercises.push(new exercise(obj, i + 1));
        });
    };
    var getStudentsCallback = function (data) {
        mainModel.students([]);
        $.each(data.students, function (i, obj) {
            mainModel.students.push(new student(obj));
        });
    };

    var exercise = function (data, index) {
        var self = this;
        self.id = ko.observable(data.Id);
        self.label = ko.observable(index);
    };

    var getAnswers = function () {
        var exercises = mainModel.exerciseIds();
        var students = mainModel.studentIds();

        $.each(students, function (i, studentId) {
            mainModel.findStudentById(studentId).answers([]); // reset
            $.when(getAnswersForStudent(studentId, exercises)).done(getAnswersForStudentCallback);
        });

    };

    var getAnswersForStudent = function (studentId, exerciseIds) {
        return $.ajax({
            url: "/api/GetAnswersForStudentAndExercise",
            data: { studentId: studentId, exerciseIds: exerciseIds },
            cache: false,
            dataType: 'json',
            method: 'POST',
            async: true
        });
    };

    var getAnswersForStudentCallback = function (data) {
        var answers = [];
        $.each(data.answers, function(i, o) {
            answers.push(new answer(o));
        });

        mainModel.findStudentById(data.studentId).answers(answers);
    };

    var student = function (data) {
        var self = this;
        self.name = ko.observable(data.Name);
        self.id = ko.observable(data.Id);
        self.answers = ko.observableArray([]).extend({ rateLimit: 500 });
    }

    var initialize = function () {
        mainModel = new viewModel();
        $.when(getObjectives()).done(getObjectivesCallback);
        $.when(getStudents()).done(getStudentsCallback);
    }

    var getExercises = function (objectiveId) {
        return $.ajax({
            url: "/api/getExercises",
            data: { objectiveId: objectiveId },
            cache: false,
            dataType: 'json',
            method: 'GET'
        });
    };

    var getStudents = function () {
        return $.ajax({
            url: "/api/getStudents",
            cache: false,
            dataType: 'json',
            method: 'GET',
            async: true
        });
    };

    var getObjectives = function () {
        return $.ajax({
            url: "/api/getObjectives",
            cache: false,
            dataType: 'json',
            method: 'GET'
        });
    };

    var answer = function (data) {
        var self = this;
        self.backgroundClass = ko.pureComputed(function () {
            var a = self.answer();
            if (a === 0) return "success";
            if (a === 1) return "danger";
            if (a === 2) return "info";
        });
        self.iconClass = ko.pureComputed(function () {
            var a = self.answer();
            if (a === 0) return "glyphicon-ok";
            if (a === 1) return "glyphicon-exclamation-sign";
            if (a === 2) return "glyphicon-ban-circle";

        });
        self.answer = ko.observable(data);
    };

    var getObjectivesCallback = function (data) {
        $.each(data.objectives, function (index, obj) {
            mainModel.objectives.push(new objective(obj));
        });

        if (!koBindingApplied) {
            ko.applyBindings(mainModel);
            koBindingApplied = true;
        }
    };

    return {
        initialize: initialize
    }
}();