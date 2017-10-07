(function() {
    "use strict";
  
    function ScatterPlotChartGenerator() {
      return {
        restrict: "EA",
        templateUrl:
          "components/scatterplotchart/scatterplot.component.html",
        scope: {
          datasample: "=datapointsamples"
        },
        controller: ["$scope", function($scope) {}],
        link: function(scope, element, attributes) {
          scope.$watch("datasample", function() {
            if (scope.datasample !== undefined) {
              if (scope.datasample !== undefined) {
                  d3.select(".scatterplot-chart").html("");
                  renderChart(scope.datasample)
              }
            }
          });
          function renderChart(data) {
            var margin = {top: 20, right: 15, bottom: 60, left: 60}
            , width = 960 - margin.left - margin.right
            , height = 500 - margin.top - margin.bottom;
          
          var x = d3.scale.linear()
                    .domain([0, d3.max(data, function(d) { return d[0]; })])
                    .range([ 0, width ]);
          
          var y = d3.scale.linear()
                    .domain([0, d3.max(data, function(d) { return d[1]; })])
                    .range([ height, 0 ]);
       
          var chart = d3.select('.scatterplot-chart')
          .append('svg:svg')
          .attr('width', width + margin.right + margin.left)
          .attr('height', height + margin.top + margin.bottom+80)
          .attr('class', 'chart')
      
          var main = chart.append('g')
          .attr('transform', 'translate(' + margin.left + ',' + margin.top + ')')
          .attr('width', width)
          .attr('height', height)
          .attr('class', 'main')   
              
          // draw the x axis
          var xAxis = d3.svg.axis()
          .scale(x)
          .orient('bottom');
      
          main.append('g')
          .attr('transform', 'translate(0,' + height + ')')
          .attr('class', 'main axis')
          .attr("stroke-width", 2)
          .call(xAxis);
      
          // draw the y axis
          var yAxis = d3.svg.axis()
          .scale(y)
          .orient('left');
      
          main.append('g')
          .attr('transform', 'translate(0,0)')
          .attr('class', 'main axis')
          .attr("stroke-width", 2)
          .call(yAxis);
      
          main.append("text")
              .attr("transform", "translate(" + (width / 2) + " ," + (height + margin.bottom+5) + ")")
              .style("text-anchor", "mideel")
              .text("Average Diffculty");
              
          main.append("text")
              .attr("transform", "rotate(-90)")
              .attr("y",(0 - margin.left))
              .attr("x",0 - (height / 2))
              .attr("dy", "1em")
              .style("text-anchor", "mideel")
              .text("Answered Correctly");
              
          var g = main.append("svg:g"); 
          
          g.selectAll("scatter-dots")
            .data(data)
            .enter().append("svg:circle")
                .attr("cx", function (d,i) { return x(d[0]); } )
                .attr("cy", function (d) { return y(d[1]); } )
                .attr("r", 5);
          }
        }
      };
    }
  
    angular
      .module("snappet")
      .directive("scatterPlotChart", ScatterPlotChartGenerator);
  
    angular.$inject = [];
  })();
  