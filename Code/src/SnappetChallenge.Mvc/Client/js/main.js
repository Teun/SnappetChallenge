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

        function compare(a, b) {
            if (a < b) {
                return -1;
            }
            if (a > b) {
                return 1;
            }
            return 0;
        }

        var ViewModel = function (metaData) {

            this.TOP = 5000;

            this.onFilterChange = function () {
                const url = this.getServiceUrl();
                console.log(url);
                $.get(url).then(items => {
                    this.items(items);
                });
            };

            this.getServiceUrl = function() {
                let result = `/api/workitem?top=${this.TOP}&skip=0`+
                    `&from=${this.formatParam(this.fromDateTime())}` +
                    `&to=${this.formatParam(this.toDateTime())}` +
                    `&nullDifficulty=${this.formatParam(this.allowNullDifficulty())}` +
                    `&minDifficulty=${this.formatParam(this.minDifficulty())}` +
                    `&maxDifficulty=${this.formatParam(this.maxDifficulty())}` +
                    `&correct=${this.formatParam(this.selectedCorrects().join(','))}` +
                    `&userId=${this.formatParam(this.selectedUserIds().join(','))}` +
                    `&domain=${this.formatParam(this.selectedDomains().join(','))}` +
                    `&minProgress=${this.formatParam(this.minProgress())}` +
                    `&maxProgress=${this.formatParam(this.maxProgress())}` +
                    `&subject=${this.formatParam(this.selectedSubjects().join(','))}` + 
                    `&excercise=${this.formatParam(this.excercise())}`;
                return result;
            }

            this.formatParam = function(param) {
                return encodeURIComponent(param);
            }

            this.onFilterChange = this.onFilterChange.bind(this);

            this.items = ko.observableArray([]);

            this.allUserIds = ko.observableArray(metaData.allUserIds.sort(compare));
            this.selectedUserIds = ko.observableArray(this.allUserIds());

            this.allDomains = ko.observableArray(metaData.allDomains.sort(compare));
            this.selectedDomains = ko.observableArray(this.allDomains());

            this.allSubjects = ko.observableArray(metaData.allSubjects.sort(compare));
            this.selectedSubjects = ko.observableArray(this.allSubjects());

            this.allDomains = ko.observableArray(metaData.allDomains.sort(compare));
            this.selectedDomains = ko.observableArray(this.allDomains());

            this.allCorrects = ko.observableArray(metaData.allCorrects.sort(compare));
            this.selectedCorrects = ko.observableArray(this.allCorrects());

            this.minDifficulty = ko.observable(-1000);
            this.maxDifficulty = ko.observable(+1000);
            this.allowNullDifficulty = ko.observable(true);

            this.minProgress = ko.observable(-1000);
            this.maxProgress = ko.observable(+1000);

            this.excercise = ko.observable("");

            this.toDateTime = ko.observable(new Date("2015-03-24T11:30:00").toISOString().slice(0, -5));
 
            this.fromDateTime = new Date("2015-03-24T11:30:00");
            this.fromDateTime.setDate(this.fromDateTime.getDate() - 7);
            this.fromDateTime = ko.observable(this.fromDateTime.toISOString().slice(0, -5));

            this.totalMessage = ko.computed(function () {
                const data = this.items();

                let result = data.length === this.TOP
                    ? `${this.TOP} first records are shown according to filters set`
                    : `Total: ${data.length} record(s)`;
                const progress = data.map(x => x.progress);
                const difficulty = data.filter(x => x.difficulty !== "NULL").map(x => parseFloat(x.difficulty));
                result = result + `</br > Minimal progress: ${Math.min.apply(Math, progress)}, Maximal progress: ${Math.max.apply(Math, progress)}`;
                result = result + `</br > Minimal difficulty: ${Math.min.apply(Math, difficulty)}, Maximal difficulty: ${Math.max.apply(Math, difficulty)}`;

                return result;
            }, this);

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
                    if (field == "difficulty") {
                        this.data.sort(function (a, b) {
                            if (a[field] === "NULL")
                                return -1;
                            return parseFloat(a[field]) < parseFloat(b[field]) ? -1 : 1;
                        });
                    } else {
                        this.data.sort(function(a, b) {
                            return a[field] < b[field] ? -1 : 1;
                        });
                    }
                    return false;
                },
                columns: [
                    { columnSortKey: "submittedAnswerId", headerText: "Submitted Answer Id", rowText: "submittedAnswerId" },
                    { columnSortKey: "exerciseId", headerText: "Excercise Id", rowText: "exerciseId" },
                    { columnSortKey: "userId", headerText: "User Id", rowText: "userId" },
                    { columnSortKey: "domain", headerText: "Domain", rowText: "domain" },
                    { columnSortKey: "subject", headerText: "Subject", rowText: "subject" },
                    { columnSortKey: "correct", headerText: "Correct", rowText: "correct" },
                    { columnSortKey: "progress", headerText: "Progress", rowText: "progress" },
                    { columnSortKey: "difficulty", headerText: "Difficulty", rowText: "difficulty" },
                    { columnSortKey: "learningObjective", headerText: "Learning Objective", rowText: "learningObjective" },
                    { columnSortKey: "submitDateTime", headerText: "Date", rowText: function (item) { return new Date(Date.parse(item.submitDateTime)).toISOString().slice(0, -5).replace('T',' '); } }
                ],
                pageSize: 25
            });
        };

        $.get("/api/workitemmetadata").then((metadata) => {
            ko.applyBindings(new ViewModel(metadata));
        });
    });