using System;
using System.Collections.Generic;
using System.Linq;
using SnappetChallenge.BusinessLogicLayer.BusinessObjects;
using SnappetChallenge.BusinessLogicLayer.Interfaces;
using SnappetChallenge.DataAccessLayer.DTO;

namespace SnappetChallenge.BusinessLogicLayer.Mappers
{
    // TODO: automapper maybe
    public sealed class SubmittedAnswerMapper : ISubmittedAnswerMapper
    {
        public SubmittedAnswer Map(SubmittedAnswerDto submittedAnswerDto)
        {
            if (submittedAnswerDto == null) return null;
            return new SubmittedAnswer()
            {
                SubmittedAnswerId = submittedAnswerDto.SubmittedAnswerId,
                UserId = submittedAnswerDto.UserId,
                ExerciseId = submittedAnswerDto.ExerciseId,

                SubmitDateTime = submittedAnswerDto.SubmitDateTime,
                IsCorrect = submittedAnswerDto.Correct == 1,
                Progress = submittedAnswerDto.Progress,

                Difficulty = submittedAnswerDto.Difficulty,
                Subject = submittedAnswerDto.Subject,
                Domain = submittedAnswerDto.Domain,
                LearningObjective = submittedAnswerDto.LearningObjective
            };
        }

        public List<SubmittedAnswer> Map(IEnumerable<SubmittedAnswerDto> submittedAnswerDto)
        {
            return submittedAnswerDto.Select(Map).ToList();
        }

        public SubmittedAnswerDto Map(SubmittedAnswer submittedAnswer)
        {
            throw new NotImplementedException();
        }

        public List<SubmittedAnswerDto> Map(IEnumerable<SubmittedAnswer> submittedAnswer)
        {
            throw new NotImplementedException();
        }
    }
}
