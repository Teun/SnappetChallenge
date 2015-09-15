function createChart(work, labels, chartName) {
    var ctx = document.getElementById(chartName).getContext("2d");
    
    var data = {
        labels: labels,
        datasets: [
            {
                label: "Average progress",
                fillColor: "rgba(153,204,255,0.5)",
                strokeColor: "rgba(153,204,255,0.8)",
                highlightFill: "rgba(153,204,255,0.75)",
                highlightStroke: "rgba(153,204,255,1)",
                data: work
            }
        ]
    };

    var myBarChart = new Chart(ctx).Bar(data);
}