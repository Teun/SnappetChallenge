import CheckIcon from "@mui/icons-material/Check";
import ClearIcon from "@mui/icons-material/Clear";

export default function CorrectCell({ correct }: { correct: 0 | 1 }) {
  return !!correct ? (
    <CheckIcon color="success" />
  ) : (
    <ClearIcon color="error" />
  );
}
