using CsvHelper.Configuration;

namespace SnappetChallenge.Data.IO
{
    public class SubmittedAnswerParser : CsvClassMap<SubmittedAnswer>
    {
        public SubmittedAnswerParser()
        {
            Map(m => m.Id).Name("SubmittedAnswerId");
            Map(m => m.SubmittedDateTime).Name("SubmitDateTime");
            Map(m => m.IsCorrect).Name("Correct").TypeConverter<BooleanTypeConverter>();
            Map(m => m.Progress).Name("Progress");
            Map(m => m.UserId).Name("UserId");
            Map(m => m.ExerciseId).Name("ExerciseId");
            Map(m => m.Difficulty).Name("Difficulty").TypeConverter<DifficultyConverter>(); // If difficulty is NULL, set to 0
            Map(m => m.Subject).Name("Subject");
            Map(m => m.Domain).Name("Domain");
            Map(m => m.LearningObjective).Name("LearningObjective");
        }
    }
}