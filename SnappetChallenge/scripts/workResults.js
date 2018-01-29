ko.bindingHandlers.htmlWithBinding = {
    'init': function () {
        return { 'controlsDescendantBindings': true };
    },
    'update': function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        element.innerHTML = ko.unwrap(valueAccessor());
        ko.applyBindingsToDescendants(bindingContext, element);
    }
};

Array.prototype.groupBy = function (prop) {
    return this.reduce(function (groups, item) {
        var val = item[prop];
        groups[val] = groups[val] || [];
        groups[val].push(item);
        return groups;
    }, {});
}

///Load ko templates from Plugins/ko/templates folder and run callback when ready
function requireTemplates(list, callback) {

    if (typeof loadedTemplates == 'undefined')
        loadedTemplates = [];

    if (typeof loadedTemplatesPromises == 'undefined')
        loadedTemplatesPromises = [];

    ko.utils.arrayForEach(list, function (name) {
        if (loadedTemplates.indexOf(name) > -1)
            return;

        loadedTemplates.push(name);

        loadedTemplatesPromises.push($.get("/scripts/ko_templates/" + name + ".html", function (template) {
            $("body").append(template);
        }));
    });

    if (typeof callback == 'function') {
        $.when.apply($, loadedTemplatesPromises).then(function () {
            callback();
        });
    }
}

function WorkResults_VM(initVals) {
    var self = this;

    var ajax = function (method, data, controllerUrl, actionUrl) {
        return $.ajax({
            url: "/api/" + controllerUrl + '/' + (actionUrl || ''),
            //context: document.body,
            method: method,
            data: JSON.stringify(data),
            contentType: "application/json",
            dataType: "json",
        }).fail(function (data, textStatus, jqXHR) { alert('Network error:(ajax) ' + textStatus); });
    }

    self.items = ko.observableArray();
    self.items.subscribe(function () {
        self.setDashboardDataForDay();
    });

    self.overallProgress = ko.observable();
    self.avgDifficulty = ko.observable();

    self.setDashboardDataForDay = function () {

        //correct/incorrect chart
        var correctCount = ko.utils.arrayFilter(vm.items(), function (item) {
            return item.Correct == 1
        }).length;

        var dataPie = google.visualization.arrayToDataTable([
              ['Correct/Incorrect Answers', 'Count of answers'],
              ['Correct', correctCount],
              ['Incorrect', self.items().length - correctCount]
        ]);

        var optionsPie = {
            title: 'Correct answers chart:',
            is3D: false,
        };

        var chartPie = new google.visualization.PieChart($('.piechart')[0]);
        chartPie.draw(dataPie, optionsPie);

        //overall progress
        var progress = 0;
        ko.utils.arrayForEach(self.items(), function (item) {
            progress += item.Progress;
        });
        self.overallProgress(progress);

        //average difficulty
        var diff = 0;
        var tmp = 0;
        ko.utils.arrayForEach(self.items(), function (item) {
            tmp = parseFloat(item.Difficulty);
            if (!isNaN(tmp))
                diff += tmp;
        });
        self.avgDifficulty((diff / self.items().length).toFixed(2));

        //subjects with correct/incorrect
        var rawData = [
          ['Subject', 'Correct', 'Incorrect']
        ];

        var groupBySubject = vm.items().groupBy('Subject');
        Object.keys(groupBySubject).forEach(function (subject) {
            var groupItems = groupBySubject[subject];
            var correctCount = ko.utils.arrayFilter(groupItems, function (item) {
                return item.Correct == 1
            }).length;
            rawData.push([subject, correctCount, groupItems.length - correctCount]);
        });

        var dataCol = google.visualization.arrayToDataTable(rawData);

        var optionsCol = {
            chart: {
                title: 'Subjects by correct / incorrect answers'
            }
        };

        var chartCol = new google.charts.Bar($('.colchart')[0]);
        chartCol.draw(dataCol, google.charts.Bar.convertOptions(optionsCol));

    };

    self.mainVM = new ko.simpleGrid.viewModel({
        rootModel: self,
        defSortProp: ko.observable({ field: 'UserId', direction: 'asc' }),
        data: self.items,
        columns: [
                     { headerText: "User Id", dataField: "UserId" },
                     { headerText: "Exercise Id", dataField: "ExerciseId" },
                     { headerText: "Answer Id", dataField: "SubmittedAnswerId" },
                     { headerText: "Domain", dataField: "Domain" },
                     { headerText: "Subject", dataField: "Subject" },
                     { headerText: "Learning Objective", dataField: "LearningObjective" },
                     { headerText: "Correct", dataField: "SubmittedAnswerId" , rowText: function (item, model) { return item.Correct == 1 ? 'Yes' : 'No' } },
                     { headerText: "Progress", dataField: "Progress" },
                     { headerText: "Difficulty", dataField: "Difficulty" },

        ],
        pageSize: 100
    });


    

    self.getDataForDate = function (date) {
       
        ajax("POST", date, "workresults", "getresultsfordate").done(function (response) { //{ date: date }
            self.items(response);
            self.mainVM.initSort();
        });
    }

    //ctor
    var $datePicker = $('.input-group.date');

    $datePicker.datepicker({
        todayBtn: "linked",
        clearBtn: true,
        format: "dd/mm/yyyy",
        todayHighlight: true,
        autoclose: true
    });

    $datePicker.on('changeDate', function (e) {
        self.getDataForDate(e.date.toISOString());
    });

}