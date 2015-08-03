(function() {

	angular
		.module('SnappetChallenge', [
			'data-extractor',
			'ngRoute',
			'templates-build',
			'angular-loading-bar',
			'highcharts-ng',
			'ui.bootstrap'
		])
		.config(Setup)
		.run(Runner);

	/**
	 * @description
	 * This config will transform all dates provide in strings into a Moment.js object
	 * We need to add the "Z" charater to ensure Moment.js won't fallback to the native Date object
	 */
	function Setup($provide, RESULTS) {

		// Set current date to specifications
		var currentDate = moment("2015-03-24T11:30:00.000Z");
		$provide.constant("NOW", currentDate.valueOf());

		// Transform all dates into moment format
		var cleanResults = RESULTS.map(function(value) {
			value.SubmitDateTime = moment(value.SubmitDateTime + "Z");
			return value;
		});

		// Filter out newer results
		cleanResults = cleanResults.filter(function(value) {
			return value.SubmitDateTime <= currentDate;
		});

		// Overwrite filtered data to the constant
		$provide.constant("RESULTS", cleanResults);

	}

	/**
	 * @description
	 * This function will execute a few configurations to the base of the application before loading routing and the controllers
	 */
	function Runner($rootScope, TRANSLATIONS) {

		// Make translations accessable to templates
		$rootScope.translations = TRANSLATIONS;

		// Setup Highcharts to Dutch and disable UTC since we already use Moment.js
		// TODO: This could be seperated from this file but it would be more preferable to add this into a JSON for even better localization if needed
		Highcharts.setOptions({
			global: {
				useUTC: false
			},
			lang: {
				loading: 'Wordt geladen...',
				months: ['januari', 'februari', 'maart', 'april', 'mei', 'juni', 'juli', 'augustus', 'september', 'oktober', 'november', 'december'],
				weekdays: ['zondag', 'maandag', 'dinsdag', 'woensdag', 'donderdag', 'vrijdag', 'zaterdag'],
				shortMonths: ['jan', 'feb', 'maa', 'apr', 'mei', 'jun', 'jul', 'aug', 'sep', 'okt', 'nov', 'dec'],
				exportButtonTitle: "Exporteren",
				printButtonTitle: "Printen",
				rangeSelectorFrom: "Vanaf",
				rangeSelectorTo: "Tot",
				rangeSelectorZoom: "Periode",
				downloadPNG: 'Download als PNG',
				downloadJPEG: 'Download als JPEG',
				downloadPDF: 'Download als PDF',
				downloadSVG: 'Download als SVG',
				resetZoom: 'Reset',
				resetZoomTitle: 'Reset',
				thousandsSep: '.',
				decimalPoint: ','
			}
		});

	}

})();
