using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Snappet_challenge_api.Models;

namespace Snappet_challenge_api.Services
{
    public class StudentsService : IStudentsService
    {
        public readonly IConfiguration _config;

        public StudentsService(IConfiguration config)
        {
            _config = config;
        }

        public List<UserSummary> GetStudents()
        {
            try
            {
                var students = new List<UserSummary>();
                var dbConnection = new SqlConnection(
                    _config.GetConnectionString("primary"));
                var command = new SqlCommand("Get_Students", dbConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                dbConnection.Open();
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    students.Add(new UserSummary((int)dataReader["UserId"]));
                }
                dbConnection.Close();

                return students;
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
            // Leaving out for challenge purposes
        }
    }
}
