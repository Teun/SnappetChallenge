using System;

namespace BlCore.DataProviders.Models
{
    public class ExerciseExecutionEntity
    {
        public int SubmittedAnswerId { get; set; }  //2395278 

        public DateTime SubmitDateTime { get; set; }  // 2015-03-02T07:35:38.740"

        public int Correct { get; set; } // 1

        public int Progress { get; set; } //  -8

        public int UserId { get; set; } //40281   

        public int ExerciseId { get; set; } // 1038396

        public string Difficulty { get; set; } // -200

        public string Subject { get; set; }  //"Begrijpend Lezen",

        public string Domain { get; set; }  // "-"

        public string LearningObjective { get; set; }  // Diverse leerdoelen Begrijpend Lezen
    }
}
