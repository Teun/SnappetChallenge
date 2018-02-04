namespace SnappetChallenge.WebApi.Models
{
    using System;

    public class ExerciseModel
    {
        public ExerciseModel() { }

        public ExerciseModel(ExerciseResultJsonDeserializeModel model)
        {
            if (model != null)
            {
                this.Id = model.ExerciseId;
                this.Difficulty = model.Difficulty == "NULL" ? 0 : Convert.ToDouble(model.Difficulty);
            }
            
        }

        public int Id { get; set; }

        public double Difficulty { get; set; }
    }
}
