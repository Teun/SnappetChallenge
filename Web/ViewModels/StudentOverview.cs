using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Web.ViewModels
{
	public class StudentOverview
	{
		[JsonProperty("userId")]
		public int UserId { get; internal set; }

		[JsonProperty("date")]
		public DateTime Date { get; set; }

		[JsonProperty("correct")]
		public int CorrectAnswers { get; set; }

		[JsonProperty("incorrect")]
		public int IncorrectAnswers { get; set; }

		[JsonProperty("learningObjectives")]
		public List<LearningObjectiveOverview> LearningObjectives { get; set; }

		[JsonProperty("progress")]
		public double Progress { get; set; }
	}
}