import { GridColDef } from "@mui/x-data-grid";
import ProgressCell from "./ProgressCell";
import DifficultyCell from "./DifficultyCell";
import DateCell from "./DateCell";
import LearningObjectiveCell from "./LearningObjectiveCell";
import CorrectCell from "./CorrectCell";

//The columns object array that will be used
//to display the data of db.json in a data grid table

export const workTableColumns: GridColDef[] = [
  { field: "SubmittedAnswerId", headerName: "Answer ID" },
  { field: "UserId", headerName: "User ID" },
  { field: "ExerciseId", headerName: "Exercise ID" },
  {
    field: "Correct",
    headerName: "Correct",
    renderCell: ({ row: { Correct } }) => <CorrectCell correct={Correct} />,
  },
  {
    field: "SubmitDateTime",
    headerName: "Date",
    flex: 1,
    renderCell: ({ row: { SubmitDateTime } }) => (
      <DateCell date={SubmitDateTime} />
    ),
  },
  {
    field: "Progress",
    headerName: "Progress",
    renderCell: ({ row: { Progress } }) => <ProgressCell progress={Progress} />,
  },
  {
    field: "Difficulty",
    headerName: "Difficulty",
    flex: 1.5,
    renderCell: ({ row: { Difficulty } }) => (
      <DifficultyCell difficulty={Difficulty} />
    ),
  },
  {
    field: "Subject",
    headerName: "Subject",
    flex: 1,
  },
  {
    field: "Domain",
    headerName: "Domain",
    flex: 1,
  },
  {
    field: "LearningObjective",
    headerName: "Learning Objective",
    flex: 2,
    renderCell: ({ row: { LearningObjective } }) => (
      <LearningObjectiveCell learningObjective={LearningObjective} />
    ),
  },
];
