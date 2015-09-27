/// <reference path="MyCache.js"/>

var application = new function(){
    var controllers = {},
    registerController = function (controllerName, controllerConstructor) {
        var controller = controllerConstructor();
        controller.services = {};
        controller.registerService = function(serviceName, serviceConstructor) {
            var service = serviceConstructor();
            service.q = q;
            controller.services[serviceName] = service;
        };
        controllers[controllerName] = controller;
    },
    registerService = function (controllerName, serviceName, serviceConstructor) {
        var idx = controllers[controllerName].registerService(serviceName, serviceConstructor);
    },
    q = function(asyncCallback) {
        var then = function(onSuccessCallback, onErrorCallback) {
                asyncCallback(onSuccessCallback, onErrorCallback);
            };
        return {then: then};
    },
    init = function () {
        $.each(controllers, function (idx, val) {
            val.init();
        });
    };

    return {
        cache : new MyCache(),
        init: init,
        registerController: registerController,
        registerService: registerService
    };
};

$(function () {
    application.init();
} );
