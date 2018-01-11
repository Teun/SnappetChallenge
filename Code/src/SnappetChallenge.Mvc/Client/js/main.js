import '../css/site.css';
import 'bootstrap/dist/css/bootstrap.css';
import 'jquery';
import 'bootstrap';
import 'knockout';
import init from './knockout.simplegrid.js';

require(['jquery', 'knockout'],
    function ($, ko) {
        window.ko = ko;

        init($, ko);

        var ViewModel = function (first, last, items) {

            this.firstName = ko.observable(first);
            this.lastName = ko.observable(last);

            this.items = ko.observableArray(items);

            this.fullName = ko.computed(function () {
                // Knockout tracks dependencies automatically. It knows that fullName depends on firstName and lastName, because these get called when evaluating fullName.
                return this.firstName() + " " + this.lastName();
            },
                this);

            this.addItem = function () {
                this.items.push({ name: "New item", sales: 0, price: 100 });
            };

            this.sortBy = function (field) {
                this.items.sort(function (a, b) {
                    return a[field] < b[field] ? -1 : 1;
                });
            };

            this.jumpToFirstPage = function () {
                this.gridViewModel.currentPageIndex(0);
            };

            this.gridViewModel = new ko.simpleGrid.viewModel({
                data: this.items,
                columns: [
                    { headerText: "Submitted Answer Id", rowText: "submittedAnswerId" },
                    { headerText: "Correct", rowText: "correct" },
                    { headerText: "Progress", rowText: "progress" },
                    { headerText: "User Id", rowText: "userId" },
                    { headerText: "Excercise Id", rowText: "exerciseId" },
                    { headerText: "Difficulty", rowText: "difficulty" },
                    { headerText: "Learning Objective", rowText: "learningObjective" },
                    { headerText: "Subject", rowText: "subject" },
                    { headerText: "Domain", rowText: "domain" },
                    { headerText: "Date", rowText: function (item) { return Date.parse(item.submitDateTime); } }
                ],
                pageSize: 20
            });
        };

        $.get("/api/workdata?topN=1000").then(initialData => {
            ko.applyBindings(new ViewModel("Planet", "Earth", initialData));
        }); // This makes Knockout get to work
    });