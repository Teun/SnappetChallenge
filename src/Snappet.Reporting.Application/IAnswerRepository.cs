using System.Linq;
using Snappet.Reporting.Application.Dto;

namespace Snappet.Reporting.Application
{
    public interface IAnswerRepository
    {
        IQueryable<CorrectAnswersPerUserDto> CorrectAnswersPerUser();
        IQueryable<CorrectAnswersPerLearningObjectiveDto> CorrectAnswersPerLearningObjective();
    }
}
