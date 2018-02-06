using System;

namespace Snappet.Assignment.Entities.DTOs
{
    public class WorkDto
    {
       

        public DateTime SubmitDateTime { get; set; }

        public bool Correct { get; set; }

        public short Progress { get; set; }


        public float? Difficulty { get; set; }

        public string Subject { get; set; }

        public string Domain { get; set; }

        public string LearningObjective { get; set; }


        public UserDto User { get; set; }

        public ExerciseDto Exercise { get; set; }
    }
}
