(function () {
    var root = this;

    define('jquery', [], function () {
        return root.jQuery;
    });
    define('ko', [], function() {
        return root.ko;
    });
    function boot() {
        require(['bootstrapper'], function (bs) {
            bs.run();
        });
    };

    /* Here I had some difficulty injecting knockout.mapping... */

    // Below plugins can be injected that need to be loaded later.
    function loadPluginsAndBoot() {
        requirejs([], boot);
    };

    loadPluginsAndBoot();
})();
