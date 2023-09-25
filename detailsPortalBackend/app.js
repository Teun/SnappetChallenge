/* This is entry point of application */
const express = require("express");
const Studentsmodel = require("./mongooseConnect");
const addData = require("./headersMiddleware");

const app = express();
const PORT = 5000;
app.use(express.json());

//This api is used to get the details of strudents based on the date and if of the user
app.get("/students/details", addData, async (req, res) => {
  let students = {};

  const id = req.query.id; //Userid is taken from query
  const dates = req.query.dates; //Date is taken from query
  if (dates != 0 && id != 0) {
    let dateFrom = new Date(dates);
    let nextDay = new Date(dateFrom);
    nextDay.setDate(dateFrom.getDate() + 1);
    console.log(dateFrom);
    console.log(nextDay);
    students = await Studentsmodel.find({
      UserId: id,
      SubmitDateTime: { $gte: dateFrom, $lt: nextDay },
    });
  } else if (id == 0 && dates == 0) {
    students = await Studentsmodel.find();
  } else if (id == 0 && dates) {
    let dateFrom = new Date(dates);
    let nextDay = new Date(dateFrom);
    nextDay.setDate(dateFrom.getDate() + 1);
    students = await Studentsmodel.find({
      SubmitDateTime: { $gte: dateFrom, $lt: nextDay },
    });
  } else if (id && dates == 0) {
    students = await Studentsmodel.find({ UserId: id });
  }
  res.send(students);
});

//This api is created to load all the unique student list from the database
app.get("/students", addData, async (req, res) => {
  let students = {};
  if (req.query.dates) {
  } else {
    students = await Studentsmodel.distinct("UserId"); //query to get list of students
  }
  res.send(students);
});

//Server is configured here
app.listen(PORT, () => {
  console.log(`Listening on ${PORT}...!`);
});
