using Snappet.Model;
using Snappet.Repository.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnappetRepository.Repository
{
    public interface IClassRepository
    {
        IEnumerable<Report> GetReport(string date, string subject, string domain, string viewtype);

        IEnumerable<Student> GetStudentDetails(string date, string subject, string domain, string objective);
    }

    public class ClassRepository:IClassRepository
    {

        private IDataProvider _dataProvider;

        public ClassRepository(IDataProviderFactory dataProviderFactory)
        {
            _dataProvider = dataProviderFactory.GetDataProvider();
        }

        public IEnumerable<Report> GetReport(string date, string subject, string domain, string viewtype)
        {
            var workData = _dataProvider.getAllData();
            var dateToSearch = DateTime.Parse(date);
            var reports = new List<Report>();

            if (workData != null)
            {
                var workList = workData.Where(a => a.SubmitDate == dateToSearch);

                if (!string.IsNullOrWhiteSpace(subject))
                {
                    workList = workList.Where(a => a.Subject == subject);
                }
                if (!string.IsNullOrWhiteSpace(domain))
                {
                    workList = workList.Where(a => a.Domain == domain);
                }

                var groupByList = GroupDataByViewType(workList, viewtype);

                foreach (var item in groupByList)
                {
                    var report = new Report();
                    report.Key = item.Key;
                    report.NoOfExercises = item.GroupBy(a => a.ExerciseId).Count();
                    report.NoOfStudents = item.GroupBy(a => a.UserId).Count();
                    report.CorrectAttempts = item.ToList().FindAll(a => a.Correct == 1).Count();
                    report.IncorrectAttempts = item.ToList().FindAll(a => a.Correct == 0).Count();
                    reports.Add(report);
                }

            }

            return reports;
        }

        public IEnumerable<Student> GetStudentDetails(string date, string subject, string domain, string objective)
        {
            var workData = _dataProvider.getAllData();
            var dateToSearch = DateTime.Parse(date);
            var reports = new List<Student>();

            if (workData != null)
            {
                var workByDate = workData.Where(a => a.SubmitDate == dateToSearch
                && a.Subject == subject && a.Domain == domain && a.LearningObjective == objective);

                var workGroupedByUser = workByDate.ToList().GroupBy(a => a.UserId);

                foreach (var user in workGroupedByUser)
                {
                    var student = new Student();
                    student.Id = user.Key;
                    student.NoOfAttempts = user.Count();
                    student.NoOfExercise = user.GroupBy(a => a.ExerciseId).Count();
                    student.RightAttemptCount = user.Count(a => a.Correct == 1);
                    student.WrongAttemptCount = student.NoOfAttempts - student.RightAttemptCount;
                    double progress = (double)student.RightAttemptCount / (double)student.NoOfAttempts * 100;
                    var progressInInteger = Math.Round(progress, 0);
                    student.Progress = Int32.Parse(progressInInteger.ToString());

                    reports.Add(student);
                }
            }

            return reports;
        }

        private IEnumerable<IGrouping<string, Work>> GroupDataByViewType(IEnumerable<Work> workList, string viewtype)
        {
            IEnumerable<IGrouping<string, Work>> groupByList;
            if (viewtype == "subject")
            {
                groupByList = workList.ToList().GroupBy(a => a.Subject);
            }
            else if (viewtype == "domain")
            {
                groupByList = workList.ToList().GroupBy(a => a.Domain);
            }
            else if (viewtype == "learningObjective")
            {
                groupByList = workList.ToList().GroupBy(a => a.LearningObjective);
            }
            else
            {
                groupByList = workList.ToList().GroupBy(a => a.Subject);
            }

            return groupByList;
        }
    }
}
