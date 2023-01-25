import dayjs from "dayjs";
import { Typography } from "@mui/material";
import timezone from "dayjs/plugin/timezone";
dayjs.extend(timezone);

export default function DateCell({ date }: { date: string }) {
  return (
    <Typography style={{ overflowWrap: "break-word", whiteSpace: "pre-wrap" }}>
      {dayjs(date).tz("Europe/Amsterdam").format("L LT").toString()}
    </Typography>
  );
}
