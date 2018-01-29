using MongoDB.Bson;

namespace SnappetTest.Model.Entities
{
   public class ReceivedAnswers
    {
        public ObjectId Id { get; set; }
        public int SubmittedAnswerId { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public string Difficulty { get; set; }
        public int Correct { get; set; }
        public int Progress { get; set; }
        public string Domain { get; set; }
        public string Subject { get; set; }
        public BsonDateTime SubmitDateTime { get; set; }
        public string LearningObjective { get; set; }
    }
}
