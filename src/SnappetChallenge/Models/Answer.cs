using System;

namespace SnappetChallenge.Models
{
    public class Answer
    {
        public string Id { get; set; }
        public bool Correct { get; set; }
        public DateTime SubmitedDate { get; set; }
        public int Progress { get; set; }
        public Exercise Exercise { get; set; }
        public string ExerciseId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}