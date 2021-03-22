using SnappetChallenge.Mappers.Interfaces;
using SnappetChallenge.Models;
using SnappetChallenge.Queries.Responses;

namespace SnappetChallenge.Mappers
{
    public class SubjectStudentOverviewMapper : IMapper<EducatorSubjectOverviewResponse, SubjectStudentOverviewDto>
    {
        public SubjectStudentOverviewDto Map(EducatorSubjectOverviewResponse input)
        {
            if (input == null)
            {
                return null;
            }

            var result = new SubjectStudentOverviewDto
            {
                Domain = input.Domain,
                LearningObjective = input.LearningObjective,
                UserId = input.UserId,
                AssessedSkillLevelChange = input.AssessedSkillLevelChange
            };

            return result;
        }
    }
}
