using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MongoDB.Bson;

using SnappetChallenge.Data.Contracts;
using SnappetChallenge.Models;
using SnappetChallenge.Models.Contracts;
using SnappetChallenge.Services.Contracts;

namespace SnappetChallenge.Services
{
    public class ClassResults : ServiceBase, IClassResults
    {
        private readonly ISubmittedAnswersRepository _repository;

        public ClassResults(ISubmittedAnswersRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets amount of answers in a given time range.
        /// </summary>
        /// <param name="timeRange"></param>
        /// <returns></returns>
        public async Task<int> GetAmountOfAnswersAsync(ITimeRange timeRange)
        {
            var answers = await GetAnswersAsync(timeRange);

            return answers.Count();
        }

        /// <summary>
        /// Gets amount of correct answers in a given time range.
        /// </summary>
        /// <param name="timeRange"></param>
        /// <returns></returns>
        public async Task<int> GetAmountCorrectAsync(ITimeRange timeRange)
        {
            var start = new BsonDateTime(timeRange.Start);
            var end = new BsonDateTime(timeRange.End);

            var answersSuccessful =
                await
                    _repository.Find(
                        a => a.Correct == Convert.ToInt32(true) && a.SubmitDateTime > start && a.SubmitDateTime < end);

            return answersSuccessful.Count();
        }

        /// <summary>
        /// Calculates total progress by summing the progress of all submitted answers.
        /// </summary>
        /// <param name="timeRange"></param>
        /// <returns></returns>
        public async Task<int> GetTotalProgressAsync(ITimeRange timeRange)
        {
            var answers = await GetAnswersAsync(timeRange);

            return answers.Sum(a => a.Progress);
        }

        /// <summary>
        /// Find out which user had made the most progress in a given time range.
        /// </summary>
        /// <param name="timeRange"></param>
        /// <returns></returns>
        public async Task<User> GetMostProgressAsync(ITimeRange timeRange)
        {
            var answers = await GetAnswersAsync(timeRange);

            var result = answers.GroupBy(answer => answer.UserId).Select(userAnswers => new
            {
                UserId = userAnswers.Key,
                Progress = userAnswers.Sum(answer => answer.Progress)
            })
                .OrderByDescending(progress => progress.Progress)
                .FirstOrDefault();

            return result == null ? null : new User { UserId = result.UserId };
        }

        /// <summary>
        /// Most difficulty is calculated by which learning objective had the lowest shared difficulty level.
        /// </summary>
        /// <remarks>
        /// Assumptions are that:
        /// 1.) Difficulty is relative over all domains.
        /// 2.) Difficulty is properly calibrated
        /// 
        /// Note: unfortunately but logically this seems to return the easiest learning goal studied.
        /// </remarks>
        /// <param name="timeRange"></param>
        /// <returns></returns>
        public async Task<LearningObjective> GetMostDifficultAsync(ITimeRange timeRange)
        {
            var answers = await GetAnswersAsync(timeRange);

            double testDouble;
            var result = answers.GroupBy(answer => answer.LearningObjective).Select(objectiveAnswers => new
            {
                Name = objectiveAnswers.Key,
                Difficulty =
                    objectiveAnswers.Where(a => double.TryParse(a.Difficulty, out testDouble))
                        .Average(a => double.Parse(a.Difficulty))
            })
                .OrderBy(d => d.Difficulty)
                .FirstOrDefault();

            return result == null ? null : new LearningObjective { Name = result.Name };
        }

        /// <summary>
        /// Gets the most studied objectives based on amount of answers.
        /// </summary>
        /// <param name="timeRange"></param>
        /// <returns>Top three studied objectives</returns>
        public async Task<IEnumerable<LearningObjective>> GetTopObjectivesAsync(ITimeRange timeRange)
        {
            const int amount = 3;

            var answers = await GetAnswersAsync(timeRange);

            return answers.GroupBy(a => a.LearningObjective)
                .OrderByDescending(l => l.Count())
                .Select(l => new LearningObjective { Name = l.Key })
                .Take(amount);
        }

        /// <summary>
        /// Gets all submitted answers.
        /// </summary>
        /// <returns></returns>
        private async Task<IEnumerable<SubmittedAnswer>> GetAnswersAsync()
        {
            return await _repository.All();
        }

        /// <summary>
        /// Gets all submitted answers in a time range.
        /// </summary>
        /// <param name="timeRange">The time range for which to retrieve answers.</param>
        /// <returns></returns>
        private async Task<IEnumerable<SubmittedAnswer>> GetAnswersAsync(ITimeRange timeRange)
        {
            var start = new BsonDateTime(timeRange.Start);
            var end = new BsonDateTime(timeRange.End);

            return await _repository.Find(a => a.SubmitDateTime > start && a.SubmitDateTime < end);
        }
    }
}