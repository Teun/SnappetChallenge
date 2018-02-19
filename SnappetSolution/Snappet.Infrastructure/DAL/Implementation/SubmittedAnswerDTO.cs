using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Infrastructure.DAL
{
	public class SubmittedAnswerDTO
	{
		[JsonProperty(PropertyName = "SubmittedAnswerId")]
		public int? SubmittedAnswerId { get; set; }

		[JsonProperty(PropertyName = "SubmitDateTime")]
		public DateTime? SubmitDateTime { get; set; }

		[JsonProperty(PropertyName = "Correct")]
		public int? Correct { get; set; }

		[JsonProperty(PropertyName = "Progress")]
		public int? Progress { get; set; }

		[JsonProperty(PropertyName = "UserId")]
		public int? UserId { get; set; }

		[JsonProperty(PropertyName = "ExerciseId")]
		public int? ExerciseId { get; set; }

		[JsonProperty(PropertyName = "Difficulty")]
		public decimal? Difficulty { get; set; }

		[JsonProperty(PropertyName = "Subject")]
		public string Subject { get; set; }

		[JsonProperty(PropertyName = "Domain")]
		public string Domain { get; set; }

		[JsonProperty(PropertyName = "LearningObjective")]
		public string LearningObjective { get; set; }
	}
}
