(function (snappet, $, ko) {

    snappet.OverviewModel = function (data) {
        var $this = this;
        $this.students = ko.observableArray(data.students);
    }

}(window.snappet = window.snappet || {}, jQuery, ko))
