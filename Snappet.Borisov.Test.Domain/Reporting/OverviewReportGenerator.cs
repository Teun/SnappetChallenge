using System.Linq;

namespace Snappet.Borisov.Test.Domain.Reporting
{
    public class OverviewReportGenerator : IGenerateOverviewReports
    {
        private readonly IProvideStudents _students;

        public OverviewReportGenerator(IProvideStudents students)
        {
            _students = students;
        }

        public OverviewReport Generate()
        {
            var students = _students.GetAll();
            return new OverviewReport
            {
                Students = students.Select(Generate).ToArray()
            };
            // student
            //   today
            //     number of objectives
            //     number of answers
            //     max progress + objective
            //     min progress + objective
            //   last 7 days
            //     number of objectives
            //     number of answers
            //     max progress + objective
            //     min progress + objective
        }

        private static OverviewReport.StudentModel Generate(Student student)
        {
            var answers = student.Today().ToArray();
            var objectives = answers
                .GroupBy(x => x.LearningObjective)
                .Select(x => new OverviewReport.StudentModel.ObjectiveProgressModel
                {
                    LearningObjective = x.Key,
                    Progress = x.Sum(y => y.Progress)
                })
                .OrderByDescending(x => x.Progress);
            var objectiveMaxProgress = objectives.First();
            var objectiveMinProgress = objectives.Last();
            return new OverviewReport.StudentModel
            {
                Name= student.Name,
                Today = new OverviewReport.StudentModel.TodayModel
                {
                    NumberOfObjectives = objectives.Count(),
                    NumberOfAnswers = answers.Length,
                    NumberOfCorrectAnswers = answers.Count(x=> x.Correct==1),
                    ObjectiveWithMaxProgress = objectiveMaxProgress,
                    ObjectiveWithMinProgress = objectiveMinProgress
                }
            };
        }
    }
}