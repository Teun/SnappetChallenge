using Snappet.Borisov.Test.Domain;

namespace Snappet.Borisov.Test.Infrastructure
{
    public class SubmittedAnswerConverter : IConvertSubmittedAnswers
    {
        public SubmittedAnswer ConvertFrom(SubmittedAnswerModel model)
        {
            var difficulty = ConvertDifficulty(model.Difficulty);
            return new SubmittedAnswer
            {
                Difficulty = difficulty,
                UserId = model.UserId,
                Correct = model.Correct,
                Domain = model.Domain,
                ExerciseId = model.ExerciseId,
                LearningObjective = model.LearningObjective,
                Progress = model.Progress,
                Subject = model.Subject,
                SubmitDateTime = model.SubmitDateTime,
                SubmittedAnswerId = model.SubmittedAnswerId
            };
        }

        private static decimal? ConvertDifficulty(string difficulty)
        {
            if (difficulty == "NULL") return null;
            return decimal.Parse(difficulty);
        }
    }
}