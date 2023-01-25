import { useState } from "react";
import { Dayjs } from "dayjs";
import TextField from "@mui/material/TextField";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { DesktopDatePicker } from "@mui/x-date-pickers/DesktopDatePicker";

interface DatePickerProps {
  value: Dayjs | null;
  minDate: Dayjs;
  maxDate: Dayjs;
  handleChange: (e: Dayjs | null) => void;
}

const DatePickerComponent = ({
  value,
  handleChange,
  maxDate,
  minDate,
}: DatePickerProps) => (
  <LocalizationProvider dateAdapter={AdapterDayjs}>
    <DesktopDatePicker
      label="Datepicker"
      inputFormat="MM/DD/YYYY"
      value={value}
      onChange={handleChange}
      renderInput={(params) => <TextField {...params} />}
      maxDate={maxDate}
      minDate={minDate}
    />
  </LocalizationProvider>
);

//Hook that allows easy access to rendering a datepicker component
//and to it's current date value

export default function useDatePicker({
  minDate,
  maxDate,
}: {
  minDate: Dayjs;
  maxDate: Dayjs;
}) {
  const [date, setDate] = useState<Dayjs | null>(maxDate);

  const handleChange = (newValue: Dayjs | null) => {
    setDate(newValue);
  };

  const renderDatePicker = () => (
    <DatePickerComponent
      value={date}
      handleChange={handleChange}
      minDate={minDate}
      maxDate={maxDate}
    />
  );

  return { date, renderDatePicker };
}
