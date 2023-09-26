//This repository is used to fire queries on students collection
const Studentsmodel = require("./mongooseConnect");
const mongoose = require("mongoose");

//This function is used to return details of students
const getStudentDetails = async(id=0,dates=0)=>{
    let students = {};
    if (dates != 0 && id != 0) { //If both date and userId is available to fetch details
        let dateFrom = new Date(dates);
        let nextDay = new Date(dateFrom); //Calculate next day from from date
        nextDay.setDate(dateFrom.getDate() + 1);
        students = await Studentsmodel.find({ 
          UserId: id,
          SubmitDateTime: { $gte: dateFrom, $lt: nextDay },
        });
    } else if (id == 0 && dates == 0) { //Get all student's all details if UserId and date is not given
        students = await Studentsmodel.find();
    } else if (id == 0 && dates) { //If userId is not present but date is given then fetch student's details
        let dateFrom = new Date(dates);
        let nextDay = new Date(dateFrom);
        nextDay.setDate(dateFrom.getDate() + 1);
        students = await Studentsmodel.find({
          SubmitDateTime: { $gte: dateFrom, $lt: nextDay },
        });
    } else if (id && dates == 0) { //If userId is given but date is not given
        students = await Studentsmodel.find({ UserId: id });
    }
    return students;
}

//This function is used to get list of unique student Id
const getStudentList = async()=>{
    students = await Studentsmodel.distinct("UserId"); //query to get list of students
    return students;
}

module.exports = {getStudentList, getStudentDetails}