import { Stack } from "@mui/material";
import useDatePicker from "../../hooks/useDatePicker";
import WorkTable from "../work-table/WorkTable";
import WorkPageLabel from "./WorkPageLabel";
import InsertEmoticonIcon from "@mui/icons-material/InsertEmoticon";
import WorkChartPanel from "../work-chart-panel/WorkChartPanel";
import { useEffect, useState } from "react";
import { searchWork, getAllWork } from "../../api/queries";
import dayjs from "dayjs";
import utc from "dayjs/plugin/utc";
import { TODAY, FIRST_DAY } from "../../constants/days";
dayjs.extend(utc);

//Entry point/container for every component in the page

export default function WorkPage() {
  const { date, renderDatePicker } = useDatePicker({
    minDate: FIRST_DAY,
    maxDate: TODAY,
  });

  const [dailyWorkData, setDailyWorkData] = useState([]);

  const [monthlyWorkData, setMonthlyWorkData] = useState([]);

  //Changing the date to UTC so it can be queried from the data
  const dateString = dayjs.utc(date).format("YYYY-MM-DD").toString();

  useEffect(() => {
    (async () => {
      const todaysWork = await searchWork(dateString);
      setDailyWorkData(todaysWork);
    })();
  }, [dateString]);

  useEffect(() => {
    (async () => {
      const allWork = await getAllWork();
      setMonthlyWorkData(allWork);
    })();
  }, []);

  return (
    <Stack direction={"column"} spacing={4}>
      {/* Title */}
      <Stack direction="row" style={{ padding: "8px", alignSelf: "center" }}>
        <WorkPageLabel message="What did my class work on today?" />
        <InsertEmoticonIcon />
      </Stack>

      {/* Date picker for choosing a specific date */}
      <Stack
        direction="row"
        spacing={2}
        style={{ flexGrow: 0.5, alignSelf: "center" }}
      >
        <WorkPageLabel
          message="Choose a specific date to view the class results: "
          variant="h6"
        />
        {renderDatePicker()}
      </Stack>

      {/* Table showcasing the class's work per chosen date */}
      <WorkTable workData={dailyWorkData} />

      {/* Charts and selects panel for daily/monthly overview */}
      <WorkChartPanel
        dailyWorkData={dailyWorkData}
        monthlyWorkData={monthlyWorkData}
      />
    </Stack>
  );
}
