import { Typography, TypographyProps } from "@mui/material";
import { ReactNode } from "react";

interface WorkPageLabelProps extends TypographyProps {
  message: ReactNode;
}

//Reusable label renderer throughout the page
//accepts a message prop to display and the native Typography props

export default function WorkPageLabel({
  message = "What did my class work on today?",
  ...props
}: WorkPageLabelProps) {
  return (
    <Typography variant="h2" alignSelf="center" {...props}>
      {message}
    </Typography>
  );
}
