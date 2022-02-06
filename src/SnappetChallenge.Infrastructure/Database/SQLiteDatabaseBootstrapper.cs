using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using SnappetChallenge.Application.Constants;
using SnappetChallenge.Application.Interfaces;

namespace SnappetChallenge.Infrastructure.Database;

public class SQLiteDatabaseBootstrapper : IDatabaseBootstrapper
{
    private readonly IConfiguration _configuration;
    private readonly IDbContext _dbContext;

    public SQLiteDatabaseBootstrapper(
        IConfiguration configuration,
        IDbContext dbContext)
    {
        _configuration = configuration;
        _dbContext = dbContext;
    }

    public async Task SetupAsync()
    {
        using (var connection = _dbContext.CreateConnection())
        {
            connection.Open();
            await CreateTableSubmittedAnswerAsync(connection);
        }
    }

    private async Task CreateTableSubmittedAnswerAsync(IDbConnection connection)
    {
        var table = await connection.QueryAsync<string>(@$"
SELECT name 
    FROM sqlite_master 
    WHERE type='table' 
        AND name = '{DatabaseConstants.TABLE_SUBMITTEDANSWER_NAME}'
;");

        var tableName = table.FirstOrDefault();
        if (!string.IsNullOrEmpty(tableName) && tableName == DatabaseConstants.TABLE_SUBMITTEDANSWER_NAME)
            return;

        await connection.ExecuteAsync(@$"
CREATE TABLE {DatabaseConstants.TABLE_SUBMITTEDANSWER_NAME} (
    SubmittedAnswerId INTEGER PRIMARY KEY,
    SubmitDateTime TEXT NOT NULL,
    Correct INTEGER NOT NULL,
    Progress INTEGER NOT NULL,
    UserId INTEGER NOT NULL,
    ExerciseId INTEGER NOT NULL,
    Difficulty VARCHAR(25) NOT NULL,
    Subject VARCHAR(100),
    Domain VARCHAR(100),
    LearningObjective VARCHAR(200)
);");

        await connection.ExecuteAsync(@$"
CREATE INDEX 
    IX_{DatabaseConstants.TABLE_SUBMITTEDANSWER_NAME}_SubmitDateTime 
    ON {DatabaseConstants.TABLE_SUBMITTEDANSWER_NAME}
        (SubmitDateTime DESC)
;");
    }
}
