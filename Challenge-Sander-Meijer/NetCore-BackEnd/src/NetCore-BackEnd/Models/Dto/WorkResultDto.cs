namespace NetCore.BackEnd.Models.Dto
{
	public class WorkResultDto
	{
		public bool Correct { get; set; }

		public int ExcerciseId { get; set; }

		public string Domain { get; set; }

		public string LearningObjective { get; set; }
	}
}