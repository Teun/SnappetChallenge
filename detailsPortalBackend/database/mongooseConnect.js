/*
Connection to monDB cluster is created here. The schema and models are created and exported
*/
const mongoose = require("mongoose");
//Cluster of mongodb is created and data is imported to it
const mongoUrl = "mongodb+srv://divyanianerao97:divyanianerao97@cluster0.bncoejp.mongodb.net/snappet?retryWrites=true&w=majority";
mongoose
  .connect(mongoUrl, {
    useNewUrlParser: true,
    useUnifiedTopology: true,
  })
  .then(() => {
    console.log("connected to database...!"); //Database is connected
  });
  
const studentSchema = new mongoose.Schema({ //Schema to define the structure is created here
  SubmittedAnswerId: {
    type: Number,
    default: null,
  },
  SubmitDateTime: Date,
  Correct: {
    type: Number,
    default: null,
  },
  Progress: {
    type: Number,
    default: null,
  },
  UserId: {
    type: Number,
    default: null,
  },
  ExerciseId: Number,
  Difficulty: {
    type: String,
    default: null,
  },
  Subject: String,
  Domain: String,
  LearningObjective: String,
});
//Model is created and exported for further use of queries
const Studentsmodel = new mongoose.model("studentportal", studentSchema); 
module.exports = Studentsmodel;
