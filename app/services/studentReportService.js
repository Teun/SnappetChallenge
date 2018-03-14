(function() {

    angular.module('students-report').factory('studentReportService',studentReportService);

    function studentReportService($http, $q) {

        var baseUrl="http://localhost:8000";
       

        var getStudentsReport = function (lon,lat) {

            var defered = $q.defer();

            $http.get(baseUrl+"/studentsData").then(function (response) {

                defered.resolve(response.data);

            }, function (error) {
                defered.reject(error.data);
            });

            return defered.promise;
        };      

         

        return {
            getStudentsReport: getStudentsReport
           
        }
    }

})();

