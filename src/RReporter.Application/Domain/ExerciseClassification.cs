namespace RReporter.Application.Domain
{
    public struct ExerciseClassification
    {
        public ExerciseClassification (
            string domain, string subject, string learningObjective
        )
        {
            Domain = domain;
            Subject = subject;
            LearningObjective = learningObjective;
        }
        public string Domain { get; private set; }

        public string Subject { get; private set; }

        public string LearningObjective { get; private set; }
    }
}