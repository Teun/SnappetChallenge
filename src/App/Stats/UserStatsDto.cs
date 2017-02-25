namespace App.Users
{
	using Domain;
	using System.Linq;

	public class UserStatsDto
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public int ExercisesAttempted { get; set; }
		public int ExercisesSolvedOnFirstTry { get; set; }
		public int ExercisesSolved { get; set; }
		public double AvgTriesPerExercise { get; set; }
		public double CorrectFirstTryRate { get; set; }
		public double AvgProgressPerExercise { get; set; }
		public int TotalProgress { get; set; }
		public int[] LatestProgressCusum { get; set; }

		public static UserStatsDto FromModel(
			UserStats model,
			UserStatsDto preCreated = null)
		{
			var dto = preCreated ?? new UserStatsDto();
			dto.Id = model.UserId;
			dto.UserName = model.UserName;
			dto.ExercisesAttempted = model.ExercisesAttempted;
			dto.ExercisesSolvedOnFirstTry = model.ExercisesSolvedOnFirstTry;
			dto.ExercisesSolved = model.ExercisesSolved;
			dto.AvgTriesPerExercise = model.AvgTriesPerExercise;
			dto.CorrectFirstTryRate = model.CorrectFirstTryRate;
			dto.AvgProgressPerExercise = model.AvgProgressPerExercise;
			dto.TotalProgress = model.TotalProgress;
			dto.LatestProgressCusum = model
				.LatestProgress
				.Aggregate(
					new { sum = Enumerable.Empty<int>(), last = 0 },
					(acc, c) => new {
						sum = acc.sum.Concat(Enumerable.Repeat(acc.last + c, 1)),
						last = acc.last + c
					},
					acc => acc.sum)
				.ToArray();
			return dto;
		}
	}
}