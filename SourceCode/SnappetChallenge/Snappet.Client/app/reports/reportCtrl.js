(function () {
    "use strict";

    angular.module("SnappetApp")
        .controller("reportCtrl", ["reportResource", "reportService", reportCtrl]);

    function reportCtrl(reportResource, reportService) {
        var vm = this;

        vm.recordLimit = 10;
        vm.TotalToComplatePerDay = 100;        


        $("#datepickerDashboard").datepicker();

        if ($("#datepickerDashboard").val() == '') {
            $("#datepickerDashboard").val("03/03/2015");
        }

        vm.ShowReport = function () {
            reportService.getLearningObjByDate($("#datepickerDashboard").val())
            .then(getLOSuccess)
            .catch(errorCallBack);
        }


        function getLOSuccess(response) {
            console.log('Get success data in reportCtrl');
            vm.ListOfObjectives = response;

            if (vm.ListOfObjectives.length > 0) {
                var completed = vm.ListOfObjectives.length;
                vm.LearningObjectiveCompleted = Math.floor((completed / vm.TotalToComplatePerDay) * 100);
                vm.StudentAverage = calculateAverage(vm.ListOfObjectives);
            }
            else {
                vm.StudentAverage = 0;
                vm.Students = [];
            }


        }

        function errorCallBack(error) {
            console.log(error);
        }

        vm.ShowUser = function (users) {

            vm.Students = users;
        }

        var calculateAverage = function (MyData) {
            var sum = 0;
            for (var i = 0; i < MyData.length; i++) {
                sum += parseInt(MyData[i].MasteryPercentage, 10); //don't forget to add the base 
            }

            var avg = sum / MyData.length;

            return Math.floor(avg);
        };

    }

}());