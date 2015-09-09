using StudyReport.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyReport.Models
{
    public class AnswerViewModel
    {
        public DateTime SubmitDateTime { get; set; }
        public AnswerCorrect Correct { get; set; }
        public int Progress { get; set; }
        public string UserId { get; set; }
        public string ExerciseId { get; set; }
        public double? Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }

        public List<AnswerViewModel> ListAnswerViewModel ()
        { // Build view model
            List<AnswerViewModel> answerVms = new List<AnswerViewModel>();

            using (var ctx = new DataAccess.StudyReportContext())
            {
                var answers = ctx.Answers.ToList();
                foreach (var answer in answers)
                {
                    if (DateTime.SpecifyKind(answer.SubmitDateTime.Value, DateTimeKind.Utc) >= new DateTime(2015, 3, 24, 0, 0, 0, DateTimeKind.Utc)
                        && DateTime.SpecifyKind(answer.SubmitDateTime.Value, DateTimeKind.Utc) <= new DateTime(2015, 3, 24, 11, 30, 0, DateTimeKind.Utc))
                    {
                        AnswerViewModel answerVm = new AnswerViewModel
                        {
                            SubmitDateTime = DateTime.SpecifyKind(answer.SubmitDateTime.Value, DateTimeKind.Utc),
                            Correct = answer.Correct,
                            Progress = answer.Progress,
                            UserId = answer.User.UserId.ToString(),
                            ExerciseId = answer.Exercise.Id.ToString(),
                            Difficulty = answer.Exercise.Difficulty,
                            Subject = answer.Exercise.LearningObjective.Domain != null ? answer.Exercise.LearningObjective.Domain.Subject.Name : string.Empty,
                            Domain = answer.Exercise.LearningObjective.Domain != null ? answer.Exercise.LearningObjective.Domain.Name : string.Empty,
                            LearningObjective = answer.Exercise.LearningObjective.Name
                        };
                        answerVms.Add(answerVm);
                    }
                }
            }

            return answerVms;
        }
    }
}
