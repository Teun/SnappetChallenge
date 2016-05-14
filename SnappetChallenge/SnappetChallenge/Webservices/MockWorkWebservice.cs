using Newtonsoft.Json;
using SnappetChallenge.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace SnappetChallenge.Webservices
{
	//This mock webservice simulates a webservice connecting to a larger datasource
	public class MockWorkWebservice
	{
		public MockWorkWebservice()
		{

		}

		// This method simulates the retrieval of the data for a class from a large datasource
		// It loads a sample JSON file which for the case of this challenge we can imagine to be the
		// result of a webservice call to get the answers for a particular class for a certain time period
		private string CallWorkWebservice()
		{
			string jsonString;
			using (WebClient wc = new WebClient())
			{
				jsonString = wc.DownloadString("http://localhost:28348/Data/work.json");
			}

			if (string.IsNullOrEmpty(jsonString))
				return string.Empty;

			return jsonString;
		}

		public List<SubmittedAnswer> GetSubmittedAnswersForClass()
		{
			var submittedAnswers = new List<SubmittedAnswer>();
			string jsonString = CallWorkWebservice();
			dynamic importedAnswers = JsonConvert.DeserializeObject(jsonString);

			foreach (var answer in importedAnswers)
			{
				try {
					submittedAnswers.Add(new SubmittedAnswer()
					{
						SubmittedAnswerId = answer.SubmittedAnswerId,
						SubmittedDateTime = answer.SubmitDateTime,
						Correct = answer.Correct == 1 ? true : false,
						Progress = answer.Progress,
						UserId = answer.UserId,
						ExerciseId = answer.ExerciseId,
						Difficulty = answer.Difficulty == "NULL" ? -99999 : answer.Difficulty, //If difficulty is null then set it to -99999
						Subject = answer.Subject,
						Domain = answer.Domain,
						LearningObjective = answer.LearningObjective
					});
				} catch (Exception e)
				{
					//do something with the error here. We will ignore any error for the sake of this exercise
					//all items in the json do correctly get added to the list but added this here to show good programming practices
				}
			}

			return submittedAnswers;
		}
	}
} 