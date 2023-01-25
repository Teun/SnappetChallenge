import { DataGrid } from "@mui/x-data-grid";
import { workTableColumns } from "./workTableColumns";
import { WorkEntry } from "../../types/WorkEntry";

//A component that receives the class work data and displays them in a data grid
//https://mui.com/x/react-data-grid/
export default function WorkTable({ workData }: { workData: WorkEntry[] }) {
  return (
    <div style={{ height: "80vh", padding: "16px" }}>
      <DataGrid
        rows={workData}
        columns={workTableColumns}
        pageSize={50}
        rowsPerPageOptions={[50]}
        getRowId={(row) => row.SubmitDateTime}
      />
    </div>
  );
}
