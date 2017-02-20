using System;

namespace Snappet.Test.DataRecorder.Interface.Events
{
    public interface IDataRecordReceivedEvent
    {
        int SubmittedAnswerId { get; set; }
        DateTime SubmitDateTime { get; set; }
        bool Correct { get; set; }
        int Progress { get; set; }
        int UserId { get; set; }
        int ExerciseId { get; set; }
        decimal? Difficulty { get; set; }
        string Subject { get; set; }
        string Domain { get; set; }
        string LearningObjective { get; set; }
    }
}