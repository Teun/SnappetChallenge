(function(snappet, $) {

    var onSuccess = function(data) {
        return new snappet.OverviewModel(data);
    };

    snappet.getOverviewModel = function() {
        return $.getJSON('api/report/overview').done(onSuccess);
    };

}(window.snappet = window.snappet || {}, jQuery))