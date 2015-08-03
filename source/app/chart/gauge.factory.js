(function() {

	/**
	 * @description
	 * This script is pretty straight forward, its a highcharts configuration.
	 */
	angular
		.module('SnappetChallenge')
		.factory('ChartGauge', chartGauge);

	function chartGauge() {

		return {
			create: function(options) {

				options = options || {};
				options.title = options.title || null;
				options.values = options.values || {};
				options.values.min = options.values.min || 0;
				options.values.max = options.values.max || 100;
				options.value = options.value || 0;
				options.data = options.data || [];

				var data = Math.round((options.data.correct / (options.data.correct + options.data.incorrect)) * 100);

				return {
					options: {
						chart: {
							type: 'solidgauge',
							alignTicks: false,
							plotBackgroundColor: null,
							plotBackgroundImage: null,
							plotBorderWidth: 0,
							plotShadow: false,
							spacingTop: 0,
							spacingLeft: 0,
							spacingRight: 0,
							spacingBottom: 0
						},

						tooltip: {
							enabled: false
						},

						title: {
							text: options.title || "",
							y: 120
						},

						pane: {
							center: ['50%', '85%'],
							size: '100%',
							startAngle: -90,
							endAngle: 90,
							background: {
								backgroundColor: '#EEE',
								innerRadius: '60%',
								outerRadius: '100%',
								shape: 'arc'
							}
						},

						plotOptions: {
							solidgauge: {
								dataLabels: {
									y: 5,
									borderWidth: 0,
									useHTML: true
								}
							}
						}
					},

					yAxis: {
						stops: [
							[0, '#DF5353'],
							[0.33, '#DDDF0D'],
							[0.66, '#55BF3B']
						],
						lineWidth: 0,
						minorTickInterval: null,
						tickPixelInterval: 400,
						tickWidth: 0,
						title: {
							y: -70
						},
						labels: {
							y: 16
						},
						min: options.values.min,
						max: options.values.max
					},

					series: [{
						name: 'Goed beantwoord',
						data: [data],
						dataLabels: {
							y: -60,
							format: '<div><strong>{y:.1f}%</strong><small>Goed beantwoord</small></div>'
						}
					}]
				}
			}
		}

	}

})();
