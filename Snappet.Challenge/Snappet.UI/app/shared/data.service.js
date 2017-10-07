(function(){

    function DataService($http,$q){
        this.getChartData=function(selecteddate,subject){
            var url='http://localhost:55315/api/bellcurve/generate?givenDateTimeUTC='+selecteddate+'&subject='+subject
            var deffered= $q.defer();

            $http
            .get(url)
            .success(function(response){
                deffered.resolve(response);
            }).error(function(error){
                deffered.reject(error);
            });


            return deffered.promise;
        }

        this.getScatterPlotData=function(selecteddate,subject){
            var url='http://localhost:55315/api/scatterplot/generate?givenDateTimeUTC='+selecteddate+'&subject='+subject
            var deffered= $q.defer();

            $http
            .get(url)
            .success(function(response){
                deffered.resolve(response);
            }).error(function(error){
                deffered.reject(error);
            });


            return deffered.promise;
        }
    }

    angular.module('snappet')
            .service('DataService',DataService);

    DataService.$inject=['$http','$q']


})();