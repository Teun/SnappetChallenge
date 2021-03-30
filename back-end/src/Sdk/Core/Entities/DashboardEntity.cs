using System;

namespace Sdk.Core.Entities
{
    public class DashboardEntity
    {
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
        public int AnswerCount { get; set; }
        public DateTime SubmitDateTime { get; set; }
    }
}
