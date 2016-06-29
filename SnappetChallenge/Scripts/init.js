requirejs.config({
    paths: {
        'lib': 'lib/',
        'jquery': 'https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.4/jquery.min',
        'knockout': 'https://cdnjs.cloudflare.com/ajax/libs/knockout/3.4.0/knockout-min',
        'jquery-ui': 'https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.4/jquery-ui.min',
        'bootstrap': 'https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.6/js/bootstrap.min'
    }
});

require(['knockout', 'reportViewModel', 'jquery'], function (ko, reportViewModel) {
    ko.applyBindings(new reportViewModel(ko));
});