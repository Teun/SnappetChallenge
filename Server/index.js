const express = require('express');
const cors = require('cors');
const luxon = require('luxon');

const app = express();
const port = 9000;

const workJson = require('../Data/work.json');
// const exampleTime = '2015-03-02T07:30:38.740';
// I see what you did there 😏
// const messedUpTime = '2015-03-24T08:44:07    ';

const removeWhitespaces = timestring => timestring.replace(/\s*/g, '');

// At first I made seperate getDay, getHour and getMinute functions,
// but I figured that it would be faster to only call the fromISO
// function one time, and deconstruct from there. So this was a
// speed vs decoupling consideration.
const getDayHourMinute = timeString => {
  const {day, hour, minute} = luxon.DateTime.fromISO(timeString).c;
  const twoDigitMinute = minute < 10 ? `0${minute}` : minute;
  return ({day, hourMinutes: parseInt(`${hour}${twoDigitMinute}`, 10)});
};
const booleanClamp = (min, max, num) => num >= min && num <= max;

app.use(cors());

app.get('/dataset', (req, res) => {
  res.send(workJson.filter(({SubmitDateTime}) => {
    const cleanISO = removeWhitespaces(SubmitDateTime);
    const {day, hourMinutes} = getDayHourMinute(cleanISO);
    return (day === 24
      && booleanClamp(0, 1130, hourMinutes)
    );
  }));
});

app.listen(port, () => {
  console.log(`🦅 We have lift off! 🦅
Snappet server listening on http://localhost:${port}`);
});
