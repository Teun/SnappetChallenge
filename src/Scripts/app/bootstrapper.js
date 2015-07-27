define('bootstrapper', ['jquery', 'binder'], function ($, binder) {

    var run = function() {
        binder.bind();
    };

    return {
        run: run
    };
});