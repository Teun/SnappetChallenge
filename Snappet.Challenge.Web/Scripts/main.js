require.config({
    waitSeconds: 30,
    baseUrl: "/Scripts/app",
    paths: {
        jquery: "../lib/jquery-2.2.4",
        bootstrap: "../lib/bootstrap",
        knockout: "../lib/knockout-3.4.0",
        jqueryUI: "../lib/jquery-ui",
        highcharts: "../lib/highcharts"
    },
    shim: {
        jqueryUI: ["jquery"],
        highcharts: ["jquery"]
    }
});

require(["knockout", "studentsResultViewModel"],
    function(ko, studentsResultViewModel) {
        ko.applyBindings(new studentsResultViewModel());
    });