angular.module('snptApp')

.service('classService', [
    '$rootScope',
    '$resource',
    'baseService',
    
    function ($rootScope, $resource, baseService) {

        var classResource = $resource('api/class/:id/:action', {}, {
            get: {
                isArray : true
            }
        });

        this.getClasses = function (onSuccessCallback) {
            var promise = classResource.get().$promise;
            baseService.execute(promise, null, null, onSuccessCallback);
        };

        //http://localhost:26039/api/class/37/currentactivity
        this.getCurrentActivity = function (classID, onSuccessCallback) {
            var promise = classResource.query({ id: classID, action: 'currentactivity' }).$promise;
            baseService.execute(promise, null, null, onSuccessCallback);
        };
    }
]);