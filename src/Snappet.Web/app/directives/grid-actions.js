angular.module('cvdApp')

.directive('gridActions', [

    function () {
        return {
            restrict: 'E',
            replace: true,
            template: 
                '<div>' +
                '<button type="button" class="btn btn-default action-button" data-animation="am-flip-x" bs-dropdown aria-haspopup="true" aria-expanded="false">...' +
                '</button>' + 
                '<ul class="dropdown-menu" role="menu">' + 
                '  <li><a href="#">Nieuw<i class=\"fa fa-plus pull-right\"></i></a></li>' +
                '  <li><a href="#">Zoeken<i class=\"fa fa-search pull-right\"></i></a></li>' +
                '  <li><a href="#">Prioriteit +<i class=\"fa fa-plus-square-o pull-right\"></i></a></li>' +
                '  <li><a href="#">Prioriteit -<i class=\"fa fa-minus-square-o pull-right\"></i></a></li>' +
                '  <li><a ui-sref="package.algemeen({id : id})" >Wijzigen<i class=\"fa fa-pencil pull-right\"></i></a></li>' +
                '  <li><a href="#">Verwijderen<i class=\"fa fa-close pull-right\"></i></a></li>' +
                '</ul>' + 
                '</div>',
            scope : {
                'id' : '='
            },
            controller: function ($scope) {

            }
        }
    }
]);
