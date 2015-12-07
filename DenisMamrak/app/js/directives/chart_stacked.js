angular.module('snappet').directive('chartStacked', ['Formatter', function(Formatter){
	return {
		restrict: 'E',
		replace: true,
		priority: 0,
		scope: {
			data: '=',
			map: '=',
			click: '&'
		},
		templateUrl: 'tpl/chart_stacked.html',
		link: function($scope, $element, $attrs){

			$scope.tooltip = {
				show: false
			}

			var $parent = $element.parent();
			var $tooltip = $element.find('.tooltip');

			var width  = $attrs.width == 'auto' ? $parent.width() : $attrs.width;
			var height = $attrs.height == 'auto' ? $parent.height() : $attrs.height;
			var map = $scope.map ? $scope.map : {date: 'date', value: 'value', type: 'type'};

			var padding = 20;
			var maxWidth = 45;
			var rendered = false;

			var x;
			var y;
			var axis;
			var layer;
			var rect;
			var stack;
			var points;
			var visible;

			var svg = d3.select($element.find('svg')[0])
				.attr('width', width)
				.attr('height', height)
				.append('g')
				.attr('class', 'base')
				.attr('transform', 'translate(0,' + (height - padding) + ')');

			svg.append('rect')
				.attr('class', 'background')
				.attr('x', 0)
				.attr('y', - height + padding)
				.attr('height', height - padding)
				.attr('width', width);

			$scope.$watch('data', function(data){
				if(data){
					visible = count(data);
					data = prepare(data);
					if(!rendered){
						render(data);
					}else{
						update(data);
					}
				}
			});

			function prepare(data){
				var result = angular.copy(data);
				result = _(result).chain()
					.each(function(d){
						d.x = new Date(d[map.date]);
						d.y = d[map.value] > 0 ? 1 : 0;
					})
					.groupBy(map.type)
					.map(function(value){
						return value;
					})
					.value();
				
				return result;
			}

			function count(data){
				var result = _(data).chain()
					.groupBy(map.date)
					.values()
					.reduce(function(max, list){
						var current = _.reduce(list, function(total, item){
							return total += item.Value;
						}, 0);
						return Math.max(current, max)
					}, 0)
					.value();

				return result;
			}

			function render(data){
				stack = d3.layout.stack()(data);

				points = stack[0].map(function(d){
					return d.x;
				});

				barWidth = Math.min((width - 10) / points.length - 2, maxWidth);

				x = d3.time.scale()
					.domain([points[0], points[points.length - 1]])
					.range([barWidth/2 + 5, width - barWidth/2 - 5]);

				y = d3.scale.linear()
					.range([0, height - padding])
					.domain([0, visible]);

				axis = d3.svg.axis()
					.scale(x)
					.ticks(Math.min(points.length, 7))
					.tickSize(0,0,0)
					.tickPadding(5)
					.tickFormat(d3.time.format(Formatter.tick(points)))	    
					.orient('bottom');

				var grid = svg.append('g')
					.attr('class', 'grid');

				var xGrid = grid.selectAll("line.grid")
					.data(x.ticks(points.length));

				xGrid
					.enter().append("line")
					.attr("class", "grid")
					.attr("x1", x)
					.attr("x2", x)
					.attr("y1", - height + padding)
					.attr("y2", 0);

				layer = svg.selectAll('g.layer')
					.data(stack)
					.enter()
					.append('g')
					.attr('class', 'layer')
					.attr('transform','translate(0,0)');

				rect = layer.selectAll('rect')
					.data(function(d){
						return d;
					})
					.enter()
					.append('rect')
					.attr('class', function(d){
						var progress = '';
						if(d.Progress < 0){
							progress = 'negative';
						}
						if(d.Progress > 0){
							progress = 'positive';
						}
						return 'bar ' + progress;
					})
					.attr('x', function(d){
						return x(d.x) - barWidth / 2 - 1;
					})
					.attr('y', function(d){
						return - y(d.y0) - y(d.y);
					})
					.attr('height', function(d){
						return y(d.y) > 0 ? y(d.y) - 1 : 0;
					})
					.attr('width', barWidth)
					.on('mouseenter', function(d){
						var format = Formatter.tooltip(points);
						tooltip(d3.event, true, d, format);
					})
					.on('mouseleave', function(d){
						tooltip(d3.event, false);
					})
					.on('click', function(d){
						$scope.click({
							data: d
						});
					});
				
				svg.append('g')
					.attr('class','axis')
					.attr('transform','translate(0,0)')
					.call(axis);
				
				rendered = true;				
            }

			function update(data){
				stack = d3.layout.stack()(data);

				points = stack[0].map(function(d){
					return d.x;
				});

				barWidth = Math.min((width - 10) / points.length - 2, maxWidth);

				x = d3.time.scale()
					.domain([points[0], points[points.length - 1]])
					.range([barWidth/2 + 5, width - barWidth/2 - 5]);

				y = d3.scale.linear()
					.range([0, height - padding])
					.domain([0, visible]);
	
				axis = d3.svg.axis()
					.scale(x)
					.ticks(Math.min(points.length, 7))
					.tickSize(0,0,0)
					.tickPadding(5)
					.tickFormat(d3.time.format(Formatter.tick(points)))	    
					.orient('bottom');

				var grid = svg.select('.grid');

				var xGrid = grid.selectAll("line.grid")
					.data(x.ticks(points.length));

				xGrid
					.enter().append("line")
					.attr("class", "grid")
					.attr("y1", - height + padding)
					.attr("y2", 0);

				xGrid
					.transition()
					.duration(500)
					.attr("x1", x)
					.attr("x2", x);

				xGrid.exit()
					.remove();
				
				layer = svg.selectAll('g.layer')
					.data(stack);

				layer.enter()
					.append('g')
					.attr('class', 'layer')
					.attr('transform', 'translate(0,0)');

				layer.exit()
					.remove();
				
				rect = layer.selectAll('rect')
					.data(function(d){
						return d;
					});

				rect.enter()
					.append('rect')
					.attr('class', function(d){
						var progress = '';
						if(d.Progress < 0){
							progress = 'negative';
						}
						if(d.Progress > 0){
							progress = 'positive';
						}
						return 'bar ' + progress;
					})
					.on('mouseenter', function(d){
						tooltip(d3.event, true, d);
					})
					.on('mouseleave', function(d){
						tooltip(d3.event, false);
					})
					.on('click', function(d){
						$scope.click({
							data: d
						});
					});

				rect.transition()
					.attr('class', function(d){
						var progress = '';
						if(d.Progress < 0){
							progress = 'negative';
						}
						if(d.Progress > 0){
							progress = 'positive';
						}
						return 'bar ' + progress;
					})
					.duration(500)
					.attr('x', function(d){
						return x(d.x) - barWidth / 2 - 1;
					})
					.attr('y', function(d){
						return - y(d.y0) - y(d.y);
					})
					.attr('height', function(d){
						return y(d.y) > 0 ? y(d.y) - 1 : 0;
					})
					.attr('width', barWidth);
				
				rect.exit()
					.remove();

				svg.select('.axis')
					.transition()
					.duration(500)
					.call(axis);
			}

			function tooltip(e, show, data){
				var target = e.target.getBoundingClientRect();

				$scope.tooltip = {
					show: show,
					data: data
				};
				$scope.$digest();

				var height = $tooltip.outerHeight();
				var width = $tooltip.outerWidth();

				$tooltip.css({
					top: (target.top - height - 10) + 'px',
					left: (target.left - width / 2 + target.width / 2) + 'px'
				});

			}

		}
	};
}]);