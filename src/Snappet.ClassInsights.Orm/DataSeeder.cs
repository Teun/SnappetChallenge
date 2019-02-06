using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Snappet.ClassInsights.Model.Configurations;
using Snappet.ClassInsights.Model.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.ClassInsights.Orm
{
    internal class SqliteDataSeeder : IDataSeeder
    {
        private readonly ILogger _logger;
        private readonly IOptions<DataSeederOptions> _dataSeederOptions;
        public SqliteDataSeeder(ILogger<SqliteDataSeeder> logger, IOptions<DataSeederOptions> dataSeederOptions)
        {
            _logger = logger;
            _dataSeederOptions = dataSeederOptions;
        }
        public async Task SeedSubmittedAnswersAsync(string connectionString)
        {
            var submittedAnswers = ReadFromJson();
            _logger.LogInformation($"{submittedAnswers.Count} submittedAnswers have been loaded from json file");
            int skipped = 0;
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = GetCommandHeader();
                    var submittedAnswerIdParam = CreateParameter(command, $"${nameof(SubmittedAnswer.SubmittedAnswerId)}");
                    var submitDateTimeParam = CreateParameter(command, $"${nameof(SubmittedAnswer.SubmitDateTime)}");
                    var correctParam = CreateParameter(command, $"${nameof(SubmittedAnswer.Correct)}");
                    var progressParam = CreateParameter(command, $"${nameof(SubmittedAnswer.Progress)}");
                    var userIdParam = CreateParameter(command, $"${nameof(SubmittedAnswer.UserId)}");
                    var exerciseIdParam = CreateParameter(command, $"${nameof(SubmittedAnswer.ExerciseId)}");
                    var difficultyParam = CreateParameter(command, $"${nameof(SubmittedAnswer.Difficulty)}");
                    var subjectParam = CreateParameter(command, $"${nameof(SubmittedAnswer.Subject)}");
                    var domainParam = CreateParameter(command, $"${nameof(SubmittedAnswer.Domain)}");
                    var learningObjectiveParam = CreateParameter(command, $"${nameof(SubmittedAnswer.LearningObjective)}");
                    foreach (var submittedAnswer in FilterToMaxValidSubmitDate(submittedAnswers))
                    {
                        submittedAnswerIdParam.Value = submittedAnswer.SubmittedAnswerId;
                        submitDateTimeParam.Value = submittedAnswer.SubmitDateTime;
                        correctParam.Value = submittedAnswer.Correct;
                        progressParam.Value = submittedAnswer.Progress;
                        userIdParam.Value = submittedAnswer.UserId;
                        exerciseIdParam.Value = submittedAnswer.ExerciseId;
                        difficultyParam.Value = submittedAnswer.Difficulty;
                        subjectParam.Value = submittedAnswer.Subject;
                        domainParam.Value = submittedAnswer.Domain;
                        learningObjectiveParam.Value = submittedAnswer.LearningObjective;
                        try
                        {
                            await command.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {
                            _logger.LogWarning($" submittedAnswer with SubmittedAnswerId : {submittedAnswer.SubmittedAnswerId}, will be skipped due to the error : {ex.Message}");
                            skipped++;
                        }
                    }
                    transaction.Commit();
                }
            }
            _logger.LogInformation($"{submittedAnswers.Count - skipped} submittedAnswers have been seeded, {skipped} submittedAnswers have been skipped due to errors");
        }

        private IEnumerable<SubmittedAnswer> FilterToMaxValidSubmitDate(List<SubmittedAnswer> submittedAnswers)
        {
            return _dataSeederOptions.Value.MaximumValidSubmitDateTime.HasValue ?
                submittedAnswers.Where(a => a.SubmitDateTime <= _dataSeederOptions.Value.MaximumValidSubmitDateTime) :
                submittedAnswers;
        }

        private List<SubmittedAnswer> ReadFromJson()
        {
            try
            {
                using (StreamReader r = new StreamReader(_dataSeederOptions?.Value.JsonFilePath))
                {
                    var jss = new JsonSerializerSettings
                    {
                        DateFormatHandling = DateFormatHandling.IsoDateFormat,
                        DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                        DateParseHandling = DateParseHandling.DateTime
                    };
                    var json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<SubmittedAnswer>>(json, jss);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Seeding Data");
                if (_dataSeederOptions.Value.ContinueOnDataSeedingFailure)
                    return new List<SubmittedAnswer>();
                throw;
            }
        }
        private SqliteParameter CreateParameter(SqliteCommand command, string parameterName)
        {
            var nameParameter = command.CreateParameter();
            nameParameter.ParameterName = parameterName;
            command.Parameters.Add(nameParameter);
            return nameParameter;
        }

        private string GetCommandHeader()
        {
            return
                "INSERT INTO SubmittedAnswers(SubmittedAnswerId,SubmitDateTime,Correct,Progress,UserId,ExerciseId,Difficulty,Subject,Domain,LearningObjective) " +
                "VALUES($SubmittedAnswerId,$SubmitDateTime,$Correct,$Progress,$UserId,$ExerciseId,$Difficulty,$Subject,$Domain,$LearningObjective);";
        }

    }
}
