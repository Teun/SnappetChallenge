app.factory('httpService', ["$http", "$q" , function ($http, $q) {

    return {
        get: function (url) {
            $("#loadingDiv").show();
            var deffered = $q.defer();
            $http.get(url).then(function (result) {
                $("#loadingDiv").hide();
                deffered.resolve(result)
            }, function (error) {
                $("#loadingDiv").hide();
                deffered.reject(error);
            })

            return deffered.promise;
        },


    };

}]);
