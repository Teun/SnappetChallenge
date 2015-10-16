using Newtonsoft.Json;
using System;

namespace Web.ViewModels
{
	public class LearningObjectiveOverview
	{
		[JsonProperty("learningObjective")]
		public string LearningObjective { get; set; }

		[JsonProperty("userId")]
		public int UserId { get; set; }

		[JsonProperty("date")]
		public DateTime Date { get; set; }

		[JsonProperty("correct")]
		public int CorrectAnswers { get; set; }

		[JsonProperty("incorrect")]
		public int IncorrectAnswers { get; set; }

		[JsonProperty("progress")]
		public double Progress { get; set; }
	}
}