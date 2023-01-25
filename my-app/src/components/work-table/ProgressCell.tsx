import NorthIcon from "@mui/icons-material/North";
import SouthIcon from "@mui/icons-material/South";
import HorizontalRuleIcon from "@mui/icons-material/HorizontalRule";
import { Stack, Tooltip } from "@mui/material";

function ProgressIcon({ progress, ...props }: { progress: number }) {
  if (progress > 0) return <NorthIcon color="success" {...props} />;
  if (progress < 0) return <SouthIcon color="error" {...props} />;
  return (
    <Tooltip title="Cannot estimate progress for this entry yet">
      <HorizontalRuleIcon {...props} />
    </Tooltip>
  );
}

//Custom visualization for the progress cells in the data grid
//Up or Down arrows indicate increse/decrease in progress respectively
//Horizontal dash means the progress is 0

export default function ProgressCell({ progress }: { progress: number }) {
  return (
    <Stack direction="row" alignItems={"flex-end"}>
      <span>{!!progress && progress}</span>
      <ProgressIcon progress={progress} />
    </Stack>
  );
}
