using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Snappet_challenge_api.Models;

namespace Snappet_challenge_api.Services
{
    public class SummaryDataService : ISummaryDataService
    {
        public readonly IConfiguration _config;

        public SummaryDataService(IConfiguration config)
        {
            _config = config;
        }

        public List<UserSummary> GetSummaryData(string summaryDate)
        {
            try
            {
                var usersData = new List<UserSummary>();
                var dbConnection = new SqlConnection(
                    _config.GetConnectionString("primary"));
                var command = new SqlCommand("Get_Summary_Data", dbConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@SummaryDate", System.Data.SqlDbType.Date).Value = summaryDate;

                dbConnection.Open();
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    bool isNewUser = false;
                    int userId = (int)dataReader["UserId"];
                    var userSummary = usersData.Find(x => x.UserId == userId);
                    if (userSummary is null)
                    {
                        isNewUser = true;
                        userSummary = new UserSummary(userId);
                    }

                    var subjectSummary = new SubjectSummary(
                            (string)dataReader["Subject"],
                            (int)dataReader["AnswersSubmitted"],
                            (int)dataReader["CorrectAnswers"],
                            (int)dataReader["Progress"]
                        );
                    userSummary.Subjects.Add(subjectSummary);

                    if (isNewUser)
                    {
                        usersData.Add(userSummary);
                    }
                }
                dbConnection.Close();

                return usersData;
            }
            catch(Exception ex)
            {
                LogError(ex.Message);
                return null;                
            }
        }

        public List<string> GetSubjects(string summaryDate)
        {
            try
            {
                var subjects = new List<string>();
                var dbConnection = new SqlConnection(
                    _config.GetConnectionString("primary"));
                var command = new SqlCommand("Get_Subjects", dbConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@SummaryDate", System.Data.SqlDbType.Date).Value = summaryDate;

                dbConnection.Open();
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    subjects.Add((string)dataReader["SubjectName"]);
                }
                dbConnection.Close();

                return subjects;
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                return null;
            }
        }

        private void LogError(string errorMessage)
        {
            // todo: Add error logging
        }
    }
}
