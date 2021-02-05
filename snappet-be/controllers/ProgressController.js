const { setHours, setMinutes, endOfDay, startOfDay } = require("date-fns");

const Progress = require("../models/Progress");

//List all available progresss from database....
// exports.listAllProgress = async (req, res) => {

//   Progress.find({
//     UserId: 40281
//     // SubmitDateTime: {
//     //   $lte: Date.UTC(2015, 03, 15, 11, 30, 00, 00),
//     //   $gte: Date.UTC(2015, 03, 15, 00, 00, 00, 00),
//     // }
//   }, (err, progress) => {
//     if (err) {
//       res.status(500).send(err);
//     }
//     res.status(200).json(progress);
//   });
// };

// read a perticular progress by _id......
exports.getProgressByDate = (req, res) => {
  const dateArray = req.params.date.split('-');

  const startDay = startOfDay(Date.UTC(dateArray[0], dateArray[1] - 1, dateArray[2]));
  let endDay = endOfDay(Date.UTC(dateArray[0], dateArray[1] - 1, dateArray[2]));

  // console.log('RANGE:', startDay, endDay);

  // if 24th of march set endOfDay time to 11:30
  if (endDay.getDate() === 24) {
    endDay = setMinutes(setHours(endDay, 11), 30);
  }

  Progress.find({SubmitDateTime: { $lte: endDay, $gte: startDay } }, (err, progress) => {
    if (err) {
      res.status(500).send(err);
    }
    res.status(200).json(progress);
  });
};
