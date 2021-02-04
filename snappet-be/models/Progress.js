const mongoose = require("mongoose");
const Schema = mongoose.Schema;

const AnswerSchema = new Schema({
  UserId: {
    type: Number,
    required: true
  },
  SubmitDateTime: {
    type: Date,
    required: true,
  },
  Progress: {
      type: Number,
      required: true
  }
})

module.exports = mongoose.model("Answers", AnswerSchema, "march2015")