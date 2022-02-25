import React from 'react';
import work from "../Data/work.json";
import {WorkType} from "../types";
import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow
} from "@mui/material";

const Overview = () => {
  const allItems = work as WorkType[];
  //It is now Tuesday 24/03/2015 11:30:00 UTC.
  const currentDate =  new Date(Date.UTC(2015, 2, 24, 11, 30, 0));
  const startOfCurrentDate = new Date(Date.UTC(2015, 2, 24, 0, 0, 0));

  const todaysWork = allItems.filter((e:WorkType) => new Date(e.SubmitDateTime) < currentDate && new Date(e.SubmitDateTime) > startOfCurrentDate)


  return (
    <div>
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>User ID</TableCell>
            <TableCell align="right">Exercise ID</TableCell>
            <TableCell align="right">Date</TableCell>
            <TableCell align="right">Subject</TableCell>
            <TableCell align="right">Domain</TableCell>
            <TableCell align="right">LearningObjective</TableCell>
            <TableCell align="right">Difficulty</TableCell>
            <TableCell align="right">Progress</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {todaysWork.map((row) => (
            <TableRow
              key={row.SubmittedAnswerId}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.UserId}
              </TableCell>
              <TableCell align="right">{row.ExerciseId}</TableCell>
              <TableCell align="right">{new Date(row.SubmitDateTime).toDateString()}</TableCell>
              <TableCell align="right">{row.Subject}</TableCell>
              <TableCell align="right">{row.Domain}</TableCell>
              <TableCell align="right">{row.LearningObjective}</TableCell>
              <TableCell align="right">{row.Difficulty}</TableCell>
              <TableCell align="right">{row.Progress}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
    </div>
  );
};

export default Overview;
