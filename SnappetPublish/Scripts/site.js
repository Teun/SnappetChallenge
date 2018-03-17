var CURRENT_TIME = "2015-03-24 11:30:00";

var app = new Vue({
    el: '#app',
    data: {
        subjectChartData: [],
        domainChartData: [],
        correctnessCompChartData: []
    },
    created: function () {
        this.loadData();
    },

    methods: {
        loadData: function () {
            var vm = this;
            axios.get(ROOT + 'Home/GetChartsData', {
                params: {
                    currentDate: CURRENT_TIME
                }
            })
            .then(function (response) {                
                vm.updateChartData(response.data);
            })
            .catch(function (error) {
                alert("Error in loading json data");
            });
        },

        updateChartData: function(data) {
            this.subjectChartData = this.convertToCKFormat(data.subjectChartData);
            this.domainChartData = this.convertToCKFormat(data.domainChartData);
            this.correctnessCompChartData = this.convertToCKFormat(data.correctnessCompChartData);
        },
                
        convertToCKFormat: function (data) {            
            var ckChart = [];            
            data.chartItems.forEach(function(chartItem) {                
                var ckDatasets = [];
                
                chartItem.datasets.forEach(function(dataset) {
                    ckDatasets.push([dataset['prop'], dataset['value']]);                    
                });
                
                var ckChartItem = {
                    name: chartItem.name,
                    data: ckDatasets
                };
                ckChart.push(ckChartItem);
            });
            //console.log(data);
            //console.log(ckChart);
            return ckChart;
        }
    }
})
