using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Web.Models;

namespace Web.Data
{
	public static class SubmittedAnswersImporter
	{
		public static void Import(IEnumerable<SubmittedAnswer> submittedAnswers)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["SnappetContext"].ToString();

			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (var sqlBulkCopy = new SqlBulkCopy(connection))
				{
					sqlBulkCopy.DestinationTableName = "SubmittedAnswers";

					var dt = new DataTable();

					dt.Columns.Add(new DataColumn("SubmittedAnswerId", typeof(int)));
					dt.Columns.Add(new DataColumn("SubmitDateTime", typeof(DateTime)));
					dt.Columns.Add(new DataColumn("Correct", typeof(bool)));
					dt.Columns.Add(new DataColumn("Progress", typeof(double)));
					dt.Columns.Add(new DataColumn("UserId", typeof(int)));
					dt.Columns.Add(new DataColumn("ExerciseId", typeof(int)));
					dt.Columns.Add(new DataColumn("Difficulty", typeof(string)));
					dt.Columns.Add(new DataColumn("Subject", typeof(string)));
					dt.Columns.Add(new DataColumn("Domain", typeof(string)));
					dt.Columns.Add(new DataColumn("LearningObjective", typeof(string)));

					foreach (var submittedAnswer in submittedAnswers)
					{
						dt.Rows.Add(
							submittedAnswer.SubmittedAnswerId,
							submittedAnswer.SubmitDateTime,
							submittedAnswer.Correct,
							submittedAnswer.Progress,
							submittedAnswer.UserId,
							submittedAnswer.ExerciseId,
							submittedAnswer.Difficulty,
							submittedAnswer.Subject,
							submittedAnswer.Domain,
							submittedAnswer.LearningObjective
						);
					}

					sqlBulkCopy.WriteToServer(dt);
				}
			}
		}
	}
}