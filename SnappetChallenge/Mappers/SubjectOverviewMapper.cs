using SnappetChallenge.Mappers.Interfaces;
using SnappetChallenge.Models;
using SnappetChallenge.Queries.Responses;
using System;

namespace SnappetChallenge.Mappers
{
    public class SubjectOverviewMapper : IMapper<DashboardResponse, SubjectOverviewDto>
    {
        public SubjectOverviewDto Map(DashboardResponse input)
        {
            if (input == null)
            {
                return null;
            }

            var result = new SubjectOverviewDto
            {
                Subject = input.Subject,
                UniqueExercises = input.UniqueExercises,
                TotalAnswers = input.TotalAnswers,
                AssessedSkillLevelChange = input.AssessedSkillLevelChange,
                TotalReanswered = input.TotalReanswered,
                TotalReansweredPercentage = input.TotalReansweredPercentage.HasValue 
                    ? Math.Round(input.TotalReansweredPercentage.Value, 2)
                    : null
            };

            return result;
        }
    }
}
