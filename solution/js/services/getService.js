angular.module('snappet').factory('dataStore',['$http',function($http){
    return{
        classData: function(){
            return $http.get('/Data/work.json')
        }
    }
}])