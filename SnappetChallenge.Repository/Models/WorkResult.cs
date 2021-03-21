using System;

namespace SnappetChallenge.Repository.Models
{
    public record WorkResult(
        long SubmittedAnswerId,
        DateTime SubmitDateTime,
        short Correct,
        short Progress,
        long UserId,
        long ExerciseId,
        string Difficulty,
        string Subject,
        string Domain,
        string LearningObjective
    );
}
