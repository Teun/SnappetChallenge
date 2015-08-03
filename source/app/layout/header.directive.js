(function() {

	angular
		.module('SnappetChallenge')
		.directive('snappetHeader', snappetHeader);

	/**
	 * @description
	 * This directive provides common functionality of a header and also include a datepicker (included with bootstrap-ui)
	 */
	function snappetHeader($rootScope, NOW) {
		var template = ''+
			'<header class="navbar navbar-default navbar-fixed-top">' +
				'<div class="container-fluid">' +
					'<div class="">' +
						'<a href="#/resultaten" class="btn btn-primary btn-back" ng-if="back" ng-click="goBack()">Terug naar vandaag</a>' +
						'<button type="button" class="navbar-toggle collapsed" ng-click="isCollapsed = !isCollapsed" aria-expanded="false">' +
							'<span class="sr-only">Toggle navigation</span>' +
							'<span class="icon-bar"></span>' +
							'<span class="icon-bar"></span>' +
							'<span class="icon-bar"></span>' +
						'</button>' +
						'<div class="collapse navbar-collapse col-xs-12" collapse="isCollapsed" id="bs-navbar-collapse">' +
							'<div class="col col-1">' +
								'<label>Resultaten filter vanaf:</label>' +
								'<div>' +
									'<p class="input-group">' +
										'<input type="text" class="form-control" datepicker-popup="{{format}}" ng-model="from" is-open="openedFrom" max-date="to" datepicker-options="{startingDay: 1, yearFormat: \'yy\'}" show-button-bar="false" ng-required="true" close-text="Close" ng-click="openFrom($event)" readonly="readonly">' +
										'<span class="input-group-btn">' +
											'<button type="button" class="btn btn-default" ng-click="openFrom($event)"><i class="glyphicon glyphicon-calendar"></i></button>' +
										'</span>' +
									'</p>' +
								'</div>' +
							'</div>' +

							'<div class="col col-2">' +
								'<label>T/m:</label>' +
								'<div>' +
									'<p class="input-group">' +
										'<input type="text" class="form-control" datepicker-popup="{{format}}" ng-model="to" is-open="openedTo" min-date="from" max-date="\'2015-03-24\'" show-button-bar="false" datepicker-options="{startingDay: 1, yearFormat: \'yy\'}" ng-required="true" close-text="Close" ng-click="openTo($event)" readonly="readonly">' +
										'<span class="input-group-btn">' +
											'<button type="button" class="btn btn-default" ng-click="openTo($event)"><i class="glyphicon glyphicon-calendar"></i></button>' +
										'</span>' +
									'</p>' +
								'</div>' +
							'</div>' +
						'</div>' +
					'</div>' +
				'</div>' +
			'</header>';

		var directive = {
			restrict: 'EA',
			template: template,
			link: link
		};
		return directive;

		function link($scope) {
			$scope.isCollapsed = true;

			$scope.fromOptions = {
				'year-format': "'yy'",
				'starting-day': 1
			};

			$scope.toOptions = {
				'year-format': "'yy'",
				'starting-day': 1
			};

			$scope.from = new Date().setTime(NOW);
			$scope.to = new Date().setTime(NOW);

			$scope.openTo = function($event) {
				$event.preventDefault();
				$event.stopPropagation();

				$scope.openedTo = true;
				$scope.openedFrom = false;
			};
			$scope.openFrom = function($event) {
				$event.preventDefault();
				$event.stopPropagation();

				$scope.openedFrom = true;
				$scope.openedTo = false;
			};
			$scope.format = 'dd/MM/yyyy';

			var discrete = false;
			var watchDatepicker = function(newValue, oldValue) {
				if (!discrete) {
					var from = moment($scope.from),
						to = moment($scope.to);

					from.hours(0).minutes(0).seconds(0).milliseconds(0);
					to.hours(23).minutes(59).seconds(59).milliseconds(999);

					if (newValue !== oldValue) {
						document.location.hash = "#/resultaten/" + from.valueOf() + "/" + to.valueOf() + "/";
						$scope.back = true;
					}
				}
				setTimeout(function() {
					discrete = false;
				}, 60);
			};

			$scope.$watch('from', watchDatepicker);
			$scope.$watch('to', watchDatepicker);

			$rootScope.updateDatepicker = function(from, to) {
				discrete = true;
				$scope.to = to;
				$scope.from = from;
			};

			if (document.location.hash.split("resultaten/").length > 1) {
				$scope.back = true;
			} else {
				$scope.back = false;
			}

			$scope.goBack = function() {
				$scope.back = false;
			};
		}
	}

})();
