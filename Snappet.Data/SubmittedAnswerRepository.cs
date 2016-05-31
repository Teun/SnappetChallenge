using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Snappet.Data.Interfaces;
using Snappet.Entities;
using Snappet.Entities.Interfaces;

namespace Snappet.Data
{
	public class SubmittedAnswerRepository : ISubmittedAnswerRepository
	{
		public IEnumerable<ISubmittedAnswer> GetSubmittedAnswersBefore(DateTime time)
		{
			List<ISubmittedAnswer> result = new List<ISubmittedAnswer>();
			
			StreamReader reader = new StreamReader(@"D:\rschip\GitHub\SnappetChallenge\Snappet.Data\work.json");
			string workJson = reader.ReadToEnd();
			var deserializedAnswers = JsonConvert.DeserializeObject<List<dynamic>>(workJson);

			foreach (var deserializedAnswer in deserializedAnswers)
			{
				int id = deserializedAnswer.SubmittedAnswerId;
				DateTime submittedDateTime = deserializedAnswer.SubmitDateTime;
				bool correct = deserializedAnswer.Correct;
				double progress = deserializedAnswer.Progress;
				string userId = deserializedAnswer.UserId;
				string exerciseId = deserializedAnswer.ExerciseId;
				string learningObj = deserializedAnswer.LearningObjective;
				string subject = deserializedAnswer.Subject;
				string domain = deserializedAnswer.Domain;

				result.Add(new SubmittedAnswer(id,
					submittedDateTime,
					correct,
					progress,
					userId,
					exerciseId,
					learningObj,
					subject,
					domain));
			}

			return result;
		}
		
	}
}
