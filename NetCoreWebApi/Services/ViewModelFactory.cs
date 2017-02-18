using SnappetWorkApp.Models;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System;

namespace SnappetWorkApp.Services{
    public interface IViewModelFactory{
        IEnumerable<Student> CreateStudents(IEnumerable<WorkItem> workItems);
        Student CreateStudentWork(IEnumerable<WorkItem> studentWorkItems, int id);
        Subject CreateSubjectViewModel(IEnumerable<WorkItem> subjectWorkItems, string name);
    }

    public class ViewModelFactory: IViewModelFactory{

        public IEnumerable<Student> CreateStudents(IEnumerable<WorkItem> workItems)
        {
            foreach(var studentItems in workItems.GroupBy(wi => wi.UserId)
                .OrderBy(wig => wig.Sum(wi => wi.Progress)))
            {
                yield return new Student{
                    Id = studentItems.Key,
                    ExercisesCount = studentItems.Count(),
                    TotalProgress = studentItems.Sum(wi => wi.Progress),
                    AverageDifficulty = GetAverageDifficulty(studentItems)
                };
            };
        }

        public Student CreateStudentWork(IEnumerable<WorkItem> workItems, int id)
        {
            return new Student{
                Id = id,
                Subjects = workItems.GroupBy(wi => wi.Subject)
                    .OrderBy(wig => wig.Sum(wi => wi.Progress))
                    .Select(wig => new Subject
                    {
                        Name = wig.Key,
                        ExercisesCount = wig.Count(),
                        TotalProgress = wig.Sum(i => i.Progress),
                        AverageDifficulty = GetAverageDifficulty(wig)
                   })
            };
        }

        public Subject CreateSubjectViewModel(IEnumerable<WorkItem> workItems, string name)
        {
            return new Subject{
                Name = name,
                Exercises = workItems.GroupBy(wi => new{wi.ExerciseId, wi.Domain, wi.LearningObjective})
                    .OrderBy(wig => wig.Sum(wi => wi.Progress))
                    .Select(wig => new Exercise{
                        Domain = wig.Key.Domain,
                        LearningObjective = wig.Key.LearningObjective,
                        Id = wig.Key.ExerciseId,
                        TimesCorrect = wig.Count(wi => wi.Correct),
                        TimesIncorrect = wig.Count(wi => !wi.Correct),
                        TotalProgress = wig.Sum(i => i.Progress),
                        AverageDifficulty = GetAverageDifficulty(wig)
                    })
            };
        }

        private double GetAverageDifficulty(IEnumerable<WorkItem> workItems)
        {
            var eligibleItems = workItems.Where(i => i.Difficulty != "NULL");

            if(!eligibleItems.Any())
                return double.NaN;

            return Math.Round(eligibleItems.Average(i =>  double.Parse(i.Difficulty, CultureInfo.InvariantCulture)),1);
        }
    }
}