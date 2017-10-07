(function() {
  "use strict";

  function BellCurveBarChartGenerator() {
    return {
      restrict: "EA",
      templateUrl:
        "components/bellcurvebarchart/bellcurvebarchart.component.html",
      scope: {
        datasample: "=datapointsamples"
      },
      controller: ["$scope", function($scope) {}],
      link: function(scope, element, attributes) {
        var data = [];
        scope.$watch("datasample", function() {
          if (scope.datasample !== undefined) {
            if (scope.datasample !== undefined) {
              var distribution = scope.datasample.Distribution;
              var datasample = scope.datasample.Data;

              if (distribution !== undefined || datasample !== undefined) {
                data = [];
                d3.select(".bar-chart").html("");
                loadData(distribution, datasample);
              }
            }
          }
        });
        function loadData(distribution, dataContent) {
          for (var i = 0; i < dataContent.length - 1; i++) {
            var q = dataContent[i];
            var p = distribution[i];
            var el = {
              q: q,
              p: p
            };
            data.push(el);
          }
          data.sort(function(x, y) {
            return x.q - y.q;
          });
          //d3.select(".chart").selectAll("*").remove();
          renderChart();
        }
        function renderChart() {
          var margin = {
              top: 20,
              right: 20,
              bottom: 40,
              left: 55
            },
            width = 960 - margin.left - margin.right,
            height = 500 - margin.top - margin.bottom;

          var xScale = d3.scale.ordinal().rangeRoundBands([0, width], 0.1);

          var xdomain = d3.extent(data, function(d) {
            return d.q;
          });

          var x = d3.scale
            .linear()
            .domain(xdomain)
            .range([0, width]);

          var y = d3.scale.linear().range([height, 0]);

          var xAxis = d3.svg
            .axis()
            .scale(xScale)
            .orient("bottom");

          var yAxis = d3.svg
            .axis()
            .scale(y)
            .orient("left");

          var line = d3.svg
            .line()
            .x(function(d) {
              return x(d.q);
            })
            .y(function(d) {
              return y(d.p);
            }); //.interpolate("basis");;

          var svg = d3
            .select(".bar-chart")
            .append("svg")
            .attr("width", width + margin.left + margin.right)
            .attr("height", height + margin.top + margin.bottom + 80)
            .append("g")
            .attr(
              "transform",
              "translate(" + margin.left + "," + margin.top + ")"
            );

          xScale.domain(
            data.map(function(d) {
              return d.q;
            })
          );
          y.domain(
            d3.extent(data, function(d) {
              return d.p;
            })
          );

          var groups = svg
            .append("g")
            .attr("class", "x axis")
            .attr("stroke-width", 2)
            .attr("transform", "translate(0," + (height + 3) + ")")
            .call(xAxis);

          svg
            .append("g")
            .attr("class", "y axis")
            .attr("stroke-width", 2)
            .call(yAxis);

          svg
            .selectAll(".bar")
            .data(data)
            .enter()
            .append("rect")
            .attr("class", "bar")
            .attr("x", function(d) {
              return xScale(d.q);
            })
            .attr("width", xScale.rangeBand())
            .attr("y", function(d) {
              return y(d.p);
            })
            .attr("height", function(d) {
              return height - y(d.p);
            });

          svg
            .append("text")
            .attr(
              "transform",
              "translate(" +
                (width / 2 - 20) +
                " ," +
                (height + margin.bottom + 20) +
                ")"
            )
            .style("text-anchor", "mideel")
            .text("Average Performers");

          svg
            .append("text")
            .attr(
              "transform",
              "translate(" +
                (width - 190) +
                " ," +
                (height + margin.bottom + 20) +
                ")"
            )
            .style("text-anchor", "mideel")
            .text("High Performers");

          svg
            .append("text")
            .attr(
              "transform",
              "translate(" + 100 + " ," + (height + margin.bottom + 20) + ")"
            )
            .style("text-anchor", "mideel")
            .text("Low Performers");

          svg
            .append("text")
            .attr(
              "transform",
              "translate(" +
                (width / 2 - 80) +
                " ," +
                (height + margin.bottom) +
                ")"
            )
            .style("text-anchor", "mideel")
            .text("CORRECT ANSWERS FROM GIVEN SUBJECT")
            .attr("class", "legend-bold");

          svg
            .selectAll("path")
            .data(data)
            .exit()
            .remove();
        }
      }
    };
  }

  angular
    .module("snappet")
    .directive("bellCurveBarChart", BellCurveBarChartGenerator);
})();
