var myApp = angular.module('myApp', ['smart-table','chart.js']);



myApp.controller('MainController', ['$scope', '$filter', '$http', function (scope, filter, $http) 
{
    function GetData() {
        // Simple GET request example :
        $http.get('/api/Default/GetUsers').
          success(function (data, status, headers, config) {
              // this callback will be called asynchronously
              // when the response is available
              scope.rowCollection = data;
              //copy the references (you could clone ie angular.copy but then have to go through a dirty checking for the matches)
              scope.displayedCollection = [].concat(scope.rowCollection);
              GetSummaries();
             
          }).
          error(function (data, status, headers, config) {
              // called asynchronously if an error occurs
              // or server returns response with an error status.
          });
    }

    /* varialbes init*/
    scope.showFull = false;
    scope.predicates = ['UserId', 'Subject'];
    scope.selectedPredicate = scope.predicates[0];

    /* Run initial Functions */
    GetData();

    scope.ShowHideFull = function ShowHideFull()
    {
        if (!scope.showFull) scope.showFull = true;
        else scope.showFull = false;
    }

    function GetSummaries()
    {
        $http.get('/api/Default/GetSubjectSummary').
           success(function (data, status, headers, config) {
               // this callback will be called asynchronously
               // when the response is available
               scope.summarySubjectRowCollection = data;
               scope.summarySubjectDisplayCollection = [].concat(scope.summarySubjectRowCollection);

               scope.subjectSummaryData = [];
               scope.subjectSummaryLabels = [];
               scope.subjectSummaryCorrectData = [];

               angular.forEach(data, function (item) {
                   scope.subjectSummaryData.push(item.TotalExercises);
                   scope.subjectSummaryLabels.push(item.Subject);
                   scope.subjectSummaryCorrectData.push(Math.round(100*item.CorrectExercises/item.TotalExercises));
               });
               
           }).
            error(function (data, status, headers, config) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });



        $http.get('/api/Default/GetUserSummary').
                       success(function (data, status, headers, config) {
                           // this callback will be called asynchronously
                           // when the response is available
                           scope.summaryRowCollection = data;
                           scope.summaryDisplayCollection = [].concat(scope.summaryRowCollection);
                       }).
                        error(function (data, status, headers, config) {
                            // called asynchronously if an error occurs
                            // or server returns response with an error status.
                        });




                        $http.get('/api/Default/GetExcerciseSummary').
                           success(function (data, status, headers, config) {
                               // this callback will be called asynchronously
                               // when the response is available
                               scope.summaryExcerciseRowCollection = data;
                               scope.summaryExcerciseDisplayCollection = [].concat(scope.summaryExcerciseRowCollection);
                           }).
                            error(function (data, status, headers, config) {
                                // called asynchronously if an error occurs
                                // or server returns response with an error status.
                            });

        

    }

    scope.changePlus = function (length, show) {
        if (!show) {
            return '-';
        } else {
            return '+' + length;
        }
    }

    scope.SelectSubject = function SelectSubject(points, evt) {

        scope.selectedSubject = points[0].label;
        // todo - trigger the filter
    };


}]);
