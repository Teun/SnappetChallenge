using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using Snappet.Test.DataRecorder.Interface.Commands;
using Snappet.Test.DataRecorder.Interface.Events;

namespace Snappet.Test.DataRecorder.Host.CommandHandlers
{
    public class RecordResultCommandHandler : IHandleMessages<RecordResultCommand>
    {
        private static readonly ILog Log = LogManager.GetLogger<Program>();

        public Task Handle(RecordResultCommand message, IMessageHandlerContext context)
        {
            // TODO Store record to db

            Log.Info($"Recording record {message.Result.SubmittedAnswerId}");

            // Publish event
            return context.Publish<IDataRecordReceivedEvent>(e =>
             {
                 e.SubmitDateTime = message.Result.SubmitDateTime;
                 e.Correct = message.Result.Correct;
                 e.Progress = message.Result.Progress;
                 e.Difficulty = message.Result.Difficulty;
                 e.Domain = message.Result.Domain;
                 e.ExerciseId = message.Result.ExerciseId;
                 e.LearningObjective = message.Result.LearningObjective;
                 e.Subject = message.Result.Subject;
                 e.UserId = message.Result.UserId;
                 e.SubmittedAnswerId = message.Result.SubmittedAnswerId;
             });
        }
    }
}