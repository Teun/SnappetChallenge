using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SnappetChallenge.Core.Entities;
using SnappetChallenge.Core.Repositories.Contracts;
using SnappetChallenge.CrossCutting.Settings;
using SnappetChallenge.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SnappetChallenge.Infrastructure.Repositories
{
    public class WorkRepository : IWorkRepository
    {
        private const string WORK_CACHE_NAME = "workJson";

        private readonly IMemoryCache _memoryCache;
        private readonly IOptionsSnapshot<ApplicationSettings> _applicationSettings;
        public WorkRepository(IMemoryCache memoryCache, IOptionsSnapshot<ApplicationSettings> applicationSettings)
        {
            _memoryCache = memoryCache;
            _applicationSettings = applicationSettings;
        }

        public Works Get(DateTime initialDate, DateTime finalDate)
            => _memoryCache.GetOrCreate(WORK_CACHE_NAME, (entry) =>
            {
                var data = JsonConvert.DeserializeObject<List<JsonWorkDTO>>(File.ReadAllText(_applicationSettings.Value.WorkJsonPath),
                                                                        new JsonSerializerSettings
                                                                        {
                                                                            DateTimeZoneHandling = DateTimeZoneHandling.Utc
                                                                        });

                var organizedData = new Works(data.Where(x => x.SubmitDateTime >= initialDate && x.SubmitDateTime <= finalDate)
                                                  .GroupBy(x => x.UserId)
                                                  .Select(x => new Student
                                                  {
                                                      Id = x.Key,
                                                      Exercises = new Exercises(x.GroupBy(y => y.ExerciseId)
                                                                                 .Select(y => new Exercise
                                                                                 {
                                                                                     Id = y.Key,
                                                                                     Difficulty = y.First().Difficulty,
                                                                                     Domain = y.First().Domain,
                                                                                     LearningObjective = y.First().LearningObjective,
                                                                                     Subject = y.First().Subject,
                                                                                     Answers = new Answers(y.Select(z => new Answer
                                                                                     {
                                                                                         Id = z.SubmittedAnswerId,
                                                                                         IsCorrect = z.Correct,
                                                                                         Progress = z.Progress,
                                                                                         Submitted = z.SubmitDateTime
                                                                                     }).OrderBy(z => z.Submitted))
                                                                                 }))
                                                  }));

                entry.SetAbsoluteExpiration(TimeSpan.FromHours(1));
                entry.SetValue(organizedData);

                return organizedData;
            });
    }
}