import React, { useLayoutEffect, useRef } from "react";
import * as am5 from "@amcharts/amcharts5";
import * as am5xy from "@amcharts/amcharts5/xy";
import am5themes_Animated from "@amcharts/amcharts5/themes/Animated";

export const StudentPerformanceBarChart = ({ data }) => {
  const series1Ref = useRef(null);
  const series2Ref = useRef(null);
  const xAxisRef = useRef(null);

  useLayoutEffect(() => {
    let root = am5.Root.new("studentPerformanceBarChartDiv");

    root.setThemes([am5themes_Animated.new(root)]);

    let chart = root.container.children.push(
      am5xy.XYChart.new(root, {
        panY: false,
        layout: root.verticalLayout,
      })
    );

    // Create Y-axis
    let yAxis = chart.yAxes.push(
      am5xy.ValueAxis.new(root, {
        renderer: am5xy.AxisRendererY.new(root, {}),
      })
    );

    // Create X-Axis
    let xAxis = chart.xAxes.push(
      am5xy.CategoryAxis.new(root, {
        renderer: am5xy.AxisRendererX.new(root, {}),
        categoryField: "category",
        tooltip: am5.Tooltip.new(root, {}),
      })
    );

    // Create series
    let series1 = chart.series.push(
      am5xy.ColumnSeries.new(root, {
        name: "Correct Answers",
        xAxis: xAxis,
        yAxis: yAxis,
        valueYField: "correct",
        categoryXField: "category",
        tooltip: am5.Tooltip.new(root, {
          labelText: "Correct: {valueY}",
        }),
      })
    );

    let series2 = chart.series.push(
      am5xy.ColumnSeries.new(root, {
        name: "Wrong Answers",
        xAxis: xAxis,
        yAxis: yAxis,
        valueYField: "false",
        categoryXField: "category",
        tooltip: am5.Tooltip.new(root, {
          labelText: "Wrong:{valueY}",
        }),
      })
    );

    var cursor = chart.set(
      "cursor",
      am5xy.XYCursor.new(root, {
        behavior: "zoomY",
      })
    );

    let legend = chart.children.push(
      am5.Legend.new(root, {
        centerX: am5.p50,
        x: am5.p50,
      })
    );

    legend.data.setAll(chart.series.values);
    cursor.lineY.set("forceHidden", true);
    cursor.lineX.set("forceHidden", true);

    xAxisRef.current = xAxis;
    series1Ref.current = series1;
    series2Ref.current = series2;

    return () => {
      root.dispose();
    };
  }, []);

  // This code will only run when props.data changes
  useLayoutEffect(() => {
    xAxisRef.current.data.setAll(data);
    series1Ref.current.data.setAll(data);
    series2Ref.current.data.setAll(data);
  }, [data]);

  return (
    <div
      id="studentPerformanceBarChartDiv"
      style={{ width: "100%", height: "500px" }}
    ></div>
  );
};
