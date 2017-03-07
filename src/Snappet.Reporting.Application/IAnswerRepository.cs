using System.Linq;
using Snappet.Reporting.Application.Dto;
using System;

namespace Snappet.Reporting.Application
{
    public interface IAnswerRepository
    {
        IQueryable<CorrectAnswersPerSubjectDto> CorrectAnswersPerSubject(DateTime date);
        IQueryable<CorrectAnswersPerUserDto> CorrectAnswersPerUser(DateTime date);
        IQueryable<CorrectAnswersPerLearningObjectiveDto> CorrectAnswersPerLearningObjective(DateTime date);
    }
}
