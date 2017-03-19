using Newtonsoft.Json;
using Snappet.Data.Interfaces;
using Snappet.TestData.Entities;
using Snappet.TestData.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using Snappet.TestData.Sources;

namespace Snappet.TestData.Repositories
{
    public class ExerciseMockRepository : IExerciseRepository
    {
        private ExerciseRecord[] _cachedExercises;
        private readonly EntityBuilderFactory _builderFactory;

        public ExerciseMockRepository(ITestDataSource testDataSource)
        {
            _builderFactory = new EntityBuilderFactory();
            InitTestData(testDataSource);
        }

        public IFrom<TEntity> Get<TEntity>() where TEntity : new()
        {
            return new Query<TEntity>(_builderFactory, _cachedExercises);
        }

        private void InitTestData(ITestDataSource testDataSource)
        {
            var testData = testDataSource.GetTestData();
            _cachedExercises = ConvertTestDataToExercises(testData);
        }

        private ExerciseRecord[] ConvertTestDataToExercises(string testData)
        {
            var deserializeSetting = new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
            return JsonConvert.DeserializeObject<ExerciseRecord[]>(testData, deserializeSetting);
        }

        private class Query<TEntity> : IFrom<TEntity>, ITo<TEntity>, IListable<TEntity> where TEntity: new()
        {
            private readonly IEntityBuilderFactory _builderFactory;
            private IEnumerable<ExerciseRecord> _query;

            public Query(IEntityBuilderFactory builderFactory, IEnumerable<ExerciseRecord> exerciseList)
            {
                _builderFactory = builderFactory;
                _query = exerciseList;
            }

            public ITo<TEntity> From(DateTime from)
            {
                _query = _query.Where(e => e.SubmitDateTime >= from);
                return this;
            }

            public IListable<TEntity> To(DateTime to)
            {
                _query = _query.Where(e => e.SubmitDateTime < to);
                return this;
            }

            public IList<TEntity> ToList()
            {
                var builder = _builderFactory.GetEntityBuilder<ExerciseRecord, TEntity>();
                var queryResult = _query.ToArray();
                return builder.BuildEntities(queryResult).ToList();
            }
        }
    }
}
