using System;
using System.Globalization;
using System.Threading.Tasks;
using RReporter.Application.Domain;
using RReporter.Application.StoreWorkEvent.Depends;

namespace RReporter.Application.StoreWorkEvent
{
    public class WorkEventHandler : IWorkEventHandler
    {
        private readonly IStoreWorkEvents storage;

        public WorkEventHandler (IStoreWorkEvents storage)
        {
            this.storage = storage;
        }

        public Task HandleAsync (WorkEventDto workEventDto)
        {
            var classification = new ExerciseClassification (workEventDto.Domain, workEventDto.Subject, workEventDto.LearningObjective);
            var exercise = new Exercise (workEventDto.ExerciseId, classification, GetDifficultyValue (workEventDto.Difficulty));
            var workEvent = WorkEvent.Create (
                workEventDto.SubmittedAnswerId, workEventDto.SubmitDateTime,
                workEventDto.UserId,
                exercise, workEventDto.Correct, workEventDto.Progress);
            return storage.StoreAsync (workEvent);
        }

        static double? GetDifficultyValue (string value)
        {
            if (double.TryParse (value, NumberStyles.Any, CultureInfo.InvariantCulture, out var val))
            {
                return val;
            }
            return null;
        }
    }

}