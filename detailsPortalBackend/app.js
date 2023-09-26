/* This is entry point of application */
const express = require("express");
const studentRepo = require("./database/studentRepository");
const addHeadersToResponse = require("./middleware/headersMiddleware");

const app = express();
const PORT = 5000;
app.use(express.json());

//This api is used to get the details of strudents based on the date and if of the user
app.get("/students/details", addHeadersToResponse, async (req, res) => {
  let students = {};

  const id = req.query.id; //Userid is taken from query
  const dates = req.query.dates; //Date is taken from query
  students = await studentRepo.getStudentDetails(id,dates);
  res.send(students);
});

//This api is created to load all the unique student list from the database
app.get("/students", addHeadersToResponse, async (req, res) => {
  let students = {};
  students = await studentRepo.getStudentList(); //query to get list of students
  res.send(students);
});

//Server is configured here
app.listen(PORT, () => {
  console.log(`Listening on ${PORT}...!`);
});
