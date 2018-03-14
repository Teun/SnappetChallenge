(function() {

angular.module('students-report').controller('studentReportCtrl', studentReportCtrl);

function studentReportCtrl($scope, studentReportService) {

$scope.studentReport=[];


  var loadReport = function () {

    studentReportService.getStudentsReport().then(function(resp){
        var grouped = groupBy(resp,'UserId');
        $scope.studentsReport = [];
        for(let k of Object.keys(grouped)){
            var avgProgress = grouped[k].reduce((a,c)=>a+=c.Progress,0);
            var avgCorrectness = grouped[k].reduce((a,c)=>a+=c.Correct,0);
            $scope.studentsReport.push({UserId:k,AvgProgress:avgProgress,AvgCorrectness:avgCorrectness})
        }
        $scope.classProgress = resp.reduce((a,c)=>a+=c.Progress,0);
    },erroHandler);
    
       
    };


   
    function erroHandler(err) {
           console.log(err);
    }

     function groupBy(xs, key) {
        return xs.reduce(function(rv, x) {
          (rv[x[key]] = rv[x[key]] || []).push(x);
          return rv;
        }, {});
      };

    loadReport();
 }

})();
