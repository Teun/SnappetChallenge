using StudyReport.Entities;
using StudyReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyReport.DataAccess
{
    public class StudyReportParser
    {
        private StudyReportContext _ctx;

        public StudyReportParser(StudyReportContext ctx)
        {
            _ctx = ctx;
            _ctx.Configuration.AutoDetectChangesEnabled = false;
        }

        public void ParseSubjects()
        {
            var subjects = _ctx.WorkModel.Select(x => x.Subject).Distinct();
            foreach (var subjectName in subjects)
            {
                Subject subject = new Subject { Name = subjectName };
                _ctx.Subjects.Add(subject);
            }

            _ctx.SaveChanges();
        }
        public void ParseDomains()
        {
            var domainObjs = _ctx.WorkModel.Select(x => new { Domain = x.Domain, Subject = x.Subject }).Distinct();
            foreach (var domainObj in domainObjs)
            {
                // Domain "-" are nulls
                if (domainObj.Domain != "-")
                {
                    Domain domain = new Domain { Name = domainObj.Domain, Subject = _ctx.Subjects.SingleOrDefault(x => x.Name == domainObj.Subject) };
                    _ctx.Domains.Add(domain);
                }
            }

            _ctx.SaveChanges();
        }
        public void ParseLearningObjects()
        {
            var learnObjs = _ctx.WorkModel.Select(x => new { LearningObjective = x.learningObjective, Domain = x.Domain }).Distinct();
            foreach (var learnObj in learnObjs)
            {
                LearningObjective learningObject = new LearningObjective { Name = learnObj.LearningObjective, Domain = _ctx.Domains.SingleOrDefault(x => x.Name == learnObj.Domain) };
                _ctx.LearningObjectives.Add(learningObject);
            }

            _ctx.SaveChanges();
        }
        public void ParseExercies()
        {
            var exercises = _ctx.WorkModel.Select(x => new { ExerciseId = x.ExerciseId, Difficulty = x.Difficulty, LearningObjective = x.learningObjective }).Distinct();
            foreach (var exerciseObj in exercises)
            {
                Exercise exercise = new Exercise { ExerciseId = exerciseObj.ExerciseId, LearningObjective = _ctx.LearningObjectives.SingleOrDefault(x => x.Name == exerciseObj.LearningObjective) };

                if (exerciseObj.Difficulty != "NULL")
                {
                    exercise.Difficulty = Convert.ToDouble(exerciseObj.Difficulty);
                }

                _ctx.Exercises.Add(exercise);
            }

            _ctx.SaveChanges();
        }
        public void ParseUsers()
        {
            var userIds = _ctx.WorkModel.Select(x => x.UserId).Distinct();
            foreach (var userId in userIds)
            {
                User user = new User { UserId = userId };
                _ctx.Users.Add(user);
            }

            _ctx.SaveChanges();
        }
        public void ParseAnswers()
        {
            var answerVms = _ctx.WorkModel;
            foreach (var answerVm in answerVms)
            {
                Answer answer = new Answer
                {
                    AnswerId = answerVm.SubmittedAnswerId,
                    SubmitDateTime = DateTime.SpecifyKind(answerVm.SubmitDateTime, DateTimeKind.Utc),
                    Correct = (AnswerCorrect)answerVm.Correct,
                    User = _ctx.Users.SingleOrDefault(x => x.UserId == answerVm.UserId),
                    Exercise = _ctx.Exercises.SingleOrDefault(x => x.ExerciseId == answerVm.ExerciseId),
                    Progress = answerVm.Progress
                };

                _ctx.Answers.Add(answer);
            }

            _ctx.SaveChanges();
        }
    }
}