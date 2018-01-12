(function () {
    "use strict";

    angular
        .module("common")
        .factory("reportResource", ["$resource","appSettings", reportResource])

    function reportResource($resource, appSettings) {
        
        return $resource(appSettings.serverPath + "/api/work/:id", null,
            {
                'get': {
                    headers: {}
                }           
            });
    }
}());

