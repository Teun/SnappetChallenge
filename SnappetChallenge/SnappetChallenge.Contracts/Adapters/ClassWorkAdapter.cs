using SnappetChallenge.Contracts.Abstractions;
using SnappetChallenge.Models;
using System.Collections.Generic;
using System.Linq;

namespace SnappetChallenge.Contracts.Adapters
{
    public class ClassWorkAdapter : IModelAdapter<IEnumerable<Work>, IEnumerable<WorkDto>>
    {
        public WorkDto AdaptNewWorkDto(Work input)
        {
            //could be also improved with automapper libraries
            return new WorkDto()
            {
                SubmittedAnswerId = input.SubmittedAnswerId,
                SubmitDateTime = input.SubmitDateTime,
                Correct = input.Correct,
                UserId = input.UserId,
                ExerciseId = input.ExerciseId,
                Subject = input.Subject,
                Domain = input.Domain,
                LearningObjective = input.LearningObjective,
                Difficulty = input.Difficulty
            };
        }

        public IEnumerable<WorkDto> Transform(IEnumerable<Work> classWorks) => classWorks.Select(x => AdaptNewWorkDto(x));

    }
}
