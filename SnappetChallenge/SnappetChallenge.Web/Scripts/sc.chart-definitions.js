"use strict";

var sc = sc || {};

sc.chartdefinitions = {};

sc.chartdefinitions.studentProgress = {
    chart: {
        type: 'bar'
    },
    xAxis: [
        {
            categories: ['Voortgang', 'Percentage goed', 'Aantal gemaakte opgaven', 'Gemiddelde moeilijkheidsgraad'],
            reversed: false,
            labels: {
                step: 1
            }
        }
    ],
    yAxis: {
        min: -3,
        max: 3,
        title: {
            text: null
        },
        labels: {
            formatter: function () {
                return Math.abs(this.value) + '%';
            }
        }
    },

    plotOptions: {
        series: {
            stacking: 'normal'
        },
    },
    legend: {
        enabled: false
    },
};