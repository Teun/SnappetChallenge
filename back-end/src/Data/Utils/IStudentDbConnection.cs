using MySql.Data.MySqlClient;
using Sdk.Interfaces;
using System;
using System.Data;

namespace Data.Utils
{
    public interface IStudentDbConnection : IDbConnectionFactory
    {
    }

    public class StudentDbConnection : IStudentDbConnection
    {
        private readonly string _connectionString;

        public StudentDbConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new NullReferenceException("StudentDbConnection_string_has_not_found");

            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            if (_connectionString == null)
                throw new NullReferenceException($"{nameof(StudentDbConnection)}_{nameof(_connectionString)}");

            return new MySqlConnection(_connectionString);
        }
    }
}
