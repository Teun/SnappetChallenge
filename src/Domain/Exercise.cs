namespace Domain
{
	public class Exercise
	{
		public int Id { get; set; }
		public double? Difficulty { get; set; }
		public LearningObjective LearningObjective { get; set; }
	}
}
