using Moserware.Skills;

namespace SnappetTrueskill.Domain
{
    public class Exercise
    {
        public int Id { get; set; }
        public Rating Rating { get; set; }
        public double? OriginalDifficulty { get; set; }
    }
}
