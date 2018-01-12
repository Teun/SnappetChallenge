(function () {
    angular.module('common').factory('reportService', ['$q', '$timeout', '$http','$filter', 'appSettings', reportService]);


    function reportService($q, $timeout, $http,$filter, constants) {
        return {
            getLearningObj: getLearningObj,
            getLearningObjByDate: getLearningObjByDate
        };

        function getLearningObj() {
            return $http({
                method: 'GET',
                url: 'http://localhost:2225/api/work',
                transformResponse: transformGetBooks
            }).then(sendResponeData)
                .catch(sendError);
        }

        function getLearningObjByDate(date) {
            console.log('report date: ' + date);
            return $http({
                method: 'GET',
                url: 'http://localhost:2225/api/work/',
                //headers: {
                //    'ttt': date
                //},
                params: {
                    dateVal: $filter('date')(date, "yyyy-MM-dd HH:mm:ss")
                },
                transformResponse: transformReport
            }).then(sendResponeData)
                .catch(sendError);
        }

        function transformReport(data, headersGetter) {           
            var transformed = angular.fromJson(data);

            transformed.forEach(function (currentValue, index, array) {
                currentValue.CreatedDate = new Date();
            });

            //console.log(transformed);
            return transformed;
        }

        function sendResponeData(response) {
            console.log('Get success data from reportService');           
            //console.log(response.data);
            return response.data;
        }

        function sendError(response) {
            return $q.reject('Error retrieving LO(s). (HTTP sstatus: ' + response.status + ')');
        }

    }

}());