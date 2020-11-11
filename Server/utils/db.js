const luxon = require('luxon');

const removeWhitespaces = timestring => timestring.replace(/\s*/g, '');

// At first I made seperate getDay, getHour and getMinute functions,
// but I figured that it would be faster to only call the fromISO
// function one time, and deconstruct from there. So this was a
// speed vs decoupling consideration.
const getDayHourMinute = timeString => {
  const {day, hour, minute} = luxon.DateTime.fromISO(timeString);
  const twoDigitMinute = minute < 10 ? `0${minute}` : minute;
  return ({day, hourMinutes: parseInt(`${hour}${twoDigitMinute}`, 10)});
};

const isBetween = (min, max, num) => num >= min && num <= max;

const getTodaysData = dataset => dataset.filter(({SubmitDateTime}) => {
  const cleanISO = removeWhitespaces(SubmitDateTime);
  const {day, hourMinutes} = getDayHourMinute(cleanISO);
  return (day === 24
    && isBetween(0, 1130, hourMinutes)
  );
});

module.exports = {
  getTodaysData
};
