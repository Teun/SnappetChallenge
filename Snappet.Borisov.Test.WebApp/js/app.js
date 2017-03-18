(function(snappet, $, ko) {

    $(function() {
        snappet
            .getOverviewModel()
            .done(function(model) {
                ko.applyBindings(model);
            });
    });

}(window.snappet = window.snappet || {}, jQuery, ko))