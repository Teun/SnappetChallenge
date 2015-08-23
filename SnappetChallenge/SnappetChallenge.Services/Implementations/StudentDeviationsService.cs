namespace SnappetChallenge.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Repository;
    using Models;

    using Interfaces;

    public class StudentDeviationsService : IStudentDeviationsService
    {
        private readonly IUnitOfWork unitOfWork;
        
        public StudentDeviationsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<StudentDeviationsModel> Get(DateTime startDateTime, DateTime endDateTime)
        {
            // all answers in range
            var answers =
                unitOfWork.AnswerRepository.Get(
                    a => a.SubmitDateTime >= startDateTime && a.SubmitDateTime <= endDateTime, null, "Exercise,Student");

            // get initial values on which to base the deviations
            var avgProgress = answers.Average(a => a.Progress);
            var numOfCorrectExercises = answers.Count(a => a.Correct);
            var numOfExercises = answers.Count();
            var avgCorrectnessRate = (double) numOfCorrectExercises/numOfExercises;
            var avgDifficulty = answers.Average(a => a.Exercise.Difficulty);

            var students = answers.GroupBy(a => a.Student).Select(a => a.Key).ToList();
            var numOfStudents = students.Count();

            var results = new List<StudentDeviationsModel>();

            foreach (var student in students)
            {
                var resultModel = new StudentDeviationsModel { StudentName = student.Name, StudentId = student.Id };
                var avgProgressForStudent = answers.Where(a=>a.StudentId == student.Id).Average(a => a.Progress);
                var numOfCorrectExercisesForStudent = answers.Where(a => a.StudentId == student.Id).Count(a => a.Correct);
                var numOfExercisesForStudent = answers.Count(a => a.StudentId == student.Id);
                var avgCorrectnessRateForStudent = (double) numOfCorrectExercisesForStudent / numOfExercisesForStudent;
                var avgDifficultyForStudent = answers.Where(a=>a.StudentId == student.Id).Average(a => a.Exercise.Difficulty);

                resultModel.Deviations.CorrectAnswerRate = avgCorrectnessRateForStudent - avgCorrectnessRate;
                resultModel.Deviations.DifficultyOfExercises = (avgDifficultyForStudent - avgDifficulty) / avgDifficulty;
                resultModel.Deviations.NumberOfExercises = (numOfExercisesForStudent -
                                                            (double) numOfExercises/numOfStudents)/numOfExercises/
                                                           numOfStudents;
                resultModel.Deviations.Progress = (avgProgressForStudent - avgProgress) / avgProgress;
                results.Add(resultModel);
            }

            return results;
        }
    }
}
