import { Typography } from "@mui/material";

export default function LearningObjectiveCell({
  learningObjective,
}: {
  learningObjective: string;
}) {
  return (
    <Typography style={{ overflowWrap: "break-word", whiteSpace: "pre-wrap" }}>
      {learningObjective}
    </Typography>
  );
}
