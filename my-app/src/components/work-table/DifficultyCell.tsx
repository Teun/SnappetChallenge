import { LinearProgress, Tooltip } from "@mui/material";

const MAX_DIFFICULTY = 530;
const MIN_DIFFICULTY = -200;

//Custom visualization of the difficulty in the data grid
//it renders a progress bar
export default function DifficultyCell({ difficulty }: { difficulty: string }) {
  if (difficulty === "NULL") {
    return <span>No recorded difficulty</span>;
  }

  const value =
    ((parseFloat(difficulty) - MIN_DIFFICULTY) * 100) /
    (MAX_DIFFICULTY - MIN_DIFFICULTY);

  return (
    <Tooltip title={difficulty}>
      <LinearProgress
        variant="determinate"
        value={value}
        sx={{ display: "flex", flex: 0.8 }}
      />
    </Tooltip>
  );
}
