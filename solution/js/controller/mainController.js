angular.module('snappet').controller('mainController', ['$scope', 'dataStore', function ($scope, dataStore) {
    $scope.index = 0;
    $scope.tail = 50;
    $scope.pageNumber = 0;
    $scope.getData = function () {
        $scope.loading = true;
        dataStore.classData().then(function (data) {
            $scope.classDataObjects = data.data;
            $scope.getClassDataByPage($scope.index);
            $scope.loading = false;

        })
    }
    $scope.init = function () {
        $scope.getData();
    }
    $scope.getUser = function () {
        $scope.hashValue = window.location.hash.split('#')[1];
    }
    $scope.getAddonData = function (obj) {
        $scope.pageAddon = [];
        var Tlength = obj.length;
        $scope.pageAddon.push(obj.length);
         $scope.getDateRange(obj);
         var CorrectCount = $scope.getCorrectCount(obj);
         $scope.pageAddon.push(CorrectCount);
         $scope.generatePagesNumbers(obj);
    }
    $scope.getDateRange = function (obj) {
       
        var dateArray = [];
        for (i = 0; i <= obj.length; i++) {
            if (obj[i] != undefined) {
                dateArray.push(new Date(obj[i].SubmitDateTime.split('T')[0]));
            }
        }
        var maxDate = new Date(Math.max.apply(null, dateArray));
        var minDate = new Date(Math.min.apply(null, dateArray));
        $scope.maxDate = maxDate.toISOString().replace(/T.*/, '').split('-').reverse().join('-');
        $scope.minDate = minDate.toISOString().replace(/T.*/, '').split('-').reverse().join('-');
    }
    $scope.getCorrectCount = function (obj) {
        var correctArray = [];
        for (i = 0; i <= obj.length; i++) {
            if ((obj[i] != undefined) && (obj[i].Correct == '1')) {
                correctArray.push(obj[i]);
            }

        }
        return correctArray.length;
    }
    $scope.gettestDetails = function () {
        $scope.user = window.location.hash.split('#')[1].split('&')[1];
        $scope.subject = window.location.hash.split('#')[1].split('&')[0];

    }
    $scope.generatePagesNumbers = function (obj) {
        $scope.pages = [];
        $scope.pageLength = obj.length / $scope.tail;
        for (i = 0; i < $scope.pageLength; i++) {
            $scope.pages.push(i);
        }
        console.log($scope.pages);
    }
    $scope.changePage = function (pageNumber) {
        $scope.newIndex = pageNumber * $scope.tail;
        $scope.getClassDataByPage($scope.newIndex);
    }
    $scope.getClassDataByPage = function (index) {
        $scope.newRangeClassData = [];
        for (var i = 0; i < $scope.tail; i++) {
            $scope.newRangeClassData.push($scope.classDataObjects[index])
            index++;
        }
    }
    $scope.updateLineLimit = function (newLimit) {
        $scope.tail = newLimit;
        $scope.getClassDataByPage($scope.index);
        $scope.generatePagesNumbers();
    }

    $scope.init();

}]);

