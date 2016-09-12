angular.module('snptApp')

.service('classService', [
    '$rootScope',
    '$resource',
    'baseService',
    
    function ($rootScope, $resource, baseService) {

        var classResource = $resource('api/class', {}, {
            get: {
                isArray : true
            }
        });

        this.getClasses = function (onSuccessCallback) {
            var promise = classResource.get().$promise;
            baseService.execute(promise, null, null, onSuccessCallback);
        };
    }
]);