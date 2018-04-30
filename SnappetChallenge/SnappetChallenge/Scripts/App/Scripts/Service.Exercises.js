angular.module('SnappetDashboard')
    .service('exercisesService', ['$http', '$q', '$log', function ($http, $q, $log) {
        let self = this;
        let rootURL = window.serviceURL;
        console.log('rootURL', rootURL);
        self.getExercises = function (pageNumber, exercisesPerPage) {
           let deferred = $q.defer();

            $http.get(rootURL + "/Exercises?pageNumber=" + pageNumber + "&exercisesPerPage=" + exercisesPerPage)
                .then(function (response) {
                    deferred.resolve(response.data);
                });
            return deferred.promise;
        };

        self.getExercisesByDomain = function (pageNumber, exercisesPerPage, domain) {
           let deferred = $q.defer();

            $http.get("http://localhost:56411/home/Domain?pageNumber=" + pageNumber + "&exercisesPerPage=" + exercisesPerPage + "&domain=" + domain)
                .then(function (response) {
                    deferred.resolve(response.data);
                });
            return deferred.promise;
        };

        self.getDropdownValues = function () {
           let deferred = $q.defer();

            $http.get("http://localhost:56411/home/DropdownValues")
                .then(function (response) {
                    deferred.resolve(response.data);
                });
            return deferred.promise;
        };

        self.getFilteredExercises = function (pageNumber, exercisesPerPage, domain, exerciseID, learningObjective, selectedSubject, selectedUser) {
           let deferred = $q.defer();

            $http.get(rootURL + "/FilterExercises?pageNumber=" + pageNumber + "&exercisesPerPage=" + exercisesPerPage + "&domain=" + domain + "&exerciseID=" + exerciseID + "&learningObjective=" + learningObjective + "&selectedSubject=" + selectedSubject + "&selectedUser=" + selectedUser)
                .then(function (response) {
                    deferred.resolve(response.data);
                });
            return deferred.promise;
        }

        self.getSummary = function (summaryDate) {
           let deferred = $q.defer();
            $http.get(rootURL + "/GetSummary?date="+summaryDate)
                .then(function (response) {
                    deferred.resolve(response.data);
                });
            return deferred.promise;
        }
    }]);