using System.Collections.Generic;
using System.Linq;
using SnappetChallenge.Core.Models;

namespace SnappetChallenge.Core
{
    public class LearningObjectivesProvider : ILearningObjectivesProvider
    {
        private readonly ISubmittedAnswersProvider submittedAnswersProvider;

        public LearningObjectivesProvider(ISubmittedAnswersProvider submittedAnswersProvider)
        {
            this.submittedAnswersProvider = submittedAnswersProvider;
        }

        public LearningObjective[] GetLearningObjectivesStatistics(SubmittedAnswersFilter filter)
        {
            return IterateLearningObjectivesStatistics(filter).ToArray();
        }

        private IEnumerable<LearningObjective> IterateLearningObjectivesStatistics(SubmittedAnswersFilter filter)
        {
            var answers = submittedAnswersProvider.GetAnswers(filter);
            var answersGrouppedByLearningObjective = answers.GroupBy(a => new LearningObjectiveGroupValues(a.LearningObjective, a.Domain, a.Subject));
            foreach (var learningObjectivesGroup in answersGrouppedByLearningObjective)
            {
                var users = learningObjectivesGroup.GroupBy(lg => lg.User.UserId)
                    .Select(ug => new UserForLearningObjective
                    {
                        UserId = ug.First().User.UserId,
                        ImageId = ug.First().User.ImageId,
                        Name = ug.First().User.Name,
                        UserAnswers = ug.ToArray()
                    }).ToArray();
                var learningObjective = new LearningObjective
                {
                    Domain = learningObjectivesGroup.Key.Domain,
                    Name = learningObjectivesGroup.Key.Name,
                    Subject = learningObjectivesGroup.Key.Subject,
                    Users = users
                };
                yield return learningObjective;
            }
        }
    }
}