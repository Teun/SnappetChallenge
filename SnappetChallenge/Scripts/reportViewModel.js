
define(['knockout', 'jquery', 'workResultViewModel', 'jquery-ui', 'bootstrap'], function (ko, $, WorkResult) {
    return function reportViewModel() {
        var self = this;
        self.results = ko.observableArray([]);

        $("#datepicker").datepicker({
            maxDate: new Date(2015, 02, 24),
            defaultDate: new Date(2015, 02, 24),
            onSelect: function (dateText, inst) {
                var dateAsObject = $(this).datepicker('getDate');
                // Get student data for the selected day:
                $.post("/home/report/", { date: dateAsObject.toISOString() }, function (data, textStatus) {
                    var mappedResults = $.map(data, function (item) { return new WorkResult(item) });
                    self.results(mappedResults);
                }, "json");
            }
        });        
    };
});