(function () {

	/**
	 * @description
	 * This script is pretty straight forward, its a highcharts configuration.
	 */
	angular
		.module('SnappetChallenge')
		.factory('ChartSpline', chartSpline);

	function chartSpline(TRANSLATIONS) {

		return {
			create: function(options) {
				var amount = "";

				options = options || {};
				options.title = options.title || null;
				options.values = options.values || {};
				options.values.min = options.values.min || 0;
				options.values.max = options.values.max || 100;
				options.value = options.value || 0;

				if(options.type == "correct" || options.type == "incorrect") {
					amount = "%";
				}

				var data = [];
				// Format data to the highcharts model
				_.reduce(options.data, function(result, value, id) {

					data.push({
						name: TRANSLATIONS[id],
						data: _.invoke(_.keys(value), function() {
							var val = value[this][0];
							val = (options.type == "progress") ? val.progress : val.percentages[options.type];
							val = (options.type == "difficulty") ? value[this][0].difficulty : val;

							return [parseFloat(this), val];
						})
					});

				}, {});

				return {
					options: {
						chart: {
							type: 'spline'
						},

						tooltip: {
							headerFormat: '<b>{series.name}</b><br>',
							pointFormat: '{point.x:%e %B}: {point.y}' + amount
						},

						title: {
							text: options.title
						},

						plotOptions: {
							spline: {
								lineWidth: 4,
								states: {
									hover: {
										lineWidth: 5
									}
								},
								marker: {
									enabled: true,
									radius: 5
								}
							}
						}
					},

					xAxis: {
						type: 'datetime',
						dateTimeLabelFormats: { // don't display the dummy year
							month: '%e %b',
							year: '%b'
						},
						title: {
							text: 'Date'
						}
					},
					yAxis: {
						title: {
							text: options.yAxisTitle || ""
						}
					},

					series: data
				}
			}
		}

	}

})();
