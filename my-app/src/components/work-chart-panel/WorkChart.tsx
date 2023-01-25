import { Stack } from "@mui/material";
import { mean } from "lodash";
import {
  XYPlot,
  XAxis,
  YAxis,
  VerticalGridLines,
  HorizontalGridLines,
  VerticalBarSeries,
} from "react-vis";
import WorkPageLabel from "../work-page/WorkPageLabel";
import { WorkEntry } from "../../types/WorkEntry";

export default function WorkChart({
  workData,
  chartTitle,
}: {
  workData: WorkEntry[];
  chartTitle: string;
}) {
  //filtering the data to extract the correct/incorrect amounts and
  //the amounts that are below/above the mean Progress (daily or monthly mean)
  const meanProgress = mean(workData.map((entry: WorkEntry) => entry.Progress));

  const correctAmount = workData.filter(
    (entry: WorkEntry) => entry.Correct === 1
  ).length;
  const incorrectAmount = workData.filter(
    (entry: WorkEntry) => entry.Correct === 0
  ).length;

  const aboveMeanProgressAmount = workData.filter(
    (entry: WorkEntry) => entry.Progress > meanProgress
  ).length;
  const belowMeanProgressAmount = workData.filter(
    (entry: WorkEntry) => entry.Progress <= meanProgress
  ).length;

  //chart data to render the bars
  const correctData = [
    {
      x: "Correct",
      y: correctAmount,
    },
  ];
  const incorrectData = [
    {
      x: "Incorrect",
      y: incorrectAmount,
    },
  ];

  const aboveMeanProgressData = [
    {
      x: "Above Mean Progress",
      y: aboveMeanProgressAmount,
    },
  ];

  const belowMeanProgressData = [
    {
      x: "Below Mean Progress",
      y: belowMeanProgressAmount,
    },
  ];

  return (
    <Stack direction="column" style={{ width: "100%" }}>
      <WorkPageLabel message={chartTitle} variant="h6" />
      <XYPlot xType="ordinal" width={800} height={500} xDistance={6000}>
        <VerticalGridLines />
        <HorizontalGridLines />
        <XAxis />
        <YAxis />
        <VerticalBarSeries data={correctData} barWidth={1} animation />
        <VerticalBarSeries data={incorrectData} barWidth={1} animation />
        <VerticalBarSeries
          data={aboveMeanProgressData}
          barWidth={1}
          animation
        />
        <VerticalBarSeries
          data={belowMeanProgressData}
          barWidth={1}
          animation
        />
      </XYPlot>
    </Stack>
  );
}
