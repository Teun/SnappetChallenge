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

        function onlyUnique(value, index, self) {
            return self.indexOf(value) === index;
        }

        var ViewModel = function (metaData) {

            this.onFilterChange = function () {
                console.log(this);
                $.get("/api/workitem?top=500").then(items => {
                    this.items(items);
                });
            };
            this.onFilterChange = this.onFilterChange.bind(this);

            this.items = ko.observableArray([]);

            this.allUserIds = ko.observableArray(metaData.allUserIds.sort());
            this.selectedUserIds = ko.observableArray([]);
            this.selectedUserIds.subscribe(this.onFilterChange);

            this.allCorrects = ko.observableArray(metaData.allCorrects.sort());
            this.selectedCorrects = ko.observableArray([]);
            this.selectedCorrects.subscribe(this.onFilterChang);

            this.allDomains = ko.observableArray(metaData.allDomains.sort());
            this.selectedDomains = ko.observableArray([]);
            this.selectedDomains.subscribe(this.onFilterChange);

            this.toDateTime = ko.observable(new Date("2015-03-24T11:30:00").toISOString().slice(0, -5));
            this.toDateTime.subscribe(this.onFilterChange);

            this.fromDateTime = new Date("2015-03-24T11:30:00");
            this.fromDateTime.setDate(this.fromDateTime.getDate() - 7);
            this.fromDateTime = ko.observable(this.fromDateTime.toISOString().slice(0, -5));
            this.fromDateTime.subscribe(this.onFilterChange);

            this.onFilterChange();

            this.sortBy = function (column) {
                const field = column.columnSortKey;
                this.items.sort(function (a, b) {
                    return a[field] < b[field] ? -1 : 1;
                });
                return false;
            };

            this.gridViewModel = new ko.simpleGrid.viewModel({
                data: this.items,
                sortBy: function (column) {
                    const field = column.columnSortKey;
                    this.data.sort(function (a, b) {
                        return a[field] < b[field] ? -1 : 1;
                    });
                    return false;
                },
                columns: [
                    { columnSortKey: "submittedAnswerId", headerText: "Submitted Answer Id", rowText: "submittedAnswerId" },
                    { columnSortKey: "correct", headerText: "Correct", rowText: "correct" },
                    { columnSortKey: "progress", headerText: "Progress", rowText: "progress" },
                    { columnSortKey: "userId", headerText: "User Id", rowText: "userId" },
                    { columnSortKey: "exerciseId", headerText: "Excercise Id", rowText: "exerciseId" },
                    { columnSortKey: "difficulty", headerText: "Difficulty", rowText: "difficulty" },
                    { columnSortKey: "learningObjective", headerText: "Learning Objective", rowText: "learningObjective" },
                    { columnSortKey: "subject", headerText: "Subject", rowText: "subject" },
                    { columnSortKey: "domain", headerText: "Domain", rowText: "domain" },
                    { columnSortKey: "submitDateTime", headerText: "Date", rowText: function (item) { return new Date(Date.parse(item.submitDateTime)).toUTCString(); } }
                ],
                pageSize: 25
            });
        };

        $.get("/api/workitemmetadata").then((metadata) => {
            ko.applyBindings(new ViewModel(metadata));
        });
    });