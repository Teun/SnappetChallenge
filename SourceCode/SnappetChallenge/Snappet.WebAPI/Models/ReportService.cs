using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snappet.WebAPI.Core.Repositories;

namespace Snappet.WebAPI.Models
{
    public class ReportService : IReportService
    {
        IWorkRepository workRepo;

        public ReportService(IWorkRepository _workRepo)
        {
            workRepo = _workRepo;
        }

        public IEnumerable<LearningObjectiveProgress> GetLearningObjectiveProgressReport(DateTime dateVal)
        {
            var dayWorkData = workRepo.GetAll().Where(o => o.SubmitDateTime.ToString("ddMMYYY") == dateVal.ToString("ddMMYYY")).ToList();
            List<LearningObjectiveProgress> report = new List<LearningObjectiveProgress>();


            var users = dayWorkData.Select(p => p.UserId).Distinct();

            var query = from o in dayWorkData
                        group o by o.LearningObjective into loGroups
                        select new
                        {
                            LearningObjective = loGroups.Key,
                            TotUser = loGroups.Distinct(),
                            Participants = from cg in loGroups
                                           group cg by cg.UserId into cityGroups
                                           select new
                                           {
                                               Student = cityGroups.Key,
                                               Name = "Little ",
                                               Exercises = cityGroups.Select(s => s.ExerciseId).Distinct().Count(),
                                               Attempts = cityGroups.Select(s => s.SubmittedAnswerId).Distinct().Count()
                                           },

                            TotalExercise = from te in loGroups
                                            group te by te.ExerciseId into teGroups
                                            select new
                                            {
                                                TotalExercise = teGroups.Count()
                                                //PostCodes = cityGroups.Count()
                                            },
                            TotalAttempts = from ta in loGroups
                                            group ta by ta.SubmittedAnswerId into taGroups
                                            select new
                                            {
                                                TotalAttempts = taGroups.Count()
                                                //PostCodes = cityGroups.Count()
                                            }

                        };

            foreach (var item in query)
            {
                LearningObjectiveProgress rep = new LearningObjectiveProgress();
                rep.LearningObjective = item.LearningObjective;
                rep.Participants = new List<Student>();

                foreach (var std in item.Participants)
                {
                    var s = new Student();
                    s.UserID = std.Student;
                    s.Exercises = std.Exercises;
                    s.Attempts = std.Attempts;
                    s.Performance = ((std.Exercises / (double)std.Attempts)).ToString("0.00%");
                    rep.Participants.Add(s);
                }

                rep.TotalExercise = item.TotalExercise.Count();
                rep.TotalAttempts = item.TotalAttempts.Count();

                rep.MasteryPercentage = (int)(100 * rep.TotalExercise / (double)rep.TotalAttempts);

                if (rep.MasteryPercentage >= 75)
                {
                    rep.Performance = "Excellent";
                }
                else if (rep.MasteryPercentage >= 50 && rep.MasteryPercentage < 75)
                {
                    rep.Performance = "Good";
                }
                else
                {
                    rep.Performance = "Poor";
                }



                report.Add(rep);
            }


            return report.ToList();
        }
    }
}