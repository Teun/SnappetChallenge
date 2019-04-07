using System.Linq;
using RReporter.Application.Domain;
using RReporter.Application.ReportWorkSummary.Dto;

namespace RReporter.Application.ReportWorkSummary
{

    public static class DtoMappings
    {

        public static WorkSummaryDto MapToDto (this WorkSummary workSummary)
        {
            return new WorkSummaryDto
            {
                Timestamp = workSummary.Timestamp,
                    PupilSummaries = workSummary.PupilSummaries.Select (MapToDto).ToArray ()
            };
        }

        public static PupilSummaryDto MapToDto (this PupilSummary pupilSummary)
        {
            return new PupilSummaryDto
            {
                UserId = pupilSummary.UserId,
                    LearningObjectiveSummaries = pupilSummary.LearningObjectiveSummaries.Select (MapToDto).ToArray ()
            };
        }

        public static LearningObjectiveSummaryDto MapToDto (this LearningObjectiveSummary loSummary)
        {
            return new LearningObjectiveSummaryDto
            {
                Domain = loSummary.Classification.Domain,
                    Subject = loSummary.Classification.Subject,
                    LearningObjective = loSummary.Classification.LearningObjective,
                    NumberOfAnswers = loSummary.NumberOfAnswers,
                    CorrectPercentage = loSummary.CorrectPercentage,
                    TotalProgress = loSummary.TotalProgress,
                    MaxDifficulty = loSummary.MaxDifficulty
            };
        }
    }
}