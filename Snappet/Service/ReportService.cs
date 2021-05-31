using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snappet.Entity;
using Snappet.Model;

namespace Snappet.Service
{
    public class ReportService : IReportService
    {
        public Task<NamedBinaryReport[]> GetDomainReport(IEnumerable<SubmittedAnswer> answers)
        {
            return Task.FromResult(answers.GroupBy(x => x.Domain.Name).Select(x => new NamedBinaryReport
            {
                Name = x.Key,
                FalseCount = x.Count(answer => answer.Correct == CorrectState.Correct),
                TrueCount = x.Count(answer => answer.Correct == CorrectState.Incorrect)
            }).ToArray());
        }

        public Task<NamedBinaryReport[]> GetSubjectReport(IEnumerable<SubmittedAnswer> answers)
        {
            return Task.FromResult(answers.GroupBy(x => x.Subject.Name).Select(x => new NamedBinaryReport
            {
                Name = x.Key,
                FalseCount = x.Count(answer => answer.Correct == CorrectState.Correct),
                TrueCount = x.Count(answer => answer.Correct == CorrectState.Incorrect)
            }).ToArray());
        }

        public Task<NamedBinaryReport[]> GetLearningObjectiveReport(IEnumerable<SubmittedAnswer> answers)
        {
            return Task.FromResult(answers.GroupBy(x => x.LearningObjective.Name).Select(x => new NamedBinaryReport
            {
                Name = x.Key,
                FalseCount = x.Count(answer => answer.Correct == CorrectState.Correct),
                TrueCount = x.Count(answer => answer.Correct == CorrectState.Incorrect)
            }).ToArray());
        }

        public Task<NamedBinaryReport[]> GetDifficultyReport(IEnumerable<SubmittedAnswer> answers)
        {
            var difficulty = -100;
            var increment = 100;

            var result = new List<NamedBinaryReport>();

            var submittedAnswers = answers as SubmittedAnswer[] ?? answers.ToArray();
            for (var i = 0; i < 8; i++)
            {
                var upperLimit = difficulty + increment;
                var periodicData = submittedAnswers.Where(x =>
                    x.Difficulty.HasValue && x.Difficulty > difficulty && x.Difficulty < upperLimit).ToList();
                var correctAnswersCount = periodicData.Count(x => x.Correct == CorrectState.Correct);
                var incorrectAnswersCount = periodicData.Count(x => x.Correct == CorrectState.Incorrect);
                
                result.Add(new NamedBinaryReport
                {
                    Name = $"({difficulty})-({upperLimit})",
                    FalseCount = incorrectAnswersCount,
                    TrueCount = correctAnswersCount
                });
                difficulty += increment;
            }

            return Task.FromResult(result.ToArray());
        }
    }

    public interface IReportService
    {
        Task<NamedBinaryReport[]> GetDomainReport(IEnumerable<SubmittedAnswer> answers);
        Task<NamedBinaryReport[]> GetSubjectReport(IEnumerable<SubmittedAnswer> answers);
        Task<NamedBinaryReport[]> GetLearningObjectiveReport(IEnumerable<SubmittedAnswer> answers);
        Task<NamedBinaryReport[]> GetDifficultyReport(IEnumerable<SubmittedAnswer> answers);
    }
}