angular.module('snptApp')

.service('learningObjectiveService', [
    '$rootScope',
    '$resource',
    'baseService',
    
    function ($rootScope, $resource, baseService) {

        var learningObjectiveResource = $resource('api/learningobjective/:classId/:userId', {}, {
            get: {
                isArray : true
            }
        });

        //http://localhost:26039/api/LearningObjective/37/40271
        this.GetProgress = function (classID, userId, onSuccessCallback) {
            var promise = learningObjectiveResource.query({ classId : classID, userId : userId }).$promise;
            baseService.execute(promise, null, null, onSuccessCallback);
        };
    }
]);