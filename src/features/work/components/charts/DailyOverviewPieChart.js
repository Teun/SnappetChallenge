import React, { useLayoutEffect, useRef } from "react";
import * as am5 from "@amcharts/amcharts5";
import am5themes_Animated from "@amcharts/amcharts5/themes/Animated";
import * as am5percent from "@amcharts/amcharts5/percent";

const prepareGraphData = (data) => {
  return Object.keys(data).map((key) => ({ category: key, value: data[key] }));
};

export const DailyOverviewPieChart = ({ data }) => {
  const seriesRef = useRef(null);

  useLayoutEffect(() => {
    let root = am5.Root.new("subjectOverviewChartDiv");

    root.setThemes([am5themes_Animated.new(root)]);

    let chart = root.container.children.push(
      am5percent.PieChart.new(root, {
        layout: root.verticalLayout,
      })
    );

    let series = chart.series.push(
      am5percent.PieSeries.new(root, {
        valueField: "value",
        categoryField: "category",
        endAngle: 270,
        legendLabelText: "[{fill}]{category}[/]",
        legendValueText: "[bold {fill}]{value}[/]",
      })
    );

    series.states.create("hidden", {
      endAngle: -90,
    });

    var legend = chart.children.push(
      am5.Legend.new(root, {
        centerX: am5.p50,
        x: am5.p50,
      })
    );

    legend.data.setAll(chart.series.values);

    seriesRef.current = series;

    return () => {
      root.dispose();
    };
  }, []);

  useLayoutEffect(() => {
    seriesRef.current.data.setAll(prepareGraphData(data));
  }, [data]);

  return (
    <div
      id="subjectOverviewChartDiv"
      style={{ width: "100%", height: "500px" }}
    ></div>
  );
};
