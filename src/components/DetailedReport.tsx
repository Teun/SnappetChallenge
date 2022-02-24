import * as React from 'react';
import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow
} from "@mui/material";
import {DetailedReportProps} from "./Types";

const DetailedReport = ({reportData}: DetailedReportProps): JSX.Element => {
  return (
    <TableContainer component={Paper}>
      <Table sx={{minWidth: 650}} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Subject</TableCell>
            <TableCell align="right">Amount Correct</TableCell>
            <TableCell align="right">Percentage Correct</TableCell>
            <TableCell align="right">Learning Objective</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {reportData.map((row, index) => (
            <TableRow
              key={index}
              sx={{'&:last-child td, &:last-child th': {border: 0}}}
            >
              <TableCell component="th" scope="row">
                {row.subject}
              </TableCell>
              <TableCell align="right">{row.amountCorrects}</TableCell>
              <TableCell
                align="right">{`${row.percentageCorrect * 100} %`}
              </TableCell>
              <TableCell align="right">{row.learningObjective}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default DetailedReport;
