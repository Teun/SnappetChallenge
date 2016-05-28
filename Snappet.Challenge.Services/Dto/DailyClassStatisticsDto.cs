using System;

namespace Snappet.Challenge.Services.Dto
{
    public class DailyClassStatisticsDto
    {
        public DateTime SubmitDateTime { get; set; }

        public float AvgProgress { get; set; }

        public double? AvgDifficulty { get; set; }

        public int AmountOfProgressedStudents { get; set; }

        public int Correct { get; set; }

        public int Incorrect { get; set; }

        public override bool Equals(object obj) 
        {
            return Equals(obj as DailyClassStatisticsDto);
        }

        public bool Equals(DailyClassStatisticsDto obj)
        {
            return SubmitDateTime.Equals(obj.SubmitDateTime)
                && AvgProgress.Equals(obj.AvgProgress)
                && AvgDifficulty.Equals(obj.AvgDifficulty)
                && AmountOfProgressedStudents.Equals(obj.AmountOfProgressedStudents)
                && Correct.Equals(obj.Correct)
                && Incorrect.Equals(obj.Incorrect);
        }

        public override int GetHashCode()
        {
            return SubmitDateTime.GetHashCode()
                ^ AvgProgress.GetHashCode()
                ^ (AvgDifficulty.HasValue ? AvgDifficulty.GetHashCode() : 0)
                ^ AmountOfProgressedStudents.GetHashCode()
                ^ Correct.GetHashCode()
                ^ Incorrect.GetHashCode();
        }
    }
}
