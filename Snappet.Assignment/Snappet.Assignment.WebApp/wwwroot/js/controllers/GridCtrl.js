app.controller('GridCtrl', ['$scope', '$filter', function ($scope, $filter) {


    $scope.sort = {
        sortingOrder: '',
        reverse: false
    };
    $scope.filter = {};
    $scope.maxGap = 5;
    $scope.itemsPerPage = 10;

    $scope.currentPage = 0;

    $scope.prevPage = function () {
        if ($scope.currentPage > 0) {
            $scope.currentPage--;
        }
    };

    $scope.nextPage = function () {
        if ($scope.currentPage < ($scope.pagedItems.length - 1)) {
            $scope.currentPage++;
        }
    };

    $scope.firstPage = function () {

        $scope.currentPage = 0;

    };

    $scope.lastPage = function () {

        $scope.currentPage = $scope.pagedItems.length - 1;

    };

    $scope.groupToPages = function (items) {

        $scope.pagedItems = [];

        if ($scope.sort.sortingOrder !== '') {
            $scope.sortedItems = $filter('orderBy')(items, $scope.sort.sortingOrder, $scope.sort.reverse);
        } else {
            $scope.sortedItems = items;
        }

        for (var i = 0; i < $scope.sortedItems.length; i++) {
            if (i % $scope.itemsPerPage === 0) {
                $scope.pagedItems[Math.floor(i / $scope.itemsPerPage)] = [$scope.sortedItems[i]];
            } else {
                $scope.pagedItems[Math.floor(i / $scope.itemsPerPage)].push($scope.sortedItems[i]);
            }
        }


        if ($scope.pagedItems.length < $scope.maxGap) {
            $scope.gap = $scope.pagedItems.length;
        } else {
            $scope.gap = $scope.maxGap;
        }
    };

    $scope.range = function (size, start, end) {
        var ret = [];

        if (size < end) {
            end = size;
            start = size - $scope.gap;
        }
        for (var i = start; i < end; i++) {
            ret.push(i);
        }

        return ret;
    };

    $scope.setPage = function () {
        $scope.currentPage = this.n;
    };


    $scope.sorting = function (newSortingOrder, items) {


        if ($scope.sort.sortingOrder === newSortingOrder) {
            $scope.sort.reverse = !$scope.sort.reverse;
        }

        $scope.sort.sortingOrder = newSortingOrder;

        $scope.groupToPages(items);
    }

}]);