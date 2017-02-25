namespace Domain
{
	public class UserStats
	{
		public int UserId { get; set; }
		public string UserName { get; set; }
		public int ExercisesAttempted { get; set; }
		public int ExercisesSolvedOnFirstTry { get; set; }
		public int ExercisesSolved { get; set; }
		public int TotalProgress { get; set; }
		public double AvgTriesPerExercise { get; set; }
		public double CorrectFirstTryRate { get; set; }
		public double AvgProgressPerExercise { get; set; }

		public int ProgressValue { get; set; }
		public int[] LatestProgress { get; set; }

		// This property is not actually needed.
		// Exists as part of a workaround for a missing feature in EF.
		// See https://github.com/aspnet/EntityFramework/issues/1862
		public int Id { get; set; }
	}
}