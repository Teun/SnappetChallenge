import Box from "@mui/material/Box";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
import { CSSProperties } from "react";
import Select, { SelectChangeEvent, SelectProps } from "@mui/material/Select";

interface ChartPanelSelectProps extends SelectProps {
  inputLabel: string;
  values: string[];
  selectedValue: string;
  setSelectedValue: (e: string) => void;
  containerStyle?: CSSProperties;
}

//Controlled Select component to be used for selecting Domain/Subject
//and subsequent domains or subjects

export default function ChartPanelSelect({
  inputLabel,
  values,
  selectedValue,
  setSelectedValue,
  disabled,
  containerStyle,
}: ChartPanelSelectProps) {
  const handleChange = (event: SelectChangeEvent) => {
    setSelectedValue(event.target.value as string);
  };

  return (
    <Box style={containerStyle}>
      <FormControl fullWidth>
        <InputLabel id={`${inputLabel}-label`}>{inputLabel}</InputLabel>
        <Select
          id={`${inputLabel}-select`}
          value={selectedValue}
          label={inputLabel}
          onChange={handleChange}
          disabled={disabled}
        >
          {values.map((value) => (
            <MenuItem value={value}>{value}</MenuItem>
          ))}
          <MenuItem value={""}>Reset</MenuItem>
        </Select>
      </FormControl>
    </Box>
  );
}
